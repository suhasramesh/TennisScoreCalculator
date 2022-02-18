using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ScoreAnalyser: Player
    {
        public const string m_PlayerName1 = "John";
        public const string m_PlayerName2 = "Kevin";

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
        #endregion

        public void AddPlayers()
        {
            Players.Add(new Player(m_PlayerName1));
            Players.Add(new Player(m_PlayerName2));
        }
    }
}
