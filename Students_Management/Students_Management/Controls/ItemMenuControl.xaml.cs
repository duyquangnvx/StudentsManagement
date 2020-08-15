using Students_Management.Menu;
using Students_Management.ViewModels;
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

namespace Students_Management.Controls
{
    /// <summary>
    /// Interaction logic for ItemMenuControl.xaml
    /// </summary>
    public partial class ItemMenuControl : UserControl
    {
        public ItemMenuViewModel ViewModel { get; set; }
        public ItemMenuControl(ItemMenu itemMenu, MainViewModel context)
        {
            InitializeComponent();
            this.DataContext = ViewModel = new ItemMenuViewModel(itemMenu, context);
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SubItem subItem = (SubItem)((ListView)sender).SelectedItem;
            if (subItem != null)
            {
                ViewModel.Context.SwitchScreen(subItem.Screen);
            }
        }
    }
}
