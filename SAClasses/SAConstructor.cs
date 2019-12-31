using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SAClasses
{
    public static class SAConstructor
    {
        public static SA CreateSAFromRFTFiles(DirectoryInfo directory)
        {
            SA result = new SA();
            result.Name = "Система Накопления";

            if (directory.Exists)
            {
                FileInfo[] files = directory.GetFiles("*.rtf");

                Collection<FileInfo> selectedFiles = new Collection<FileInfo>();

                foreach (FileInfo itemFile in files)
                {
                    if (!itemFile.Name.StartsWith("!") && !itemFile.Name.StartsWith("~"))
                    {
                        selectedFiles.Add(itemFile);
                    }
                }

                if (selectedFiles.Count > 0)
                {
                    Collection<SABlock> blocks = GetBlocksFromRTFFiles(selectedFiles);

                    foreach (SABlock itemBlock in blocks)
                    {
                        if (itemBlock != null && (itemBlock.Poems.Count > 0 || itemBlock.Parts.Count > 0))
                        {
                            result.Blocks.Add(itemBlock);
                        }
                    }
                }
            }

            return result;
        }

        public static SA CreateSAFromSingleRtfFile(string fileName)
        {
            SA result = new SA();
            result.Name = "Система Накопления";

            FileInfo file = new FileInfo(fileName);

            if (file.Exists)
            {
                Collection<FileInfo> selectedFiles = new Collection<FileInfo>();
                selectedFiles.Add(file);

                {
                    Collection<SABlock> blocks = GetBlocksFromRTFFiles(selectedFiles);

                    foreach (SABlock itemBlock in blocks)
                    {
                        if (itemBlock != null && (itemBlock.Poems.Count > 0 || itemBlock.Parts.Count > 0))
                        {
                            result.Blocks.Add(itemBlock);
                        }
                    }
                }
            }

            return result;
        }

        private const string regexNamePattern = @"^(?<Rank>[0-9]{2}). (?<Author>\w*). (?<Name>.*)$";
        private const string BlockSplitter = "\f";
        private const string PoemSplitter = "\n\n\n\n\n\n";
        private const string PoemPartSplitter = "\n\n\n";

        internal static Collection<SABlock> GetBlocksFromRTFFiles(Collection<FileInfo> selectedFiles)
        {
            Collection<SABlock> result = new Collection<SABlock>();

            using (RichTextBox rTB = new RichTextBox())
            {
                string tempDirName = GetTemporaryDirectoryName();

                DirectoryInfo tempDir = new DirectoryInfo(tempDirName);

                tempDir.Create();

                foreach (FileInfo file in selectedFiles)
                {
                    if (file.Exists)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file.Name);
                        SABlock block = CreateNewBlock(fileName);

                        string tempFileName = Path.Combine(tempDir.FullName, file.Name);

                        file.CopyTo(tempFileName);

                        rTB.LoadFile(tempFileName);
                        DeleteComments(rTB);

                        string text = rTB.Text;

                        if (text.Contains(BlockSplitter))
                        {
                            Collection<SABlockPart> newBlockParts = GetBlockParts(text);

                            foreach (SABlockPart itemBlockPart in newBlockParts)
                            {
                                block.Parts.Add(itemBlockPart);
                            }
                        }
                        else
                        {
                            Collection<Poem> poems = GetPoemsFromText(text);
                            foreach (Poem item in poems)
                            {
                                block.Poems.Add(item);
                            }
                        }

                        result.Add(block);
                    }
                }

                tempDir.Delete(true);
            }

            return result;
        }

        private static string GetTemporaryDirectoryName()
        {
            string result = string.Empty;

            result = Path.Combine(Path.GetTempPath(), "TempFolder_" + Guid.NewGuid().ToString());

            return result;
        }

        private static SABlock CreateNewBlock(string fileName)
        {
            SABlock block = new SABlock();

            Regex regexName = new Regex(regexNamePattern);
            if (regexName.IsMatch(fileName))
            {
                Match match = regexName.Match(fileName);
                block.Name = match.Groups["Name"].Value;

                block.Author = match.Groups["Author"].Value;

                string rankString = match.Groups["Rank"].Value;
                int temp;
                if (int.TryParse(rankString, out temp))
                {
                    block.Rank = temp;
                }
            }

            if (string.IsNullOrEmpty(block.Name))
            {
                block.Name = fileName;
            }

            return block;
        }

        private static Collection<SABlockPart> GetBlockParts(string fullText)
        {
            Collection<SABlockPart> result = new Collection<SABlockPart>();

            string[] splitBlockParts = fullText.Trim('\n').Split(new string[] { BlockSplitter }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string itemText in splitBlockParts)
            {
                string name = string.Empty;
                string text = CutName(itemText, out name);

                SABlockPart blockPart = new SABlockPart();
                blockPart.Name = name;

                result.Add(blockPart);

                Collection<Poem> poems = GetPoemsFromText(text);
                foreach (Poem item in poems)
                {
                    blockPart.Poems.Add(item);
                }
            }

            return result;
        }

        private static Collection<Poem> GetPoemsFromText(string poemCollectionText)
        {
            Collection<Poem> result = new Collection<Poem>();

            string[] splitPoems = poemCollectionText.Split(new string[] { PoemSplitter }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string itemText in splitPoems)
            {
                string name = string.Empty;
                string text = CutName(itemText, out name);

                Poem newPoem = new Poem();
                newPoem.Name = name;

                result.Add(newPoem);

                if (text.Contains(PoemPartSplitter))
                {
                    Collection<PoemPart> poems = GetPoemParts(text);
                    foreach (PoemPart itemPart in poems)
                    {
                        newPoem.Parts.Add(itemPart);
                    }
                }
                else
                {
                    Collection<PoemLine> poems = GetLines(text);
                    foreach (PoemLine item in poems)
                    {
                        newPoem.Lines.Add(item);
                    }
                }
            }


            return result;
        }

        private static Collection<PoemPart> GetPoemParts(string fullText)
        {
            Collection<PoemPart> result = new Collection<PoemPart>();

            string[] splitPoemParts = fullText.Trim('\n').Split(new string[] { PoemPartSplitter }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string itemText in splitPoemParts)
            {
                string name = string.Empty;
                string text = CutName(itemText, out name);

                PoemPart newPoemPart = new PoemPart();
                newPoemPart.Name = name;

                result.Add(newPoemPart);

                Collection<PoemLine> poems = GetLines(text);
                foreach (PoemLine item in poems)
                {
                    newPoemPart.Lines.Add(item);
                }
            }

            return result;
        }

        private static Collection<PoemLine> GetLines(string text)
        {
            Collection<PoemLine> result = new Collection<PoemLine>();

            string[] splitBlockParts = text.Trim('\n').Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string itemText in splitBlockParts)
            {
                string newLineText = itemText.Trim();

                string testText = newLineText.Replace(".", "");
                testText = newLineText.Replace(" ", "");

                if (!string.IsNullOrEmpty(testText))
                {
                    PoemLine newLine = new PoemLine(newLineText);

                    result.Add(newLine);
                }
            }

            return result;
        }

        #region Работа с именем.

        private static string CutName(string text, out string name)
        {
            name = string.Empty;

            string temp = text.Trim('\n');

            string[] lineSplit = temp.Split(new char[] { '\n' }, StringSplitOptions.None);

            bool hasName = false;

            if (lineSplit.Length > 1)
            {
                if (string.IsNullOrEmpty(lineSplit[1]))
                {
                    hasName = true;
                    name = lineSplit[0];
                }
            }

            if (hasName)
            {
                StringBuilder result = new StringBuilder();

                for (int i = 2; i < lineSplit.Length; i++)
                {
                    if (result.Length > 0)
                    {
                        result.AppendLine();
                    }

                    result.Append(lineSplit[i]);
                }

                return result.Replace("\r\n", "\n").ToString();
            }
            else
            {
                return temp;
            }
        }

        #endregion Работа с именем.

        private static void DeleteComments(RichTextBox richTextBox)
        {
            richTextBox.SelectionLength = 0;
            richTextBox.SelectionStart = 0;

            while (true)
            {
                int findIndex = richTextBox.Find(@"//", richTextBox.SelectionStart, RichTextBoxFinds.None);

                if (findIndex == -1)
                {
                    break;
                }

                int selectionStart = richTextBox.SelectionStart;

                int ind = richTextBox.Text.IndexOf("\n", selectionStart);


                if (ind != -1)
                {
                    richTextBox.SelectionLength = ind - selectionStart + 2;

                    richTextBox.SelectedText = string.Empty;
                }
            }
        }
    }
}
