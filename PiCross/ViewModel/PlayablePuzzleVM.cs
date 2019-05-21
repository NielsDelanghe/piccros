using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Input;
using DataStructures;
using Cells;

namespace ViewModel
{


    public class PlayablePuzzleVM
    {
        private readonly IPlayablePuzzle puzzle;


        public PlayablePuzzleVM(IPlayablePuzzle puzzle)
        {
            this.puzzle = puzzle;

            this.RowConstraints = Sequence.FromEnumerable( puzzle.RowConstraints.Select( constraint => new ConstraintsVM( constraint ) ) );
            this.ColumnConstraints = Sequence.FromEnumerable( puzzle.ColumnConstraints.Select( constraint => new ConstraintsVM( constraint ) ) );
            this.Grid = puzzle.Grid.Map(square => new SquareVM(square)).Copy();
            this.IsSolved = puzzle.IsSolved;



        }

        



        public IGrid<SquareVM> Grid { get; }
        public ISequence<ConstraintsVM> RowConstraints { get; }
        public ISequence<ConstraintsVM> ColumnConstraints { get; }
        public Cell<bool> IsSolved { get; }
        




        //private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    var rect = (Rectangle)sender;
        //    var tag = rect.Tag;
        //    var square = (IPlayablePuzzleSquare)tag;

        //    square.Contents.Value = Square.FILLED;



        //}


    }
}
