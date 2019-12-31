using System;
using System.Xml;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Тип упражнения. Включает в себя общий тип упражнения и настройки.
    /// </summary>
    public class ExerciseType
    {
        protected TrainType type = TrainType.None;
        /// <summary>
        /// Общий тип упражнения.
        /// </summary>
        public TrainType Type
        { get { return type; } set { type = value; } }

        protected ExerciseType() { }

        public ExerciseType(TrainType type)
        {
            this.type = type;
        }

        public override string ToString()
        {
            return this.type.ToString();
        }

        /// <summary>
        /// Время отображения вопроса.
        /// </summary>
        public int? ShowTime { get; set; }

        /// <summary>
        /// Время на написание ответа.
        /// </summary>
        public int? AutoAnswerCheckTime { get; set; }

        /// <summary>
        /// Получить описание данного типа.
        /// </summary>
        /// <returns></returns>
        public virtual string GetDescription()
        {
            string result = "Общий тип упражнения";

            if (this.ShowTime.HasValue)
            {
                result += string.Format(", вопрос отображается {0} мс", this.ShowTime.Value.ToString());
            }

            if (this.AutoAnswerCheckTime.HasValue)
            {
                result += string.Format(", на ответ дается {0} мс", this.AutoAnswerCheckTime.Value.ToString());
            }

            result += ".";


            return result;
        }

        private const string xmlFieldTrainType = "TrainType";
        private const string xmlFieldShowTime = "ShowTime";
        private const string xmlFieldAutoAnswerCheckTime = "AutoAnswerCheckTime";

        /// <summary>
        /// Сохранение атрибутов экзепляра в указанный XmlNode.
        /// </summary>
        /// <param name="xmlNode"></param>
        internal virtual void SaveTypeAttributes(XmlNode xmlNode)
        {
            XmlAttribute attr;

            attr = xmlNode.OwnerDocument.CreateAttribute(xmlFieldTrainType);
            attr.Value = this.type.ToString();
            xmlNode.Attributes.Append(attr);

            if (this.ShowTime.HasValue)
            {
                attr = xmlNode.OwnerDocument.CreateAttribute(xmlFieldShowTime);
                attr.Value = this.ShowTime.Value.ToString();
                xmlNode.Attributes.Append(attr);
            }

            if (this.AutoAnswerCheckTime.HasValue)
            {
                attr = xmlNode.OwnerDocument.CreateAttribute(xmlFieldAutoAnswerCheckTime);
                attr.Value = this.AutoAnswerCheckTime.Value.ToString();
                xmlNode.Attributes.Append(attr);
            }
        }

        /// <summary>
        /// Считывание атрибутов экзепляра из XmlNode.
        /// </summary>
        /// <param name="xmlNode"></param>
        protected virtual void LoadTypeAttributes(XmlNode xmlNode)
        {
            XmlAttribute attr;

            attr = xmlNode.Attributes[xmlFieldTrainType];

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                this.type = (TrainType)Enum.Parse(typeof(TrainType), attr.Value);

                attr = xmlNode.Attributes[xmlFieldShowTime];
                if (attr != null && !string.IsNullOrEmpty(attr.Value))
                {
                    int temp;
                    if (int.TryParse(attr.Value, out temp))
                    {
                        this.ShowTime = temp;
                    }
                }

                attr = xmlNode.Attributes[xmlFieldAutoAnswerCheckTime];
                if (attr != null && !string.IsNullOrEmpty(attr.Value))
                {
                    int temp;
                    if (int.TryParse(attr.Value, out temp))
                    {
                        this.AutoAnswerCheckTime = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Создание экзепляра типа по XmlNode.
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <returns></returns>
        public static ExerciseType CreateFromXml(XmlNode xmlNode)
        {
            ExerciseType result = new ExerciseType();
            XmlAttribute attr;

            attr = xmlNode.Attributes[xmlFieldTrainType];

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                TrainType baseType = (TrainType)Enum.Parse(typeof(TrainType), attr.Value);

                switch (baseType)
                {
                    case TrainType.Date:
                        result = new ExerciseTypeDate();
                        break;
                    case TrainType.NumericAlphabet:
                        result = new ExerciseTypeNumericAlphaget();
                        break;
                    case TrainType.Impression:
                        result = new ExerciseTypeImpression();
                        break;
                    case TrainType.Calculate:
                        result = new ExerciseTypeCalculate();
                        break;
                    case TrainType.RecentMemory:
                        result = new ExerciseTypeStepanovAndRecentMemory(TrainType.RecentMemory);
                        break;
                    case TrainType.Stepanov:
                        result = new ExerciseTypeStepanovAndRecentMemory(TrainType.Stepanov);
                        break;
                    case TrainType.NumberGenerator:
                        result = new ExerciseTypeNumberGenerator();
                        break;
                    case TrainType.SecondArrowAttention:
                        result = new ExerciseTypeSecondArrowAttention();
                        break;
                    case TrainType.Strup:
                        result = new ExerciseTypeStrup();
                        break;
                    case TrainType.NetTrain:
                        result = new ExerciseTypeNetTrain();
                        break;
                    case TrainType.InterruptionReading:
                        result = new ExerciseTypeInterruptionReading();
                        break;

                    default:
                        result = new ExerciseType(baseType);
                        break;
                }

                result.LoadTypeAttributes(xmlNode);
            }

            return result;
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        /// <summary>
        /// Определяем метод проверки эквивалентности.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ExerciseType))
            {
                return false;
            }

            ExerciseType target = (ExerciseType)obj;

            return target.type == this.type && target.ShowTime == this.ShowTime && this.AutoAnswerCheckTime == this.AutoAnswerCheckTime;
        }
    }
}
