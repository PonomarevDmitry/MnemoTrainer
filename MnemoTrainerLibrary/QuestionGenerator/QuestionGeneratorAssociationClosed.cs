using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;
using MnemoTrainerLibrary.Classes;
using System.IO;

namespace MnemoTrainerLibrary.QuestionGenerator
{
    public class QuestionGeneratorAssociationClosed
    {
        #region Внутренние поля.

        Random rnd = new Random();

        private ArrayList programDictionary = new ArrayList();

        #endregion Внутренние поля.

        #region Свойства.

        public TrainTypeAssociationClosed TestType { get; set; }

        private FileInfo selectedDictionary = null;
        public FileInfo SelectedDictionary
        {
            get { return this.selectedDictionary; }
            set
            {
                if (value != null && !value.Exists)
                {
                    throw new ArgumentException("SelectedFile");
                }

                bool changed = this.selectedDictionary != value;

                this.selectedDictionary = value;
                if (changed)
                {
                    programDictionary.Clear();

                    programDictionary = WordDictionary.GetWordsFromFile(this.selectedDictionary.FullName);
                }
            }
        }

        public ClosedList SelectedClosedList { get; set; }

        private int questionsCount = 20;
        public int QuestionsCount
        {
            get { return this.questionsCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("QuestionsCount");
                }

                this.questionsCount = value;
            }
        }

        #endregion Свойства.

        public QuestionGeneratorAssociationClosed()
        {
            this.TestType = TrainTypeAssociationClosed.WordDictionary;
        }

        #region Генерация нового вопроса.

        public Collection<AssociationQuestion> CreateNewQuestionList()
        {
            Collection<AssociationQuestion> associationQuestions = new Collection<AssociationQuestion>();

            Collection<string> questionSource = new Collection<string>();

            if (this.TestType == TrainTypeAssociationClosed.WordDictionary)
            {
                for (int i = 0; i < 7; i++)
                {
                    string nextWord = string.Empty;

                    do
                    {
                        int nextWordIndex = rnd.Next(programDictionary.Count);

                        nextWord = (string)programDictionary[nextWordIndex];

                    } while (questionSource.Contains(nextWord));

                    questionSource.Add(nextWord);
                }
            }
            else if (this.TestType == TrainTypeAssociationClosed.ClosedList || this.TestType == TrainTypeAssociationClosed.RandomClosedList)
            {
                if (this.TestType == TrainTypeAssociationClosed.RandomClosedList)
                {
                    int tmp = rnd.Next(ClosedList.ClosedLists.Count);

                    this.SelectedClosedList = ClosedList.ClosedLists[tmp];
                }

                foreach (string item in this.SelectedClosedList.Words)
                {
                    questionSource.Add(item);
                }
            }

            for (int i = 0; i < this.questionsCount; i++)
            {
                string nextWord;

                do
                {
                    int nextWordIndex = rnd.Next(questionSource.Count);

                    nextWord = (string)questionSource[nextWordIndex];

                } while (CheckNextQuestion(nextWord, associationQuestions));

                AssociationQuestion temp = new AssociationQuestion();
                temp.QuestionSerie.Add(new AssociationQuestionPart(nextWord));
                temp.Number = i + 1;
                temp.ShowPosition = temp.Number;

                associationQuestions.Add(temp);
            }

            return associationQuestions;
        }

        private bool CheckNextQuestion(string nextWord, Collection<AssociationQuestion> associationQuestions)
        {
            if (associationQuestions.Count > 0)
            {
                AssociationQuestion temp = associationQuestions[associationQuestions.Count - 1];

                if (temp.Question.ToLower() == nextWord.ToLower())
                {
                    return true;
                }
            }

            if (associationQuestions.Count > 1)
            {
                AssociationQuestion temp = associationQuestions[associationQuestions.Count - 2];

                if (temp.Question.ToLower() == nextWord.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Генерация нового вопроса.
    }
}
