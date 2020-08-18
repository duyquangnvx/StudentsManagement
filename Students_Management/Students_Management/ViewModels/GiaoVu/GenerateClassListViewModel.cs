using Students_Management.Dialogs;
using Students_Management.Models;
using Students_Management.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Students_Management.ViewModels
{
    public class GenerateClassListViewModel : BaseViewModel
    {
        public ICommand GenerateCommand { get; set; }
        public GenerateClassListViewModel()
        {
            InitCommand();

        }

        private void InitCommand()
        {
            GenerateCommand = new RelayCommand<Object>(p => true, p =>
            {
                generate();
            });
        }

        private void generate()
        {
            List<HocSinh> hocSinhs = DataProvider.Instance.DB.HocSinhs.ToList();

            List<HocSinh> unClassifiedStudentK10 = hocSinhs.Where<HocSinh>(hs => hs.LopHoc.Id == 1).ToList();
            List<HocSinh> unClassifiedStudentK11 = hocSinhs.Where<HocSinh>(hs => hs.LopHoc.Id == 2).ToList();
            List<HocSinh> unClassifiedStudentK12 = hocSinhs.Where<HocSinh>(hs => hs.LopHoc.Id == 3).ToList();

            int countK10Students = hocSinhs.Where<HocSinh>(hs => hs.LopHoc.Khoi.Id == 10).Count();
            int countK11Students = hocSinhs.Where<HocSinh>(hs => hs.LopHoc.Khoi.Id == 11).Count();
            int countK12Students = hocSinhs.Where<HocSinh>(hs => hs.LopHoc.Khoi.Id == 12).Count();

            List<LopHoc> Classes = DataProvider.Instance.DB.LopHocs.ToList();
            List<Khoi> Grades = DataProvider.Instance.DB.Khois.ToList();

            foreach (Khoi grade in Grades)
            {
                List<HocSinh> unClassifiedStudent = hocSinhs.Where<HocSinh>(hs => hs.LopHoc.Khoi.Id == grade.Id && (hs.LopHoc.Id == 1 || hs.LopHoc.Id == 2 || hs.LopHoc.Id == 3)).ToList();
                int countStudents = hocSinhs.Where<HocSinh>(hs => hs.LopHoc.Khoi.Id == grade.Id).Count();
                int countClasses = grade.LopHocs.Count;
                int average = (int)Math.Ceiling((double)countStudents / countClasses);
                List<LopHoc> usableClasses = grade.LopHocs.Where((c) => (c.Id != 1 && c.Id != 2 && c.Id != 3)).ToList();

                for (int i = 0; i < unClassifiedStudent.Count; i++)
                {
                    foreach (LopHoc lop in unClassifiedStudent.ElementAt(i).LopHocs.ToList())
                    {
                        if (lop.Id == 1 || lop.Id == 2 || lop.Id == 3)
                        {
                            unClassifiedStudent.ElementAt(i).LopHoc.HocSinhs.Remove(unClassifiedStudent.ElementAt(i));
                            unClassifiedStudent.ElementAt(i).LopHocs.Remove(lop);
                        }
                    }
                    unClassifiedStudent.ElementAt(i).LopHocs.Add(usableClasses.ElementAt(i%countClasses));
                }
            }

            var db = DataProvider.Instance.DB;
            db.HocSinhs.AddOrUpdate();
            if (db.SaveChanges() > 0)
            {
                MyMessageBox.Show("Lập thành công");
            }
            else
            {
                MyMessageBox.Show("Lập thất bại");
            }
        }


    }
}
