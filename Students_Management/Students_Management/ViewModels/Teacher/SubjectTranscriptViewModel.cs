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
    public class SubjectTranscriptViewModel : BaseViewModel
    {
        private string _title;
        
        private List<HocSinh> _students;


        public string Title { get => _title; set { _title = value; OnPropertyChanged(); } }
        public string Keyword { get; set; }

        public SubjectTranscriptViewModel()
        {
            Title = "Bảng điểm môn học";
        }
        public SubjectTranscriptViewModel(int TeacherId) : this()
        {
            
        }

        private void InitCommands()
        {
            
        }

    }
}

