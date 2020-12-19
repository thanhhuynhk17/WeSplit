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

        #region CONSTANTS
        private const int MAX_PROGRESS = 100;
        private const int HALF_TIMER = 2;     // seconds
        #endregion

        #region attributes & properties
        // Binding Window
        private Window _BindingWindow;
        public Window BindingWindow { 
            get => _BindingWindow;
            set {
                _BindingWindow = value;
                OnPropertyChanged();
            } 
        }

        // Show screen state
        private bool _IsShowScr;
        public bool IsShowScr {
            get {
                _IsShowScr = bool.Parse(ConfigurationManager.AppSettings["isShowSplashScr"]);
                return _IsShowScr;
            } 
            set { 
                _IsShowScr = value;

                // update config value 
                var config = ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);
                config.AppSettings.Settings["isShowSplashScr"].Value = (value == true) ? "true" : "false";
                config.Save(ConfigurationSaveMode.Minimal);

                OnPropertyChanged(); 
            } 
        }

        // Progress Bar
        private int _ProgressBar = (MAX_PROGRESS - 1) / (HALF_TIMER * 2) + 1;   
        public int ProgressBar{
            get => _ProgressBar;
            set{
                _ProgressBar = (value > MAX_PROGRESS) ? MAX_PROGRESS : value;
                OnPropertyChanged();
            }
        }

        // Time
        private double _CurrentTime;
        public double CurrentTime
        {
            get{ return _CurrentTime; }
            set{
                _CurrentTime = value;
                OnPropertyChanged();
            }
        }

        public ICommand CheckShowScrCmd { get; set; }
        #endregion

        #region constructor & destructor

        public SplashScreenViewModel()
        {
            // Load Splash Screen Window
            LoadedCmd = new RelayCommand<object>(
                                    (p) => { return p == null ? false : true; },
                                    (p) =>{
                                        // get SplashScreenWindow
                                        var window = (FrameworkElement)p;
                                        BindingWindow = (window as Window);

                                        LoadSplashScr();
                                    });

            // Check changed handling
            CheckShowScrCmd = new RelayCommand<object>(
                                        (p) => { return p == null ? false : true; },
                                        (p) => {
                                            var hideScrCheckBox = (CheckBox)p;
                                            IsShowScr = !((bool)hideScrCheckBox.IsChecked);
                                        });
        }
        #endregion

        #region Load Splash Screen Handlers
        /// <summary>
        /// Load Splash Screen
        /// </summary>
        private void LoadSplashScr(){
            if (IsShowScr)
            {   // Start timer: show splash screen first
                StartTimer();
            }else{
                // Hide Splash window
                BindingWindow.Hide();
                // Show main window
                LoadMainWindow();
            }

        }

        /// <summary>
        /// Show main window & Close showed one before
        /// </summary>
        private void LoadMainWindow()
        {

            // show main window
            var mainWindow = new MainWindow();
            mainWindow.Show();

            // close showed window
            var splashScr = BindingWindow;
            if (splashScr != null)
            {
                splashScr.Close();
            }
        }


            
        #endregion

        #region DispatcherTimer for visualizing Progress Bar
        private DispatcherTimer timer;
        private void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += new EventHandler(timer_Tick);
            CurrentTime = HALF_TIMER*2;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // update progress bar value
            ProgressBar += (MAX_PROGRESS - 1) / (HALF_TIMER*2) + 1;  // ceiling division

            // timer ticking
            CurrentTime -= 1;
            if (CurrentTime == 0)
            {
                // Show main window
                LoadMainWindow();

                timer.Stop();
            }
        }
        #endregion



    }
}
