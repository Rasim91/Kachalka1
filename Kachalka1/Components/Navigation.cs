using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kachalka1.Components
{
    public class Navigation
    {
        public static bool IsAutorizate = false;
        public static User AutorizateUser;
        public static MainWindow main;

        public static void Update(Page nav)
        {
            main.MyFrame.Navigate(nav);
        }
    }
}
