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
            StartMatch();
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
            AddPlayers();
        }
    }
}
