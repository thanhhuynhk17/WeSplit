using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Timers;
using System.Windows.Input;
using System.Configuration;
using System.Windows.Controls;

using WeSplit.Helpers;

namespace WeSplit.ViewModel
{
    public class SplashScreenViewModel: BaseViewModel
    {
        #region Cmd
        public ICommand LoadedCmd { get; set; }
        #endregion

        #region attributes
        private const int MAX_PROGRESS = 100;
        private int progressVal = 0;

        #endregion

        #region properties
        public int ProgressVal {
            get { return this.progressVal; }
            set {
                this.progressVal = value;
                if (this.progressVal > MAX_PROGRESS)
                {
                    this.progressVal = MAX_PROGRESS;
                }
            }
        }

        #endregion

        #region constructor & destructor

        public SplashScreenViewModel()
        {
            // Load Splash Screen Window
            LoadedCmd = new RelayCommand<UserControl>(
                                    (p) => { return p == null ? false : true; },
                                    (p) =>{
                                        SplashScreenWindow splashScrWindow = new SplashScreenWindow();
                                        
                                    });
        }
        #endregion

        private void LoadSplashScr(UserControl p)
        {
            // get show state
            var value = ConfigurationManager.AppSettings["isShowSplashScr"];
            var isShowSplashScr = bool.Parse(value);

            // get SplashScreenWindow
            var window = WindowHandler.GetParentWindow(p);
            var splashScr = (window as Window);

            if (isShowSplashScr)
            {
                // show splash screen first

            }
            else{
                // show main window
                var mainWindow = new MainWindow();
                mainWindow.Show();

                // close splash screen window
                if (splashScr != null){
                    splashScr.Close();
                }
            }
        }

        System.Timers.Timer timer;
        int count = 0;
        int target = 5;



    }
}
