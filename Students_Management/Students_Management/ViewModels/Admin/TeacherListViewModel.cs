using Students_Management.Models;
using Students_Management.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Students_Management.ViewModels
{
    class TeacherListViewModel: BaseViewModel
    {

        private List<GiaoVien> teachers;
        public List<GiaoVien> Teachers { get => teachers; set { teachers = value; OnPropertyChanged(); } }

        private List<GiaoVien> allTeacher = DataProvider.Instance.DB.GiaoViens.ToList();

        private String searchName;
        public String SearchName
        {
            get { return searchName; }
            set
            {
                searchName = value;
                OnPropertyChanged();
                Teachers = searchUser(searchName);
            }
        }
        public ICommand SearchUserCommand { get; set; }

        public TeacherListViewModel()
        {
            Teachers = allTeacher;
            InitCommand();
        }

        private void InitCommand()
        {
            SearchUserCommand = new RelayCommand<Object>(
                (p) => { return true; },
                (p) =>
                {
                    Teachers = searchUser(searchName);
                });
        }

        List<GiaoVien> searchUser(String name)
        {
            if (name.Equals(String.Empty))
            {
                return DataProvider.Instance.DB.GiaoViens.ToList();
            }
            else
            {
                return allTeacher.Where<GiaoVien>(u => u.HoTen.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
        }
    }
}

