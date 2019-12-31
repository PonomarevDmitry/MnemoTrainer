using System;
using System.Collections.ObjectModel;
using System.Drawing;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.QuestionGenerator
{
    public class QuestionGeneratorStrup
    {
        Random rnd = new Random();

        private Collection<ColorTest> lastQuestions = new Collection<ColorTest>();
        private const int standartRepeatCount = 70;

        private ColorTest currentQuestion;
        public string CurrentColorName
        {
            get
            {
                if (currentQuestion != null)
                {
                    return currentQuestion.Text;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public Color? CurrentColor
        {
            get 
            {
                if (currentQuestion != null)
                {
                    return currentQuestion.Color;
                }
                else
                {
                    return null;
                }
            }
        }

        public void CreateNewQuestion()
        {
            do
            {
                Color color = ColorTest.colorCollection[rnd.Next(ColorTest.colorCollection.Count)].Color;
                string text = ColorTest.colorCollection[rnd.Next(ColorTest.colorCollection.Count)].Text;

                currentQuestion = new ColorTest(color, text);

            } while (QuestionIsRepeat(currentQuestion));
        }

        private bool QuestionIsRepeat(ColorTest question)
        {
            if (lastQuestions.Contains(question)) return true;

            for (int i = 1; i < 4; i++)
            {
                int ind = lastQuestions.Count - i;

                if (ind > -1)
                {
                    if (lastQuestions[ind].Color == question.Color || lastQuestions[ind].Text == question.Text)
                    {
                        return true;
                    }
                }
                else
                {
                    break;
                }
            }

            lastQuestions.Add(question);
            while (lastQuestions.Count > standartRepeatCount)
            {
                lastQuestions.RemoveAt(0);
            }

            return false;
        }
    }
}
