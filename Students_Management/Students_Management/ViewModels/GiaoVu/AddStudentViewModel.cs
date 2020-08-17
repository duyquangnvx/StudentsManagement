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
    public class AddStudentViewModel : BaseViewModel
    {
        public HocSinh HocSinh { get; set; }
        private List<LopHoc> classes;
        private Khoi selectedGrade = null;
        public ICommand AddStudentCommand { get; set; }
        public ICommand GradeChangedCommand { get; set; }
        public List<LopHoc> Classes {
            get { return classes; }
            set
            {
                if (classes != value)
                {
                    classes = value;
                    OnPropertyChanged("Classes");
                }
            }
        }
        public List<Khoi> Grades { get; set; }
        public AddStudentViewModel()
        {
            HocSinh = new HocSinh();
            //Classes = DataProvider.Instance.DB.LopHocs.ToList<LopHoc>();
            Grades = DataProvider.Instance.DB.Khois.ToList<Khoi>();
            InitCommand();
        }
        private void InitCommand()
        {
            AddStudentCommand = new RelayCommand<object>(
                (p) => { return true; },
                (p) =>
                {
                    var comboBox = p as ComboBox;
                    LopHoc lopHoc = comboBox.SelectedItem as LopHoc;
                    if (lopHoc == null)
                    {
                        MyMessageBox.Show("Vui lòng chọn lớp");
                        return;
                    }
                    HocSinh.LopHocs.Add(comboBox.SelectedItem as LopHoc);
                    var db = DataProvider.Instance.DB;
                    db.HocSinhs.Add(HocSinh);
                    if (db.SaveChanges() > 0)
                    {
                        MyMessageBox.Show("thêm thành công");
                        OnPropertyChanged("Classes");
                        OnPropertyChanged("HocSinhs");
                    }
                    else
                    {
                        MyMessageBox.Show("thêm thất bại");
                    }


                });

            GradeChangedCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                var gradeBox = p as ComboBox;

                if (gradeBox.SelectedIndex >= 0) { 
                
                    selectedGrade = gradeBox.SelectedItem as Khoi;
                    classes = DataProvider.Instance.DB.LopHocs.ToList<LopHoc>();
                    classes = classes.Where<LopHoc>(c => { if (c.Khoi != null) return c.Khoi.Id == (gradeBox.SelectedItem as Khoi).Id; else return false; }).ToList();
                    // classBox.SelectedIndex = 0;
                }
                OnPropertyChanged("Classes");
            });
        }
    }

}
