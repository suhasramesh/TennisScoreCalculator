using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TennisScoreCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            NavigationModel NV = new NavigationModel();
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            DataContext = NV;
            NV.SelectedViewModel = new TennisPageControler.Pages.TennisScoringPage();
        }
    }
}
