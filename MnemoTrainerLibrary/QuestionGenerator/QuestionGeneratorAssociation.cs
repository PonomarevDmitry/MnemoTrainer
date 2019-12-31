using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;
using MnemoTrainerLibrary.Classes;
using System.IO;
using MnemoTrainerLibrary.Logging;

namespace MnemoTrainerLibrary.QuestionGenerator
{
    public class QuestionGeneratorAssociation
    {
        #region Внутренние поля.

        Random rnd = new Random();

        private ArrayList programDictionary = new ArrayList();

        #endregion Внутренние поля.

        public int WordsCount
        {
            get
            {
                if (programDictionary != null)
                {
                    return programDictionary.Count;


                }
                else
                {
                    return 0;
                }
            }
        }

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

        public virtual bool WithRepeats { get; set; }

        public virtual bool WithNumber { get; set; }

        public virtual bool RandomOrder { get; set; }

        public virtual bool WithoutOldWords { get; set; }

        private int oldWordsCount = 100;
        public int OldWordsCount
        {
            get { return this.oldWordsCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("OldWordsCount");
                }

                this.oldWordsCount = value;
            }
        }

        #region Генерация нового вопроса.

        public Collection<AssociationQuestion> CreateNewQuestionList()
        {
            Collection<AssociationQuestion> associationQuestions = new Collection<AssociationQuestion>();

            Hashtable oldTestWords = new Hashtable();

            if (this.WithoutOldWords)
            {
                oldTestWords = LogExercise.GetOldTestWords(this.oldWordsCount);
            }

            Collection<string> questions = new Collection<string>();

            for (int i = 0; i < this.questionsCount; i++)
            {
                string nextWord;

                do
                {
                    int nextWordIndex = rnd.Next(programDictionary.Count);

                    nextWord = (string)programDictionary[nextWordIndex];

                } while (oldTestWords.ContainsKey(nextWord) || (questions.Contains(nextWord) && !this.WithRepeats));

                questions.Add(nextWord);

                AssociationQuestion temp = new AssociationQuestion();
                temp.QuestionSerie.Add(new AssociationQuestionPart(nextWord));
                temp.Number = i + 1;

                associationQuestions.Add(temp);
            }

            if (this.WithNumber && this.RandomOrder)
            {
                Collection<int> allPositions = new Collection<int>();

                for (int i = 0; i < associationQuestions.Count; i++)
                {
                    allPositions.Add(i);
                }

                for (int i = 0; i < associationQuestions.Count; i++)
                {
                    int ind = allPositions[rnd.Next(allPositions.Count)];
                    allPositions.Remove(ind);

                    associationQuestions[ind].ShowPosition = i + 1;
                }
            }
            else
            {
                foreach (AssociationQuestion item in associationQuestions)
                {
                    item.ShowPosition = item.Number;
                }
            }

            return associationQuestions;
        }

        #endregion Генерация нового вопроса.
    }
}
