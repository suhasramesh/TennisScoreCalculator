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
            
            John.CurrentPoints = 40;
            Kevin.CurrentPoints = 30;
            John.SetPoints[0].GamePoints = 6;
            Kevin.SetPoints[0].GamePoints = 5;
            
            Analyser.SelectedServingPlayer = John;
            Analyser.PushResult(PointTypeEnum.PT_Ace);
            Assert.True(John.SetPoints.Count == 3);
            Assert.True(Kevin.SetPoints.Count == 3);
            Assert.True(John.SetPoints[0].GamePoints == 7);
            Assert.True(John.HasGameWin == true);
            Assert.True(Analyser.Player1CurrentSet.GamePoints == 0);
            Assert.True(John.CurrentPoints == 0);

            Analyser.SelectedServingPlayer = Kevin;
            Analyser.PushResult(PointTypeEnum.PT_Ace);
            Analyser.PushResult(PointTypeEnum.PT_Fault);
            Analyser.PushResult(PointTypeEnum.PT_FaultOnServe);
            Analyser.PushResult(PointTypeEnum.PT_FaultOnServe);
            Analyser.PushResult(PointTypeEnum.PT_FaultOnServe);
            Analyser.PushResult(PointTypeEnum.PT_Ace);
            Analyser.PushResult(PointTypeEnum.PT_Fault);
            Analyser.PushResult(PointTypeEnum.PT_FaultOnServe);
            Analyser.PushResult(PointTypeEnum.PT_FaultOnServe);

            Assert.True(John.CurrentPoints > 40);
            Assert.True(Kevin.CurrentPoints == 30);
            Assert.True(John.HasGameWin == true);
            Assert.True(Kevin.HasGameWin == false);
            

        }
    }
}
