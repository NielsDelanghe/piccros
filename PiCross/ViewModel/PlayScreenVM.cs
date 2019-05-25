using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using DataStructures;
using Cells;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows.Controls;

namespace ViewModel
{
    public class PlayScreenVM : ScreenVM, INotifyPropertyChanged
    {

        private TimeSpan accumulatedTime;
        private DateTime lastTick;
        private DispatcherTimer timer;

        public PlayScreenVM(Navigator navigator, Puzzle puzzle) : base(navigator)
        {
            GoToSelectionScreen = new SwitchScreenCommand(() => SwitchTo(new SelectionScreenVM(navigator)));
           
            this.puzzle = puzzle;
            this.facade = new PiCrossFacade();
            this.playablePuzzle = facade.CreatePlayablePuzzle(this.puzzle);
            this.playablePuzzleVM = new PlayablePuzzleVM(playablePuzzle);
            this.RowConstraints = playablePuzzleVM.RowConstraints;
            this.ColumnConstraints = playablePuzzleVM.ColumnConstraints;
            this.Grid = playablePuzzleVM.Grid;
            this.IsSolved = playablePuzzle.IsSolved;
    
            ResetPuzzle = new SwitchScreenCommand(() => SwitchTo(new PlayScreenVM(navigator, puzzle)));

            lastTick = DateTime.Now;
            timer = new DispatcherTimer(TimeSpan.FromMilliseconds(10), DispatcherPriority.Background, OnTimerTick, Dispatcher.CurrentDispatcher);
            timer.IsEnabled = true;
            
            
            
        }

        public TimeSpan Time
        {
            get
            {
                return accumulatedTime;
            }
            set
            {
                accumulatedTime = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Time)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnTimerTick(object sender, EventArgs args)
        {
            if(this.IsSolved.Value)
            {
                this.timer.IsEnabled = false;
            }

            else
            {
                var now = DateTime.Now;
                Time += now - lastTick;
                lastTick = now;
            }

            

           
        }


        public ICommand GoToSelectionScreen { get; }
        public ICommand ResetPuzzle { get; }
        public Puzzle puzzle;

        public PiCrossFacade facade;
        public IPlayablePuzzle playablePuzzle { get; }
        public PlayablePuzzleVM playablePuzzleVM { get; }

        public IGrid<SquareVM> Grid { get; }
        public ISequence<ConstraintsVM> RowConstraints { get; }
        public ISequence<ConstraintsVM> ColumnConstraints { get; }
        public Cell<bool> IsSolved { get; }
        public ICommand GetUsername { get;}
        public string name;

        
        
    }

    

    public class ConstraintsToSatisfiedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //var constraint = (ConstraintsVM)value;

            if ((bool)value)
            {
                return new SolidColorBrush(Colors.Green);
                
            }

            else
            {
                return new SolidColorBrush(Colors.Red);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    

    public class PuzzleCompletedTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return "Proficiat u heeft de puzzel opgelost";
               
                
            }

            else
            {
                return "Deze puzzel is nog niet opgelost";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class PuzzleCompletedBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return new SolidColorBrush(Colors.LightGreen);
            }

            

            else
            {
                return new SolidColorBrush(Colors.WhiteSmoke);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }



}
