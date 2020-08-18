using Students_Management.Dialogs;
using Students_Management.Models;
using Students_Management.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Students_Management.ViewModels
{
    public class EditStudentViewModel : BaseViewModel
    {
        private List<LopHoc> classes = null;
        private Khoi gradeSelected = null;
        private LopHoc classSelected = null;
        public HocSinh HocSinh { get; set; }
        private HocSinh rootStudent { get; set; }
        public Khoi GradeSelected
        {
            get { return gradeSelected; }
            set
            {
                if (gradeSelected != value)
                {
                    gradeSelected = value;
                    OnPropertyChanged("GradeSelected");
                }
            }
        }

        public LopHoc ClassSelected
        {
            get { return classSelected; }
            set
            {
                if (classSelected != value)
                {
                    classSelected = value;
                    OnPropertyChanged("ClassSelected");
                }
            }
        }
        public Khoi Khoi
        {
            get
            {
                if (HocSinh.LopHocs != null && HocSinh.LopHocs.Count > 0)
                    return HocSinh.LopHocs.Last().Khoi;
                else return null;
            }
            set { }
        }

        public LopHoc LopHoc
        {
            get
            {
                if (HocSinh.LopHocs != null && HocSinh.LopHocs.Count > 0)
                    return HocSinh.LopHocs.Last();
                else return null;
            }
            set { }
        }

        public List<LopHoc> Classes
        {
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

        public ICommand GradeChangedCommand { get; set; }
        public ICommand UpdateStudentCommand { get; set; }
        public EditStudentViewModel()
        {
            HocSinh = new HocSinh();
            Grades = DataProvider.Instance.DB.Khois.ToList<Khoi>();
        }
        public EditStudentViewModel(HocSinh hs) : base()
        {
            HocSinh = hs.Clone();
            rootStudent = hs;
            OnPropertyChanged("student");

            InitGradeClass();
            InitCommand();
        }

        private void InitCommand()
        {
            GradeChangedCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                var gradeBox = p as ComboBox;

                if (gradeBox.SelectedIndex >= 0)
                {

                    gradeSelected = gradeBox.SelectedItem as Khoi;
                    classes = DataProvider.Instance.DB.LopHocs.ToList<LopHoc>();
                    classes = classes.Where<LopHoc>(c => { if (c.Khoi != null) return c.Khoi.Id == (gradeBox.SelectedItem as Khoi).Id; else return false; }).ToList();
                    // classBox.SelectedIndex = 0;
                }
                OnPropertyChanged("Classes");
            });

            UpdateStudentCommand = new RelayCommand<object>(
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
                    foreach(LopHoc lop in HocSinh.LopHocs.ToList())
                    {
                        if (lop.Id == 1 || lop.Id == 2 || lop.Id == 3)
                        {
                            HocSinh.LopHocs.Remove(lop);
                        }
                    }
                    HocSinh.LopHocs.Add(comboBox.SelectedItem as LopHoc);
                    HocSinh.LopHoc.HocSinhs.Remove(HocSinh);
                    var db = DataProvider.Instance.DB;
                    db.HocSinhs.AddOrUpdate(HocSinh);
                    if (db.SaveChanges() > 0)
                    {
                        rootStudent = HocSinh;
                        MyMessageBox.Show("Cập nhật thành công");
                        OnPropertyChanged("Classes");
                        OnPropertyChanged("HocSinhs");
                        OnPropertyChanged("selectedStudent");

                    }
                    else
                    {
                        MyMessageBox.Show("Cập nhật thất bại");
                    }


                });
        }

        private void InitGradeClass()
        {
            Grades = DataProvider.Instance.DB.Khois.ToList<Khoi>();

            if (HocSinh.LopHocs != null && HocSinh.LopHocs.Count > 0)
            {
                foreach (Khoi khoi in Grades)
                {
                    if (khoi.Id == HocSinh.LopHocs.Last().Khoi.Id)
                    {
                        gradeSelected = khoi;
                        OnPropertyChanged("gradeSelected");
                    }
                }
            }

            if (gradeSelected != null)
            {
                classes = DataProvider.Instance.DB.LopHocs.ToList();
                classes = classes.Where<LopHoc>((p) => p.IdKhoi == gradeSelected.Id).ToList();
                foreach (LopHoc lopHoc in classes)
                {
                    if (lopHoc.Id == HocSinh.LopHocs.Last().Id)
                    {
                        classSelected = lopHoc;
                        OnPropertyChanged("classSelected");
                    }
                }
            }
        }

    }
}
