using MvvmBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class NavigationModel : NotifyPropertyChanged
    {
        private object m_SelectedViewModel;
        public object SelectedViewModel
        {
            get => m_SelectedViewModel;
            set
            {
                m_SelectedViewModel = value;
                InvokePropertyChanged(() => SelectedViewModel);
            }
        }
    }
}
