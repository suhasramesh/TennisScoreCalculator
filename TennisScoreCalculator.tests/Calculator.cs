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

            Player John = players[0];
            Player Kevin = players[1];
            
            John.CurrentScore = 40;
            Kevin.CurrentScore = 30;
            Analyser.ServeCompleted(Kevin.Name);

            Assert.True(Kevin.CurrentScore == 40);
            Assert.True(John.CurrentScore == 40);
            Assert.True(Analyser.Deuce == true);

            Analyser.ServeCompleted(John.Name);
            Assert.True(John.CurrentScore > 40);
            Assert.True(John.Advantage == true);
            Assert.True(Analyser.Deuce == false);


            Analyser.ServeCompleted(Kevin.Name);
            Assert.True(John.CurrentScore > 40);
            Assert.True(Kevin.CurrentScore > 40);
            Assert.True(Analyser.Deuce == true);


            Analyser.ServeCompleted(John.Name);
            Assert.True(John.CurrentScore > 40);
            Assert.True(Kevin.CurrentScore > 40);
            Assert.True(Kevin.Advantage == false);
            Assert.True(John.Advantage == true);

            Analyser.ServeCompleted(John.Name);
            Assert.True(Kevin.Advantage == false);
            Assert.True(John.Advantage == false);
            Assert.True(John.HasWin == true);

        }
    }
}
