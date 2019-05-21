using Cells;
using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class AddPlayerScreenVM : ScreenVM
    {
        public string name;
        public List<String> players;
        

        public AddPlayerScreenVM(Navigator navigator) : base(navigator)
        {
            this.players = new List<string>();
            GotToIntroductionScreen = new SwitchScreenCommand(() => SwitchTo(new IntroductionPlayScreenVM(navigator, players)));
            name = "Name";
            
            AddPlayer = new AddPlayerCommand(name, playerLibrary,players);
           
            
            
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

            private void OnNameChanged(object sender, EventArgs args)
            {
                name = Playername;

            }

            public event EventHandler CanExecuteChanged;

            private string name;
            IPlayerLibrary playerLibrary;
            private List<string> players;



            public AddPlayerCommand(string name, IPlayerLibrary playerLibrary, List<String> players)
            {
                
                this.name = name;
                this.playerLibrary = playerLibrary;
                this.players = players;

            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                name = Playername;
                players.Add(name);
                
                //IPlayerDatabase playerDatabase;
                Console.WriteLine(name);
                
                //playerLibrary.CreateNewProfile(name);

            }
        }


    }

   
}
