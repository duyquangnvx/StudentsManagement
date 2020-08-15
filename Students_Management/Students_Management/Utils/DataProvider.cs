using Students_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Management.Utils
{
    public class DataProvider
    {
        private static DataProvider _instance;
        public static DataProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataProvider();
                }

                return _instance;
            }
        }

        public StudentManagementEntities DB { get; set; }

        private DataProvider()
        {
            DB = new StudentManagementEntities();
        }
    }
}
