using Students_Management.Models;
using Students_Management.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Students_Management.ViewModels
{
    public class UserListViewModel : BaseViewModel
    {
        private List<User> users;
        public List<User> Users { get => users; set { users = value; OnPropertyChanged(); } }

        private List<User> allUser = DataProvider.Instance.DB.Users.ToList();

        private String searchName;
        public String SearchName
        { 
            get { return searchName; }
            set
            {
                searchName = value;
                OnPropertyChanged();
                Users = searchUser(searchName);
            }
        }
        public ICommand SearchUserCommand { get; set; }

        public UserListViewModel()
        {
            Users = allUser;
            InitCommand();
        }

        private void InitCommand()
        {
            SearchUserCommand = new RelayCommand<Object>(
                (p) => { return true; },
                (p) =>
                {                  
                    Users = searchUser(searchName);
                });
        }

        List<User> searchUser(String name)
        {
            if (name.Equals(String.Empty))
            {
                return DataProvider.Instance.DB.Users.ToList();
            } else {
                return allUser.Where<User>(u => u.HoTen.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }
    }
}
