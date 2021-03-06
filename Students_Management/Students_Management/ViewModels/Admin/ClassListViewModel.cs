﻿using MaterialDesignThemes.Wpf;
using Students_Management.Models;
using Students_Management.Utils;
using Students_Management.Views.GiaoVu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Students_Management.ViewModels
{
    class ClassListViewModel : BaseViewModel
    {
        private List<LopHoc> classes;
        public List<LopHoc> Classes { get => classes; set { classes = value; OnPropertyChanged(); } }

        private List<LopHoc> allSubject = DataProvider.Instance.DB.LopHocs.ToList();

        private String searchName;
        public LopHoc SelectedClass { get; set; }
        public String SearchName
        {
            get { return searchName; }
            set
            {
                searchName = value;
                OnPropertyChanged();
                Classes = searchUser(searchName);
            }
        }
        public ICommand SearchUserCommand { get; set; }
        public ICommand DoubleClickCommand { get; set; }
        public ClassListViewModel()
        {
            Classes = allSubject;
            InitCommand();
        }

        private void InitCommand()
        {
            SearchUserCommand = new RelayCommand<Object>(
                (p) => { return true; },
                (p) =>
                {
                    Classes = searchUser(searchName);
                });

            DoubleClickCommand = new RelayCommand<Object>(
                (p) => { return true; },
                (p) =>
                {
                    var window = new ClassStudentList();
                    window.DataContext = new ClassStudentListViewModel(SelectedClass);
                    window.Show();
                });
        }

        List<LopHoc> searchUser(String name)
        {
            if (name.Equals(String.Empty))
            {
                return DataProvider.Instance.DB.LopHocs.ToList();
            }
            else
            {
                return allSubject.Where<LopHoc>(u => u.TenLop.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
        }
    }
}
