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

    public class ControlBarViewModel: BaseViewModel
    {
        #region cmd
        public ICommand CloseWindowCmd { get; set; }
        public ICommand RestoreWindowCmd { get; set; }
        public ICommand MinimizeWindowCmd { get; set; }
        public ICommand MouseMoveWindowCmd { get; set; }
        #endregion

        public ControlBarViewModel()
        {
            #region ControlBar handlers
            // Close Window
            CloseWindowCmd = new RelayCommand<UserControl>(
                                    (p) => { return p == null ? false : true; },
                                    (p) => {
                                        FrameworkElement window = GetParentWindow(p);
                                        var w = (window as Window);
                                        if (w != null)
                                        {
                                            w.Close();
                                        }
                                    });
            // Restore Up&Down Window
            RestoreWindowCmd = new RelayCommand<UserControl>(
                                    (p) => { return p == null ? false : true; },
                                    (p) => {
                                        FrameworkElement window = GetParentWindow(p);
                                        var w = (window as Window);
                                        if (w != null)
                                        {
                                            // Check window state: maximized or minimized
                                            if (w.WindowState != WindowState.Maximized)
                                            {
                                                w.WindowState = WindowState.Maximized;
                                            }
                                            else
                                            {
                                                w.WindowState = WindowState.Normal;
                                            }
                                        }
                                    });
            // Minimize Window
            MinimizeWindowCmd = new RelayCommand<UserControl>(
                                    (p) => { return p == null ? false : true; },
                                    (p) => {
                                        FrameworkElement window = GetParentWindow(p);
                                        var w = (window as Window);
                                        if (w != null)
                                        {
                                            w.WindowState = WindowState.Minimized;
                                        }
                                    });
            // Mouse left button down move Window
            MouseMoveWindowCmd = new RelayCommand<UserControl>(
                                    (p) => { return p == null ? false : true; },
                                    (p) => {
                                        FrameworkElement window = GetParentWindow(p);
                                        var w = (window as Window);
                                        w.DragMove();
                                    });
            #endregion




        }

        /// <summary>
        /// Get real parent of UserControl p
        /// </summary>
        /// <param name="p">UserControl</param>
        /// <returns>real parent of p</returns>
        FrameworkElement GetParentWindow(UserControl p)
        {
            FrameworkElement parent = p;
            
            while (parent.Parent != null){
                parent = parent.Parent as FrameworkElement;
            }

            return parent;
        }
    }
}
