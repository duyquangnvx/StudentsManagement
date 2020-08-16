using Students_Management.Dialogs;
using Students_Management.Models;
using Students_Management.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Students_Management.ViewModels
{
    public class AddUserViewModel : BaseViewModel
    {
        public User User { get; set; }
        public ChucVu SelectedRole { get; set; }
        public ICommand AddUserCommand { get; set; }

        public List<ChucVu> Roles { get; set; }
        public AddUserViewModel() {
            User = new User() { NgaySinh = DateTime.Today };
            Roles = DataProvider.Instance.DB.ChucVus.ToList<ChucVu>();
            InitCommand(); }
        private void InitCommand()
        {
            AddUserCommand = new RelayCommand<object>(
                (p) => { return true; },
                (p) =>
                {
                    var passwordBox = p as PasswordBox;
                    User.Password = passwordBox.Password;

                    var db = DataProvider.Instance.DB;
                    db.Users.Add(User);
                    if (db.SaveChanges() > 0)
                    {
                        MyMessageBox.Show("thêm thành công");
                    }
                    else
                    {
                        MyMessageBox.Show("thêm thất bại");
                    }


                });
        }
    }

}
