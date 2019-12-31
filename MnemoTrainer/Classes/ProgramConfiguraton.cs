using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace MnemoTrainer.Classes
{
    /// <summary>
    /// Свойства формы для загрузки/сохранения в конфиг-файле.
    /// </summary>
    [Flags]
    internal enum ConfigFormOption
    {
        /// <summary>
        /// Размер формы.
        /// </summary>
        Size = 1,

        /// <summary>
        /// Расположение формы.
        /// </summary>
        Location = 2,

        /// <summary>
        /// Свойство FormWindowState.Maximized формы.
        /// </summary>
        Maximized = 4
    }

    /// <summary>
    /// Статический класс для работы с настройками формы.
    /// </summary>
    public static class ProgramConfiguraton
    {
        public const string trainerConfigFileName = "MnemoTrainer.conf";
        public const string trainerSubdirectoryName = "MnemoTrainer";
        public const string trainerRootNodeName = "MnemoTrainer_Configuration";

        /// <summary>
        /// XmlDocument с настройками программы.
        /// </summary>
        private static ConfigXmlDocument programParams = new ConfigXmlDocument();

        #region Стандартные имя файла и его местоположение.

        /// <summary>
        /// Стандартная папка для хранения конфиг-файла.
        /// </summary>
        private static string DefaultFormDirectory
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), trainerSubdirectoryName);
            }
        }

        /// <summary>
        /// Стандартное имя конфиг-файла.
        /// </summary>
        private static string DefaultFormFullFileName
        {
            get
            {
                return Path.Combine(DefaultFormDirectory, trainerConfigFileName);
            }
        }

        #endregion Стандартные имя файла и его местоположение.

        #region Работа с файлами.

        /// <summary>
        /// Загрузить конфиг-файл.
        /// </summary>
        internal static void LoadXmlConfig()
        {
            string fileName = DefaultFormFullFileName;

            bool create = false;

            if (File.Exists(fileName))
            {
                try
                {
                    programParams.Load(fileName);
                }
                catch (Exception)
                {
                    create = true;
                }
            }

            if (create)
            {
                programParams = new ConfigXmlDocument();

                XmlDeclaration declaration = programParams.CreateXmlDeclaration("1.0", "utf-8", "yes");
                programParams.AppendChild(declaration);
                XmlNode root = programParams.CreateElement(trainerRootNodeName);
                programParams.AppendChild(root);
            }
        }

        /// <summary>
        /// Сохранить конфиг-файл.
        /// </summary>
        internal static void SaveXmlConfig()
        {
            string dirName = DefaultFormDirectory;
            string fileName = DefaultFormFullFileName;

            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }

            programParams.Save(fileName);

            LocalConfiguration.SaveXmlConfig();
        }

        #endregion Работа с файлами.

        #region Методы для работы интерфейсом форм.

        #region Формы.

        #region Свободный параметр формы.

        /// <summary>
        /// Загрузить свободный параметр формы.
        /// </summary>
        /// <param name="form">Форма, которой нужен параметр.</param>
        /// <param name="paramName">Имя параметра.</param>
        /// <returns>Значение параметра как строка, если параметра нет, то возвращается пустая строка.</returns>
        internal static string LoadFormCustomParameter(Form form, string paramName)
        {
            // Результат.
            string result = string.Empty;

            // Форма не нуль, имя формы не пустое, имя параметра не нуль.
            if (!string.IsNullOrEmpty(paramName) && form != null && !string.IsNullOrEmpty(form.Name))
            {
                // Корневой элемент конфигурации программы.
                XmlNode root = programParams[trainerRootNodeName];
                if (root != null)
                {
                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode != null)
                    {
                        // Элемент параметра.
                        XmlNode formParamValue = formNode[paramName];
                        if (formParamValue != null)
                        {
                            // Загрузка значения.
                            result = formParamValue.InnerText;
                        }
                    }
                }
            }

            // Проверка правильности сохранения параметра не входит в список обязанностей этой функции.
            return result;
        }

        /// <summary>
        /// Сохранить свободный параметр формы.
        /// </summary>
        /// <param name="form">Форма, которой принадлежит этот параметр.</param>
        /// <param name="paramName">Имя параметра.</param>
        /// <param name="paramValue">Значение параметра в виде строки.</param>
        internal static void SaveFormCustomParameter(Form form, string paramName, string paramValue)
        {
            // Форма не нуль, имя формы не нуль, имя параметра не нуль.
            if (!string.IsNullOrEmpty(paramName) && form != null && !string.IsNullOrEmpty(form.Name))
            {
                // Корневой элемент конфигурации программы.
                XmlNode root = programParams[trainerRootNodeName];
                if (root == null)
                {
                    // Создаем корень, если его нет.
                    root = programParams.CreateElement(trainerRootNodeName);
                    programParams.AppendChild(root);
                }

                // Элемент формы.
                XmlNode formNode = root[form.Name];
                if (formNode == null)
                {
                    // Создаем его, если нет.
                    formNode = programParams.CreateElement(form.Name);
                    root.AppendChild(formNode);
                }

                // Элемент параметра.
                XmlNode formParamValue = formNode[paramName];
                if (formParamValue == null)
                {
                    // Создаем его, если нет.
                    formParamValue = programParams.CreateElement(paramName);
                    formNode.AppendChild(formParamValue);
                }
                // Сохраняем значение параметра.
                formParamValue.InnerText = paramValue;
            }
        }

        #endregion Свободный параметр формы.

        #region Стандартные настройки форм.

        private const string xlmNodeNameWidth = "Width";
        private const string xlmNodeNameHeight = "Height";

        private const string xlmNodeNameLeft = "Left";
        private const string xlmNodeNameTop = "Top";

        /// <summary>
        /// Загрузка стандартных параметров формы по указанному списку флагов.
        /// </summary>
        /// <param name="form">Форма для загрузки параметров.</param>
        /// <param name="options">Флаги параметров.</param>
        internal static void LoadFormParams(Form form, ConfigFormOption options)
        {
            bool locationExists = false;

            // Форма не нулевая и с непустым именем.
            if (form != null && !string.IsNullOrEmpty(form.Name))
            {
                // Ищем конфигурационный корень в файле.
                XmlNode root = programParams[trainerRootNodeName];
                if (root != null)
                {
                    // Ищем элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode != null)
                    {
                        // Переменная для конвертирования текста элементов.
                        int value = 0;

                        // Если есть флаг размеров.
                        if ((options & ConfigFormOption.Size) == ConfigFormOption.Size)
                        {
                            // Ширина.
                            XmlNode formWidth = formNode[xlmNodeNameWidth];
                            if (formWidth != null)
                            {
                                if (int.TryParse(formWidth.InnerText, out value))
                                {
                                    form.Width = value;
                                }
                            }

                            // Высота.
                            XmlNode formHeight = formNode[xlmNodeNameHeight];
                            if (formHeight != null)
                            {
                                if (int.TryParse(formHeight.InnerText, out value))
                                {
                                    form.Height = value;
                                }
                            }
                        }

                        // Если есть флаг расположения.
                        if ((options & ConfigFormOption.Location) == ConfigFormOption.Location)
                        {
                            bool locationIsNull = true;

                            // Горизонталь.
                            XmlNode formLeft = formNode[xlmNodeNameLeft];
                            if (formLeft != null)
                            {
                                if (int.TryParse(formLeft.InnerText, out value))
                                {
                                    locationIsNull = false;
                                    form.Left = value;
                                }
                            }

                            // Вертикаль.
                            XmlNode formTop = formNode[xlmNodeNameTop];
                            if (formTop != null)
                            {
                                if (int.TryParse(formTop.InnerText, out value))
                                {
                                    locationIsNull = false;
                                    form.Top = value;
                                }
                            }

                            // Если элемент формы есть, но расположение не сохранено, то показываем форму в центре.
                            if (locationIsNull)
                            {
                                form.StartPosition = FormStartPosition.CenterScreen;
                            }
                            else
                            {
                                locationExists = true;

                                form.StartPosition = FormStartPosition.Manual;
                            }
                        }

                        // Если считываем Состояним Максимизации.
                        if ((options & ConfigFormOption.Maximized) == ConfigFormOption.Maximized)
                        {
                            XmlNode formMaximized = formNode[ConfigFormOption.Maximized.ToString()];
                            // Если элемент есть и его значение "1".
                            if (formMaximized != null && formMaximized.InnerText == "1")
                            {
                                form.WindowState = FormWindowState.Maximized;
                            }
                            else
                            {
                                form.WindowState = FormWindowState.Normal;
                            }
                        }
                    }
                    // Если нет элемента формы и есть считывание расположения, то задаем стандартное положение - в центре.
                    else if ((options & ConfigFormOption.Location) == ConfigFormOption.Location)
                    {
                        form.StartPosition = FormStartPosition.CenterScreen;
                    }
                }
            }

            if (!locationExists)
            {
                form.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        /// <summary>
        /// Сохранение в конфиг-файле настроек формы по указанному списку свойств.
        /// </summary>
        /// <param name="form">Форма для сохранения ее параметров.</param>
        /// <param name="options">Набор флагов для сохранения параметров.</param>
        internal static void SaveFormParams(Form form, ConfigFormOption options)
        {
            // Форма не нуль и имя формы непустое.
            if (form != null && !string.IsNullOrEmpty(form.Name))
            {
                // Ищем корень конфигурации программы.
                XmlNode root = programParams[trainerRootNodeName];
                if (root == null)
                {
                    // Создаем корень, если его нет.
                    root = programParams.CreateElement(trainerRootNodeName);
                    programParams.AppendChild(root);
                }

                // Ищем элемент формы.
                XmlNode formNode = root[form.Name];
                if (formNode == null)
                {
                    // Создаем его, если его нет.
                    formNode = programParams.CreateElement(form.Name);
                    root.AppendChild(formNode);
                }

                // Сохраняем расположение и размер, только если форма не в Максимизированном состоянии.
                if (form.WindowState == FormWindowState.Normal)
                {
                    // Если сохраняем размер.
                    if ((options & ConfigFormOption.Size) == ConfigFormOption.Size)
                    {
                        // Элемент ширины.
                        XmlNode formWidth = formNode[xlmNodeNameWidth];
                        if (formWidth == null)
                        {
                            // Создаем его, если нет.
                            formWidth = programParams.CreateElement(xlmNodeNameWidth);
                            formNode.AppendChild(formWidth);
                        }
                        // Сохраняем ширину.
                        formWidth.InnerText = form.Width.ToString();

                        // Элемент высоты.
                        XmlNode formHeight = formNode[xlmNodeNameHeight];
                        if (formHeight == null)
                        {
                            // Создаем его, если нет.
                            formHeight = programParams.CreateElement(xlmNodeNameHeight);
                            formNode.AppendChild(formHeight);
                        }
                        // Сохраняем высоту.
                        formHeight.InnerText = form.Height.ToString();
                    }

                    // Если сохраняем расположение.
                    if ((options & ConfigFormOption.Location) == ConfigFormOption.Location)
                    {
                        // Элемент горизонтали.
                        XmlNode formLeft = formNode[xlmNodeNameLeft];
                        if (formLeft == null)
                        {
                            // Создаем его, если нет.
                            formLeft = programParams.CreateElement(xlmNodeNameLeft);
                            formNode.AppendChild(formLeft);
                        }
                        // Сохраняем горизонталь.
                        formLeft.InnerText = form.Left.ToString();

                        // Элемент вертикали.
                        XmlNode formTop = formNode[xlmNodeNameTop];
                        if (formTop == null)
                        {
                            // Создаем его, если нет.
                            formTop = programParams.CreateElement(xlmNodeNameTop);
                            formNode.AppendChild(formTop);
                        }
                        // Сохраняем вертикаль.
                        formTop.InnerText = form.Top.ToString();
                    }
                }

                // Если сохраняем состояние окна.
                if ((options & ConfigFormOption.Maximized) == ConfigFormOption.Maximized)
                {
                    // Элемент максимизации.
                    XmlNode formMaximized = formNode[ConfigFormOption.Maximized.ToString()];
                    if (formMaximized == null)
                    {
                        // Создаем его, если нет.
                        formMaximized = programParams.CreateElement(ConfigFormOption.Maximized.ToString());
                        formNode.AppendChild(formMaximized);
                    }
                    // Сохраняем максимизацию.
                    formMaximized.InnerText = form.WindowState == FormWindowState.Maximized ? "1" : "0";
                }
            }
        }

        #endregion Стандартные настройки форм.

        #endregion Формы.

        #region Контролы.

        #region Свободного параметр контрола.

        /// <summary>
        /// Загрузка кастомного параметра контрола из конфиг-файла.
        /// </summary>
        /// <param name="control">Контрол, которому принадлежит параметр.</param>
        /// <param name="paramName">Имя параметра.</param>
        /// <returns>Сохраненное значение параметра.</returns>
        internal static string LoadControlCustomParameter(Control control, string paramName)
        {
            string result = string.Empty;
            // Если имя параметра не нулевое, контрое и его имя не нуль.
            if (!string.IsNullOrEmpty(paramName) && control != null && !string.IsNullOrEmpty(control.Name))
            {
                // Форма, содержащая данный контрол.
                Form form = control.FindForm();
                // Форма и его имя не нуль.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфигурации программы.
                    XmlNode root = programParams[trainerRootNodeName];
                    if (root != null)
                    {
                        // Элемент формы.
                        XmlNode formNode = root[form.Name];
                        if (formNode != null)
                        {
                            // Элемент контрола.
                            XmlNode controlNode = formNode[control.Name];
                            if (controlNode != null)
                            {
                                // Элемент параметра.
                                XmlNode controlParamValue = controlNode[paramName];
                                if (controlParamValue != null)
                                {
                                    // Считываем параметр.
                                    result = controlParamValue.InnerText;
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Сохранение в конфиг-файл кастомного параметра контрола.
        /// </summary>
        /// <param name="control">Контрол, которому принадлежит параметр.</param>
        /// <param name="paramName">Имя параметра.</param>
        /// <param name="paramValue">Значение параметра.</param>
        internal static void SaveControlCustomParameter(Control control, string paramName, string paramValue)
        {
            // Если имя параметра, контрол и его имя не нулевые.
            if (!string.IsNullOrEmpty(paramName) && control != null && !string.IsNullOrEmpty(control.Name))
            {
                // Форма, содержащая данную форму.
                Form form = control.FindForm();
                // Форма и его имя не нуль.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфиг-файла.
                    XmlNode root = programParams[trainerRootNodeName];
                    if (root == null)
                    {
                        // Создаем корневой элемент, если его нет.
                        root = programParams.CreateElement(trainerRootNodeName);
                        programParams.AppendChild(root);
                    }

                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode == null)
                    {
                        // Создаем его, если его нет.
                        formNode = programParams.CreateElement(form.Name);
                        root.AppendChild(formNode);
                    }

                    // Элемент контрола.
                    XmlNode controlNode = formNode[control.Name];
                    if (controlNode == null)
                    {
                        // Создаем его, если его нет.
                        controlNode = programParams.CreateElement(control.Name);
                        formNode.AppendChild(controlNode);
                    }

                    // Элемент параметра.
                    XmlNode controlParamValue = controlNode[paramName];
                    if (controlParamValue == null)
                    {
                        // Создаем его, если его нет.
                        controlParamValue = programParams.CreateElement(paramName);
                        controlNode.AppendChild(controlParamValue);
                    }
                    // Сохраняем параметр.
                    controlParamValue.InnerText = paramValue;
                }
            }
        }

        #endregion Свободного параметр контрола.

        #region Размеры контролов.

        /// <summary>
        /// Загрузка размеров списка контролов из конфиг-файла.
        /// </summary>
        /// <param name="controls">Массив контролов, для считывания размеров.</param>
        internal static void LoadControlsSize(params Control[] controls)
        {
            // Массив не нулевая и в нем более одного элемента.
            if (controls != null && controls.Length > 0)
            {
                // Форма, содержащая данные контролы (считывается с первого контрола).
                Form form = controls[0].FindForm();
                // Форма и ее имя не нуль.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфигурации программы.
                    XmlNode root = programParams[trainerRootNodeName];
                    if (root != null)
                    {
                        // Элемент формы.
                        XmlNode formNode = root[form.Name];
                        if (formNode != null)
                        {
                            // Переменная для конверта текста в число.
                            int value = 0;
                            // По всем контролам.
                            for (int i = 0; i < controls.Length; i++)
                            {
                                Control control = controls[i];
                                // Имя контрола не нуль.
                                if (!string.IsNullOrEmpty(control.Name))
                                {
                                    // Элемент контрола.
                                    XmlNode controlNode = formNode[control.Name];
                                    if (controlNode != null)
                                    {
                                        // Элемент ширины.
                                        XmlNode controlWidth = controlNode[xlmNodeNameWidth];
                                        if (controlWidth != null)
                                        {
                                            if (int.TryParse(controlWidth.InnerText, out value))
                                            {
                                                // Загружаем ширину.
                                                control.Width = value;
                                            }
                                        }
                                        // Элемент высоты.
                                        XmlNode controlHeight = controlNode[xlmNodeNameHeight];
                                        if (controlHeight != null)
                                        {
                                            if (int.TryParse(controlHeight.InnerText, out value))
                                            {
                                                // Загружаем высоту.
                                                control.Height = value;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Сохранение конфиг-файл размеров контролов.
        /// </summary>
        /// <param name="controls">Массив контролов для сохранения размеров.</param>
        internal static void SaveControlsSize(params Control[] controls)
        {
            // Массив контролов не нулевой и в нем есть хоть один элемент.
            if (controls != null && controls.Length > 0)
            {
                // Форма, содержащая эти контролы.
                Form form = controls[0].FindForm();
                // Форма и ее имя не нулевые.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфигурации программы.
                    XmlNode root = programParams[trainerRootNodeName];
                    if (root == null)
                    {
                        // Создать корневой элемент.
                        root = programParams.CreateElement(trainerRootNodeName);
                        programParams.AppendChild(root);
                    }
                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode == null)
                    {
                        // Создать его, если его нет.
                        formNode = programParams.CreateElement(form.Name);
                        root.AppendChild(formNode);
                    }
                    // По всему массиву.
                    for (int i = 0; i < controls.Length; i++)
                    {
                        Control control = controls[i];
                        // Имя контрола не нулевое.
                        if (!string.IsNullOrEmpty(control.Name))
                        {
                            // Элемент контрола.
                            XmlNode controlNode = formNode[control.Name];
                            if (controlNode == null)
                            {
                                // Создать его, если его нет.
                                controlNode = programParams.CreateElement(control.Name);
                                formNode.AppendChild(controlNode);
                            }
                            // Элемент ширины.
                            XmlNode controlWidth = controlNode[xlmNodeNameWidth];
                            if (controlWidth == null)
                            {
                                // Создать его, если его нет.
                                controlWidth = programParams.CreateElement(xlmNodeNameWidth);
                                controlNode.AppendChild(controlWidth);
                            }
                            // Сохраняем ширину.
                            controlWidth.InnerText = control.Width.ToString();
                            // Элемент высоты.
                            XmlNode controlHeight = controlNode[xlmNodeNameHeight];
                            if (controlHeight == null)
                            {
                                // Создать его, если его нет.
                                controlHeight = programParams.CreateElement(xlmNodeNameHeight);
                                controlNode.AppendChild(controlHeight);
                            }
                            // Сохраняем высоту.
                            controlHeight.InnerText = control.Height.ToString();
                        }
                    }
                }
            }
        }

        #endregion Размеры контролов.

        #region Отображаемость контролов.

        private const string xmlNodeNameVisible = "Visible";

        /// <summary>
        /// Загрузка свойства отображения набора контролов из конфиг-файла.
        /// </summary>
        /// <param name="controls">Массив контролов, для которых считывается отображаемость.</param>
        internal static void LoadControlsVisible(params Control[] controls)
        {
            // Массив не нуль, и в нем хоть один элемент.
            if (controls != null && controls.Length > 0)
            {
                // Форма, содержащая эти контролы.
                Form form = controls[0].FindForm();
                // Форма и ее имя не нуль.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфигурации программы.
                    XmlNode root = programParams[trainerRootNodeName];
                    if (root != null)
                    {
                        // Элемент формы.
                        XmlNode formNode = root[form.Name];
                        if (formNode != null)
                        {
                            // По всему массиву.
                            for (int i = 0; i < controls.Length; i++)
                            {
                                Control control = controls[i];
                                // Имя контрола не нуль.
                                if (!string.IsNullOrEmpty(control.Name))
                                {
                                    // Элемент контрола.
                                    XmlNode controlNode = formNode[control.Name];
                                    if (controlNode != null)
                                    {
                                        // Элемент отображаемости.
                                        XmlNode controlVisible = controlNode[xmlNodeNameVisible];
                                        if (controlVisible != null)
                                        {
                                            // Устанавливаем отображаемость.
                                            control.Visible = controlVisible.InnerText == "1";
                                            if (control.Parent != null)
                                            {
                                                // Заставляем родителя переформировать отступы.
                                                control.Parent.PerformLayout();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Сохранение в конфиг-файл свойства отображения набора контролов.
        /// </summary>
        /// <param name="controls">Контролы, отображаемость которых надо сохранять.</param>
        internal static void SaveControlsVisible(params Control[] controls)
        {
            // Массив не нуль, и в нем хоть один элемент.
            if (controls != null && controls.Length > 0)
            {
                // Форма, содержащая данный контрол.
                Form form = controls[0].FindForm();
                // Форма и ее имя не нуль.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфигурации программы.
                    XmlNode root = programParams[trainerRootNodeName];
                    if (root == null)
                    {
                        // Создаем корневой элемент.
                        root = programParams.CreateElement(trainerRootNodeName);
                        programParams.AppendChild(root);
                    }
                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode == null)
                    {
                        // Создаем его, если его нет.
                        formNode = programParams.CreateElement(form.Name);
                        root.AppendChild(formNode);
                    }
                    // По всему массиву.
                    for (int i = 0; i < controls.Length; i++)
                    {
                        Control control = controls[i];
                        // Имя контрола не нуль.
                        if (!string.IsNullOrEmpty(control.Name))
                        {
                            // Элемент контрола.
                            XmlNode controlNode = formNode[control.Name];
                            if (controlNode == null)
                            {
                                // Создаем его, если его нет.
                                controlNode = programParams.CreateElement(control.Name);
                                formNode.AppendChild(controlNode);
                            }
                            // Элемент отображаемости.
                            XmlNode controlVisible = controlNode[xmlNodeNameVisible];
                            if (controlVisible == null)
                            {
                                // Создаем его, если его нет.
                                controlVisible = programParams.CreateElement(xmlNodeNameVisible);
                                controlNode.AppendChild(controlVisible);
                            }
                            // Сохраняем отображаемость.
                            controlVisible.InnerText = control.Visible ? "1" : "0";
                        }
                    }
                }
            }
        }

        #endregion Отображаемость контролов.

        #endregion Контролы.

        #endregion Методы для работы интерфейсом форм.
    }
}
