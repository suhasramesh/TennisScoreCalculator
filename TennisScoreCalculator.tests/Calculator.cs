using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TennisPageControler.ViewModels;
using Models;

namespace TennisScoreCalculator.tests
{
    public class Calculator
    {
        [Fact]
        public void GetPlayerList_Test()
        {
            TennisScoringViewModel Analyser = new TennisScoringViewModel();
            IList<Player> playersList = Analyser.AddPlayers();

            Assert.True(playersList.Count == 2);
            foreach(var player in playersList)
            {
                Assert.True(!string.IsNullOrEmpty(player.Name));
            }
        }
    }
}
