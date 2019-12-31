using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using MnemoTrainerLibrary;
using SAClasses;

namespace MnemoTrainer.Classes
{
    public static class LocalConfiguration
    {
        /// <summary>
        /// XmlDocument с настройками программы.
        /// </summary>
        private static ConfigXmlDocument localParams = new ConfigXmlDocument();

        #region Стандартные имя файла и его местоположение.

        /// <summary>
        /// Стандартная папка для хранения конфиг-файла.
        /// </summary>
        private static string DefaultFormDirectory
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ProgramConfiguraton.trainerSubdirectoryName);
            }
        }

        /// <summary>
        /// Стандартное имя конфиг-файла.
        /// </summary>
        private static string DefaultFormFullFileName
        {
            get
            {
                return Path.Combine(DefaultFormDirectory, ProgramConfiguraton.trainerConfigFileName);
            }
        }

        private static string DefaultProgramFullFileName
        {
            get
            {
                return Path.Combine(Config.LocalSettingFolder, ProgramConfiguraton.trainerConfigFileName);
            }
        }

        #endregion Стандартные имя файла и его местоположение.

        #region Работа с файлами.

        /// <summary>
        /// Загрузить конфиг-файл.
        /// </summary>
        internal static void LoadXmlConfig()
        {
            string fileName = DefaultProgramFullFileName;

            bool create = false;

            if (File.Exists(fileName))
            {
                try
                {
                    localParams.Load(fileName);
                }
                catch (Exception)
                {
                    create = true;
                }
            }

            if (create)
            {
                localParams = new ConfigXmlDocument();

                XmlDeclaration declaration = localParams.CreateXmlDeclaration("1.0", "utf-8", "yes");
                localParams.AppendChild(declaration);

                XmlNode root = localParams.CreateElement(ProgramConfiguraton.trainerRootNodeName);
                localParams.AppendChild(root);
            }
        }

        /// <summary>
        /// Сохранить конфиг-файл.
        /// </summary>
        internal static void SaveXmlConfig()
        {
            string dirName = Config.LocalSettingFolder;
            string fileName = DefaultProgramFullFileName;

            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }

            localParams.Save(fileName);
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
                XmlNode root = localParams[ProgramConfiguraton.trainerRootNodeName];
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
                XmlNode root = localParams[ProgramConfiguraton.trainerRootNodeName];
                if (root == null)
                {
                    // Создаем корень, если его нет.
                    root = localParams.CreateElement(ProgramConfiguraton.trainerRootNodeName);
                    localParams.AppendChild(root);
                }

                // Элемент формы.
                XmlNode formNode = root[form.Name];
                if (formNode == null)
                {
                    // Создаем его, если нет.
                    formNode = localParams.CreateElement(form.Name);
                    root.AppendChild(formNode);
                }

                // Элемент параметра.
                XmlNode formParamValue = formNode[paramName];
                if (formParamValue == null)
                {
                    // Создаем его, если нет.
                    formParamValue = localParams.CreateElement(paramName);
                    formNode.AppendChild(formParamValue);
                }
                // Сохраняем значение параметра.
                formParamValue.InnerText = paramValue;
            }
        }

        #endregion Свободный параметр формы.

        #region Конфигурация контроллева СН.

        internal static void LoadControllerConfiguration(Form form, Controller saController)
        {
            // Форма и ее имя не нуль.
            if (saController != null && form != null && !string.IsNullOrEmpty(form.Name))
            {
                // Корневой элемент конфигурации программы.
                XmlNode root = localParams[ProgramConfiguraton.trainerRootNodeName];
                if (root != null)
                {
                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode != null)
                    {
                        // Элемент контрола.
                        XmlNode nodeConfiguration = formNode[Controller.objName];
                        if (nodeConfiguration != null)
                        {
                            saController.LoadConfigurationFromNode(nodeConfiguration);
                        }
                    }
                }
            }
        }

        internal static void SaveControllerConfiguration(Form form, Controller saController)
        {
            // Если имя параметра, контрол и его имя не нулевые.
            if (saController != null && form != null && !string.IsNullOrEmpty(form.Name))
            {
                // Форма, содержащая данную форму.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфиг-файла.
                    XmlNode root = localParams[ProgramConfiguraton.trainerRootNodeName];
                    if (root == null)
                    {
                        // Создаем корневой элемент, если его нет.
                        root = localParams.CreateElement(ProgramConfiguraton.trainerRootNodeName);
                        localParams.AppendChild(root);
                    }

                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode == null)
                    {
                        // Создаем его, если его нет.
                        formNode = localParams.CreateElement(form.Name);
                        root.AppendChild(formNode);
                    }

                    XmlNode tempNode = formNode[Controller.objName];
                    if (tempNode != null)
                    {
                        formNode.RemoveChild(tempNode);
                    }

                    XmlNode confController = saController.CreateXmlNode(localParams);
                    formNode.AppendChild(confController);
                }
            }
        }

        #endregion Конфигурация контроллева СН.

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
                    XmlNode root = localParams[ProgramConfiguraton.trainerRootNodeName];
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
                    XmlNode root = localParams[ProgramConfiguraton.trainerRootNodeName];
                    if (root == null)
                    {
                        // Создаем корневой элемент, если его нет.
                        root = localParams.CreateElement(ProgramConfiguraton.trainerRootNodeName);
                        localParams.AppendChild(root);
                    }

                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode == null)
                    {
                        // Создаем его, если его нет.
                        formNode = localParams.CreateElement(form.Name);
                        root.AppendChild(formNode);
                    }

                    // Элемент контрола.
                    XmlNode controlNode = formNode[control.Name];
                    if (controlNode == null)
                    {
                        // Создаем его, если его нет.
                        controlNode = localParams.CreateElement(control.Name);
                        formNode.AppendChild(controlNode);
                    }

                    // Элемент параметра.
                    XmlNode controlParamValue = controlNode[paramName];
                    if (controlParamValue == null)
                    {
                        // Создаем его, если его нет.
                        controlParamValue = localParams.CreateElement(paramName);
                        controlNode.AppendChild(controlParamValue);
                    }
                    // Сохраняем параметр.
                    controlParamValue.InnerText = paramValue;
                }
            }
        }

        #endregion Свободного параметр контрола.

        #region Размеры контролов.

        private const string xlmNodeNameWidth = "Width";
        private const string xlmNodeNameHeight = "Height";

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
                    XmlNode root = localParams[ProgramConfiguraton.trainerRootNodeName];
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
                    XmlNode root = localParams[ProgramConfiguraton.trainerRootNodeName];
                    if (root == null)
                    {
                        // Создать корневой элемент.
                        root = localParams.CreateElement(ProgramConfiguraton.trainerRootNodeName);
                        localParams.AppendChild(root);
                    }
                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode == null)
                    {
                        // Создать его, если его нет.
                        formNode = localParams.CreateElement(form.Name);
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
                                controlNode = localParams.CreateElement(control.Name);
                                formNode.AppendChild(controlNode);
                            }
                            // Элемент ширины.
                            XmlNode controlWidth = controlNode[xlmNodeNameWidth];
                            if (controlWidth == null)
                            {
                                // Создать его, если его нет.
                                controlWidth = localParams.CreateElement(xlmNodeNameWidth);
                                controlNode.AppendChild(controlWidth);
                            }
                            // Сохраняем ширину.
                            controlWidth.InnerText = control.Width.ToString();
                            // Элемент высоты.
                            XmlNode controlHeight = controlNode[xlmNodeNameHeight];
                            if (controlHeight == null)
                            {
                                // Создать его, если его нет.
                                controlHeight = localParams.CreateElement(xlmNodeNameHeight);
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
                    XmlNode root = localParams[ProgramConfiguraton.trainerRootNodeName];
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
                    XmlNode root = localParams[ProgramConfiguraton.trainerRootNodeName];
                    if (root == null)
                    {
                        // Создаем корневой элемент.
                        root = localParams.CreateElement(ProgramConfiguraton.trainerRootNodeName);
                        localParams.AppendChild(root);
                    }
                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode == null)
                    {
                        // Создаем его, если его нет.
                        formNode = localParams.CreateElement(form.Name);
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
                                controlNode = localParams.CreateElement(control.Name);
                                formNode.AppendChild(controlNode);
                            }
                            // Элемент отображаемости.
                            XmlNode controlVisible = controlNode[xmlNodeNameVisible];
                            if (controlVisible == null)
                            {
                                // Создаем его, если его нет.
                                controlVisible = localParams.CreateElement(xmlNodeNameVisible);
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

        #region Список выбранных элементов в списке.

        private const string xmlNodeNameCheckedItems = "CheckedItems";
        private const string xmlNodeNameItem = "Item";

        internal static void LoadListCheckedItems(Form form, CheckedListBox listBox)
        {
            if (!string.IsNullOrEmpty(listBox.Name))
            {
                // Форма и ее имя не нуль.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфигурации программы.
                    XmlNode root = localParams[ProgramConfiguraton.trainerRootNodeName];
                    if (root != null)
                    {
                        // Элемент формы.
                        XmlNode formNode = root[form.Name];
                        if (formNode != null)
                        {
                            // Элемент контрола.
                            XmlNode controlNode = formNode[listBox.Name];
                            if (controlNode != null)
                            {
                                XmlNode items = controlNode[xmlNodeNameCheckedItems];
                                if (items != null)
                                {
                                    foreach (XmlNode item in items.ChildNodes)
                                    {
                                        for (int i = 0; i < listBox.Items.Count; i++)
                                        {
                                            object listItem = listBox.Items[i];
                                            if (listItem.ToString() == item.InnerText)
                                            {
                                                listBox.SetItemChecked(i, true);
                                                break;
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

        internal static void SaveListCheckedItems(Form form, CheckedListBox listBox)
        {
            // Если имя параметра, контрол и его имя не нулевые.
            if (listBox != null && !string.IsNullOrEmpty(listBox.Name))
            {
                // Форма, содержащая данную форму.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфиг-файла.
                    XmlNode root = localParams[ProgramConfiguraton.trainerRootNodeName];
                    if (root == null)
                    {
                        // Создаем корневой элемент, если его нет.
                        root = localParams.CreateElement(ProgramConfiguraton.trainerRootNodeName);
                        localParams.AppendChild(root);
                    }

                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode == null)
                    {
                        // Создаем его, если его нет.
                        formNode = localParams.CreateElement(form.Name);
                        root.AppendChild(formNode);
                    }

                    // Элемент контрола.
                    XmlNode listNode = formNode[listBox.Name];
                    if (listNode == null)
                    {
                        // Создаем его, если его нет.
                        listNode = localParams.CreateElement(listBox.Name);
                        formNode.AppendChild(listNode);
                    }

                    // Элемент Списка выбранных элементов.
                    XmlNode itemsNode = listNode[xmlNodeNameCheckedItems];
                    if (itemsNode == null)
                    {
                        // Создаем его, если его нет.
                        itemsNode = localParams.CreateElement(xmlNodeNameCheckedItems);
                        listNode.AppendChild(itemsNode);
                    }

                    itemsNode.InnerText = string.Empty;
                    foreach (object item in listBox.CheckedItems)
                    {
                        XmlNode controlParamValue = localParams.CreateElement(xmlNodeNameItem);
                        itemsNode.AppendChild(controlParamValue);

                        controlParamValue.InnerText = item.ToString();
                    }
                }
            }
        }

        #endregion Список выбранных элементов в списке.

        #endregion Контролы.

        #endregion Методы для работы интерфейсом форм.
    }
}
