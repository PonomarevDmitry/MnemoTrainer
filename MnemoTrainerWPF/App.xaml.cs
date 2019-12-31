using System;
using System.Threading;
using System.Windows;
using MnemoTrainer.Classes;

namespace MnemoTrainer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex mutex = new Mutex(false, "Panama.Progs.Mnemotrainer");

        public App()
        {
            if (!mutex.WaitOne(TimeSpan.FromSeconds(1), false))
            {
                return;
            }

            try
            {
                ProgramConfiguraton.LoadXmlConfig();

                //Application.Run(new FormSelect());

                ProgramConfiguraton.SaveXmlConfig();
            }
            finally { mutex.ReleaseMutex(); }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
