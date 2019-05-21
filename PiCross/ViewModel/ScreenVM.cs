using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public abstract class ScreenVM
    {
        protected readonly Navigator navigator;

        protected ScreenVM(Navigator navigator)
        {
            this.navigator = navigator;
        }

        protected void SwitchTo(ScreenVM screen)
        {
            this.navigator.CurrentScreen = screen;
        }
    }

    public class Navigator : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<string> players = new List<string>();

        private ScreenVM currentScreen;

        public Navigator()
        {
            this.currentScreen = new IntroductionPlayScreenVM(this,players);
        }

        public ScreenVM CurrentScreen
        {
            get
            {
                return currentScreen;
            }
            set
            {
                this.currentScreen = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentScreen)));
            }
        }
    }
}
