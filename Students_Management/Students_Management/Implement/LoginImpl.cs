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

namespace Students_Management.Implement
{
    public class LoginImpl : ILogin
    {
        List<User> Users { get; set; }

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
            // Mở màn hình chính dựa theo chức vụ của user
            MyMessageBox.Show("Đăng nhập thành công", "Đăng nhập thành công");
        }

        public void OnFailure()
        {
            // Thông báo tên đăng nhập hoặc mật khẩu không đúng
            MyMessageBox.Show("Đăng nhập thất bại", "Tên đăng nhập hoặc mật khẩu không đúng");
        }
    }
}
