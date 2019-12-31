using System;
using System.Collections.ObjectModel;

namespace MnemoTrainerLibrary.Classes
{
    public class CheckPointCollection
    {
        private Collection<DateTime> checkPoints;

        public CheckPointCollection()
        {
            this.checkPoints = new Collection<DateTime>();
        }

        public DateTime this[int index]
        {
            get { return this.checkPoints[index]; }
        }

        public int Count
        {
            get { return this.checkPoints.Count; }
        }

        public void Clear()
        {
            this.checkPoints.Clear();
        }

        public void MakeCheckPoint()
        {
            this.checkPoints.Add(DateTime.Now);
        }

        public DateTime? LastCheckPoint
        {
            get
            {
                if (this.checkPoints.Count > 0)
                {
                    return this.checkPoints[this.checkPoints.Count - 1];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
