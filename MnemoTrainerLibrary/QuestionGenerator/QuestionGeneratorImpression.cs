using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Text;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.QuestionGenerator
{
    public class QuestionGeneratorImpression
    {
        #region Внутренние поля.

        Random rnd = new Random();

        //private string charCollection = "0123456789АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЫЭЮЯ";
        private string charCollection = "0123456789";

        private Color[] colorCollection = new Color[10] 
        { 
            Color.White,    // 0 - Белый
            Color.HotPink,  // 1 - Розовый
            Color.Orange,   // 2 - Оранжевый
            Color.Green,    // 3 - Зеленый
            Color.Black,    // 4 - Черный
            Color.Red,      // 5 - Красный
            Color.Yellow,   // 6 - Желтый
            Color.Blue,     // 7 - Синий
            Color.Purple,   // 8 - Фиолетовый
            Color.Brown     // 9 - Коричневый
        };

        private ArrayList programDictionary = new ArrayList();

        private int standartRepeatCount = 2000;
        private Collection<string> lastQuestions = new Collection<string>();

        #endregion Внутренние поля.

        private Color? questionColor = null;
        public Color? QuestionColor
        {
            get
            {
                if (this.WithColor)
                {
                    return this.questionColor;
                }

                return null;
            }
        }

        private string questionText = string.Empty;
        public string QuestionText
        {
            get { return this.questionText; }
        }

        private string answerText = string.Empty;
        public string AnswerText
        {
            get { return this.answerText; }
        }

        public TrainTypeImpression TestType { get; set; }

        private int wordsCount = 1;
        public int WordsCount
        {
            get { return this.wordsCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("WordsCount");
                }

                this.wordsCount = value;
            }
        }

        private int symbolsCount = 6;
        public int SymbolsCount
        {
            get { return this.symbolsCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("SymbolsCount");
                }

                this.symbolsCount = value;
            }
        }

        public bool WithColor { get; set; }

        public virtual bool WithRandomLiters { get; set; }

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

        public QuestionGeneratorImpression()
        {
            this.TestType = TrainTypeImpression.None;
        }

        #region Генерация нового вопроса.

        public void CreateNewQuestion()
        {
            if (this.TestType == TrainTypeImpression.Dictionary)
            {
                if (programDictionary.Count == 0)
                {
                    throw new NotSupportedException();
                }

                Collection<string> newQuestionsCol = new Collection<string>();

                while (newQuestionsCol.Count < this.wordsCount)
                {
                    string newTest;

                    do
                    {
                        int nextWordIndex = rnd.Next(programDictionary.Count);

                        newTest = (string)programDictionary[nextWordIndex];

                    } while (lastQuestions.Contains(newTest));

                    AddQuestionToCollection(newTest);

                    newQuestionsCol.Add(newTest);
                }

                this.answerText = GenerateQuestionString(newQuestionsCol, false);
                this.questionText = GenerateQuestionString(newQuestionsCol, this.WithRandomLiters);
            }
            else if (TestType == TrainTypeImpression.Symbols)
            {
                StringBuilder strBuilder;

                do
                {
                    strBuilder = new StringBuilder();

                    for (int i = 0; i < this.symbolsCount; i++)
                    {
                        int temp = rnd.Next(charCollection.Length);

                        strBuilder.Append(charCollection[temp]);
                    }

                } while (lastQuestions.Contains(strBuilder.ToString()));

                this.questionText = strBuilder.ToString();
                this.answerText = this.questionText;

                if (this.WithColor)
                {
                    int colorIndex = rnd.Next(colorCollection.Length);

                    this.answerText = colorIndex.ToString() + this.answerText;
                    this.questionColor = colorCollection[colorIndex];
                }

                this.questionText = Common.FillSpaces(this.questionText);
            }
        }

        private string GenerateQuestionString(Collection<string> coll, bool confuseSymbols)
        {
            StringBuilder strBuilder = new StringBuilder();

            foreach (string itemString in coll)
            {
                if (strBuilder.Length > 0)
                {
                    strBuilder.Append(" ");
                }

                string tempString;
                if (confuseSymbols)
                {
                    tempString = Common.ConfuseSymbols(itemString);
                }
                else
                {
                    tempString = itemString;
                }

                strBuilder.Append(tempString);
            }

            return strBuilder.ToString();
        }

        #region Проверка повторов вопросов.

        private void AddQuestionToCollection(string text)
        {
            lastQuestions.Add(text);

            while (lastQuestions.Count > this.standartRepeatCount)
            {
                lastQuestions.RemoveAt(0);
            }
        }

        #endregion Проверка повторов вопросов.

        #endregion Генерация нового вопроса.

        public void Clear()
        {
            lastQuestions.Clear();
        }

        public void CheckAnswer(string userAnswer, out bool isAnswerRight, out string answerText, out string userAnswerText)
        {
            isAnswerRight = CompareAnswers(this.answerText, userAnswer);

            answerText = this.answerText;
            userAnswerText = userAnswer;

            if (TestType == TrainTypeImpression.Symbols)
            {
                answerText = Common.FillSpaces(this.answerText);
                userAnswerText = Common.FillSpaces(userAnswer);
            }

            if (!isAnswerRight)
            {
                answerText += !string.IsNullOrEmpty(userAnswerText) ? "\r\n" + userAnswerText : string.Empty;
            }
        }

        private bool CompareAnswers(string rightAnswer, string answer)
        {
            string temp1 = rightAnswer.Replace(" ", string.Empty);
            string temp2 = answer.Replace(" ", string.Empty);

            return string.Compare(temp1, temp2, true) == 0;
        }
    }
}
