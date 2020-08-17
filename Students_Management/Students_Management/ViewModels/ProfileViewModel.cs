using Students_Management.Dialogs;
using Students_Management.Models;
using Students_Management.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Students_Management.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private User _user;
        public User User { get => _user; set { _user = value; OnPropertyChanged(); } }
        private string _title;
        private bool _isEditing = false;
        public string Title { get => _title; set { _title = value; OnPropertyChanged(); } }
        public bool IsEditing { get => _isEditing; set { _isEditing = value; OnPropertyChanged(); } }
        public List<ChucVu> Roles { get; set; }
        public ChucVu SelectedRole { get; set; }
        public bool isAdmin { get; set; }
        private Visibility _saveButtonVisibility = Visibility.Collapsed;
        public Visibility SaveButtonVisibility { get => _saveButtonVisibility; set { _saveButtonVisibility = value; OnPropertyChanged(); } }
        public ICommand EditCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ProfileViewModel()
        {
            Roles = DataProvider.Instance.DB.ChucVus.ToList();
            Title = "Thông tin cá nhân";
            IsEditing = false;
            InitCommands();
        }

        public ProfileViewModel(User user) : this()
        {
            User = user;
            SelectedRole = Roles.Where(r => r.Id == User.IdChucVu).FirstOrDefault();
        }

        private void InitCommands()
        {
            EditCommand = new RelayCommand<object>(
                (p) =>
                {
                    return !IsEditing;
                },
                (p) =>
                {
                    IsEditing = true;
                    SaveButtonVisibility = Visibility.Visible;
                });

            SaveCommand = new RelayCommand<object>(
                (p) =>
                {
                    return IsEditing;
                },
                (p) =>
                {
                    IsEditing = false;
                    SaveButtonVisibility = Visibility.Collapsed;
                    DataProvider.Instance.DB.SaveChanges();
                    
                });

            CancelCommand = new RelayCommand<object>(
                (p) =>
                {
                    return IsEditing;
                },
                (p)=> {
                    IsEditing = false;
                    SaveButtonVisibility = Visibility.Collapsed;
                    var entry = DataProvider.Instance.DB.Entry(User);
                    entry.Reload();
                    
                    OnPropertyChanged(nameof(User));

                    MainViewModel.Instance.User = User;

                    OnPropertyChanged(nameof(MainViewModel.Instance.User));
                });
        }
    }
}
