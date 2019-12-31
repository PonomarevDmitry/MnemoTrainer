using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml;

namespace MnemoTrainerLibrary.Logging
{
    /// <summary>
    /// Серия попыток выполнения определенного упражнения.
    /// </summary>
    public class ExerciseSerie
    {
        protected ExerciseType type = null;
        /// <summary>
        /// Тип упражнения.
        /// </summary>
        public ExerciseType Type { get { return type; } }

        protected ExerciseSerie() { }

        public ExerciseSerie(ExerciseType type)
        {
            this.type = type;
        }

        protected Collection<ExerciseAttempt> attempts = new Collection<ExerciseAttempt>();
        /// <summary>
        /// Все попытки выполнения упражнения.
        /// </summary>
        public Collection<ExerciseAttempt> Attempts { get { return attempts; } }

        public void SortAttempts()
        {
            ExerciseAttempt[] items = new ExerciseAttempt[this.attempts.Count];
            DateTime?[] keys = new DateTime?[this.attempts.Count];

            for (int i = 0; i < this.attempts.Count; i++)
            {
                items[i] = this.attempts[i];
                keys[i] = this.attempts[i].DateStart;
            }

            // Сортируем свойства.
            Array.Sort(keys, items);

            attempts.Clear();
            foreach (ExerciseAttempt item in items)
            {
                attempts.Add(item);
            }
        }

        public string GetDescription(bool withErrorsList)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.type.GetDescription());

            DateTime d = new DateTime();
            d = d.AddSeconds(this.GetTimeTotal);

            int errorCount = this.GetErrorsCount;

            double procent = 100 - (double)errorCount * 100 / (double)this.GetAttemptsCount;

            string tmp = string.Format("Всего попыток: {0}. Ошибок: {1}. Процент правильных ответов: {2}%.\r\n", this.GetAttemptsCount.ToString(), this.GetErrorsCount.ToString(), procent.ToString("F2"));
            tmp += string.Format("Всего потрачено времени {0}.\r\n", d.ToLongTimeString());
            tmp += string.Format("Среднее время {0} c. Минимальное время {1} c. Максимальное время {2} c.", this.GetTimeAverange.ToString("F2"), this.GetTimeMinimum.ToString("F2"), this.GetTimeMaximum.ToString("F2"));

            sb.Append(tmp);

            if (withErrorsList && errorCount > 0)
            {
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine("Ошибки:");

                Collection<ExerciseAttempt> errors = this.GerErrors();
                for (int i = 0; i < errors.Count; i++)
                {
                    ExerciseAttempt item = errors[i];
                    sb.AppendFormat(item.GetErrorDesctiption());

                    if (i != errorCount - 1)
                    {
                        sb.AppendLine();
                    }
                }

            }

            return sb.ToString();
        }

        /// <summary>
        /// Количество попыток в данной серии.
        /// </summary>
        public int GetAttemptsCount
        {
            get
            {
                return this.attempts.Count;
            }
        }

        #region Ошибки данной серии.

        /// <summary>
        /// Получить все ошибки.
        /// </summary>
        /// <returns></returns>
        public Collection<ExerciseAttempt> GerErrors()
        {
            Collection<ExerciseAttempt> result = new Collection<ExerciseAttempt>();

            foreach (ExerciseAttempt item in this.attempts)
            {
                if (!item.AnswerIsRight)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        /// <summary>
        /// Количество неправильных ответов в данной серии.
        /// </summary>
        public int GetErrorsCount
        {
            get
            {
                int result = 0;

                foreach (ExerciseAttempt item in this.attempts)
                {
                    if (!item.AnswerIsRight)
                    {
                        result++;
                    }
                }

                return result;
            }
        }

        #endregion Ошибки данной серии.

        #region Статистические данные по времени выполнения попыток.

        /// <summary>
        /// Наибольшее время выполнения попытки в данной серии.
        /// </summary>
        public double GetTimeMaximum
        {
            get
            {
                double result = 0;

                if (this.attempts.Count > 0)
                {
                    result = this.attempts[0].GetTotalTime;

                    for (int i = 1; i < this.attempts.Count; i++)
                    {
                        result = Math.Max(result, this.attempts[i].GetTotalTime);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Наименьшее время выполнения попытки в данной серии.
        /// </summary>
        public double GetTimeMinimum
        {
            get
            {
                double result = 0;

                if (this.attempts.Count > 0)
                {
                    result = this.attempts[0].GetTotalTime;

                    for (int i = 1; i < this.attempts.Count; i++)
                    {
                        result = Math.Min(result, this.attempts[i].GetTotalTime);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Полное время выполнения всех попыток.
        /// </summary>
        public double GetTimeTotal
        {
            get
            {
                double result = 0;

                for (int i = 0; i < this.attempts.Count; i++)
                {
                    result += this.attempts[i].GetTotalTime;
                }

                return result;
            }
        }

        /// <summary>
        /// Среднее время выполнения попытки в данной серии.
        /// </summary>
        public double GetTimeAverange
        {
            get
            {
                if (this.attempts.Count > 0)
                {
                    return this.GetTimeTotal / this.attempts.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion Статистические данные по времени выполнения попыток.

        /// <summary>
        /// Создание XmlNode по объекту.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual XmlNode CreateXmlNode(XmlDocument doc, string name)
        {
            XmlNode result = doc.CreateElement(name);

            this.type.SaveTypeAttributes(result);

            foreach (ExerciseAttempt item in this.attempts)
            {
                result.AppendChild(item.CreateXmlNode(doc));
            }

            return result;
        }

        /// <summary>
        /// Считывание полей из XmlNode.
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <returns></returns>
        public static ExerciseSerie CreateFromXml(XmlNode xmlNode)
        {
            ExerciseSerie result = new ExerciseSerie();

            result.type = ExerciseType.CreateFromXml(xmlNode);

            foreach (XmlNode item in xmlNode.ChildNodes)
            {
                result.attempts.Add(ExerciseAttempt.CreateFromXml(item));
            }

            return result;
        }
    }
}
