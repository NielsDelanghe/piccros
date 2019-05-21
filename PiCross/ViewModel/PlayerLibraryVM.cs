using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiCross;

namespace ViewModel
{
    class PlayerLibraryVM
    {
        private IPlayerLibrary playerLibrary { get; }
        private IPlayerProfile PlayerProfile { get; }

        public PlayerLibraryVM(IPlayerLibrary playerLibrary)
        {
            this.playerLibrary = playerLibrary;
            this.CreateNewProfile = this.playerLibrary.CreateNewProfile(PlayerProfile.Name);

            
        }

        public IPlayerProfile CreateNewProfile { get; set; }
        
    }


}
