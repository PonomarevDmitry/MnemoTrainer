using System;
using System.Collections.ObjectModel;
using System.Xml;
using SAClasses.Interators;

namespace SAClasses
{
    public class Controller
    {
        #region Свойства.

        private const int maxHistoryElement = 45;
        public Collection<PoemLine> HistoryPreviousLines { get; private set; }
        public Collection<PoemLine> HistoryNextLines { get; private set; }

        private int selectedLinesCount = 10;
        public int SelectedLinesCount
        {
            get { return this.selectedLinesCount; }
            set
            {
                if (value > 0)
                {
                    this.selectedLinesCount = value;

                    bool hasChanged = false;

                    while (selectedLines.Count > selectedLinesCount)
                    {
                        selectedLines.RemoveAt(0);

                        hasChanged = true;
                    }

                    if (hasChanged)
                    {
                        OnCurrentLineChanged();
                    }
                }
            }
        }

        private Collection<PoemLine> selectedLines = new Collection<PoemLine>();
        public Collection<PoemLine> SelectedLines { get { return this.selectedLines; } }

        public PoemLine CurrentLine
        {
            get
            {
                if (selectedLines.Count > 0)
                {
                    return selectedLines[selectedLines.Count - 1];
                }

                return null;
            }
        }

        private IteratorSA mySAIterator = new IteratorSA();

        private SA systemAccumulation = null;
        public SA SystemAccumulation
        {
            get { return this.systemAccumulation; }
            set
            {
                this.systemAccumulation = value;

                this.Clear();

                OnCurrentSAChanged();
            }
        }

        #endregion Свойства.

        #region События.

        public event EventHandler HistoryChanged;

        protected void OnHistoryChanged()
        {
            if (HistoryChanged != null)
            {
                HistoryChanged(this, new EventArgs());
            }
        }

        public event EventHandler CurrentLineChanged;

        protected void OnCurrentLineChanged()
        {
            if (CurrentLineChanged != null)
            {
                CurrentLineChanged(this, new EventArgs());
            }
        }

        public event EventHandler CurrentSAChanged;

        protected void OnCurrentSAChanged()
        {
            if (CurrentSAChanged != null)
            {
                CurrentSAChanged(this, new EventArgs());
            }
        }

        #endregion События.

        public Controller()
        {
            HistoryPreviousLines = new Collection<PoemLine>();
            HistoryNextLines = new Collection<PoemLine>();
        }

        #region Получение случайных строк.

        #region Строки.

        public void GetRandomLine()
        {
            PoemLine result = null;

            if (systemAccumulation != null)
            {
                int lineCount = systemAccumulation.LinesCount;

                int randomIndex = CommonOperations.rnd.Next(lineCount);

                result = systemAccumulation.GetLineByIndex(randomIndex);
            }

            SetOneLine(result);
        }

        public void GetRandomLine(SABlock block)
        {
            PoemLine result = null;

            if (block != null)
            {
                int lineCount = block.LinesCount;

                int randomIndex = CommonOperations.rnd.Next(lineCount);

                result = block.GetLineByIndex(randomIndex);
            }

            SetOneLine(result);
        }

        public void GetRandomLine(SABlockPart blockPart)
        {
            PoemLine result = null;

            if (blockPart != null)
            {
                int lineCount = blockPart.LinesCount;

                int randomIndex = CommonOperations.rnd.Next(lineCount);

                result = blockPart.GetLineByIndex(randomIndex);
            }

            SetOneLine(result);
        }

        public void GetRandomLine(Poem poem)
        {
            PoemLine result = null;

            if (poem != null)
            {
                int lineCount = poem.LinesCount;

                int randomIndex = CommonOperations.rnd.Next(lineCount);

                result = poem.GetLineByIndex(randomIndex);
            }

            SetOneLine(result);
        }

        public void GetRandomLine(PoemPart poemPart)
        {
            PoemLine result = null;

            if (poemPart != null)
            {
                int lineCount = poemPart.LinesCount;

                int randomIndex = CommonOperations.rnd.Next(lineCount);

                result = poemPart.GetLineByIndex(randomIndex);
            }

            SetOneLine(result);
        }

        #endregion Строки.

        #region Части стихов.

        public void GetRandomPoemPart(Poem poem)
        {
            PoemLine result = null;

            if (poem != null && poem.Parts.Count > 0)
            {
                int partsCount = poem.Parts.Count;

                int randomIndex = CommonOperations.rnd.Next(partsCount);

                PoemPart poemPart = poem.Parts[randomIndex];

                result = poemPart.GetFirstLine();
            }

            SetOneLine(result);
        }

        #endregion Части стихов.

        #region Стихи.

        public void GetRandomPoem()
        {
            PoemLine result = null;

            if (systemAccumulation != null)
            {
                int poemCount = systemAccumulation.PoemCount;

                int randomPoemIndex = CommonOperations.rnd.Next(poemCount);

                Poem randomPoem = systemAccumulation.GetPoemByIndex(randomPoemIndex);

                result = randomPoem.GetFirstLine();
            }

            SetOneLine(result);
        }

        public void GetRandomPoem(SABlock block)
        {
            PoemLine result = null;

            if (block != null)
            {
                int poemCount = block.PoemCount;

                int randomPoemIndex = CommonOperations.rnd.Next(poemCount);

                Poem randomPoem = block.GetPoemByIndex(randomPoemIndex);

                result = randomPoem.GetFirstLine();
            }

            SetOneLine(result);
        }

        public void GetRandomPoem(SABlockPart blockPart)
        {
            PoemLine result = null;

            if (blockPart != null)
            {
                int poemCount = blockPart.PoemCount;

                int randomPoemIndex = CommonOperations.rnd.Next(poemCount);

                Poem randomPoem = blockPart.GetPoemByIndex(randomPoemIndex);

                result = randomPoem.GetFirstLine();
            }

            SetOneLine(result);
        }

        #endregion Стихи.

        #region Части блоков.

        public void GetRandomBlockPart(SABlock block)
        {
            PoemLine result = null;

            if (block != null && block.Parts.Count > 0)
            {
                int partsCount = block.Parts.Count;

                int randomIndex = CommonOperations.rnd.Next(partsCount);

                SABlockPart blockPart = block.Parts[randomIndex];

                result = blockPart.GetFirstLine();
            }

            SetOneLine(result);
        }

        #endregion Части блоков.

        #region Блоки.

        public void GetRandomBlock()
        {
            PoemLine result = null;

            if (systemAccumulation != null)
            {
                int blockCount = systemAccumulation.Blocks.Count;

                int randomIndex = CommonOperations.rnd.Next(blockCount);

                SABlock block = systemAccumulation.Blocks[randomIndex];

                result = block.GetFirstLine();
            }

            SetOneLine(result);
        }

        #endregion Блоки.

        #endregion Получение случайных строк.

        #region Перемещение по строкам.

        public void GoLineNext()
        {
            PoemLine curLine = this.CurrentLine;

            if (systemAccumulation != null)
            {
                if (curLine == null)
                {
                    curLine = systemAccumulation.GetFirstLine();
                }
                else
                {
                    curLine = this.mySAIterator.GetNextLine(curLine, true);
                }
            }

            if (curLine != null)
            {
                selectedLines.Add(curLine);
            }

            //this.HistoryNextLines.Clear();
            //OnHistoryChanged();

            while (selectedLines.Count > selectedLinesCount)
            {
                selectedLines.RemoveAt(0);
            }

            OnCurrentLineChanged();
        }

        public void GoLinePrevious()
        {
            PoemLine curLine = null;

            if (selectedLines.Count > 0)
            {
                curLine = selectedLines[0];
                selectedLines.RemoveAt(selectedLines.Count - 1);
            }

            if (systemAccumulation != null)
            {
                if (curLine == null)
                {
                    curLine = systemAccumulation.GetLastLine();
                }
                else
                {
                    curLine = this.mySAIterator.GetNextLine(curLine, false);
                }
            }

            if (curLine != null)
            {
                selectedLines.Insert(0, curLine);
            }

            HistoryNextLines.Clear();

            while (selectedLines.Count > selectedLinesCount)
            {
                selectedLines.RemoveAt(selectedLines.Count - 1);
            }

            OnCurrentLineChanged();
        }

        #endregion Перемещение по строкам.

        #region Перемещение по частям стихов.

        public void GoPoemPartNext()
        {
            PoemLine result = this.CurrentLine;

            if (systemAccumulation != null)
            {
                if (result == null)
                {
                    result = systemAccumulation.GetFirstLine();
                }
                else
                {
                    result = this.GenerateNextPoemPart(result, true);
                }
            }

            SetOneLine(result);
        }

        public void GoPoemPartPrevious()
        {
            PoemLine result = this.CurrentLine;

            if (SystemAccumulation != null)
            {
                if (result == null)
                {
                    result = SystemAccumulation.GetLastLine();
                }
                else
                {
                    result = this.GenerateNextPoemPart(result, false);
                }
            }

            SetOneLine(result);
        }

        public void GoPoemPartBegining()
        {
            PoemLine curLine = this.CurrentLine;

            if (systemAccumulation != null)
            {
                if (curLine == null)
                {
                    curLine = systemAccumulation.GetFirstLine();

                    SetOneLine(curLine);
                }
                else
                {
                    PoemPart curPoemPart = curLine.ParentPoemPart;
                    Poem curPoem = curLine.ParentPoem;

                    if (curPoemPart != null)
                    {
                        bool isFirstLine = curPoemPart.IsFirstLine(curLine);

                        if (!isFirstLine)
                        {
                            SetOneLine(curPoemPart.GetFirstLine());
                        }
                    }
                    else
                    {
                        bool isFirstLine = curPoem.IsFirstLine(curLine);

                        if (!isFirstLine)
                        {
                            SetOneLine(curPoem.GetFirstLine());
                        }
                    }
                }
            }
        }

        private PoemLine GenerateNextPoemPart(PoemLine currentLine, bool forward)
        {
            if (currentLine.ParentPoemPart != null)
            {
                PoemPart nextPoemPart = this.mySAIterator.GetNextPoemPart(currentLine.ParentPoemPart, forward);

                if (nextPoemPart != null)
                {
                    return nextPoemPart.GetFirstLine();
                }
            }

            return GenerateNextPoem(currentLine, forward);
        }

        #endregion Перемещение по частям стихов.

        #region Перемещение по стихам.

        public void GoPoemNext()
        {
            PoemLine curLine = this.CurrentLine;

            if (systemAccumulation != null)
            {
                if (curLine == null)
                {
                    curLine = systemAccumulation.GetFirstLine();
                }
                else
                {
                    curLine = this.GenerateNextPoem(curLine, true);
                }
            }

            SetOneLine(curLine);
        }

        public void GoPoemPreviousOrBegining()
        {
            PoemLine curLine = this.CurrentLine;

            if (systemAccumulation != null)
            {
                if (curLine == null)
                {
                    curLine = systemAccumulation.GetLastLine();
                }
                else
                {
                    bool isFirstLine = curLine.ParentPoem.IsFirstLine(curLine);

                    if (!isFirstLine)
                    {
                        curLine = curLine.ParentPoem.GetFirstLine();
                    }
                    else
                    {
                        curLine = this.GenerateNextPoem(curLine, false);
                    }
                }
            }

            SetOneLine(curLine);
        }

        public void GoPoemPrevious()
        {
            PoemLine curLine = this.CurrentLine;

            if (systemAccumulation != null)
            {
                if (curLine == null)
                {
                    curLine = systemAccumulation.GetLastLine();
                }
                else
                {
                    curLine = this.GenerateNextPoem(curLine, false);
                }
            }

            SetOneLine(curLine);
        }

        public void GoPoemBegining()
        {
            PoemLine curLine = this.CurrentLine;

            if (systemAccumulation != null)
            {
                if (curLine == null)
                {
                    curLine = systemAccumulation.GetFirstLine();

                    SetOneLine(curLine);
                }
                else
                {
                    Poem curPoem = curLine.ParentPoem;

                    bool isFirstLine = curPoem.IsFirstLine(curLine);

                    if (!isFirstLine)
                    {
                        SetOneLine(curPoem.GetFirstLine());
                    }
                }
            }
        }

        private PoemLine GenerateNextPoem(PoemLine currentLine, bool forward)
        {
            Poem nextPoem = this.mySAIterator.GetNextPoem(currentLine.ParentPoem, forward);
            return nextPoem.GetFirstLine();
        }

        #endregion Перемещение по стихам.

        #region Перемещение по частям блоков.

        public void GoBlockPartNext()
        {
            PoemLine curLine = this.CurrentLine;

            if (systemAccumulation != null)
            {
                if (curLine == null)
                {
                    curLine = systemAccumulation.GetFirstLine();
                }
                else
                {
                    curLine = this.GenerateNextBlockPart(curLine, true);
                }
            }

            SetOneLine(curLine);
        }

        public void GoBlockPartPrevious()
        {
            PoemLine curLine = this.CurrentLine;

            if (systemAccumulation != null)
            {
                if (curLine == null)
                {
                    curLine = systemAccumulation.GetLastLine();
                }
                else
                {
                    curLine = this.GenerateNextBlockPart(curLine, false);
                }
            }

            SetOneLine(curLine);
        }

        public void GoBlockPartBegining()
        {
            PoemLine curLine = this.CurrentLine;

            if (systemAccumulation != null)
            {
                if (curLine == null)
                {
                    curLine = systemAccumulation.GetFirstLine();

                    SetOneLine(curLine);
                }
                else
                {
                    SABlockPart curBlockPart = curLine.ParentPoem.ParentBlockPart;
                    SABlock curBlock = curLine.ParentPoem.ParentBlock;

                    if (curBlockPart != null)
                    {
                        bool isFirstLine = curBlockPart.IsFirstLine(curLine);

                        if (!isFirstLine)
                        {
                            SetOneLine(curBlockPart.GetFirstLine());
                        }
                    }
                    else
                    {
                        bool isFirstLine = curBlock.IsFirstLine(curLine);

                        if (!isFirstLine)
                        {
                            SetOneLine(curBlock.GetFirstLine());
                        }
                    }
                }
            }
        }

        private PoemLine GenerateNextBlockPart(PoemLine currentLine, bool forward)
        {
            if (currentLine.ParentPoem.ParentBlockPart != null)
            {
                SABlockPart nextPart = this.mySAIterator.GetNextBlockPart(currentLine.ParentPoem.ParentBlockPart, forward);
                if (nextPart != null)
                {
                    return nextPart.GetFirstLine();
                }
            }

            return GenerateNextBlock(currentLine, forward);
        }

        #endregion Перемещение по частям блоков.

        #region Перемещение по частям блоков.

        public void GoBlockNext()
        {
            PoemLine curLine = this.CurrentLine;

            if (systemAccumulation != null)
            {
                if (curLine == null)
                {
                    curLine = systemAccumulation.GetFirstLine();
                }
                else
                {
                    curLine = this.GenerateNextBlock(curLine, true);
                }
            }

            SetOneLine(curLine);
        }

        public void GoBlockPreviousOrBegining()
        {
            PoemLine curLine = this.CurrentLine;

            if (systemAccumulation != null)
            {
                if (curLine == null)
                {
                    curLine = systemAccumulation.GetLastLine();
                }
                else
                {
                    bool isFirstLine = curLine.ParentPoem.ParentBlock.IsFirstLine(curLine);

                    if (!isFirstLine)
                    {
                        curLine = curLine.ParentPoem.ParentBlock.GetFirstLine();
                    }
                    else
                    {
                        curLine = this.GenerateNextBlock(curLine, false);
                    }
                }
            }

            SetOneLine(curLine);
        }

        public void GoBlockPrevious()
        {
            PoemLine curLine = this.CurrentLine;

            if (systemAccumulation != null)
            {
                if (curLine == null)
                {
                    curLine = systemAccumulation.GetLastLine();
                }
                else
                {
                    curLine = this.GenerateNextBlock(curLine, false);
                }
            }

            SetOneLine(curLine);
        }

        public void GoBlockBegining()
        {
            PoemLine curLine = this.CurrentLine;

            if (systemAccumulation != null)
            {
                if (curLine == null)
                {
                    curLine = systemAccumulation.GetFirstLine();

                    SetOneLine(curLine);
                }
                else
                {
                    SABlock curBlock = curLine.ParentPoem.ParentBlock;

                    bool isFirstLine = curBlock.IsFirstLine(curLine);

                    if (!isFirstLine)
                    {
                        SetOneLine(curBlock.GetFirstLine());
                    }
                }
            }
        }

        private PoemLine GenerateNextBlock(PoemLine currentLine, bool forward)
        {
            SABlock nextBlock = this.mySAIterator.GetNextBlock(currentLine.ParentPoem.ParentBlock, forward);
            return nextBlock.GetFirstLine();
        }

        #endregion Перемещение по частям блоков.

        #region Перемещение по истории.

        public void MoveHistoryPreviousLine()
        {
            if (CanMoveHistoryPreviousLine)
            {
                PoemLine curLine = this.CurrentLine;
                PoemLine line = HistoryPreviousLines[0];

                selectedLines.Clear();
                selectedLines.Add(line);

                HistoryPreviousLines.RemoveAt(0);

                if (curLine != null)
                {
                    HistoryNextLines.Insert(0, curLine);
                }

                OnHistoryChanged();
                OnCurrentLineChanged();
            }
        }

        public void MoveHistoryPreviousLineByIndex(int itemIndex)
        {
            if (CanMoveHistoryPreviousLine)
            {
                PoemLine curLine = this.CurrentLine;
                if (curLine != null)
                {
                    HistoryNextLines.Insert(0, curLine);
                }

                for (int index = 0; index < itemIndex; index++)
                {
                    HistoryNextLines.Insert(0, HistoryPreviousLines[index]);
                }

                for (int i = 0; i < itemIndex; i++)
                {
                    HistoryPreviousLines.RemoveAt(0);
                }

                PoemLine line = HistoryPreviousLines[0];

                selectedLines.Clear();
                selectedLines.Add(line);

                HistoryPreviousLines.RemoveAt(0);

                OnHistoryChanged();
                OnCurrentLineChanged();
            }
        }

        public void MoveHistoryNextLine()
        {
            if (CanMoveHistoryNextLine)
            {
                PoemLine curLine = this.CurrentLine;
                PoemLine line = HistoryNextLines[0];

                selectedLines.Clear();
                selectedLines.Add(line);

                if (curLine != null)
                {
                    HistoryPreviousLines.Insert(0, curLine);

                    while (HistoryPreviousLines.Count > maxHistoryElement)
                    {
                        HistoryPreviousLines.RemoveAt(HistoryPreviousLines.Count - 1);
                    }
                }

                HistoryNextLines.RemoveAt(0);

                OnHistoryChanged();
                OnCurrentLineChanged();
            }
        }

        public void MoveHistoryNextLineByIndex(int itemIndex)
        {
            if (CanMoveHistoryNextLine)
            {
                PoemLine curLine = this.CurrentLine;

                if (curLine != null)
                {
                    HistoryPreviousLines.Insert(0, curLine);
                }

                for (int index = 0; index < itemIndex; index++)
                {
                    HistoryPreviousLines.Insert(0, HistoryNextLines[index]);
                }

                for (int i = 0; i < itemIndex; i++)
                {
                    HistoryNextLines.RemoveAt(0);
                }

                while (HistoryPreviousLines.Count > maxHistoryElement)
                {
                    HistoryPreviousLines.RemoveAt(HistoryPreviousLines.Count - 1);
                }

                PoemLine line = HistoryNextLines[0];

                selectedLines.Clear();
                selectedLines.Add(line);

                HistoryNextLines.RemoveAt(0);

                OnHistoryChanged();
                OnCurrentLineChanged();
            }
        }

        public bool CanMoveHistoryPreviousLine
        {
            get
            {
                return this.HistoryPreviousLines.Count > 0;
            }
        }

        public bool CanMoveHistoryNextLine
        {
            get
            {
                return this.HistoryNextLines.Count > 0;
            }
        }

        #endregion Перемещение по истории.

        #region Текущая позиция.

        private void SetOneLine(PoemLine line)
        {
            PoemLine curLine = this.CurrentLine;

            selectedLines.Clear();

            if (line != null)
            {
                selectedLines.Add(line);

                if (curLine != null && curLine != line)
                {
                    HistoryPreviousLines.Insert(0, curLine);
                    HistoryNextLines.Clear();

                    while (HistoryPreviousLines.Count > maxHistoryElement)
                    {
                        HistoryPreviousLines.RemoveAt(HistoryPreviousLines.Count - 1);
                    }
                }
            }

            OnHistoryChanged();
            OnCurrentLineChanged();
        }

        public void SetCurrentLine(SABlock block)
        {
            PoemLine line = block.GetFirstLine();

            if (CurrentLine != line)
            {
                SetOneLine(line);
            }
        }

        public void SetCurrentLine(SABlockPart blockPart)
        {
            PoemLine line = blockPart.GetFirstLine();

            if (CurrentLine != line)
            {
                SetOneLine(line);
            }
        }

        public void SetCurrentLine(Poem poem)
        {
            PoemLine line = poem.GetFirstLine();

            if (CurrentLine != line)
            {
                SetOneLine(line);
            }
        }

        public void SetCurrentLine(PoemPart poemPart)
        {
            PoemLine line = poemPart.GetFirstLine();

            if (CurrentLine != line)
            {
                SetOneLine(line);
            }
        }

        public void SetCurrentLine(PoemLine line)
        {
            if (CurrentLine != line)
            {
                SetOneLine(line);
            }
        }

        public void ClearHistory()
        {
            HistoryNextLines.Clear();
            HistoryPreviousLines.Clear();

            OnHistoryChanged();
        }

        public void Clear()
        {
            this.ClearHistory();

            selectedLines.Clear();
            OnCurrentLineChanged();
        }

        public PoemLineIdentifier GetCurrentLineID()
        {
            PoemLine curLine = this.CurrentLine;

            if (curLine != null)
            {
                return curLine.GetID();
            }

            return null;
        }

        public void SetCurrentLineByID(PoemLineIdentifier curLine)
        {
            PoemLine line = systemAccumulation.GetLineByID(curLine);

            if (line != null)
            {
                SetOneLine(line);
            }
        }

        #endregion Текущая позиция.

        #region Сохранение настроек.

        public const string objName = "ControllerConfiguration";

        private const string objCurrentPosition = "CurrentPosition";

        private const string objSelectedLines = "SelectedLines";
        private const string objHistoryPreviousLines = "PreviousLines";
        private const string objHistoryNextLines = "NextLines";

        //public void SaveConfiguration(string fileName)
        //{
        //    XmlDocument xmlFile = new XmlDocument();

        //    xmlFile.AppendChild(xmlFile.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        //    XmlNode root = CreateXmlNode(xmlFile);
        //    xmlFile.AppendChild(root);

        //    xmlFile.Save(fileName);
        //}

        public XmlNode CreateXmlNode(XmlDocument xmlFile)
        {
            XmlNode nodeControllerConfig = xmlFile.CreateElement(objName);

            //{
            //    PoemLine curLine = this.CurrentLine;

            //    if (curLine != null)
            //    {
            //        PoemLineIdentifier lineId = curLine.GetID();

            //        if (lineId != null)
            //        {
            //            XmlNode nodeCurrentPosition = xmlFile.CreateElement(objCurrentPosition);
            //            nodeControllerConfig.AppendChild(nodeCurrentPosition);

            //            nodeCurrentPosition.AppendChild(lineId.CreateNode(xmlFile));
            //        }
            //    }
            //}

            {
                XmlNode nodeSelectedLines = xmlFile.CreateElement(objSelectedLines);
                nodeControllerConfig.AppendChild(nodeSelectedLines);

                foreach (PoemLine line in this.selectedLines)
                {
                    PoemLineIdentifier lineId = line.GetID();
                    if (lineId != null)
                    {
                        nodeSelectedLines.AppendChild(lineId.CreateNode(xmlFile));
                    }
                }
            }

            {
                XmlNode nodePreviousLines = xmlFile.CreateElement(objHistoryPreviousLines);
                nodeControllerConfig.AppendChild(nodePreviousLines);

                foreach (PoemLine line in this.HistoryPreviousLines)
                {
                    PoemLineIdentifier lineId = line.GetID();
                    if (lineId != null)
                    {
                        nodePreviousLines.AppendChild(lineId.CreateNode(xmlFile));
                    }
                }
            }

            {
                XmlNode nodeNextLines = xmlFile.CreateElement(objHistoryNextLines);
                nodeControllerConfig.AppendChild(nodeNextLines);

                foreach (PoemLine line in this.HistoryNextLines)
                {
                    PoemLineIdentifier lineId = line.GetID();
                    if (lineId != null)
                    {
                        nodeNextLines.AppendChild(lineId.CreateNode(xmlFile));
                    }
                }
            }

            return nodeControllerConfig;
        }

        //public void LoadConfigurationFromFile(string fileName)
        //{
        //    if (!File.Exists(fileName))
        //    {
        //        return;
        //    }

        //    XmlDocument saXmlFile = new XmlDocument();
        //    saXmlFile.Load(fileName);

        //    XmlNode node = saXmlFile[objName];

        //    if (node != null)
        //    {
        //        LoadConfigurationFromNode(node);
        //    }
        //}

        public void LoadConfigurationFromNode(XmlNode nodeControllerConfig)
        {
            //{
            //    XmlNode nodeCurrentPosition = nodeControllerConfig[objCurrentPosition];

            //    if (nodeCurrentPosition != null && nodeCurrentPosition.ChildNodes.Count == 1)
            //    {
            //        PoemLineIdentifier lineId = PoemLineIdentifier.CreateFromXmlNode(nodeCurrentPosition.ChildNodes[0]);

            //        PoemLine line = systemAccumulation.GetLineByID(lineId);

            //        if (line != null)
            //        {
            //            selectedLines.Clear();
            //            selectedLines.Add(line);
            //        }
            //    }
            //}

            {
                this.selectedLines.Clear();

                XmlNode nodeSelectedLines = nodeControllerConfig[objSelectedLines];

                if (nodeSelectedLines != null)
                {
                    foreach (XmlNode node in nodeSelectedLines)
                    {
                        PoemLineIdentifier lineId = PoemLineIdentifier.CreateFromXmlNode(node);

                        if (lineId != null)
                        {
                            PoemLine line = systemAccumulation.GetLineByID(lineId);

                            if (line != null)
                            {
                                bool addLine = true;

                                if (this.selectedLines.Count > 0)
                                {
                                    PoemLine lastLine = selectedLines[selectedLines.Count - 1];

                                    PoemLine nextLine = mySAIterator.GetNextLine(lastLine, true);

                                    addLine = nextLine == line;
                                }
                                else
                                {
                                    addLine = true;
                                }

                                if (addLine)
                                {
                                    this.selectedLines.Add(line);
                                }
                            }
                        }
                    }
                }

                while (this.selectedLines.Count > this.selectedLinesCount)
                {
                    this.selectedLines.RemoveAt(0);
                }
            }

            {
                this.HistoryPreviousLines.Clear();

                XmlNode nodePreviousLines = nodeControllerConfig[objHistoryPreviousLines];

                if (nodePreviousLines != null)
                {
                    foreach (XmlNode node in nodePreviousLines)
                    {
                        PoemLineIdentifier lineId = PoemLineIdentifier.CreateFromXmlNode(node);

                        if (lineId != null)
                        {
                            PoemLine line = systemAccumulation.GetLineByID(lineId);

                            if (line != null)
                            {
                                this.HistoryPreviousLines.Add(line);
                            }
                        }
                    }
                }

                while (HistoryPreviousLines.Count > maxHistoryElement)
                {
                    HistoryPreviousLines.RemoveAt(HistoryPreviousLines.Count - 1);
                }
            }

            {
                this.HistoryNextLines.Clear();

                XmlNode nodeNextLines = nodeControllerConfig[objHistoryNextLines];

                if (nodeNextLines != null)
                {
                    foreach (XmlNode node in nodeNextLines)
                    {
                        PoemLineIdentifier lineId = PoemLineIdentifier.CreateFromXmlNode(node);

                        if (lineId != null)
                        {
                            PoemLine line = systemAccumulation.GetLineByID(lineId);

                            if (line != null)
                            {
                                this.HistoryNextLines.Add(line);
                            }
                        }
                    }
                }
            }

            OnCurrentLineChanged();
            OnHistoryChanged();
        }

        #endregion Сохранение настроек.
    }
}
