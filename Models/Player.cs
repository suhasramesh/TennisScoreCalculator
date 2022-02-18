﻿using MvvmBase;
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

        public double SetsWon { get; set; }

        public List<double> SetPoints { get; set; }

        public bool HasWin { get; set; }

        public bool Advantage { get; set; }

        public int CurrentScore { get; set; }

        public Player() { }
        public Player(string name)
        {
            this.Name = name;
        }
    }
}
