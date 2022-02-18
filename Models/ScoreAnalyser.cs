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
            var Player1 = new Player(m_PlayerName1);
            var Player2 = new Player(m_PlayerName2);
            Players.Add(Player1);
            Players.Add(Player2);
        }
        private void GetPlayerCurrentScore(int currentScore)
        {
            currentScore += 15;
            if (currentScore == 45)
            {
                currentScore = 40;
            }
        }
        public void ServeCompleted()
        {
            try
            {
                if (Player1.GotPoint)
                {
                    GetPlayerCurrentScore(Player1.CurrentScore);
                }
                else
                {
                    GetPlayerCurrentScore(Player2.CurrentScore);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught while reading: {0}", e.Message);
            }
        }
    }
}
