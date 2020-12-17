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

namespace WeSplit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void NewJourneyBtn_Click(object sender, RoutedEventArgs e)
        {
            HomeUC.Visibility = System.Windows.Visibility.Hidden;
            DetailJourneyUC.Visibility = System.Windows.Visibility.Hidden;
            NewPlaceUC.Visibility = System.Windows.Visibility.Hidden;
            NewJourneyUC.Visibility = System.Windows.Visibility.Visible;
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            NewJourneyUC.Visibility = System.Windows.Visibility.Hidden;
            DetailJourneyUC.Visibility = System.Windows.Visibility.Hidden;
            NewPlaceUC.Visibility = System.Windows.Visibility.Hidden;
            HomeUC.Visibility = System.Windows.Visibility.Visible;
        }

        private void NewPlaceBtn_Click(object sender, RoutedEventArgs e)
        {
            HomeUC.Visibility = System.Windows.Visibility.Hidden;
            DetailJourneyUC.Visibility = System.Windows.Visibility.Hidden;
            HomeUC.Visibility = System.Windows.Visibility.Hidden;
            NewPlaceUC.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
