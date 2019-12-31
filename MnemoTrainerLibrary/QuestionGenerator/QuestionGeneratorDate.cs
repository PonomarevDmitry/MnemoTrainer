using System;
using System.Collections.ObjectModel;
using System.Globalization;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.QuestionGenerator
{
    public class QuestionGeneratorDate
    {
        Random rnd = new Random();

        private const int standartRepeatCount = 70;
        private const int loopsCount = 70;

        private Collection<int> lastAges = new Collection<int>();
        private Collection<int> lastQuestionYears = new Collection<int>();
        private Collection<DateTime> lastQuestionDates = new Collection<DateTime>();
        private Collection<int> lastDateFormats = new Collection<int>();

        private int leapYearCounter = 0;
        private int leapYearFrequency = 4;

        private string[] dateFormat = { "dd.MM.yyyy", "d MMMM yyyy", "yyyy.MM.dd", "yyyy MMMM d", "MM*dd*yyyy", "MMMM d yyyy" };
        private string[] monthFormat = { "dd.MM", "d MMMM", "MMMM d", "MM*dd", "MMMM d" };

        private int[] monthIndex = { 6, 2, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };

        #region Свойства.

        public TrainTypeDate TestType { get; set; }

        private int minYear = 1600;
        public int MinYear
        {
            get { return this.minYear; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MinYear");
                }

                this.minYear = value;
            }
        }

        private int maxYear = 2099;
        public int MaxYear
        {
            get { return this.maxYear; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MaxYear");
                }

                this.maxYear = value;
            }
        }

        #endregion Свойства.

        private DateTime questionDate;
        public DateTime QuestionDate
        {
            get { return this.questionDate; }
        }

        private string questionText = string.Empty;
        public string QuestionText
        {
            get { return this.questionText; }
        }

        private int answerInt = -1;
        public int AnswerInt
        {
            get { return this.answerInt; }
        }

        private string answerText = string.Empty;
        public string AnswerText
        {
            get { return this.answerText; }
        }

        public QuestionGeneratorDate()
        {
            this.TestType = TrainTypeDate.DayOfWeek;
        }

        #region Генерация нового вопроса.

        public void CreateNewQuestion()
        {
            if (this.TestType == TrainTypeDate.DayOfWeek)
            {
                CreateNewQuestionForDayOfWeek();
            }
            else if (this.TestType == TrainTypeDate.MonthDate)
            {
                CreateNewQuestionForMonthDate();
            }
            else if (this.TestType == TrainTypeDate.IndexOf12)
            {
                CreateNewQustionForIndexOf12();
            }
            else if (this.TestType == TrainTypeDate.IndexOfYear)
            {
                CreateNewQuestionForIndexOfYear();
            }
        }

        private void CreateNewQuestionForDayOfWeek()
        {
            leapYearCounter++;

            int loops = 0;

            do
            {
                int year, month;

                int minValue = this.minYear;
                int maxValue = this.maxYear;

                if (leapYearCounter == leapYearFrequency)
                {
                    int firstLeap = GetFirstLeap(minValue);
                    int leapCount = (maxValue - firstLeap) / 4;

                    year = firstLeap + rnd.Next(leapCount) * 4;

                    month = rnd.Next(2) + 1;
                }
                else
                {
                    year = rnd.Next(maxValue - minValue + 1) + minValue;

                    month = rnd.Next(12) + 1;
                }

                int day = rnd.Next(DateTime.DaysInMonth(year, month)) + 1;

                questionDate = new DateTime(year, month, day);

                loops++;

            } while (QuestionDateIsRepeat(questionDate, true) && loops < loopsCount);

            if (leapYearCounter == leapYearFrequency)
            {
                leapYearCounter = 0;
                leapYearFrequency = 3 + rnd.Next(3);
            }

            questionText = GenerateDateString(questionDate, true);

            answerInt = (int)questionDate.DayOfWeek;

            answerText = GetNameDayOfWeek(questionDate.DayOfWeek);
        }

        private void CreateNewQuestionForMonthDate()
        {
            do
            {
                int month = rnd.Next(12) + 1;

                int day = rnd.Next(DateTime.DaysInMonth(2000, month)) + 1;

                questionDate = new DateTime(2000, month, day);

            } while (QuestionDateIsRepeat(questionDate, false));

            questionText = GenerateDateString(questionDate, false);

            answerInt = (questionDate.Day + monthIndex[questionDate.Month - 1]) % 7;

            answerText = answerInt.ToString();
        }

        private void CreateNewQustionForIndexOf12()
        {
            int year, temp;

            do
            {
                year = rnd.Next(12);

                temp = (year + year / 4) % 7;
                if (temp > 3) temp -= 7;

            } while (temp == answerInt);

            questionText = year.ToString();

            answerInt = temp;
            answerText = answerInt.ToString();
        }

        private void CreateNewQuestionForIndexOfYear()
        {
            int minValue = this.minYear;
            int maxValue = this.maxYear;

            int year;

            do
            {
                year = rnd.Next(maxValue - minValue + 1) + minValue;

            } while (YearIsRepeat(year));

            questionText = year.ToString();

            answerInt = (year + year / 4 - year / 100 + year / 400) % 7;

            answerText = answerInt.ToString();
        }

        #region Проверка повторов вопросов.

        private bool QuestionDateIsRepeat(DateTime date, bool checkYear)
        {
            foreach (DateTime item in lastQuestionDates)
            {
                TimeSpan temp = new DateTime(2000, date.Month, date.Day) - new DateTime(2000, item.Month, item.Day);

                if ((checkYear && item.Year == date.Year) || Math.Abs(temp.TotalDays) < 2)
                {
                    return true;
                }
            }

            if (checkYear)
            {
                if (AgeIsRepeat(date.Year)) return true;
            }

            lastQuestionDates.Add(date);

            while (lastQuestionDates.Count > standartRepeatCount)
            {
                lastQuestionDates.RemoveAt(0);
            }

            return false;
        }

        private bool AgeIsRepeat(int year)
        {
            int minValue = this.minYear;
            int maxValue = this.maxYear;

            int lastAgesCount = (maxValue / 100 - minValue / 100) / 2;

            if (lastAgesCount != 0)
            {
                int age = (year - 1) / 100;
                if (lastAges.Contains(age)) return true;

                lastAges.Add(age);

                while (lastAges.Count > lastAgesCount)
                {
                    lastAges.RemoveAt(0);
                }
            }

            return false;
        }

        private bool YearIsRepeat(int year)
        {
            if (lastQuestionYears.Contains(year)) return true;

            if (AgeIsRepeat(year)) return true;

            lastQuestionYears.Add(year);

            while (lastQuestionYears.Count > standartRepeatCount)
            {
                lastQuestionYears.RemoveAt(0);
            }

            return false;
        }

        #endregion Проверка повторов вопросов.

        #region Формирование стоки даты.

        private string GenerateDateString(DateTime date, bool withYear)
        {
            string result = string.Empty;

            int index = 0;

            do
            {
                if (withYear)
                {
                    index = rnd.Next(dateFormat.Length);
                }
                else
                {
                    index = rnd.Next(monthFormat.Length);
                }

            } while (DateFormatIsRepeat(index));

            if (withYear)
            {
                result = date.ToString(dateFormat[index]).Replace("*", @"/");
            }
            else
            {
                result = date.ToString(monthFormat[index]).Replace("*", @"/");
            }

            return result;
        }

        private bool DateFormatIsRepeat(int index)
        {
            bool result = false;

            if (lastDateFormats.Count > 0)
            {
                result = true;

                for (int i = 1; i < 3; i++)
                {
                    int ind = lastDateFormats.Count - i;

                    if (ind > -1)
                    {
                        if (lastDateFormats[ind] != index)
                        {
                            result = false;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (result) return true;

            lastDateFormats.Add(index);

            while (lastDateFormats.Count > 10)
            {
                lastDateFormats.RemoveAt(0);
            }

            return false;
        }

        #endregion Формирование стоки даты.

        #endregion Генерация нового вопроса.

        public void CheckAnswer(string userAnswer, out bool isAnswerRight, out string answerText, out string userAnswerText)
        {
            isAnswerRight = false;

            int? userAnswerInt = null;
            int tempInt = 0;

            if (int.TryParse(userAnswer, out tempInt))
            {
                userAnswerInt = tempInt;
            }

            isAnswerRight = CompareAnswers(this.answerInt, userAnswerInt);

            userAnswerText = string.Empty;
            if (userAnswerInt.HasValue)
            {
                if (this.TestType == TrainTypeDate.DayOfWeek)
                {
                    userAnswerInt = (userAnswerInt.Value + 70) % 7;

                    userAnswerText = GetNameDayOfWeek((DayOfWeek)userAnswerInt);
                }
                else
                {
                    userAnswerText = userAnswerInt.Value.ToString();
                }
            }

            answerText = this.questionText + "\r\n" + this.answerText;

            if (!isAnswerRight)
            {
                answerText += !string.IsNullOrEmpty(userAnswerText) ? " <> " + userAnswerText : string.Empty;
            }
        }

        private bool CompareAnswers(int rightAnswer, int? answer)
        {
            if (answer.HasValue && -3 <= answer.Value && answer.Value <= 7)
            {
                return (rightAnswer - answer.Value) % 7 == 0;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            lastQuestionDates.Clear();
            lastAges.Clear();
            lastQuestionYears.Clear();
            lastDateFormats.Clear();
        }

        #region Дополнительные функции.

        private int GetFirstLeap(int year)
        {
            for (int i = 0; i < 20; i++)
            {
                if (DateTime.IsLeapYear(year + i))
                {
                    return year + i;
                }
            }

            return year;
        }

        private string GetNameDayOfWeek(DayOfWeek dayOfWeek)
        {
            CultureInfo rusCulture = CultureInfo.GetCultureInfo("ru-Ru");

            DateTimeFormatInfo tmp = rusCulture.DateTimeFormat;

            string result = tmp.GetDayName(dayOfWeek);

            result = char.ToUpper(result[0]) + result.Substring(1);

            return result;
        }

        #endregion Дополнительные функции.
    }
}
