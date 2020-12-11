using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WeSplit.Helpers
{
    public static class WindowHandler
    {

        /// <summary>
        /// Get real parent of UserControl p
        /// </summary>
        /// <param name="p">UserControl</param>
        /// <returns>real parent of p</returns>
        public static FrameworkElement GetParentWindow(UserControl p)
        {
            FrameworkElement parent = p;

            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }

            return parent;
        }

    }
}
