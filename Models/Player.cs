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
        public string Name { get;}

        public PerfomanceAnalyser Performace { get; set; }
        
        public List<Sets> SetPoints { get; set; }

        public bool HasGameWin { get; set; }

        public bool Advantage { get; set; }
        private int m_CurrentPoints = 0;
        public int CurrentPoints
        {
            get => m_CurrentPoints;
            set
            {
                m_CurrentPoints = value;
                InvokePropertyChanged(() => CurrentPoints);
            }
        }
        public Player(string name = "") 
        {
            this.Name = name;
            this.SetPoints = new List<Sets>();
            this.Performace = new PerfomanceAnalyser();
            //SR: Initailly 3 sets are added, used this for better visúalisation
            for (int iSet = 0; iSet < 3; iSet++)
            {
                var set = new Sets();
                set.GamePoints = 0;
                set.SetNumber = iSet + 1;
                this.SetPoints.Add(set);
            }
        }
    }
}
