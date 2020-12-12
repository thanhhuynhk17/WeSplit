using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WeSplit.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        public ICommand AddJourneyCommand { get; set; }
        
        public MainViewModel()
        {
            AddJourneyCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SplashScreenWindow splash = new SplashScreenWindow();
                splash.ShowDialog();
            });
        }
    }
}
