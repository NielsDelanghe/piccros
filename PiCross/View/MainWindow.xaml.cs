using DataStructures;
using PiCross;
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
using Grid = DataStructures.Grid;
using Size = DataStructures.Size;
using ViewModel;
using System.Globalization;
using Cells;
using System.ComponentModel;
using System.Windows.Threading;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer player;
        private List<string> songs;
        private static Random rng = new Random();


        public MainWindow()
        {
            songs = new List<string>();
            songs.Add("../AvengersEndgame.mp3");
            
            

            InitializeComponent();

            var navigatorVM = new Navigator();
            this.DataContext = navigatorVM;


            player = new MediaPlayer();
            player.MediaEnded += OnMediaEnded;
            var randomSongs = songs.OrderBy(a => rng.Next());
            player.Open(new Uri((randomSongs.ElementAt(0)).ToString(), UriKind.Relative));
            player.Play();

        }

        private void OnMediaEnded(object sender, EventArgs e)
        {
            var randomSongs = songs.OrderBy(a => rng.Next());
            player.Open(new Uri((randomSongs.ElementAt(0)).ToString(), UriKind.Relative));
            player.Play();
        }

        
    }

}

    



    

