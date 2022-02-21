using MvvmBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PerfomanceAnalyser: NotifyPropertyChanged
    {
        #region properties
        private double m_Aces;
        public double Aces
        {
            get => m_Aces;
            set
            {
                m_Aces = value;
                InvokePropertyChanged(() => Aces);
            }
        }

        private double m_DoubleFaults;
        public double DoubleFaults
        {
            get => m_DoubleFaults;
            set
            {
                m_DoubleFaults = value;
                InvokePropertyChanged(() => DoubleFaults);
            }
        }

        private double m_FirstServePoints;
        public double FirstServePoints
        {
            get => m_FirstServePoints;
            set
            {
                m_FirstServePoints = value;
                InvokePropertyChanged(() => FirstServePoints);
            }
        }

        private double m_SecondServePoints;
        public double SecondServePoints
        {
            get => m_SecondServePoints;
            set
            {
                m_SecondServePoints = value;
                InvokePropertyChanged(() => SecondServePoints);
            }
        }
        #endregion
    }
}
