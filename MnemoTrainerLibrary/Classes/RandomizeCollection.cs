using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace MnemoTrainerLibrary.Classes
{
    public class RandomizeCollection
    {
        #region Внутренние поля.

        Random rnd = new Random();

        private const int standartRepeatCount = 40;
        private const int lastCountWeight = 10;

        private int RepeatCount { get; set; }

        Collection<int> randomCollection = new Collection<int>();
        private Collection<int> lastQuestion = new Collection<int>();

        #endregion Внутренние поля.

        #region Свойства.

        private int lapsCount = 0;
        public int LapsCount
        {
            get { return this.lapsCount; }
        }

        Collection<int> askedQuestions = new Collection<int>();
        public int AskedQuestionsCount
        {
            get { return this.askedQuestions.Count; }
        }

        private int[] weights;
        public int Length
        {
            get { return weights.Length; }

            set
            {
                SetArrayLength(value);
            }
        }

        #endregion Свойства.

        public RandomizeCollection()
        {
            
        }

        #region События.

        public event EventHandler AfterLapsCountChanged;

        protected virtual void OnAfterLapsCountChanged(EventArgs e)
        {
            if (AfterLapsCountChanged != null)
                AfterLapsCountChanged(this, e);
        }

        #endregion События.

        private void SetArrayLength(int length)
        {
            lapsCount = 0;
            askedQuestions.Clear();
            randomCollection.Clear();
            lastQuestion.Clear();

            weights = new int[length];
            for (int index = 0; index < length; index++)
            {
                weights[index] = 1;
                randomCollection.Add(index);
            }

            if (length < standartRepeatCount * 3 / 2)
            {
                int temp = length * 2 / 3;

                if (temp > 0)
                {
                    this.RepeatCount = temp;
                }
                else
                {
                    this.RepeatCount = 0;
                }
            }
            else
            {
                this.RepeatCount = standartRepeatCount;
            }
        }

        #region Открытые методы.

        public int GetRandomIndex()
        {
            int totalWeight = 0;

            foreach (int index in randomCollection)
            {
                totalWeight += weights[index];
            }

            int selectedWeight = rnd.Next(totalWeight) + 1;

            int indexInRandomCollection = -1;

            while (selectedWeight > 0)
            {
                indexInRandomCollection++;

                selectedWeight -= weights[randomCollection[indexInRandomCollection]];
            }

            if (askedQuestions.Count == weights.Length)
            {
                lapsCount++;
                askedQuestions.Clear();
            }

            int resultIndex = randomCollection[indexInRandomCollection];

            OnAfterLapsCountChanged(new EventArgs());

            if (!askedQuestions.Contains(resultIndex))
            {
                askedQuestions.Add(resultIndex);
            }

            return resultIndex;
        }

        public void CheckInIndex(int itemIndex, bool answerIsRight)
        {
            if (answerIsRight)
            {
                weights[itemIndex] = 1;
            }
            else
            {
                weights[itemIndex]++;
            }

            if (this.RepeatCount != 0)
            {
                randomCollection.Remove(itemIndex);

                ArrayList listWeights = new ArrayList();

                foreach (int index in randomCollection)
                {
                    weights[index] += 2;

                    listWeights.Add(weights[index]);
                }

                if (lastQuestion.Count == this.RepeatCount)
                {
                    int temp = lastQuestion[0];
                    randomCollection.Add(temp);

                    lastQuestion.RemoveAt(0);
                }

                lastQuestion.Add(itemIndex);

                listWeights.Sort();

                if (listWeights.Count > lastCountWeight)
                {
                    int minWeight = (int)listWeights[listWeights.Count - lastCountWeight];

                    int elementCount = 0;
                    foreach (int index in randomCollection)
                    {
                        if (weights[index] >= minWeight)
                        {
                            elementCount++;
                        }
                    }

                    if (elementCount <= lastCountWeight)
                    {
                        foreach (int index in randomCollection)
                        {
                            if (weights[index] >= minWeight)
                            {
                                weights[index] += 10;
                            }
                        }
                    }
                }
            }
        }

        #endregion Открытые методы.
    }
}
