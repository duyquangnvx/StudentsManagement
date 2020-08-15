using Students_Management.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Students_Management.Dialogs
{
    public class MyMessageBox
    {
        public static void Show(string message)  { Show(null, string.Empty, message); }
        public static void Show(string title, string message) { Show(null, title, message); }
        public static void Show(Window owner, string message) { Show(null, string.Empty, message); }
        public static void Show(Window owner, string title, string message)
        {
            DialogWindow dialog = new DialogWindow();
            dialog.Owner = owner;
            dialog.WindowStartupLocation = dialog.Owner == null ? WindowStartupLocation.CenterScreen : WindowStartupLocation.CenterOwner;
            dialog.DataContext = new DialogViewModel(title, message);
            dialog.ShowDialog();
        }
    }
}
