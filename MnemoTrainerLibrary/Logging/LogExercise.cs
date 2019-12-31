using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using MnemoTrainerLibrary.Classes;

namespace MnemoTrainerLibrary.Logging
{
    public static class LogExercise
    {
        public const string logFileName = "Тренировки за {0} на {1}";
        public static readonly string regexLogFileName = string.Format(LogExercise.logFileName, @"(?<Year>[0-9]{4})-(?<Month>[0-9]{2})-(?<Day>[0-9]{2})", @"[a-zA-Z].*");
        public const string searchPattern = "Тренировки за {0}.xml";

        private const string rootNodeName = "LogExercise";
        private static Collection<ExerciseSerie> exerciseLogs = new Collection<ExerciseSerie>();

        #region Стандартные имя файла и его местоположение.

        private static string DefaultFullFileName(DateTime date)
        {
            if (date.TimeOfDay < new TimeSpan(5, 0, 0))
            {
                date = date.AddDays(-1);
            }

            string fileName = string.Format(logFileName + ".xml", date.ToString("yyyy-MM-dd"), Environment.MachineName);

            return Path.Combine(Config.LogFolder, fileName);
        }

        #endregion Стандартные имя файла и его местоположение.

        public static void AddNewExerciseSerie(ExerciseSerie item)
        {
            bool itemIsAdded = false;

            for (int i = exerciseLogs.Count - 1; i >= 0; i--)
            {
                ExerciseSerie serie = exerciseLogs[i];

                if (serie.Type.Equals(item.Type))
                {
                    foreach (ExerciseAttempt attempt in item.Attempts)
                    {
                        serie.Attempts.Add(attempt);
                    }

                    itemIsAdded = true;
                    break;
                }
            }

            if (!itemIsAdded)
            {
                exerciseLogs.Add(item);
            }
        }

        public static void SaveProgramsLogs()
        {
            if (exerciseLogs.Count > 0)
            {
                XmlDocument logFile = new XmlDocument();

                if (!Directory.Exists(Config.LogFolder))
                {
                    Directory.CreateDirectory(Config.LogFolder);
                }

                string fileName = DefaultFullFileName(DateTime.Now);

                if (File.Exists(fileName))
                {
                    logFile.Load(fileName);
                }
                else
                {
                    logFile.AppendChild(logFile.CreateXmlDeclaration("1.0", "utf-8", "yes"));
                    logFile.AppendChild(logFile.CreateElement(rootNodeName));
                }

                XmlNode root = logFile[rootNodeName];

                foreach (ExerciseSerie item in exerciseLogs)
                {
                    if (item.Attempts.Count > 0)
                    {
                        bool itemIsSaved = false;

                        for (int i = root.ChildNodes.Count - 1; i >= 0; i--)
                        {
                            XmlNode node = root.ChildNodes[i];

                            ExerciseSerie tmp = ExerciseSerie.CreateFromXml(node);

                            if (tmp.Type.Equals(item.Type))
                            {
                                foreach (ExerciseAttempt attemp in item.Attempts)
                                {
                                    node.AppendChild(attemp.CreateXmlNode(node.OwnerDocument));
                                }

                                itemIsSaved = true;
                                break;
                            }
                        }

                        if (!itemIsSaved)
                        {
                            XmlNode node = item.CreateXmlNode(logFile, "ExerciseSerie");

                            root.AppendChild(node);
                        }
                    }
                }

                exerciseLogs.Clear();

                logFile.Save(fileName);
            }
        }

        #region Работа с файлами.

        public static Collection<ExerciseSerie> CreateSeriesFromFile(string fileName)
        {
            Collection<ExerciseSerie> result = new Collection<ExerciseSerie>();

            if (File.Exists(fileName))
            {
                XmlDocument logFile = new XmlDocument();
                logFile.Load(fileName);

                XmlNode root = logFile[rootNodeName];

                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    XmlNode node = root.ChildNodes[i];

                    ExerciseSerie tmp = ExerciseSerie.CreateFromXml(node);
                    tmp.SortAttempts();

                    result.Add(tmp);
                }
            }

            return result;
        }

        public static Collection<ExerciseSerie> CreateSeriesForDate(DateTime date)
        {
            if (date.TimeOfDay < new TimeSpan(5, 0, 0))
            {
                date = date.AddDays(-1);
            }

            Collection<ExerciseSerie> result = new Collection<ExerciseSerie>();

            DirectoryInfo mainTempDir = new DirectoryInfo(Config.LogFolder);
            if (mainTempDir.Exists)
            {
                FileInfo[] xmlFiles;

                // Получение файлов для Меркурия.
                xmlFiles = mainTempDir.GetFiles(string.Format("Тренировки за {0}.xml", date.ToString("yyyy-MM-dd") + "*"), SearchOption.TopDirectoryOnly);
                foreach (FileInfo file in xmlFiles)
                {
                    Collection<ExerciseSerie> col = LogExercise.CreateSeriesFromFile(file.FullName);

                    foreach (ExerciseSerie item in col)
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        public static Hashtable GetOldTestWords(int wordCount)
        {
            Hashtable result = new Hashtable();

            if (wordCount <= 0)
            {
                return result;
            }

            DirectoryInfo mainTempDir = new DirectoryInfo(Config.LogFolder);
            if (mainTempDir.Exists)
            {
                FileInfo[] xmlFiles;

                // Получение файлов для Меркурия.
                xmlFiles = mainTempDir.GetFiles(string.Format(LogExercise.searchPattern, "*"), SearchOption.TopDirectoryOnly);

                Collection<KeyValuePair<DateTime, FileInfo>> filesList = new Collection<KeyValuePair<DateTime, FileInfo>>();
                foreach (FileInfo item in xmlFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(item.FullName);

                    Regex regex = new Regex(LogExercise.regexLogFileName, RegexOptions.ExplicitCapture);
                    if (regex.IsMatch(fileName))
                    {
                        Match match = regex.Match(fileName);
                        DateTime date = new DateTime(Convert.ToInt32(match.Groups["Year"].Value), Convert.ToInt32(match.Groups["Month"].Value), Convert.ToInt32(match.Groups["Day"].Value));

                        filesList.Add(new KeyValuePair<DateTime, FileInfo>(date, item));
                    }
                }

                DateTime[] dates = new DateTime[filesList.Count];
                FileInfo[] files = new FileInfo[filesList.Count];

                for (int i = 0; i < filesList.Count; i++)
                {
                    dates[i] = filesList[i].Key;
                    files[i] = filesList[i].Value;
                }

                Array.Sort(dates, files);

                int fileIndex = files.Length - 1;
                while (fileIndex >= 0)
                {
                    FileInfo file = files[fileIndex];

                    Collection<ExerciseSerie> series = LogExercise.CreateSeriesFromFile(file.FullName);

                    foreach (ExerciseSerie itemSerie in series)
                    {
                        if (itemSerie.Type.Type == TrainType.ConsecutiveAssociations)
                        {
                            foreach (ExerciseAttemptAssociationsСonsecutive item in itemSerie.Attempts)
                            {
                                foreach (AssociationQuestion question in item.Questions)
                                {
                                    if (!result.ContainsKey(question.Question))
                                    {
                                        result.Add(question.Question, null);

                                        if (result.Count == wordCount)
                                        {
                                            return result;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    fileIndex--;
                }
            }

            return result;
        }

        #endregion Работа с файлами.
    }
}
