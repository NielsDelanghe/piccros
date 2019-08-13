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
            //songs.Add("Music/AvengersEndgame.mp3");
            songs.Add("D:/UCLL2018-2019/Semester2/Programmeren van visuele gebruikersomgeving/Opdracht/picross-1819-NielsDelanghe/PiCross/View/Music/AvengersEndgame.mp3");
            
            

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

    public class PuzzleCompletedBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return new SolidColorBrush(Colors.LightGreen);
            }



            else
            {
                return new SolidColorBrush(Colors.WhiteSmoke);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PuzzleCompletedTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return "Proficiat u heeft de puzzel opgelost";


            }

            else
            {
                return "Deze puzzel is nog niet opgelost";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ConstraintsToSatisfiedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //var constraint = (ConstraintsVM)value;

            if ((bool)value)
            {
                return new SolidColorBrush(Colors.Green);

            }

            else
            {
                return new SolidColorBrush(Colors.Red);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ConstraintsToSatisfiedConverterX : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //var constraint = (ConstraintsVM)value;

            if ((bool)value)
            {
                return new SolidColorBrush(Colors.White);

            }

            else
            {
                return new SolidColorBrush(Colors.Orange);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AddedTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(bool)value)
            {
                return "No player added yet";
            }



            else
            {
                return "Player added";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PuzzleNameTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String g1 = value.ToString().Substring(11);
            String g2 = value.ToString().Substring(14);

            char[] textChar = value.ToString().ToCharArray();
            String text = "Puzzle " + textChar[11].ToString() + " X " + textChar[14].ToString();
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

    



    

