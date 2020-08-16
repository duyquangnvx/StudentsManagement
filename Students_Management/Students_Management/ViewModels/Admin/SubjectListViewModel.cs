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
    public class SubjectListViewModel: BaseViewModel
    {
        private List<MonHoc> subjects;
        public List<MonHoc> Subjects { get => subjects; set { subjects = value; OnPropertyChanged(); } }

        private List<MonHoc> allSubject = DataProvider.Instance.DB.MonHocs.ToList();

        private String searchName;
        public String SearchName
        {
            get { return searchName; }
            set
            {
                searchName = value;
                OnPropertyChanged();
                Subjects = searchUser(searchName);
            }
        }
        public ICommand SearchUserCommand { get; set; }

        public SubjectListViewModel()
        {
            Subjects = allSubject;
            InitCommand();
        }

        private void InitCommand()
        {
            SearchUserCommand = new RelayCommand<Object>(
                (p) => { return true; },
                (p) =>
                {
                    Subjects = searchUser(searchName);
                });
        }

        List<MonHoc> searchUser(String name)
        {
            if (name.Equals(String.Empty))
            {
                return DataProvider.Instance.DB.MonHocs.ToList();
            }
            else
            {
                return allSubject.Where<MonHoc>(u => u.TenMonHoc.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
        }
    }
}
