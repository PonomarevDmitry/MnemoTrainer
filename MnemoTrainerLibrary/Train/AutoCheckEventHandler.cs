
namespace MnemoTrainerLibrary.Train
{
    /// <summary>
    /// Обработчик события ответа по таймеру
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void AutoCheckEventHandler(object sender, AutoCheckEventArgs e);

    /// <summary>
    /// Аргументы события ответа по таймеру
    /// </summary>
    public class AutoCheckEventArgs
    {
        private string userAnswer = string.Empty;
        public string UserAnswer
        {
            get { return this.userAnswer; }
            set { this.userAnswer = value; }
        }

        public AutoCheckEventArgs()
        {
            userAnswer = string.Empty;
        }
    }
}
