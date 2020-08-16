using Students_Management.Dialogs;
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
    class AddClassViewModel : BaseViewModel
    {
        private LopHoc class_;
        private List<Khoi> grades;
        private List<GiaoVien> teachers;
        public AddClassViewModel()
        {
            this.class_ = new LopHoc();
            this.grades = DataProvider.Instance.DB.Khois.ToList();
            this.teachers = DataProvider.Instance.DB.GiaoViens.ToList();
            InitCommand();
        }
        public LopHoc Class { get => class_; set => class_ = value; }

        public ICommand AddClassCommand { get; set; }
        public List<Khoi> Grades { get => grades; set => grades = value; }
        public List<GiaoVien> Teachers { get => teachers; set => teachers = value; }

        private void InitCommand()
        {
            AddClassCommand = new RelayCommand<Object>(
                (p) => { return true; },
                (p) =>
                {
                    if (checkClassInfoValid(Class))
                    {
                        var db = DataProvider.Instance.DB;
                        db.LopHocs.Add(Class);
                        if (db.SaveChanges() > 0)
                        {
                            MyMessageBox.Show("thêm thành công");
                        }
                        else
                        {
                            MyMessageBox.Show("thêm thất bại");
                        }
                    }
                });
        }


        private bool checkClassInfoValid(LopHoc clazz)
        {
            return true;
        }
        




    }
}
