using System;
using System.Threading;
using System.Windows.Forms;
using MnemoTrainer.Classes;

namespace MnemoTrainer
{
    static class Program
    {
        private static Mutex mutex = new Mutex(false, "Panama.Progs.Mnemotrainer");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!mutex.WaitOne(TimeSpan.FromSeconds(1), false))
            {
                return;
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                ProgramConfiguraton.LoadXmlConfig();

                Application.Run(new FormSelect());

                ProgramConfiguraton.SaveXmlConfig();
            }
            finally { mutex.ReleaseMutex(); }
        }
    }
}
