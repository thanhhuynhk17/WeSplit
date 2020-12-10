using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Timers;

namespace WeSplit.ViewModel
{
    public class SplashScreenViewModel: BaseViewModel
    {
        #region attributes
        private const int MAX_PROGRESS = 100;
        private int progressVal = 0;
        private Timer _timer;

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
            //MessageBox.Show($"{this.IsLoaded} boolean value");
            _timer = new Timer(100);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {


        }


        #endregion
    }
}
