using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisPageControler.ViewModels
{
    public class TennisScoringViewModel: Player
    {
        #region Properties		
        private Player m_Player1 = new Player("Rock");
        public Player Player1
        {
            get => m_Player1;
            set
            {
                m_Player1 = value;
                InvokePropertyChanged(() => Player1);
            }
        }

        private Player m_Player2 = new Player("Sand");
        public Player Player2
        {
            get => m_Player2;
            set
            {
                m_Player2 = value;
                InvokePropertyChanged(() => Player2);
            }
        }
        #endregion
        public TennisScoringViewModel()
        {            
        }
    }
}
