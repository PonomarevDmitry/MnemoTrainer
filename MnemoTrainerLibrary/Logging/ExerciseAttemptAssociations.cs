using System;
using System.Collections.ObjectModel;
using System.Xml;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Попытка выполнения тренировки ассоциаций.
    /// </summary>
    public class ExerciseAttemptAssociations : ExerciseAttempt
    {
        /// <summary>
        /// Дата начала теста
        /// </summary>
        public DateTime? DateCheck { get; set; }

        /// <summary>
        /// Время выполнения теста
        /// </summary>
        public double TimeCheck { get; set; }

        public int? TimeForWord { get; set; }

        private Collection<AssociationQuestion> questions = new Collection<AssociationQuestion>();
        public Collection<AssociationQuestion> Questions { get { return questions; } }

        public ExerciseAttemptAssociations()
        {
            this.type = TrainType.None;
        }

        #region Статистические данные об упражнении.

        public double GetTimeMaximum()
        {
            double result = 0;

            if (this.questions.Count > 0)
            {
                result = this.questions[0].Time;

                for (int i = 1; i < this.questions.Count; i++)
                {
                    result = Math.Max(result, this.questions[i].Time);
                }
            }

            return result;
        }

        public double GetTimeMinimum()
        {
            double result = 0;

            if (this.questions.Count > 0)
            {
                result = this.questions[0].Time;

                for (int i = 1; i < this.questions.Count; i++)
                {
                    result = Math.Min(result, this.questions[i].Time);
                }
            }

            return result;
        }

        public double GetTimeAverange()
        {
            if (this.questions.Count > 0)
            {
                return this.GetTimeTotal() / this.questions.Count;
            }
            else
            {
                return 0;
            }
        }

        public double GetTimeTotal()
        {
            double result = 0;

            for (int i = 0; i < this.questions.Count; i++)
            {
                result += this.questions[i].Time;
            }

            return result;
        }

        #endregion Статистические данные об упражнении.

        public override double GetTotalTime
        {
            get
            {
                return this.Time + this.TimeCheck;
            }
        }

        #region Сохранение в xml.

        private const string xmlFieldTimeForWord = "TimeForWord";
        private const string xmlFieldDateCheck = "DateCheck";
        private const string xmlFieldTimeCheck = "TimeCheck";
        private const string xmlFieldQuestionCount = "QuestionCount";

        /// <summary>
        /// Считывание атрибутов из XmlNode.
        /// </summary>
        /// <param name="xmlNode"></param>
        public override void LoadAttributesFromXml(XmlNode xmlNode)
        {
            base.LoadAttributesFromXml(xmlNode);

            XmlAttribute attr;

            attr = xmlNode.Attributes[xmlFieldTimeForWord];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                int temp;
                if (int.TryParse(attr.Value, out temp))
                {
                    this.TimeForWord = temp;
                }
            }

            attr = xmlNode.Attributes[xmlFieldDateCheck];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                DateTime temp;
                if (DateTime.TryParse(attr.Value, out temp))
                {
                    this.DateCheck = temp;
                }
            }

            attr = xmlNode.Attributes[xmlFieldTimeCheck];
            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                double temp;
                if (double.TryParse(attr.Value, out temp))
                {
                    this.TimeCheck = temp;
                }
            }

            foreach (XmlNode item in xmlNode.ChildNodes)
            {
                this.questions.Add(AssociationQuestion.CreateFromXml(item));
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

            if (this.TimeForWord.HasValue)
            {
                attr = doc.CreateAttribute(xmlFieldTimeForWord);
                attr.Value = this.TimeForWord.Value.ToString();
                result.Attributes.Append(attr);
            }

            attr = doc.CreateAttribute(xmlFieldQuestionCount);
            attr.Value = this.questions.Count.ToString();
            result.Attributes.Append(attr);

            if (this.DateCheck.HasValue)
            {
                attr = doc.CreateAttribute(xmlFieldDateCheck);
                attr.Value = this.DateCheck.Value.ToString();
                result.Attributes.Append(attr);

                attr = doc.CreateAttribute(xmlFieldTimeCheck);
                attr.Value = this.TimeCheck.ToString();
                result.Attributes.Append(attr);
            }

            foreach (AssociationQuestion item in this.questions)
            {
                result.AppendChild(item.CreateXmlNode(doc));
            }

            return result;
        }

        #endregion Сохранение в xml.

        public virtual void CreateTestTextFile()
        {

        }
    }
}
