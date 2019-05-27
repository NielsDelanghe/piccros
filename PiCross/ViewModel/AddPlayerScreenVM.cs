using Cells;
using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace ViewModel
{
    public class AddPlayerScreenVM : ScreenVM
    {
        public string name;
        public List<String> players;
        public bool added;

        public AddPlayerScreenVM(Navigator navigator) : base(navigator)
        {
            this.players = new List<string>();
            
            GotToIntroductionScreen = new SwitchScreenCommand(() => SwitchTo(new IntroductionPlayScreenVM(navigator, players)));
            name = "Name";
            added = false;
            AddPlayer = new AddPlayerCommand(name, playerLibrary,players, added);
        }


        public ICommand GotToIntroductionScreen { get; }
        public IPlayerLibrary playerLibrary { get; }
        
        public ICommand AddPlayer { get; set; }
       

        


        public class AddPlayerCommand : ICommand, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
           
            public string Playername
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Playername)));
                    
                }
            }

            public bool Added
            {
                get
                {
                    return add;
                }

                set
                {
                    add = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Added)));
                }
            }

            private void OnNameChanged(object sender, EventArgs args)
            {
                name = Playername;

            }

            

            public event EventHandler CanExecuteChanged;

            private string name;
            IPlayerLibrary playerLibrary;
            private List<string> players;

            private bool add;

            public AddPlayerCommand(string name, IPlayerLibrary playerLibrary, List<string> players, bool added)
            {
                
                this.name = name;
                this.playerLibrary = playerLibrary;
                this.players = players;
                this.add = added;
                
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                name = Playername;
                players.Add(name);
                this.Added = true;
              
                //Console.WriteLine(name);

               
            }

        }

    }

    


}
