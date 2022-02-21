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
        public ICommand PushToSpectorsCommand { get; set; }
        public ICommand MatchStartCommand { get; set; }

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
        public TennisScoringViewModel()
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
                }
            });
            PlayerSelectionChangedCommand = new RelayCommand((o) =>
            {
                PlayerChanged = true;
                PreviousServeOnFault = false;
                PreviousServePoint = false;
            });
        }

        private void StartMatch()
        {
            AddPlayers(SelectedSetCount);
            MatchStarted = true;
        }
    }
}
