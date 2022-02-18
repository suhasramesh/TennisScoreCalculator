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
        public void ServeCompleted()
        {
            try
            {
                if (Player1.GotPoint)
                {
                    Player1.CurrentScore = GetPlayerCurrentScore(Player1.CurrentScore);
                }
                else if(Player2.GotPoint)
                {
                    Player2.CurrentScore = GetPlayerCurrentScore(Player2.CurrentScore);
                }
                //Check deuce condition
                if (CheckDeuce())
                {
                    Deuce = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught while reading: {0}", e.Message);
            }
        }
        private bool CheckDeuce()
        {
            return this.Player1.CurrentScore == this.Player2.CurrentScore && this.Player1.CurrentScore == 40;
        }
    }
}
