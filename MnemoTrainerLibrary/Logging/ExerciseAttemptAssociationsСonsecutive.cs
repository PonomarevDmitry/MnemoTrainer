using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Попытка выполнения тренировки последовательных ассоциаций.
    /// </summary>
    public class ExerciseAttemptAssociationsСonsecutive : ExerciseAttemptAssociations
    {
        public bool WithRepeats { get; set; }

        public bool WithNumber { get; set; }
        public bool Random { get; set; }

        public ExerciseAttemptAssociationsСonsecutive()
        {
            this.type = TrainType.ConsecutiveAssociations;
        }

        public ExerciseAttemptAssociationsСonsecutive(DateTime dateStart, DateTime dateEnd, DateTime dateCheck, double time, double timeCheck)
        {
            this.type = TrainType.ConsecutiveAssociations;

            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
            this.DateCheck = dateCheck;
            this.Time = time;
            this.TimeCheck = timeCheck;

            this.AutoAnswerCheck = false;
            this.answerIsRight = true;
        }

        private const string xmlFieldWithRepeats = "WithRepeats";
        private const string xmlFieldWithNumber= "WithNumber";
        private const string xmlFieldRandom = "Random";

        /// <summary>
        /// Считывание атрибутов из XmlNode.
        /// </summary>
        /// <param name="xmlNode"></param>
        public override void LoadAttributesFromXml(XmlNode xmlNode)
        {
            base.LoadAttributesFromXml(xmlNode);

            XmlAttribute attr;

            attr = xmlNode.Attributes[xmlFieldWithRepeats];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                bool temp;
                if (bool.TryParse(attr.Value, out temp))
                {
                    this.WithRepeats = temp;
                }
            }

            attr = xmlNode.Attributes[xmlFieldWithNumber];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                bool temp;
                if (bool.TryParse(attr.Value, out temp))
                {
                    this.WithNumber = temp;
                }
            }

            attr = xmlNode.Attributes[xmlFieldRandom];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                bool temp;
                if (bool.TryParse(attr.Value, out temp))
                {
                    this.Random = temp;
                }
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

            if (this.WithRepeats)
            {
                attr = doc.CreateAttribute(xmlFieldWithRepeats);
                attr.Value = this.WithRepeats.ToString();
                result.Attributes.Append(attr);
            }

            if (this.WithNumber)
            {
                attr = doc.CreateAttribute(xmlFieldWithNumber);
                attr.Value = this.WithNumber.ToString();
                result.Attributes.Append(attr);
            }

            if (this.Random)
            {
                attr = doc.CreateAttribute(xmlFieldRandom);
                attr.Value = this.Random.ToString();
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

                sb.AppendLine(string.Format("Тест последовательных ассоциаций на {0} слов.", this.Questions.Count));
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

                    string position = string.Empty;
                    if (this.WithNumber && this.Random)
                    {
                        position = string.Format("на {0} месте, ", item.ShowPosition.ToString(numFormat));
                    }

                    tmp += string.Format("     {0}отображался {1}c.", position, item.Time.ToString("F2").PadLeft(maxLengthTime));

                    sb.AppendLine(tmp);
                }

                string fileName = "Тест " + this.DateStart.Value.ToString("yyyy-MM-dd HH-mm-ss") + " Ассоциации " + this.Questions.Count.ToString() + ".txt";

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
