using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ScoreAnalyser: Player
    {
        const string m_PlayerName1 = "John";
        const string m_PlayerName2 = "Kevin";
        #region Properties		
        private IList<Player> m_Players = new List<Player>();
        public IList<Player> Players
        {
            get => m_Players;
            set
            {
                m_Players = value;
                InvokePropertyChanged(() => Players);
            }
        }

        private Player m_SelectedPointPlayer = null;
        public Player SelectedPointPlayer
        {
            get => m_SelectedPointPlayer;
            set
            {
                m_SelectedPointPlayer = value;
                InvokePropertyChanged(() => SelectedPointPlayer);
            }
        }

        private bool m_Deuce = false;
        public bool Deuce
        {
            get => m_Deuce;
            set
            {
                m_Deuce = value;
                InvokePropertyChanged(() => Deuce);
            }
        }

        private bool m_PlayerChanged = false;
        public bool PlayerChanged
        {
            get => m_PlayerChanged;
            set
            {
                m_PlayerChanged = value;
                InvokePropertyChanged(() => PlayerChanged);
            }
        }
        #endregion
        private Player Player1 { get; set; }
        private Player Player2 { get; set; }

        public bool PreviousServeOnFault { get; set; }
        public bool PreviousServePoint { get; set; }

        public void AddPlayers()
        {
            Players = new List<Player>();
            Player1 = new Player(m_PlayerName1);
            Player2 = new Player(m_PlayerName2);
            Players.Add(Player1);
            Players.Add(Player2);
        }
        private int GetPlayerCurrentPoints(int currentPoints)
        {
            currentPoints += 15;
            if (currentPoints == 45)
            {
                currentPoints = 40;
            }
            return currentPoints;
        }
        public void PushResult(PointTypeEnum selectedPointType)
        {
            if (selectedPointType == PointTypeEnum.PT_Ace)
            {
                SelectedPointPlayer.Performace.Aces++;
            }
            else if (selectedPointType == PointTypeEnum.PT_FaultOnServe && PreviousServeOnFault && !PlayerChanged)
            {
                SelectedPointPlayer.Performace.DoubleFaults++;
                PreviousServeOnFault = false;
            }
            else if (selectedPointType == PointTypeEnum.PT_FaultOnServe && !PreviousServeOnFault)
            {
                PreviousServeOnFault = true; // store previous result
                return;
            }
           // else if (selectedPointType == PointTypeEnum.PT_Point && (PreviousServePoint|| PlayerChanged))
           // {
           //     SelectedPointPlayer.Performace.FirstServePoints++;
           // }
           //else if(selectedPointType == PointTypeEnum.PT_Point && !PreviousServePoint && !PlayerChanged)
           // {
           //     SelectedPointPlayer.Performace.SecondServePoints++;
           // }

            foreach (var player in Players)
            {
                if(SelectedPointPlayer.Name == player.Name && (selectedPointType == PointTypeEnum.PT_Point || selectedPointType == PointTypeEnum.PT_Ace))
                {
                    ServeCompleted(player.Name);
                }
                else if(SelectedPointPlayer.Name != player.Name && (selectedPointType == PointTypeEnum.PT_Fault || selectedPointType == PointTypeEnum.PT_FaultOnServe))
                {
                    ServeCompleted(player.Name);
                }
            }
            PlayerChanged = false;

            PreviousServePoint = (selectedPointType == PointTypeEnum.PT_Point || selectedPointType == PointTypeEnum.PT_Ace) ? true : false;
        }
        public void ServeCompleted(string playerNameWithPoint)
        {
            try
            {
                if (playerNameWithPoint == Player1.Name)
                {
                    Player1.CurrentPoints = GetPlayerCurrentPoints(Player1.CurrentPoints);
                }
                else if(playerNameWithPoint == Player2.Name)
                {
                    Player2.CurrentPoints = GetPlayerCurrentPoints(Player2.CurrentPoints);
                }
                //Check deuce condition
                Deuce = false;
                Player1.Advantage = false;
                Player2.Advantage = false;
                Player1.HasGameWin = false;
                Player2.HasGameWin = false;

                if (CheckDeuce())
                {
                    Deuce = true;
                }
                else if(CheckGamePointWin())// Check win
                {
                    if (Player1.HasGameWin)
                    {
                        Player1.CurrentSet.GamePoints++;
                    }
                    else
                    {
                        Player2.CurrentSet.GamePoints++;

                    }
                    bool setWinPlayer1 = Player1.CurrentSet.GamePoints >= Player2.CurrentSet.GamePoints + 2 ? true : false;
                    bool setWinPlayer2 = Player2.CurrentSet.GamePoints >= Player1.CurrentSet.GamePoints + 2 ? true : false;
                    if (setWinPlayer1 || setWinPlayer2)
                    {
                        Player1.CurrentSet = new Sets();
                        Player1.CurrentPoints = 0;
                        Player1.SetPoints.Add(Player1.CurrentSet);

                        Player2.CurrentSet = new Sets();
                        Player2.CurrentPoints = 0;
                        Player2.SetPoints.Add(Player2.CurrentSet);
                    }
                }
                else
                {
                    CheckAdvantage();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught while reading: {0}", e.Message);
            }
        }

        private bool CheckDeuce()
        {
            return Player1.CurrentPoints == Player2.CurrentPoints && Player1.CurrentPoints >= 40;
        }
        private void CheckAdvantage()
        {
           Player1.Advantage = Player1.CurrentPoints > 40 && Player1.CurrentPoints > Player2.CurrentPoints;
           Player2.Advantage = Player2.CurrentPoints > 40 && Player2.CurrentPoints > Player1.CurrentPoints;
        }
        private bool CheckGamePointWin()
        {
            Player1.HasGameWin = Player1.CurrentPoints > 40 
                                 && (Player1.CurrentPoints >= Player2.CurrentPoints + 30 || Player2.CurrentPoints <= 30);
            Player2.HasGameWin = Player2.CurrentPoints > 40 
                                 && (Player2.CurrentPoints >= Player1.CurrentPoints + 30 || Player1.CurrentPoints <= 30);
            return Player1.HasGameWin || Player2.HasGameWin;
        }
    }
}
