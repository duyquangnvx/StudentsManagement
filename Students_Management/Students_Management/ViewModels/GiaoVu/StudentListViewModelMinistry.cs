using Students_Management.Models;
using Students_Management.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Students_Management.ViewModels
{
    public class StudentListViewModelMinistry : BaseViewModel
    {

        private List<HocSinh> hocSinhs;
        public List<HocSinh> HocSinhs { get => hocSinhs; set { hocSinhs = value; OnPropertyChanged(); } }

        private List<HocSinh> allStudents = DataProvider.Instance.DB.HocSinhs.ToList();

        private String searchName = "";
        public List<Khoi> searchKhoi { get; set; }
        private List<LopHoc> searchLopHoc;
        private Khoi selectedGrade = null;
        private LopHoc selectedClass = null;
        
        public List<LopHoc> SearchLopHoc
        {
            get { return searchLopHoc; }
            set
            {
                if (value != searchLopHoc)
                {
                    searchLopHoc = value;
                    OnPropertyChanged();
                };
            }
        }

        private Khoi allKhoi;
        private LopHoc allLopHoc;
        public String SearchName
        {
            get { return searchName; }
            set
            {
                searchName = value;
                OnPropertyChanged("SearchLopHoc");
                HocSinhs = searchStudent(searchName);
            }
        }
        public ICommand SearchStudentCommand { get; set; }
        public ICommand searchKhoiChangedCommand { get; set; }
        public ICommand searchLopChangedCommand { get; set; }
        public StudentListViewModelMinistry()
        {
            HocSinhs = allStudents;
            allKhoi = new Khoi();
            allKhoi.TenKhoi = "Tất cả";

            allLopHoc = new LopHoc();
            allLopHoc.TenLop = "Tất cả";

            searchKhoi = DataProvider.Instance.DB.Khois.ToList<Khoi>();
            searchLopHoc = DataProvider.Instance.DB.LopHocs.ToList<LopHoc>();
            searchKhoi.Insert(0, allKhoi);
            searchLopHoc.Insert(0, allLopHoc);
            InitCommand();
        }

        private void InitCommand()
        {
            SearchStudentCommand = new RelayCommand<Object>(
                (p) => { return true; },
                (p) =>
                {
                    HocSinhs = searchStudent(searchName);
                });

            searchKhoiChangedCommand = new RelayCommand<Object>((p) => true, (p) =>
            {
                var gradeBox = p as ComboBox;

                if (gradeBox.SelectedIndex <= 0)
                {
                    selectedGrade = null;
                    searchLopHoc = DataProvider.Instance.DB.LopHocs.ToList<LopHoc>();
                    searchLopHoc.Insert(0, allLopHoc);
                   // classBox.SelectedIndex = 0;
                } else
                {
                    selectedGrade = gradeBox.SelectedItem as Khoi;
                    searchLopHoc = DataProvider.Instance.DB.LopHocs.ToList<LopHoc>();
                    searchLopHoc = searchLopHoc.Where<LopHoc>(c => { if (c.Khoi != null) return c.Khoi.Id == (gradeBox.SelectedItem as Khoi).Id; else return false; }).ToList();
                   // classBox.SelectedIndex = 0;
                }
                OnPropertyChanged("SearchLopHoc");

                HocSinhs = searchStudent(searchName);
            });

            searchLopChangedCommand = new RelayCommand<Object>((p) => true, (p) =>
            {
                var classBox = p as ComboBox;

                if (classBox.SelectedIndex <= 0)
                {
                    selectedClass = null;
                    // classBox.SelectedIndex = 0;
                }
                else
                {
                    selectedClass = classBox.SelectedItem as LopHoc;
                    // classBox.SelectedIndex = 0;
                }
                OnPropertyChanged("SearchLopHoc");
                HocSinhs = searchStudent(searchName);
            });
        }

        List<HocSinh> searchStudent(String name)
        {
            List<HocSinh> searchResult;
            if (name.Equals(String.Empty))
            {
                searchResult = DataProvider.Instance.DB.HocSinhs.ToList();
            }
            else
            {
                searchResult = allStudents.Where<HocSinh>(u =>{
                    return u.HoTen.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0 ;
                    }).ToList();
            }

            if (selectedGrade == null)
            {
                if (selectedClass == null)
                {
                    return searchResult;
                }
                else
                {
                    searchResult = searchResult.Where<HocSinh>(u => {
                        if (u.LopHocs.Count == 0) return false;
                        return u.LopHocs.Last().Id == selectedClass.Id;
                    }).ToList();
                }
            } else
            {
                searchResult = searchResult.Where<HocSinh>(u => {
                    if (u.LopHocs.Count == 0) return false;
                    return u.LopHocs.Last().Khoi.Id == selectedGrade.Id;
                }).ToList();
                
                if (selectedClass != null) {
                    searchResult = searchResult.Where<HocSinh>(u => {
                        if (u.LopHocs.Count == 0) return false;
                        return u.LopHocs.Last().Id ==   selectedClass.Id;
                    }).ToList();
                }
            }

            return searchResult;
            
        }
    }
}

