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

            IList<Player> players = Analyser.Players;
            Assert.True(players.Count == 2);
            foreach(var player in players)
            {
                Assert.True(!string.IsNullOrEmpty(player.Name));
            }

            players[0].CurrentScore = 40;
            players[1].CurrentScore = 30;

            players[1].GotPoint = true;
            Analyser.ServeCompleted();

            Assert.True(players[1].CurrentScore == 40);
            Assert.True(Analyser.Deuce == true);
        }
    }
}
