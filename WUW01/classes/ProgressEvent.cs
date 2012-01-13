using System;
using System.Collections.Generic;
using System.Text;

namespace WUW01
{
    public class ProgressEventArgs : System.EventArgs
    {
        private double _percent;

        public ProgressEventArgs(double percent)
        {
            _percent = percent;
        }

        public double Percent
        {
            get
            {
                return _percent;
            }
        }
    }
    
    public delegate void ProgressEventHandler(object source, ProgressEventArgs e);
}
