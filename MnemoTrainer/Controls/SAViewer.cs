using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using SAClasses;

namespace MnemoTrainer.Controls
{
    public partial class SAViewer : UserControl
    {
        public SAViewer()
        {
            InitializeComponent();
        }

        public void SetLines(Collection<PoemLine> SelectedLines)
        {
            {
                Collection<ControlPoemLine> controlsToDelete = new Collection<ControlPoemLine>();

                foreach (Control item in panelLines.Controls)
                {
                    ControlPoemLine controlPoemLine = item as ControlPoemLine;
                    if (controlPoemLine != null)
                    {
                        if (!SelectedLines.Contains(controlPoemLine.PoemLine))
                        {
                            controlsToDelete.Add(controlPoemLine);
                        }
                    }
                }

                panelLines.SuspendLayout();

                foreach (ControlPoemLine item in controlsToDelete)
                {
                    panelLines.Controls.Remove(item);
                }

                foreach (PoemLine line in SelectedLines)
                {
                    ControlPoemLine controlPoemLine = null;
                    foreach (Control item in panelLines.Controls)
                    {
                        ControlPoemLine searchControlPoemLine = item as ControlPoemLine;
                        if (searchControlPoemLine != null)
                        {
                            if (searchControlPoemLine.PoemLine == line)
                            {
                                controlPoemLine = searchControlPoemLine;
                                break;
                            }
                        }
                    }

                    if (controlPoemLine == null)
                    {
                        controlPoemLine = new ControlPoemLine(line);
                        controlPoemLine.Dock = DockStyle.Bottom;

                        panelLines.Controls.Add(controlPoemLine);
                    }

                    int childIndex = panelLines.Controls.GetChildIndex(controlPoemLine);
                    if (childIndex != SelectedLines.IndexOf(line))
                    {
                        panelLines.Controls.SetChildIndex(controlPoemLine, SelectedLines.IndexOf(line));
                    }
                }

                panelLines.ResumeLayout(true);
            }

            this.Select();
        }
    }
}
