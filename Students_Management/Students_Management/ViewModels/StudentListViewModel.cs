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
    public class StudentListViewModel : BaseViewModel
    {
        private LopHoc _selectedClass;
        private List<HocSinh> _filterList;
        public string Keyword { get; set; }
        public LopHoc SelectedClass { get => _selectedClass; set { _selectedClass = value; OnPropertyChanged(); } }
        public List<HocSinh> FilterList { get => _filterList; set { _filterList = value; OnPropertyChanged(); } }
        public List<LopHoc> Classes { get; set; }
        public List<HocSinh> Students { get; set; }
        public ICommand SearchCommand { get; set; }
        public StudentListViewModel()
        {
            Classes = DataProvider.Instance.DB.LopHocs.ToList();
            InitCommands();
        }

        public StudentListViewModel(LopHoc c) : this()
        {
            SelectedClass = c;
            Filter(SelectedClass.HocSinhs.ToList());
        }

        private void Filter(List<HocSinh> students)
        {
            FilterList = new List<HocSinh>(students);
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
                        Filter(SelectedClass.HocSinhs.ToList());
                    }
                    else
                    {
                        Filter(SelectedClass.HocSinhs.Where(c => c.HoTen.ToLower().Contains(Keyword.ToLower())).ToList());
                    }
                });
        }

    }
}
