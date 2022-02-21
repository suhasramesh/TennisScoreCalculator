using MvvmBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Sets : NotifyPropertyChanged
    {
        private int m_GamePoints = -1;
        public int GamePoints
        {
            get => m_GamePoints;
            set
            {
                m_GamePoints = value;
                InvokePropertyChanged(() => GamePoints);
            }
        }
    }
}
