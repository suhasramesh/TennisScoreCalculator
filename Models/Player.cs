using MvvmBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player : NotifyPropertyChanged
    {
        string Name { get; }

        PerfomanceAnalyser Performace { get; set; }

        double SetsWon { get; set; }

        List<double> SetPoints { get; set; }

        public Player() { }
        public Player(string name)
        {
            this.Name = name;
        }
    }
}
