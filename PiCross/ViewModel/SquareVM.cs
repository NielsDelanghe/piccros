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
            this.clickRectangle = new ClickRectangleCommand(this.square);
            
        }

        public Cell<Square> Contents => square.Contents;

        public ICommand clickRectangle { get; }

        private class ClickRectangleCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private readonly IPlayablePuzzleSquare square;

            public ClickRectangleCommand(IPlayablePuzzleSquare square)
            {
                this.square = square;
            }

            public bool CanExecute(object parameter)
            {
               return true;
            }

            public void Execute(object parameter)
            {
                square.Contents.Value = Square.FILLED;
            }
        }
    }
}
