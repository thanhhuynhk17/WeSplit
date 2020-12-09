using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WeSplit.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        // Constructor
        bool isLoaded = false;
        public MainViewModel()
        {
            isLoaded = true;
            if (!isLoaded)
            {
                MessageBox.Show($"{isLoaded} boolean value");
            }
        }
    }
}
