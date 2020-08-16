using Students_Management.Dialogs;
using Students_Management.Models;
using Students_Management.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Students_Management.ViewModels
{
    public class AssignSubjectTeacherForClass : BaseViewModel
    {
        private PhanCong assignment;
        private List<LopHoc> classes;
        private List<GiaoVien> teachers;
        private List<MonHoc> subjects;
        public ICommand AssignCommand { get; set; }
        public AssignSubjectTeacherForClass()
        {
            assignment = new PhanCong();
            classes = DataProvider.Instance.DB.LopHocs.ToList();
            teachers = DataProvider.Instance.DB.GiaoViens.ToList();
            subjects = DataProvider.Instance.DB.MonHocs.ToList();
            InitCommand();
        }

        public List<MonHoc> Subjects { get => subjects; set => subjects = value; }
        public List<GiaoVien> Teachers { get => teachers; set => teachers = value; }
        public List<LopHoc> Classes { get => classes; set => classes = value; }
        public PhanCong Assignment { get => assignment; set => assignment = value; }

        private void InitCommand()
        {
            AssignCommand = new RelayCommand<object>(
                (p) => { return true; },
                (p) =>
                {
                    var db = DataProvider.Instance.DB;
                    db.PhanCongs.Add(assignment);
                    try
                    {

                        if (db.SaveChanges() > 0)
                        {
                            MyMessageBox.Show("thêm thành công");
                        }
                        else
                        {
                            MyMessageBox.Show("thêm thất bại");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Fail(ex.StackTrace);
                        MyMessageBox.Show("thêm thất bại");
                    }
                }
            );
        }
    }
}
