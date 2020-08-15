using Students_Management.Implement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            LoginCommand = new RelayCommand<Window>(
                (p) => { return Username != String.Empty && Password != String.Empty; },
                (p) => 
                {
                    LoginImpl.Window = p;

                    LoginImpl.Login(Username, Password);
                });

            ForgotPasswordCommand = new RelayCommand<object>(
                (p) => { return true; },
                (p) => 
                {
                    // Mở màn hình quên mật khẩu
                });
        }
    }
}
