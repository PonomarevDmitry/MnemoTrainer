using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using MnemoTrainer.Classes;
using MnemoTrainerLibrary;
using MnemoTrainerLibrary.Classes;
using MnemoTrainerLibrary.Logging;
using Excel = Microsoft.Office.Interop.Excel;

namespace MnemoTrainer
{
    public partial class FormReport : Form
    {
        //private string regexLogFileName = @"Тренировки за (?<Year>[0-9]{4})-(?<Month>[0-9]{2})-(?<Day>[0-9]{2}) на [a-zA-Z].*";


        public FormReport()
        {
            InitializeComponent();

            LoadFormConfiguration();

            FillDateList();
        }

        #region Инициализация.

        private void LoadFormConfiguration()
        {
            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location | ConfigFormOption.Size);

            this.FormClosed += new FormClosedEventHandler(SaveFormConfiguration);
        }

        void SaveFormConfiguration(object sender, FormClosedEventArgs e)
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location | ConfigFormOption.Size);

            ProgramConfiguraton.SaveXmlConfig();
        }

        #endregion Инициализация.

        private void FillDateList()
        {
            Collection<DateTime> result = new Collection<DateTime>();

            DirectoryInfo mainTempDir = new DirectoryInfo(Config.LogFolder);
            if (mainTempDir.Exists)
            {
                FileInfo[] xmlFiles;

                // Получение файлов для Меркурия.
                xmlFiles = mainTempDir.GetFiles(string.Format(LogExercise.searchPattern, "*"), SearchOption.TopDirectoryOnly);
                foreach (FileInfo item in xmlFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(item.FullName);

                    Regex regex = new Regex(LogExercise.regexLogFileName, RegexOptions.ExplicitCapture);
                    if (regex.IsMatch(fileName))
                    {
                        Match match = regex.Match(fileName);
                        DateTime date = new DateTime(Convert.ToInt32(match.Groups["Year"].Value), Convert.ToInt32(match.Groups["Month"].Value), Convert.ToInt32(match.Groups["Day"].Value));

                        if (!result.Contains(date))
                        {
                            result.Add(date);
                        }
                    }
                }
            }

            DateTime[] keys = new DateTime[result.Count];

            for (int i = 0; i < result.Count; i++)
            {
                keys[i] = result[i];
            }

            // Сортируем свойства.
            Array.Sort(keys);

            for (int i = result.Count - 1; i >= 0; i--)
            {
                cLBReportDates.Items.Add(keys[i]);
            }

            DateTime currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            foreach (DateTime date in result)
            {
                DateTime month = new DateTime(date.Year, date.Month, 1);

                if (month != currentMonth && !cBMonth.Items.Contains(month))
                {
                    cBMonth.Items.Add(month);
                }
            }

            if (cBMonth.Items.Count > 0)
            {
                cBMonth.SelectedIndex = 0;
            }
            else
            {
                cBMonth.Enabled = false;
            }
        }

        private void FormReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        #region Отчеты.

        private void btnCreateDayTextReport_Click(object sender, EventArgs e)
        {
            foreach (DateTime item in cLBReportDates.CheckedItems)
            {
                CreateTextReport(item);
            }

            MessageBox.Show(this, "Создание отчетов закончено.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateTextReport(DateTime date)
        {
            StringBuilder sb = new StringBuilder();

            DirectoryInfo mainTempDir = new DirectoryInfo(Config.LogFolder);
            if (mainTempDir.Exists)
            {
                FileInfo[] xmlFiles;

                // Получение файлов для Меркурия.
                xmlFiles = mainTempDir.GetFiles(string.Format(LogExercise.searchPattern, date.ToString("yyyy-MM-dd") + "*"), SearchOption.TopDirectoryOnly);
                foreach (FileInfo file in xmlFiles)
                {
                    Collection<ExerciseSerie> col = LogExercise.CreateSeriesFromFile(file.FullName);

                    foreach (ExerciseSerie item in col)
                    {
                        sb.AppendLine(item.GetDescription(true));

                        sb.AppendLine();
                        sb.AppendLine();
                    }

                    sb.AppendLine();
                    sb.AppendLine();
                }
            }

            if (sb.ToString() != string.Empty)
            {
                string pathFile = Path.Combine(Config.ReportFolder, string.Format("Тренировки за {0}.txt", date.ToString("yyyy-MM-dd")));
                if (!Directory.Exists(Config.ReportFolder))
                {
                    Directory.CreateDirectory(Config.ReportFolder);
                }

                using (StreamWriter sw = File.CreateText(pathFile))
                {
                    sw.Write(sb.ToString());
                }
            }
        }

        #endregion Отчеты.

        #region Создание сетки из xls-файла.

        private void btnCreateNetsFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "(*.xls)|*.xls";
            openDialog.FilterIndex = 0;

            openDialog.RestoreDirectory = true;

            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = openDialog.FileName;

                CreateNetsFileFromFile(fileName);
            }
        }

        private const string xmlNodeNameNets = "Nets";

        private void CreateNetsFileFromFile(string sourceFileName)
        {
            Collection<Net> allNets = CreateNetCollectionFromExcelFile(sourceFileName);

            if (allNets.Count > 0)
            {
                bool netsHaveRepeats = false;
                string message = string.Empty;
                foreach (Net item in allNets)
                {
                    string temp = string.Empty;

                    if (item.HasRepeats(out temp))
                    {
                        netsHaveRepeats = true;

                        message += (!string.IsNullOrEmpty(message) ? "\r\n\r\n" : string.Empty) + string.Format("Сетка {0}:\r\n{1}", item.Name, temp);
                    }
                }

                for (int i = 0; i < allNets.Count; i++)
                {
                    Net net1 = allNets[i];

                    for (int j = i + 1; j < allNets.Count; j++)
                    {
                        Net net2 = allNets[j];

                        string temp = string.Empty;

                        if (Net.HasIntersection(net1, net2, out temp))
                        {
                            netsHaveRepeats = true;

                            message += (!string.IsNullOrEmpty(message) ? "\r\n\r\n" : string.Empty) + temp;
                        }
                    }
                }
                if (netsHaveRepeats)
                {
                    message += "\r\n\r\nПродолжить создание файла сеток?";

                    netsHaveRepeats = MessageBox.Show(this, string.Format("Сетки имеют повторы.\r\n{0}", message), "Ошибки", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) != System.Windows.Forms.DialogResult.OK;

                    if (netsHaveRepeats)
                    {
                        return;
                    }
                }



                XmlDocument netsFile = new XmlDocument();

                netsFile.AppendChild(netsFile.CreateXmlDeclaration("1.0", "utf-8", "yes"));
                netsFile.AppendChild(netsFile.CreateElement(xmlNodeNameNets));

                XmlNode root = netsFile[xmlNodeNameNets];

                foreach (Net item in allNets)
                {
                    XmlNode node = item.CreateNode(netsFile);

                    root.AppendChild(node);
                }

                string targetFile = Net.NetsFileName;

                //if (File.Exists(targetFile))
                //{
                //    File.Delete(targetFile);
                //}

                netsFile.Save(targetFile);

                MessageBox.Show(this, "Сетки сформированы.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show(this, "Сетки не сформированы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Collection<Net> CreateNetCollectionFromExcelFile(string sourceFileName)
        {
            Collection<Net> result = new Collection<Net>();

            Excel.Application excelapp = new Excel.Application();

            if (excelapp != null)
            {
                excelapp.Visible = false;

                excelapp.Workbooks.Open(sourceFileName, Type.Missing, true);

                Excel.Workbook workBook = excelapp.Workbooks[1];

                Excel.Worksheet workSheet = null;

                foreach (Excel.Worksheet item in workBook.Sheets)
                {
                    if (item.Name == "Цифровой алфавит")
                    {
                        workSheet = item;
                        break;
                    }
                }

                int col = 1, row = 2;

                Net net;

                net = new Net("Цифровой алфавит");
                for (int i = 0; i < 10; i++)
                {
                    Excel.Range cellNumber = (Excel.Range)workSheet.Cells[row + i, col];
                    Excel.Range cellPattern = (Excel.Range)workSheet.Cells[row + i, col + 1];

                    if (cellNumber != null && cellPattern != null && cellNumber.Value2 != null && cellPattern.Value2 != null)
                    {
                        string numberString = cellNumber.Value2.ToString();
                        string pattern = cellPattern.Value2.ToString();

                        if (!string.IsNullOrEmpty(numberString) && !string.IsNullOrEmpty(pattern))
                        {
                            int temp = 0;
                            if (int.TryParse(numberString, out temp))
                            {
                                NetUnit unit = new NetUnit(numberString, pattern, net.Name);

                                net.Units.Add(unit);
                            }
                        }
                    }
                }

                if (net.Units.Count > 0)
                {
                    result.Add(net);
                }


                net = new Net("Цифровые цвета");
                for (int i = 0; i < 10; i++)
                {
                    Excel.Range cellNumber = (Excel.Range)workSheet.Cells[row + i, col];
                    Excel.Range cellPattern = (Excel.Range)workSheet.Cells[row + i, col + 2];

                    if (cellNumber != null && cellPattern != null && cellNumber.Value2 != null && cellPattern.Value2 != null)
                    {
                        string numberString = cellNumber.Value2.ToString();
                        string pattern = cellPattern.Value2.ToString();

                        if (!string.IsNullOrEmpty(numberString) && !string.IsNullOrEmpty(pattern))
                        {
                            int temp = 0;
                            if (int.TryParse(numberString, out temp))
                            {
                                Excel.Range cellColor = (Excel.Range)workSheet.Cells[row + i, col + 3];

                                if (cellColor != null && cellColor.Value2 != null)
                                {
                                    string colorName = cellColor.Value2.ToString();

                                    NetUnit unit;

                                    if (!string.IsNullOrEmpty(colorName))
                                    {
                                        unit = new NetUnit(numberString, pattern, net.Name, Color.FromName(colorName));
                                    }
                                    else
                                    {
                                        unit = new NetUnit(numberString, pattern, net.Name);
                                    }

                                    net.Units.Add(unit);
                                }
                            }
                        }
                    }
                }

                if (net.Units.Count > 0)
                {
                    result.Add(net);
                }



                foreach (Excel.Worksheet item in workBook.Sheets)
                {
                    if (item.Name == "Итоговые")
                    {
                        workSheet = item;
                        break;
                    }
                }

                row = 2;
                col = 2;

                Excel.Range rangeTitle = (Excel.Range)workSheet.Cells[row - 1, col];
                while (rangeTitle != null && rangeTitle.Value2 != null)
                {
                    string netName = rangeTitle.Value2.ToString();
                    if (!string.IsNullOrEmpty(netName))
                    {
                        net = new Net(netName);

                        for (int i = 0; i < 110; i++)
                        {
                            Excel.Range cellNumber = (Excel.Range)workSheet.Cells[row + i, 1];
                            Excel.Range cellPattern = (Excel.Range)workSheet.Cells[row + i, col];

                            if (cellNumber != null && cellPattern != null && cellNumber.Value2 != null && cellPattern.Value2 != null)
                            {
                                string numberString = cellNumber.Value2.ToString();
                                string pattern = cellPattern.Value2.ToString();

                                if (!string.IsNullOrEmpty(numberString) && !string.IsNullOrEmpty(pattern))
                                {
                                    int temp = 0;
                                    if (int.TryParse(numberString, out temp))
                                    {
                                        NetUnit unit = new NetUnit(numberString, pattern, net.Name);
                                        net.Units.Add(unit);
                                    }
                                }
                            }
                        }

                        if (net.Units.Count > 0)
                        {
                            result.Add(net);
                        }

                        col++;
                        rangeTitle = (Excel.Range)workSheet.Cells[row - 1, col];
                    }
                }

                excelapp.Quit();
            }

            return result;
        }

        #endregion Создание сетки из xls-файла.
    }
}
