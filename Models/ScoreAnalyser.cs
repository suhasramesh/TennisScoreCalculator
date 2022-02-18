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

        private Player m_ServingPlayer = null;
        public Player ServingPlayer
        {
            get => m_ServingPlayer;
            set
            {
                m_ServingPlayer = value;
                InvokePropertyChanged(() => ServingPlayer);
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
        #endregion
        private Player Player1 { get; set; }
        private Player Player2 { get; set; }

        public void AddPlayers()
        {
            Players = new List<Player>();
            Player1 = new Player(m_PlayerName1);
            Player2 = new Player(m_PlayerName2);
            Players.Add(Player1);
            Players.Add(Player2);
        }
        private int GetPlayerCurrentScore(int currentScore)
        {
            currentScore += 15;
            if (currentScore == 45)
            {
                currentScore = 40;
            }
            return currentScore;
        }
        public void ServeCompleted(string playerNameWithPoint)
        {
            try
            {
                if (playerNameWithPoint == Player1.Name)
                {
                    Player1.CurrentScore = GetPlayerCurrentScore(Player1.CurrentScore);
                }
                else if(playerNameWithPoint == Player2.Name)
                {
                    Player2.CurrentScore = GetPlayerCurrentScore(Player2.CurrentScore);
                }
                //Check deuce condition
                Deuce = false;
                Player1.Advantage = false;
                Player2.Advantage = false;
                Player1.HasWin = false;
                Player2.HasWin = false;

                if (CheckDeuce())
                {
                    Deuce = true;
                }
                else if(CheckSetPointWin())// Check win
                {
                    if (Player1.HasWin)
                    {
                        Player1.SetPoint++;
                    }
                    else
                    {
                        Player2.SetPoint++;
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
            return this.Player1.CurrentScore == this.Player2.CurrentScore && this.Player1.CurrentScore >= 40;
        }
        private void CheckAdvantage()
        {
           Player1.Advantage = Player1.CurrentScore > 40 && Player1.CurrentScore > Player2.CurrentScore;
           Player2.Advantage = Player2.CurrentScore > 40 && Player2.CurrentScore > Player1.CurrentScore;
        }

        private bool CheckSetPointWin()
        {
            Player1.HasWin = Player1.CurrentScore > 40 && Player1.CurrentScore >= Player2.CurrentScore + 30;
            Player2.HasWin = Player2.CurrentScore > 40 && Player2.CurrentScore >= Player1.CurrentScore + 30;
            return Player1.HasWin || Player2.HasWin;
        }
    }
}
