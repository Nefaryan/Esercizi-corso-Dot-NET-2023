using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEx
{
    public class Country
    {
        public string Name { get; set; }
        public delegate void PositiveChangeEventHandler(object sender, CovidPositiveEventArgs e);
        public event PositiveChangeEventHandler PositiveChange;

        private int positive;

        public int Positive
        {
            get { return positive; }
            set
            {
                if (positive != value)
                {
                    CovidPositiveEventArgs e = new CovidPositiveEventArgs(value);
                    positive = value;
                    OnPositiveChange(e);
                }
            }
        }

        protected virtual void OnPositiveChange(CovidPositiveEventArgs e)
        {
            PositiveChange?.Invoke(this, e);
        }

    }
}
