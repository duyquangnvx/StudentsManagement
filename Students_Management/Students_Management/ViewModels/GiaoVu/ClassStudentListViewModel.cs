using Students_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Students_Management.ViewModels
{
    public class ClassStudentListViewModel : BaseViewModel
    {
        LopHoc LopHoc = null;
        public List<HocSinh> HocSinhs { get; set; }
        public string SearchName { get; set; }
        public ICommand SearchStudentCommand { get; set; }
        public ICommand DoubleClickCommand { get; set; }
        public ClassStudentListViewModel()
        {
            LopHoc = new LopHoc();
            InitComponent();
        }

        public ClassStudentListViewModel(LopHoc lop) :base()
        {
            LopHoc = lop;
            HocSinhs = lop.HocSinhs.ToList();
            InitComponent();
        }

        private void InitComponent()
        {
            SearchStudentCommand = new RelayCommand<Object>(p => true, (p) =>
             {
                 HocSinhs = LopHoc.HocSinhs.ToList();
                 if (!SearchName.Equals(String.Empty))
                 {
                     HocSinhs = HocSinhs.Where((h) => h.HoTen.IndexOf(SearchName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                 }
             });

            DoubleClickCommand = new RelayCommand<Object>(p => true, (p) =>
            {

            });
        }

    }
}
