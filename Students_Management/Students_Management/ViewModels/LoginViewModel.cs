using Students_Management.Implement;
using Students_Management.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Students_Management.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Private members
        private string _username = String.Empty;
        private string _password = String.Empty;
        #endregion

        #region Properties
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string Username { get => _username; set { _username = value; ValidateProperty(value); OnPropertyChanged(); } }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get => _password; set { _password = value; ValidateProperty(value); OnPropertyChanged(); } }
        LoginImpl LoginImpl { get; set; }
        #endregion

        #region Commands
        public ICommand LoginCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }
        #endregion

        public LoginViewModel()
        {
            if (LoginImpl == null)
            {
                LoginImpl = new LoginImpl();
            }

            InitCommands();
        }

        private void InitCommands()
        {
            LoginCommand = new RelayCommand<object[]>(
                (p) => 
                {
                    string password = (p[1] as PasswordBox).Password;
                    return Username != String.Empty && password != String.Empty;
                },
                (p) => 
                {
                    string password = (p[1] as PasswordBox).Password;
                    LoginImpl.Window = p[0] as Window;
                    LoginImpl.Login(Username, password);
                });

            ForgotPasswordCommand = new RelayCommand<object>(
                (p) => { return true; },
                (p) => 
                {
                    ForgotPasswordWindow forgot = new ForgotPasswordWindow();
                    forgot.ShowDialog();
                });
        }
    }
}
