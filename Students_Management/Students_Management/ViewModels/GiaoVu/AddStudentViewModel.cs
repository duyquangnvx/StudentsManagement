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

        public ICommand AddStudentCommand { get; set; }
        public List<LopHoc> Classes { get; set; }
        public AddStudentViewModel()
        {
            HocSinh = new HocSinh();
            Classes = DataProvider.Instance.DB.LopHocs.ToList<LopHoc>();
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
                    }
                    else
                    {
                        MyMessageBox.Show("thêm thất bại");
                    }


                });
        }
    }

}
