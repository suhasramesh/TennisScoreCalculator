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
        public string Name { get; }

        public PerfomanceAnalyser Performace { get; set; }
        
        public List<Sets> SetPoints { get; set; }

        public bool HasGameWin { get; set; }

        public bool Advantage { get; set; }

        public int CurrentPoints { get; set; }
        public Sets CurrentSet { get; set; }

        public Player() { }
        public Player(string name)
        {
            this.Name = name;
            this.SetPoints = new List<Sets>();
            this.Performace = new PerfomanceAnalyser();
            this.CurrentSet = new Sets();
            this.SetPoints.Add(this.CurrentSet);
        }
    }
}
