using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeSplit.ViewModel;

namespace WeSplit.UserControlWeSplit
{
    /// <summary>
    /// Interaction logic for HomeContentUC.xaml
    /// </summary>
    public partial class HomeContentUC : UserControl
    {
        public HomeContentUC()
        {
            InitializeComponent();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement window = GetWindowParent(this);
            var w = window as Window;
            var HomeContentUC = (UserControl)w.FindName("HomeUC");
            var NewJourneyUC = (UserControl)w.FindName("NewJourneyUC");
            var DetailJourneyUC = (UserControl)w.FindName("DetailJourneyUC");
            HomeContentUC.Visibility = System.Windows.Visibility.Hidden;
            NewJourneyUC.Visibility = System.Windows.Visibility.Hidden;
            DetailJourneyUC.Visibility = System.Windows.Visibility.Visible;
        }

        FrameworkElement GetWindowParent(FrameworkElement p)
        {
            FrameworkElement parent = p;
            
            while(parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }

            return parent;
        }
    }
}
