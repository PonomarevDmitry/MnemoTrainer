using System;
using System.Collections;
using System.IO;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Train
{
    public class TrainMachine100For100
    {
        #region Поля

        private int selectedSource = -1;
        public int SelectedSource
        {
            get { return this.selectedSource; }
            set
            {
                if (value == -1)
                {
                    if (this.selectedSource != value)
                    {
                        this.Stop();
                    }

                    this.selectedSource = value;
                }
                else
                {
                    if (value >= 0 && value < this.sourcesFile.Length)
                    {
                        if (this.selectedSource != value)
                        {
                            this.Stop();
                        }

                        this.selectedSource = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        public bool IsFileSource
        {
            get { return this.selectedSource != -1; }
        }

        private FileInfo[] sourcesFile = new FileInfo[0];
        public FileInfo[] SourcesFile
        {
            get { return this.sourcesFile; }
        }

        private bool randomOrder = false;
        /// <summary>
        /// Случайный порядок
        /// </summary>
        public bool RandomOrder
        {
            get { return this.randomOrder; }
            set
            {
                if (this.selectedSource != -1 && this.randomOrder != value)
                {
                    this.Stop();
                }

                this.randomOrder = value;
            }
        }

        private MachineStatus status = MachineStatus.NotStarted;
        /// <summary>
        /// Статус.
        /// </summary>
        public MachineStatus Status
        {
            get { return this.status; }
        }

        private int currentIndex = 0;
        private ArrayList dictionary = new ArrayList();

        public int CurrentIndex
        {
            get { return this.currentIndex + 1; }
        }

        public string Element
        {
            get
            {
                string result = string.Empty;

                if (this.selectedSource == -1)
                {
                    result = (this.currentIndex + 1).ToString();
                }
                else
                {
                    result = (string)this.dictionary[this.currentIndex];
                }

                return result;
            }
        }

        #endregion Поля

        public TrainMachine100For100()
        {
            RefreshSourcesFiles();
        }

        #region События

        public event EventHandler StartTest;

        public event EventHandler StopTest;

        public event EventHandler NextElement;

        protected void OnStartTest(EventArgs args)
        {
            if (StartTest != null)
            {
                StartTest(this, args);
            }
        }

        protected void OnStopTest(EventArgs args)
        {
            if (StopTest != null)
            {
                StopTest(this, args);
            }
        }

        protected void OnNextElement(EventArgs args)
        {
            if (NextElement != null)
            {
                NextElement(this, args);
            }
        }

        #endregion События

        #region Методы

        public void ShowNextNumber()
        {
            if (this.status == MachineStatus.NotStarted)
            {
                this.status = MachineStatus.ShowingQuestion;
                this.currentIndex = -1;

                if (this.selectedSource != -1)
                {
                    OperationList(this.sourcesFile[this.selectedSource]);
                }

                OnStartTest(new EventArgs());
            }

            currentIndex++;

            if (this.selectedSource != -1 && this.currentIndex >= this.dictionary.Count)
            {
                this.Stop();
            }
            else
            {
                OnNextElement(new EventArgs());
            }
        }

        private void OperationList(FileInfo fileInfo)
        {
            ArrayList list = WordDictionary.GetWordsFromFile(fileInfo.FullName);

            if (this.randomOrder)
            {
                this.dictionary = new ArrayList();

                Random rnd = new Random();

                while (list.Count > 0)
                {
                    int index = rnd.Next(list.Count);

                    this.dictionary.Add(list[index]);

                    list.RemoveAt(index);
                }
            }
            else
            {
                this.dictionary = list;
            }
        }

        public void Stop()
        {
            if (this.status != MachineStatus.NotStarted)
            {
                this.status = MachineStatus.NotStarted;
                OnStopTest(new EventArgs());
            }
        }

        public void RefreshSourcesFiles()
        {
            DirectoryInfo mainDir = new DirectoryInfo(Config.Train100For100Folder);
            if (mainDir.Exists)
            {
                FileInfo[] files = mainDir.GetFiles("*.txt");

                this.sourcesFile = files;
            }
        }

        #endregion Методы
    }
}
