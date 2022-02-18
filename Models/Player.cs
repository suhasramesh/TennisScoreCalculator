using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player
    {
        string Name { get; }

        PerfomanceAnalyser Performace { get; set; }

        double SetsWon { get; set; }

        public Player(string name)
        {
            this.Name = name;
        }
    }
}
