using Students_Management.Interfaces;
using Students_Management.Utils;
using Students_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Students_Management.Dialogs;
using Students_Management.Views;
using Students_Management.ViewModels;

namespace Students_Management.Implement
{
    public class LoginImpl : ILogin
    {
        public Window Window { get; set; }
        private List<User> Users { get; set; }

        public LoginImpl()
        {
            if (DataProvider.Instance.DB.Database.Exists())
            {
                Users = DataProvider.Instance.DB.Users.ToList();
            }
        }

        public void Login(string username, string password)
        {
            foreach(var user in Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    OnSuccess(user);
                    return;
                }
            }

            OnFailure();
        }
        public void OnSuccess(User user)
        {
            // Lưu dữ liệu người dùng
            DataProvider.Instance.My = user;

            // Mở màn hình chính dựa theo chức vụ của user
            MainWindow view = new MainWindow();
            MainViewModel viewModel = new MainViewModel();
            view.DataContext = viewModel;
            view.Show();

            // Đóng màn hình đăng nhập
            if (Window != null)
            {
                Window.Close();
            }

        }

        public void OnFailure()
        {
            MyMessageBox.Show(Window, "Đăng nhập thất bại", "Tên đăng nhập hoặc mật khẩu không đúng");
        }
    }
}
