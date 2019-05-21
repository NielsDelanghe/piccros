using Cells;
using PiCross;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace ViewModel
{
    public class SelectionScreenVM : ScreenVM
    {
        public SelectionScreenVM(Navigator navigator) : base(navigator)
        {
            addPuzzels();

            GoToPlayScreen = new SwitchScreenCommand(() => SwitchTo(new PlayScreenVM(navigator, SelectedPuzzle)));
        }

        public ICommand GoToPlayScreen { get; }

        public Puzzle SelectedPuzzle { get; set; }

        public List<Puzzle> Puzzles { get; } = new List<Puzzle>();

        public void addPuzzels()
        {
            Puzzles.Add(p3x3);
            Puzzles.Add(p5x5);
            Puzzles.Add(p6x6);
            Puzzles.Add(p8x8);
        }


        public Puzzle p5x5 = Puzzle.FromRowStrings(
               "xxxxx",
               "x...x",
               "x...x",
               "x...x",
               "xxxxx"
            );
        public Puzzle p6x6 = Puzzle.FromRowStrings(
            "xxxxxx",
            "xx..xx",
            "x.xx.x",
            "x.xx.x",
            "xx..xx",
            "xxxxxx");

        public Puzzle p8x8 = Puzzle.FromRowStrings(
            "xxx..xxx",
            "...xx...",
            "...xx...",
            "xxx..xxx",
            "xxx..xxx",
            "...xx...",
            "...xx...",
            "xxx..xxx");

        public Puzzle p3x3 = Puzzle.FromRowStrings(
            "x.x",
            ".x.",
            "x.x");
    }

    public class PuzzleNameTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String g1 = value.ToString().Substring(11);
            String g2 = value.ToString().Substring(14);
           
            char[] textChar = value.ToString().ToCharArray();
            String text ="Puzzle "+  textChar[11].ToString() + " X "+ textChar[14].ToString();
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
