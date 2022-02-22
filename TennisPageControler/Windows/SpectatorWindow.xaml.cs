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
using TennisPageControler.ViewModels;

namespace TennisPageControler.Windows
{
    /// <summary>
    /// Interaction logic for RefereeWindow.xaml
    /// </summary>
    public partial class SpectatorWindow : Window
    {
        public SpectatorWindow(TennisRefereeViewModel refereeVm)
        {
            NavigationModel NV = new NavigationModel();
            InitializeComponent();
            DataContext = NV;
            NV.SelectedViewModel = refereeVm;
        }
    }
}
