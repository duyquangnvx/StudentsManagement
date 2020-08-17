using Students_Management.Dialogs;
using Students_Management.Models;
using Students_Management.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Students_Management.ViewModels.Teacher
{
    public class AssignmentClassListViewModel : BaseViewModel
    {
        private string _title;
        private GiaoVien _teacher;
        private List<LopHoc> _classes;
        private List<PhanCong> _assignments;
        private List<PhanCong> _filterList;

        public string Title { get => _title; set { _title = value; OnPropertyChanged(); } }
        public string Keyword { get; set; }
        public GiaoVien Teacher { get => _teacher; set { _teacher = value; OnPropertyChanged(); } }
        public List<LopHoc> Classes { get => _classes; set { _classes = value; OnPropertyChanged(); } }

        public List<PhanCong> Assignments { get => _assignments; set { _assignments = value; OnPropertyChanged(); } }
        public List<PhanCong> FilterList { get => _filterList; set { _filterList = value; OnPropertyChanged(); } }

        public ICommand SearchCommand { get; set; }

        public AssignmentClassListViewModel()
        {
            Title = "Danh sách lớp phân công";           
        }

        public AssignmentClassListViewModel(int TeacherId) : this()
        {
            Teacher = DataProvider.Instance.DB.GiaoViens.Where(gv => gv.Id == TeacherId).First();
            Classes = DataProvider.Instance.DB.LopHocs.Where(c => c.PhanCongs.Any(pc => pc.IdGiaoVien == TeacherId)).ToList();
            Assignments = DataProvider.Instance.DB.PhanCongs.Where(pc => pc.IdGiaoVien == TeacherId).ToList();
            FilterList = new List<PhanCong>(Assignments);
            InitCommands();
        }

        private void InitCommands()
        {
            SearchCommand = new RelayCommand<Object>(
                (p) => 
                {
                    return true;
                },
                (p) => 
                {
                    if (String.IsNullOrEmpty(Keyword))
                    {
                        FilterList = new List<PhanCong>(Assignments);
                    } else
                    {
                        FilterList = Assignments.Where(pc => pc.LopHoc.TenLop.ToLower().Contains(Keyword.ToLower())).ToList();
                        Filter(FilterList);
                    }
                });
        }

        private void Filter(List<PhanCong> assignments)
        {
            this.FilterList = assignments;
        }
    }
}
