using System.Drawing;

namespace MnemoTrainerLibrary.Classes
{
    public class NetTest
    {
        #region Свойства.

        public string Question { get; private set; }
        public string Answer { get; private set; }

        public NetTestType TestType { get; private set; }
        public NetUnit BaseUnit { get; private set; }

        public Color? QuestionColor { get; set; }

        #endregion Свойства.

        #region Конструкторы.

        public NetTest(string question, string answer, NetTestType testType, NetUnit baseUnit)
        {
            this.Question = question;
            this.Answer = answer;

            this.TestType = testType;
            this.BaseUnit = baseUnit;
        }

        public NetTest(string question, string answer, NetTestType testType, NetUnit baseUnit, Color? questionColor) :
            this(question, answer, testType, baseUnit)
        {
            this.QuestionColor = questionColor;
        }

        #endregion Конструкторы.

        #region Методы.

        public override string ToString()
        {
            return this.Question + " - " + this.Answer;
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is NetTest))
            {
                return false;
            }

            NetTest target = obj as NetTest;

            return this.Question == target.Question
                && this.Answer == target.Answer && this.TestType == target.TestType;
        }

        #endregion Методы.
    }
}
