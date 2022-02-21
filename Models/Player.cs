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
        private IList<Sets> m_SetPoints = new List<Sets>();
        public IList<Sets> SetPoints
        {
            get => m_SetPoints;
            set
            {
                m_SetPoints = value;
                InvokePropertyChanged(() => SetPoints);
            }

        }

        public bool HasGameWin { get; set; }
        
        private bool m_Advantage = false;
        public bool Advantage
        {
            get => m_Advantage;
            set
            {
                m_Advantage = value;
                InvokePropertyChanged(() => Advantage);
            }
        }

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


        public uint SetsWonCount { get;set; }

        private bool m_MatchWon = false;
        public bool MatchWon
        {
            get => m_MatchWon;
            set
            {
                m_MatchWon = value;
                InvokePropertyChanged(() => MatchWon);
            }
        }

        private bool m_IsServe = false;
        public bool IsServe
        {
            get => m_IsServe;
            set
            {
                m_IsServe = value;
                InvokePropertyChanged(() => IsServe);
            }
        }

        public string Name { get; }

        public PerfomanceAnalyser Performace { get; set; }

        public Player(string name = "") 
        {
            this.Name = name;
            this.SetPoints = new List<Sets>();
            this.Performace = new PerfomanceAnalyser();
            //SR: Initailly 3 sets are added, used this for better visúalisation
            for (int iSet = 0; iSet < 3; iSet++)
            {
                var set = new Sets();
                this.SetPoints.Add(set);
            }
        }
    }
}
