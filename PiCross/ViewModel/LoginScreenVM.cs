using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class LoginScreenVM : ScreenVM
    {
        public IList<String> players { get; set; }
        
        public LoginScreenVM(Navigator navigator, List<String> players) : base(navigator)
        {
            this.players = players;
            
            GoToSelectionScreen = new SwitchScreenCommand(() => SwitchTo(new SelectionScreenVM(navigator)));
            GotToIntroductionScreen = new SwitchScreenCommand(() => SwitchTo(new IntroductionPlayScreenVM(navigator, players)));
        }

        public ICommand GoToSelectionScreen { get; }
        public ICommand GotToIntroductionScreen { get; }
        public string SelectedUser { get; set; }
    }
}
