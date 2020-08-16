using Students_Management.Dialogs;
using Students_Management.Models;
using Students_Management.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Students_Management.ViewModels.Admin
{
    class AddUserViewModel : BaseViewModel
    {
        [Required]
        [RegularExpression(@"\d{2,2}/\d{2,2}/\d{4,4} \d{2,2}:\d{2,2}:\d{2,2}", ErrorMessage = "Wrong Syntax")]
        public string Dob { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public Role SelectedRole { get; set; }
        public ICommand AddUserCommand { get; set; }
        private void InitCommand()
        {

            AddUserCommand = new RelayCommand<object>(
                (p) => { return true; },
                (p) =>
           {
               DateTime date;

               if (DateTime.TryParse(Dob, out date))
               {
                   var passwordBox = p as PasswordBox;

                   User user = new User
                   {
                       Username = this.Username,
                       HoTen = Name,
                       DiaChi = Address,
                       Email = Email,
                        //Phone = Phone,
                        GioiTinh = Gender,
                       IdChucVu = (int)SelectedRole,
                       Password = passwordBox.Password
                   };

                   var db = DataProvider.Instance.DB;
                   db.Users.Add(user);
                   if (db.SaveChanges() > 0)
                   {
                       MyMessageBox.Show("thêm thành công");
                   }
                   else
                   {
                       MyMessageBox.Show("thêm thất bại");
                   }
               }
               else
               {
                   MessageBox.Show("Thêm Thất Bại");
               }
           });
        }
    }

}
