using System;
using System.Collections;
using System.IO;

namespace MnemoTrainerLibrary.Classes
{
    public class WordDictionary
    {
        public static FileInfo[] SourcesFile { get; private set; }

        static WordDictionary()
        {
            string listPath = Path.Combine(Config.LocalSettingFolder, "Словари");

            DirectoryInfo mainDir = new DirectoryInfo(listPath);
            if (mainDir.Exists)
            {
                FileInfo[] files = mainDir.GetFiles("*.txt");

                SourcesFile = files;
            }
        }

        public static ArrayList GetWordsFromFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
            {
                throw new ArgumentException("Отсутствует файл.", "fileName");
            }

            ArrayList result = new ArrayList();

            using (StreamReader stringReader = File.OpenText(fileName))
            {
                if (stringReader != null)
                {
                    Hashtable hashtable = new Hashtable();

                    while (!stringReader.EndOfStream)
                    {
                        string line = stringReader.ReadLine();
                        line = line.Trim().ToLower();

                        if (!string.IsNullOrEmpty(line))
                        {
                            line = Char.ToUpper(line[0]) + line.Substring(1);

                            if (!hashtable.ContainsKey(line))
                            {
                                hashtable.Add(line, null);
                                result.Add(line);
                            }
                        }
                    }

                    hashtable.Clear();

                    stringReader.Close();
                    stringReader.Dispose();
                }
            }

            return result;
        }

        public static int GetWordsCount(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
            {
                throw new ArgumentException("Отсутствует файл.", "fileName");
            }

            int result = 0;

            using (StreamReader stringReader = File.OpenText(fileName))
            {
                if (stringReader != null)
                {
                    Hashtable hashtable = new Hashtable();

                    while (!stringReader.EndOfStream)
                    {
                        string line = stringReader.ReadLine();
                        line = line.Trim().ToLower();

                        if (!string.IsNullOrEmpty(line))
                        {
                            line = Char.ToUpper(line[0]) + line.Substring(1);

                            if (!hashtable.ContainsKey(line))
                            {
                                hashtable.Add(line, null);
                                result++;
                            }
                        }
                    }

                    hashtable.Clear();

                    stringReader.Close();
                    stringReader.Dispose();
                }
            }

            return result;
        }
    }
}
