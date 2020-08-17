using Students_Management.Models;
using Students_Management.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Management.ViewModels
{
    public class ClassInfoViewModel : BaseViewModel
    {
        private LopHoc _class;
        public LopHoc Class { get => _class; set { _class = value; OnPropertyChanged(); } }
        
        public ClassInfoViewModel(LopHoc Class) : this()
        {
            this.Class = Class;
        }

        public ClassInfoViewModel(int ClassId) : this()
        {
            Class = DataProvider.Instance.DB.LopHocs.Where(c => c.Id == ClassId).First();
        }

        public ClassInfoViewModel()
        {

        }
    }
}
