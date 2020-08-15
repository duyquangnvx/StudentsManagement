using Students_Management.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Students_Management.ViewModels
{
    public class ItemMenuViewModel : BaseViewModel
    {
        #region Command
        public ICommand ViewStudentsCommand { get; set; }
        public ICommand AddStudentsCommand { get; set; }
        public ICommand SearchStudentsCommand { get; set; }
        #endregion

        #region Properties
        public ItemMenu ItemMenu { get; set; }
        public MainViewModel Context { get; set; }
        public SubItem SelectedItem { get; set; }
        public Visibility ExVisibility { get; set; }
        public Visibility ListVisibility { get; set; }
        #endregion

        public ItemMenuViewModel(ItemMenu itemMenu, MainViewModel context)
        {
            ExVisibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListVisibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;
            ItemMenu = itemMenu;
            Context = context;
        }

        private void InitCommand()
        {

        }
    }
}
