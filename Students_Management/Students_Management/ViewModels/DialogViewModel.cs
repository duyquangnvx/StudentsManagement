using Students_Management.Dialogs;
using Students_Management.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Students_Management.ViewModels
{
    public class DialogViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public ICommand OKCommand { get; set; }
        public DialogViewModel() : this(String.Empty, string.Empty) { }
        public DialogViewModel(string message) : this(String.Empty, message) { }
        public DialogViewModel(string title, string message)
        {
            Title = title;
            Message = message;

            OKCommand = new RelayCommand<DialogWindow>(
                (p) => { return true; },
                (p) => OK(p));
        }

        private void OK(DialogWindow dialog)
        {
            dialog.Close();
        }
    }
}
