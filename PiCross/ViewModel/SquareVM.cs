using Cells;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class SquareVM
    {
        private readonly IPlayablePuzzleSquare square;
        

        public SquareVM(IPlayablePuzzleSquare square)
        {
            this.square = square;
            this.fillRectangle = new FillRectangleCommand(this.square);
            this.emptyRectangle = new EmptyRectangleCommand(this.square);
            
            
        }

        public Cell<Square> Contents => square.Contents;

        public ICommand fillRectangle { get; }
        public ICommand emptyRectangle { get; }

        private class FillRectangleCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private readonly IPlayablePuzzleSquare square;

            public FillRectangleCommand(IPlayablePuzzleSquare square)
            {
                this.square = square;
            }

            public bool CanExecute(object parameter)
            {
               return true;
            }

            public void Execute(object parameter)
            {
                if(square.Contents.Value == Square.UNKNOWN || square.Contents.Value== Square.EMPTY)
                {
                    square.Contents.Value = Square.FILLED;
                }

                else
                {
                    square.Contents.Value = Square.UNKNOWN;
                }
                
            }
        }

        private class EmptyRectangleCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private readonly IPlayablePuzzleSquare square;

            public EmptyRectangleCommand(IPlayablePuzzleSquare s)
            {
                this.square = s;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                square.Contents.Value = Square.EMPTY;
            }
        }



       
    }
}
