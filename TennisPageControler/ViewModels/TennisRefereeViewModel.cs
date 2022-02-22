using Models;
using MVVmBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TennisPageControler.ViewModels
{
    public class TennisRefereeViewModel : TennisScoringViewModel
    {
        #region Command
        public ICommand PushToSpectorsCommand { get; set; }
        public ICommand MatchStartCommand { get; set; }
        #endregion

        #region Properties	

        private PointTypeEnum m_SelectedPointType;
        public PointTypeEnum SelectedPointType
        {
            get => m_SelectedPointType;
            set
            {
                m_SelectedPointType = value;
                InvokePropertyChanged(() => SelectedPointType);
            }
        }

        private SetCountEnum m_SelectedSetCount;
        public SetCountEnum SelectedSetCount
        {
            get => m_SelectedSetCount;
            set
            {
                m_SelectedSetCount = value;
                InvokePropertyChanged(() => SelectedSetCount);
            }
        }

        private Windows.SpectatorWindow m_SpectatorsWindow;
        public Windows.SpectatorWindow SpectatorsWindow
        {
            get => m_SpectatorsWindow;
            set
            {
                m_SpectatorsWindow = value;
                InvokePropertyChanged(() => SpectatorsWindow);
            }
        }
        private bool m_MatchStarted;
        public bool MatchStarted
        {
            get
            {
                return m_MatchStarted;
            }
            set
            {
                m_MatchStarted = value;
                InvokePropertyChanged(() => MatchStarted);
            }
        }
        #endregion
        public TennisRefereeViewModel()
        {
            MatchStartCommand = new RelayCommand((o) =>
            {
                StartMatch();
            });
            PushToSpectorsCommand = new RelayCommand((o) =>
            {
                PushResult(SelectedPointType);
                if (CheckMatchWin())
                {
                    if (Player1.MatchWon)
                    {
                        MatchWinner = string.Format(Resource.StringResource.MatchWinner, Player1.Name);
                    }
                    else
                    {
                        MatchWinner = string.Format(Resource.StringResource.MatchWinner, Player2.Name);
                    }
                    MatchStarted = false;
                }
            });
        }

        private void StartMatch()
        {
            if(SpectatorsWindow!= null)
            {
                SpectatorsWindow.Close();
            }
            AddPlayers(SelectedSetCount);
            MatchStarted = true;

            SpectatorsWindow = new Windows.SpectatorWindow(this);
            SpectatorsWindow.Show();
        }
    }
}
