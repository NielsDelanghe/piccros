using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ConstraintsVM
    {
        private readonly IPlayablePuzzleConstraints constraints;
        

        public ConstraintsVM(IPlayablePuzzleConstraints constraints)
        {
            this.constraints = constraints;
            this.Values = constraints.Values.Select(v => new ConstrainstValueVM(v)).ToList();
            
        }

        public IList<ConstrainstValueVM> Values { get; }
        public Cell<bool> IsSatisfied => constraints.IsSatisfied;
    }
}
