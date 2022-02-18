﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisPageControler.ViewModels
{
    public class TennisScoringViewModel: Player
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
        public TennisScoringViewModel()
        {
            Players =  AddPlayers();
        }

        public IList<Player> AddPlayers()
        {
            var temPlayers = new List<Player>();
            temPlayers.Add(new Player(m_PlayerName1));
            temPlayers.Add(new Player(m_PlayerName2));
            return temPlayers;
        }
    }
}
