using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class IntroductionPlayScreenVM : ScreenVM
    {
        private List<String> players;
        private IPlayerLibrary playerLibrary;
        public IntroductionPlayScreenVM(Navigator navigator, List<String> players) : base(navigator)
        {
            this.players = players;
            
            GoToLoginScreen = new SwitchScreenCommand(() => SwitchTo(new LoginScreenVM(navigator,players)));
            this.GoToAddUserScreen = new SwitchScreenCommand(() => SwitchTo(new AddPlayerScreenVM(navigator)));
        }
        

        public ICommand GoToLoginScreen { get; }
        public ICommand GoToAddUserScreen { get; }
    }
}
