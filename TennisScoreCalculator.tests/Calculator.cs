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
        [StaFact]
        public void GetPlayerList_Test()
        {
            TennisRefereeViewModel Analyser = new TennisRefereeViewModel();
            Analyser.SelectedSetCount = SetCountEnum.SC_Three;
            Analyser.MatchStartCommand.Execute(null);

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
            Assert.True(John.Performace.Aces == 1);

            Kevin.SetPoints[1].GamePoints = 5;
            John.SetPoints[1].GamePoints = 3;

            Analyser.SelectedServingPlayer = John;
            Analyser.PushResult(PointTypeEnum.PT_Ace);
            Assert.True(John.Performace.Aces == 2);
            Assert.True(John.CurrentPoints == 15);
            Analyser.PushResult(PointTypeEnum.PT_Fault);
            Assert.True(Kevin.CurrentPoints == 15);
            Analyser.PushResult(PointTypeEnum.PT_FaultOnServe);
            Analyser.PushResult(PointTypeEnum.PT_FaultOnServe);
            Assert.True(John.Performace.DoubleFaults == 1);
            Assert.True(Kevin.CurrentPoints == 30);
            Analyser.PushResult(PointTypeEnum.PT_FaultOnServe);
            Analyser.PushResult(PointTypeEnum.PT_Ace);
            Assert.True(John.Performace.Aces == 3);
            Assert.True(John.Performace.SecondServePoints == 1);
            Assert.True(John.CurrentPoints == 30);
            Analyser.PushResult(PointTypeEnum.PT_Fault);
            Assert.True(Kevin.CurrentPoints == 40);
            Analyser.PushResult(PointTypeEnum.PT_FaultOnServe);
            Analyser.PushResult(PointTypeEnum.PT_FaultOnServe);
            Assert.True(John.Performace.DoubleFaults == 2);
            Assert.True(Kevin.HasGameWin == true);
            Assert.True(John.HasGameWin == false);


            Assert.True(Kevin.SetsWonCount == 1);
            Assert.True(John.SetsWonCount == 1);

            Kevin.SetPoints[2].GamePoints = 3;
            John.SetPoints[2].GamePoints = 0;

            Analyser.SelectedServingPlayer = Kevin;
            Analyser.PushResult(PointTypeEnum.PT_Ace);
            Analyser.PushResult(PointTypeEnum.PT_Ace);
            Analyser.PushResult(PointTypeEnum.PT_Ace);
            Analyser.PushResult(PointTypeEnum.PT_Ace);
            Assert.True(Kevin.Performace.Aces == 4);
            Analyser.PushResult(PointTypeEnum.PT_Fault);
            Analyser.PushResult(PointTypeEnum.PT_Ace);
            Assert.True(Kevin.Performace.Aces == 5);
            Assert.True(Kevin.Performace.SecondServePoints == 1);
            Analyser.CheckMatchWin();
            Assert.True(Kevin.MatchWon == true);



        }
    }
}
