using System;
using System.IO;

namespace MnemoTrainerLibrary
{
    public static class Config
    {
        private const string folderTrains = "Тренировки";
        private const string folderLogs = "Логи";
        private const string folderSystemAccumulation = "Система накопления";
        private const string folder100For100 = "100 за 100";
        private const string fileSystemAccumulation = "СН.xml";

        private static string localSettingFolder = Environment.CurrentDirectory;
        public static string LocalSettingFolder
        {
            get
            {
                string path = localSettingFolder;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }

            set
            {
                if (Directory.Exists(value))
                {
                    localSettingFolder = value;
                }
            }
        }

        public static string ReportFolder
        {
            get
            {
                string path = Path.Combine(Config.LocalSettingFolder, folderTrains);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        public static string LogFolder
        {
            get
            {
                string path = Path.Combine(Config.ReportFolder, folderLogs);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        public static string SystemAccumulationFileName
        {
            get
            {
                return Path.Combine(Config.LocalSettingFolder, fileSystemAccumulation);
            }
        }

        public static string SystemAccumulationRtfLibrary
        {
            get
            {
                string path = Path.Combine(Config.LocalSettingFolder, folderSystemAccumulation);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }

        public static string Train100For100Folder
        {
            get
            {
                string path = Path.Combine(Config.LocalSettingFolder, folder100For100);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }
        }
    }
}
