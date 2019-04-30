using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Input;
using DataStructures;

namespace ViewModel
{


    public class PlayablePuzzleVM
    {
        private readonly IPlayablePuzzle puzzle;

        public PlayablePuzzleVM(IPlayablePuzzle puzzle)
        {
            this.puzzle = puzzle;

            this.RowConstraints = puzzle.RowConstraints.Select(constraint => new ConstraintsVM(constraint)).ToList();
            this.ColumnConstraints = puzzle.ColumnConstraints.Select(constraint => new ConstraintsVM(constraint)).ToList();
            this.Grid = puzzle.Grid.Map(square => new SquareVM(square)).Copy();
        }



        public IGrid<SquareVM> Grid { get; }
        public IList<ConstraintsVM> RowConstraints { get; }
        public IList<ConstraintsVM> ColumnConstraints { get; }




        //private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    var rect = (Rectangle)sender;
        //    var tag = rect.Tag;
        //    var square = (IPlayablePuzzleSquare)tag;

        //    square.Contents.Value = Square.FILLED;



        //}


    }
}
