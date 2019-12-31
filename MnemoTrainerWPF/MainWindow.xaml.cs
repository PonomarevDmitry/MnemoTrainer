using System.Windows;

namespace MnemoTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //LoadFormConfiguration();
        }

        //#region Инициализация.

        //        private void LoadFormConfiguration()
        //        {
        //            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

        //            string text;

        //#if DEBUG
        //            text = ProgramConfiguraton.LoadFormCustomParameter(this, "LocalSettingFolder_Debug");
        //#else
        //            text = ProgramConfiguraton.LoadFormCustomParameter(this, "LocalSettingFolder");
        //#endif
        //            //OperateLocalSettingsPath(text);

        //            text = ProgramConfiguraton.LoadFormCustomParameter(this, "ClickedButton");
        //            if (!string.IsNullOrEmpty(text))
        //            {
        //                Control[] controls = this.Controls.Find(text, true);
        //                if (controls.Length == 1 && controls[0] is Button)
        //                {
        //                    this.clickedButton = controls[0].Name;
        //                    controls[0].Select();
        //                }
        //            }
        //        }

        //        protected override void OnClosed(EventArgs e)
        //        {
        //            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);

        //#if DEBUG
        //            ProgramConfiguraton.SaveFormCustomParameter(this, "LocalSettingFolder_Debug", Config.LocalSettingFolder);
        //#else
        //            ProgramConfiguraton.SaveFormCustomParameter(this, "LocalSettingFolder", Config.LocalSettingFolder);
        //#endif

        //            ProgramConfiguraton.SaveFormCustomParameter(this, "ClickedButton", this.clickedButton);

        //            ProgramConfiguraton.SaveXmlConfig();

        //            base.OnClosed(e);
        //        }

        //        #endregion Инициализация.
    }
}
