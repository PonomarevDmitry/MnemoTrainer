using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.QuestionGenerator
{
    public class QuestionGeneratorAssociationNumber
    {
        #region Внутренние поля.

        Random rnd = new Random();

        #endregion Внутренние поля.

        #region Свойства.

        private bool[] SourceCheckState;

        public static ReadOnlyCollection<Net> SourceNets { get; private set; }

        public void SetCheckState(int index, bool state)
        {
            SourceCheckState[index] = state;
        }

        public bool GetCheckState(int index)
        {
            return SourceCheckState[index];
        }

        public void SetCheckState(Net net, bool state)
        {
            int index = SourceNets.IndexOf(net);
            if (index != -1)
            {
                SourceCheckState[index] = state;
            }
        }

        public bool GetCheckState(Net net)
        {
            int index = SourceNets.IndexOf(net);
            if (index != -1)
            {
                return SourceCheckState[index];
            }

            return false;
        }

        private int numbersCount = 30;
        public int NumbersCount
        {
            get { return this.numbersCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("NumbersCount");
                }

                this.numbersCount = value;
            }
        }

        public virtual bool WithNumber { get; set; }

        public virtual bool RandomOrder { get; set; }

        #endregion Свойства.

        public QuestionGeneratorAssociationNumber()
        {
            this.SourceCheckState = new bool[SourceNets.Count];
        }

        static QuestionGeneratorAssociationNumber()
        {
            SourceNets = Net.FilteredNets;
        }

        #region Генерация нового вопроса.

        public Collection<AssociationQuestion> CreateNewQuestionList()
        {
            Collection<AssociationQuestion> associationQuestions = new Collection<AssociationQuestion>();

            int patternCount = this.numbersCount / 2 + this.numbersCount % 2;

            int singleNumber = -1;
            if (this.numbersCount % 2 != 0)
            {
                singleNumber = rnd.Next(patternCount);
            }

            for (int i = 0; i < patternCount; i++)
            {
                string nextNumber = rnd.Next(100).ToString("D2");
                if (i == singleNumber)
                {
                    nextNumber = rnd.Next(10).ToString();
                }

                AssociationQuestion temp = new AssociationQuestion();
                temp.QuestionSerie.Add(new AssociationQuestionPart(nextNumber));
                temp.Number = i + 1;

                associationQuestions.Add(temp);
            }

            Collection<Net> selectedNets = GetSelectedNets();

            if (selectedNets.Count > 2)
            {
                int[] netIndexs = new int[associationQuestions.Count];

                int serieCount = associationQuestions.Count / selectedNets.Count + (associationQuestions.Count % selectedNets.Count > 0 ? 1 : 0);

                for (int i = 0; i < serieCount; i++)
                {
                    bool cont = false;

                    int[] netOrder = new int[selectedNets.Count];

                    do
                    {
                        Collection<int> allPositions = new Collection<int>();
                        for (int j = 0; j < selectedNets.Count; j++)
                        {
                            allPositions.Add(j);
                        }

                        for (int j = 0; j < selectedNets.Count; j++)
                        {
                            int index = allPositions[rnd.Next(allPositions.Count)];
                            allPositions.Remove(index);

                            netOrder[j] = index;
                        }

                        cont = i != 0 && netIndexs[i * selectedNets.Count - 1] == netOrder[0];
                        if (i != 0)
                        {
                            bool equals = true;

                            for (int j = 0; j < selectedNets.Count; j++)
                            {
                                if (netIndexs[(i - 1) * selectedNets.Count + j] != netOrder[j])
                                {
                                    equals = false;
                                    break;
                                }
                            }

                            if (equals)
                            {
                                cont = true;
                            }
                        }


                    } while (cont);

                    for (int j = 0; j < selectedNets.Count && (i * selectedNets.Count + j < associationQuestions.Count); j++)
                    {
                        netIndexs[i * selectedNets.Count + j] = netOrder[j];
                    }
                }

                for (int i = 0; i < associationQuestions.Count; i++)
                {
                    associationQuestions[i].QuestionSerie[0].NetName = selectedNets[netIndexs[i]].ToString();
                }
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

                    AssociationQuestion quest = associationQuestions[ind];
                    quest.ShowPosition = i + 1;
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

        private Collection<Net> GetSelectedNets()
        {
            Collection<Net> result = new Collection<Net>();

            for (int i = 0; i < SourceNets.Count; i++)
            {
                if (this.SourceCheckState[i])
                {
                    result.Add(SourceNets[i]);
                }
            }

            return result;
        }

        #endregion Генерация нового вопроса.
    }
}
