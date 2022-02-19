using Models;
using MVVmBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TennisPageControler.ViewModels
{
    public class TennisScoringViewModel: ScoreAnalyser
    {
        #region Properties	

        private PointTypeEnum m_SelectedPointType ;
        public PointTypeEnum SelectedPointType
        {
            get => m_SelectedPointType;
            set
            {
                m_SelectedPointType = value;
                InvokePropertyChanged(() => SelectedPointType);
            }
        }

        private ICommand m_PushToSpectorsCommand;
        public ICommand PushToSpectorsCommand
        {
            get
            {
                return m_PushToSpectorsCommand;
            }
            set
            {
                m_PushToSpectorsCommand = value;
                InvokePropertyChanged(() => PushToSpectorsCommand);
            }
        }

        private ICommand m_PlayerSelectionChangedCommand;
        public ICommand PlayerSelectionChangedCommand
        {
            get
            {
                return m_PlayerSelectionChangedCommand;
            }
            set
            {
                m_PlayerSelectionChangedCommand = value;
                InvokePropertyChanged(() => PlayerSelectionChangedCommand);
            }
        }

        #endregion
        public TennisScoringViewModel()
        {
            AddPlayers();
            PushToSpectorsCommand = new RelayCommand((o) =>
            {
                PushResult(SelectedPointType);
            });
            PlayerSelectionChangedCommand = new RelayCommand((o) =>
            {
                PlayerChanged = true;
                PreviousServeOnFault = false;
                PreviousServePoint = false;
            });
        }
    }
}
