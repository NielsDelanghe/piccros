using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ConstrainstValueVM
    {
        private readonly IPlayablePuzzleConstraintsValue value;

        public ConstrainstValueVM(IPlayablePuzzleConstraintsValue value)
        {
            this.value = value;
        }

        public int Value => value.Value;
    }
}
