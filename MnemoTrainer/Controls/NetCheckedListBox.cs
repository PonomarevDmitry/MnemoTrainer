using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace MnemoTrainer.Controls
{
    public class NetCheckedListBox : Label
    {
        public delegate void CheckedItemsChangedEventHandler(object sender, CheckedItemsChangedEventArgs e);

        public class CheckedItemsChangedEventArgs
        {
            public Collection<object> CheckedItems { get; private set; }

            public CheckedItemsChangedEventArgs(Collection<object> checkedItems)
            {
                this.CheckedItems = checkedItems;
            }
        }
        
        private const int periodMilliseconds = 300;

        private DateTime dropDownHideTime;

        #region Свойства.

        private int dropDownHeight = 0;
        public int DropDownHeight
        {
            get { return this.dropDownHeight; }
            set { this.dropDownHeight = value; }
        }

        private ToolStripDropDown dropDown;
        private CheckedListBox listBox;

        public CheckedListBox ListBox
        {
            get { return this.listBox; }
        }

        public override string Text
        {
            get { return base.Text; }
            set { }
        }

        #endregion Свойства.

        public NetCheckedListBox()
        {
            base.AutoSize = false;
            this.BackColor = SystemColors.Window;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.TextAlign = ContentAlignment.MiddleLeft;
            base.Text = "Не выбрана";

            InitializeListBox();

            dropDown = new ToolStripDropDown();
            dropDown.AutoSize = true;

            ToolStripControlHost item = new ToolStripControlHost(listBox);

            dropDown.Items.Add(item);
            dropDown.Closed += new ToolStripDropDownClosedEventHandler(dropDown_Closed);
        }

        private void InitializeListBox()
        {
            listBox = new CheckedListBox();
            listBox.Name = "InnerCheckedListBox";
            listBox.TabStop = false;
            listBox.CheckOnClick = true;
            listBox.IntegralHeight = true;
            listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;

            listBox.ItemCheck += new ItemCheckEventHandler(listBox_ItemCheck);
        }

        #region События.

        public event CheckedItemsChangedEventHandler CheckedItemsChanged;

        protected void OnCheckedItemsChanged(CheckedItemsChangedEventArgs args)
        {
            if (CheckedItemsChanged != null)
            {
                CheckedItemsChanged(this, args);
            }
        }

        #endregion События.

        #region Обработчики событий.

        void listBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Collection<object> checkedItems = new Collection<object>();

            foreach (var item in listBox.CheckedItems)
            {
                checkedItems.Add(item);
            }

            if (e != null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    checkedItems.Add(listBox.Items[e.Index]);
                }
                else
                {
                    checkedItems.Remove(listBox.Items[e.Index]);
                }
            }

            if (checkedItems.Count == 0)
            {
                base.Text = "Не выбрана";
            }
            else if (checkedItems.Count == 1)
            {
                base.Text = checkedItems[0].ToString();
            }
            else
            {
                base.Text = string.Format("Выбрано сеток: {0}.", checkedItems.Count.ToString());
            }

            OnCheckedItemsChanged(new CheckedItemsChangedEventArgs(checkedItems));
        }

        private void dropDown_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            dropDownHideTime = DateTime.UtcNow;
        }

        #endregion Обработчики событий.

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (dropDown != null)
                {
                    if ((DateTime.UtcNow - dropDownHideTime).TotalMilliseconds > periodMilliseconds)
                    {
                        dropDown.Show(this, 0, this.Height + dropDownHeight);
                    }
                    else
                    {
                        dropDownHideTime = DateTime.UtcNow.Subtract(new TimeSpan(0, 0, 0, 0, 2 * periodMilliseconds));
                        Focus();
                    }
                }
            }

            base.OnMouseDown(e);
        }
    }
}