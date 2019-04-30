using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    class GridVM
    {
        private IPlayablePuzzleSquare square;

        public SquareVM SquareVM { get; set; }
        private readonly IGrid<SquareVM> grid;

        public GridVM(IGrid<SquareVM> grid)
        {
            this.grid = grid;
            
        }
    }
}
