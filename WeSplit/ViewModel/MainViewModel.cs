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
        public ICommand ShowAddJourneyView { get; set; }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        public MainViewModel()
        {
            ShowAddJourneyView = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //handle logic here
            });

            AddJourneyCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MessageBox.Show(Name);
            });
        }
    }
}
