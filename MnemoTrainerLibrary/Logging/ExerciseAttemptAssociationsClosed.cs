using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Попытка выполнения тренировки закрытые ассоциации.
    /// </summary>
    public class ExerciseAttemptAssociationsClosed : ExerciseAttemptAssociations
    {
        public bool FromDictionary { get; set; }
        public string ListName { get; set; }

        public ExerciseAttemptAssociationsClosed()
        {
            this.type = TrainType.ClosedAssociations;
        }

        public ExerciseAttemptAssociationsClosed(DateTime dateStart, DateTime dateEnd, DateTime dateCheck, double time, double timeCheck)
        {
            this.type = TrainType.ClosedAssociations;

            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
            this.DateCheck = dateCheck;
            this.Time = time;
            this.TimeCheck = timeCheck;

            this.AutoAnswerCheck = false;
            this.answerIsRight = true;
        }

        private const string xmlFieldFromDictionary = "FromDictionary";
        private const string xmlFieldListName = "ListName";

        /// <summary>
        /// Считывание атрибутов из XmlNode.
        /// </summary>
        /// <param name="xmlNode"></param>
        public override void LoadAttributesFromXml(XmlNode xmlNode)
        {
            base.LoadAttributesFromXml(xmlNode);

            XmlAttribute attr;

            attr = xmlNode.Attributes[xmlFieldFromDictionary];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                bool temp;
                if (bool.TryParse(attr.Value, out temp))
                {
                    this.FromDictionary = temp;
                }
            }

            attr = xmlNode.Attributes[xmlFieldListName];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                this.ListName = attr.Value;
            }
        }

        /// <summary>
        /// Создание XmlNode по экземпляру класса.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public override XmlNode CreateXmlNode(XmlDocument doc)
        {
            XmlNode result = base.CreateXmlNode(doc);

            XmlAttribute attr;

            if (this.FromDictionary)
            {
                attr = doc.CreateAttribute(xmlFieldFromDictionary);
                attr.Value = this.FromDictionary.ToString();
                result.Attributes.Append(attr);
            }
            else
            {
                attr = doc.CreateAttribute(xmlFieldListName);
                attr.Value = this.ListName;
                result.Attributes.Append(attr);
            }

            return result;
        }

        public override void CreateTestTextFile()
        {
            if (this.Questions.Count > 0)
            {
                string numFormat = "D1";
                if (this.Questions.Count > 99)
                {
                    numFormat = "D3";
                }
                else if (this.Questions.Count > 9)
                {
                    numFormat = "D2";
                }

                int maxLengthQuestion = 0;
                int maxLengthTime = 0;

                foreach (AssociationQuestion item in this.Questions)
                {
                    string tmp = item.ToString(numFormat);
                    maxLengthQuestion = Math.Max(maxLengthQuestion, tmp.Length);

                    tmp = item.Time.ToString("F2");
                    maxLengthTime = Math.Max(maxLengthTime, tmp.Length);
                }


                StringBuilder sb = new StringBuilder();

                DateTime durationTest = new DateTime().Add(this.DateEnd.Value - this.DateStart.Value);
                DateTime durationCheck = new DateTime().Add(this.DateCheck.Value - this.DateEnd.Value);
                DateTime durationTotal = new DateTime().Add(this.DateCheck.Value - this.DateStart.Value);

                sb.AppendLine(string.Format("Тест закрытых ассоциаций на {0} слов.", this.Questions.Count));
                if (this.FromDictionary)
                {
                    sb.AppendLine("Случайный набор слов.");
                }
                else
                {
                    sb.AppendLine(string.Format("Набор слов из собственного списка \"{0}\".", this.ListName));
                }

                sb.AppendLine();
                sb.AppendLine(string.Format("Время начала теста                 {0}", this.DateStart.Value.ToString("dd.MM.yyyy HH:mm:ss")));
                sb.AppendLine(string.Format("Время окончания теста              {0}", this.DateEnd.Value.ToString("dd.MM.yyyy HH:mm:ss")));
                sb.AppendLine(string.Format("Время окончания написания ответов  {0}", this.DateCheck.Value.ToString("dd.MM.yyyy HH:mm:ss")));
                sb.AppendLine();
                sb.AppendLine(string.Format("Продолжительность теста              {0}", durationTest.ToLongTimeString()));
                sb.AppendLine(string.Format("Продолжительность написания ответов  {0}", durationCheck.ToLongTimeString()));
                sb.AppendLine(string.Format("Продолжительность общая              {0}", durationTotal.ToLongTimeString()));
                sb.AppendLine();
                sb.AppendLine(string.Format("Минимальное время на образ   {0}", this.GetTimeMinimum().ToString("F2").PadLeft(maxLengthTime)));
                sb.AppendLine(string.Format("Среднее время на образ       {0}", this.GetTimeAverange().ToString("F2").PadLeft(maxLengthTime)));
                sb.AppendLine(string.Format("Максимальное время на образ  {0}", this.GetTimeMaximum().ToString("F2").PadLeft(maxLengthTime)));
                sb.AppendLine();
                sb.AppendLine();

                for (int i = 0; i < this.Questions.Count; i++)
                {
                    AssociationQuestion item = this.Questions[i];

                    string tmp = item.ToString(numFormat);
                    tmp = tmp.PadRight(maxLengthQuestion);

                    tmp += string.Format("     отображался {0}c.", item.Time.ToString("F2").PadLeft(maxLengthTime));

                    sb.AppendLine(tmp);
                }

                string fileName = "Тест " + this.DateStart.Value.ToString("yyyy-MM-dd HH-mm-ss") + " Ассоциации закрытые " + this.Questions.Count.ToString() + ".txt";

                string pathFile = Path.Combine(Config.ReportFolder, fileName);
                if (!Directory.Exists(Config.ReportFolder))
                {
                    Directory.CreateDirectory(Config.ReportFolder);
                }

                using (StreamWriter sw = File.CreateText(pathFile))
                {
                    sw.Write(sb.ToString());
                }

                try
                {
                    Process.Start(pathFile);
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
