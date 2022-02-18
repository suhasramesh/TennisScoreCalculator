using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisPageControler.ViewModels
{
    public class TennisScoringViewModel: ScoreAnalyser
    {
        #region Properties		
        #endregion
        public TennisScoringViewModel()
        {
            AddPlayers();
            ServeCompleted();
        }
    }
}
