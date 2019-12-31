using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.QuestionGenerator
{
    public class QuestionGeneratorNumericAlphabet
    {
        #region Внутренние поля.

        Random rnd = new Random();

        private const int standartRepeatCount = 2000;
        private readonly string[] numberAlphabet = new string[] { "НЛ", "Р", "ДГ", "ТЗ", "ЧК", "ПБ", "ШЖЩ", "СЦ", "ВФ", "МХ" };

        private Collection<string> lastQuestions = new Collection<string>();

        private ArrayList programDictionary = new ArrayList();

        #endregion Внутренние поля.

        private string questionText = string.Empty;
        public string QuestionText
        {
            get { return this.questionText; }
        }

        private string answerValue = string.Empty;
        public string AnswerValue
        {
            get { return this.answerValue; }
        }

        public TrainTypeNumericAlphaget TestType { get; set; }

        private FileInfo selectedFile = null;
        public FileInfo SelectedFile
        {
            get { return this.selectedFile; }
            set
            {
                if (value != null && !value.Exists)
                {
                    throw new ArgumentException("SelectedFile");
                }

                bool changed = this.selectedFile != value;

                this.selectedFile = value;
                if (changed)
                {
                    programDictionary.Clear();

                    programDictionary = WordDictionary.GetWordsFromFile(this.selectedFile.FullName);
                }
            }
        }

        public QuestionGeneratorNumericAlphabet()
        {
            this.TestType = TrainTypeNumericAlphaget.None;
        }

        #region Генерация нового вопроса.

        public void CreateNewQuestion()
        {
            string numberString = string.Empty;

            do
            {
                int nextWordIndex = rnd.Next(programDictionary.Count);

                questionText = (string)programDictionary[nextWordIndex];

                numberString = GetNumber(ConvertLitersIntoDigits(questionText));

            } while (string.IsNullOrEmpty(numberString) || QuestionIsRepeat(questionText));

            if (this.TestType == TrainTypeNumericAlphaget.Sum)
            {
                long summ = 0;

                foreach (char ch in numberString)
                {
                    summ += ch - '0';
                }

                this.answerValue = summ.ToString();
            }
            else if (this.TestType == TrainTypeNumericAlphaget.Number)
            {
                try
                {
                    this.answerValue = numberString;
                }
                catch (Exception)
                {
                }
            }
        }

        #region Проверка повторов вопросов.

        private string ConvertLitersIntoDigits(string questionText)
        {
            StringBuilder strBilder = new StringBuilder(questionText.ToUpper());

            for (int i = 0; i < numberAlphabet.Length; i++)
            {
                string item = numberAlphabet[i];

                foreach (char ch in item)
                {
                    strBilder.Replace(ch, (char)('0' + i));
                }
            }

            StringBuilder result = new StringBuilder();

            for (int index = 0; index < questionText.Length; index++)
            {
                char charOriginal = questionText[index];
                char charNew = strBilder[index];

                if (Char.ToUpper(charOriginal) != Char.ToUpper(charNew))
                {
                    result.Append(charNew);
                }
                else
                {
                    result.Append(charOriginal);
                }
            }

            return result.ToString();
        }

        private string GetNumber(string text)
        {
            StringBuilder resultBuilder = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];

                if (char.IsDigit(ch))
                {
                    resultBuilder.Append(ch);
                }
            }

            return resultBuilder.ToString();
        }

        private bool QuestionIsRepeat(string text)
        {
            if (lastQuestions.Contains(text)) return true;

            if (lastQuestions.Count == standartRepeatCount)
            {
                lastQuestions.RemoveAt(0);
            }

            lastQuestions.Add(text);

            return false;
        }

        #endregion Проверка повторов вопросов.

        #endregion Генерация нового вопроса.

        public void Clear()
        {
            lastQuestions.Clear();
        }

        public void CheckAnswer(string userAnswer, out bool isAnswerRight, out string answerText, out string userAnswerText)
        {
            isAnswerRight = false;

            userAnswerText = GetNumber(userAnswer);

            isAnswerRight = CompareAnswers(this.answerValue, userAnswerText);

            answerText = this.questionText + "\r\n" + this.answerValue.ToString();

            if (!isAnswerRight)
            {
                answerText += !string.IsNullOrEmpty(userAnswerText) ? " <> " + userAnswerText : string.Empty;
            }
        }

        private bool CompareAnswers(string rightAnswer, string answer)
        {
            return !string.IsNullOrEmpty(answer) && string.Compare(rightAnswer, answer, true) == 0;
        }
    }
}
