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

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();

            var puzzle = Puzzle.FromRowStrings(
                "xxxxx",
                "x...x",
                "x...x",
                "x...x",
                "xxxxx"
             );

            var facade = new PiCrossFacade();
            var playablePuzzle = facade.CreatePlayablePuzzle(puzzle);
          
            var playablePuzzleVM = new PlayablePuzzleVM(playablePuzzle);

            //playablePuzzle.Grid[new DataStructures.Vector2D(0, 0)].Contents.Value = Square.FILLED;
            //playablePuzzle.Grid[new DataStructures.Vector2D(1, 0)].Contents.Value = Square.EMPTY;

            this.DataContext = playablePuzzleVM;
            
            //picrossController.Grid = playablePuzzle.Grid;
            //picrossController.RowConstraints = playablePuzzle.RowConstraints; //cijfers rijen
            //picrossController.ColumnConstraints = playablePuzzle.ColumnConstraints; //cijfers kolomen

        }

        //private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    var rect = (Rectangle)sender;
        //    var tag = rect.Tag;
        //    var square = (IPlayablePuzzleSquare)tag;

        //    square.Contents.Value = Square.FILLED;



        //}


    }

}
