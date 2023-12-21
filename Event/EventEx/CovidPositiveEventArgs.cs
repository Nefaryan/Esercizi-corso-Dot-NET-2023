using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEx
{
    public class CovidPositiveEventArgs : EventArgs
    {
        int _newPositivesCount;

        public int NewPositivesCount { get { return _newPositivesCount; } }

        public CovidPositiveEventArgs(int newPositivesCount)
        {
            _newPositivesCount = newPositivesCount;
        }
    }
}
