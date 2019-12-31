using System.Collections.ObjectModel;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Train
{
    public delegate void QuestionResultEventHandler(object sender, QuestionResultEventArgs e);

    public class QuestionResultEventArgs
    {
        private string text;
        public string Text
        {
            get { return this.text; }
        }

        private bool isAnswerRight;
        public bool IsAnswerRight
        {
            get { return this.isAnswerRight; }
        }

        private bool isAutoCheck;
        public bool IsAutoCheck
        {
            get { return this.isAutoCheck; }
        }

        public QuestionResultEventArgs(string text, bool isAnswerRight, bool isAutoCheck)
        {
            this.text = text;
            this.isAnswerRight = isAnswerRight;
            this.isAutoCheck = isAutoCheck;
        }
    }

    public delegate void AssociationResultEventHandler(object sender, AssociationResultEventArgs e);

    public class AssociationResultEventArgs
    {
        public Collection<AssociationQuestion> Associations { get; private set; }

        public AssociationResultEventArgs(Collection<AssociationQuestion> associations)
        {
            this.Associations = associations;
        }
    }

    public delegate void FirstWordsEventHandler(object sender, FirstWordsEventArgs e);

    public class FirstWordsEventArgs
    {
        public Collection<string> FirstWords { get; private set; }

        public FirstWordsEventArgs(Collection<string> words)
        {
            this.FirstWords = words;
        }
    }
}
