using MaterialDesignThemes.Wpf;
using Students_Management.Controls;
using Students_Management.Menu;
using Students_Management.Models;
using Students_Management.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Students_Management.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public User User { get; set; }
        /// <summary>
        /// Danh sách các tùy chọn của menu bên trái
        /// </summary>
        public List<ItemMenuControl> ItemMenus { get; set; }
        /// <summary>
        /// Màn hình đang hiển thị
        /// </summary>
        public UserControl CurrentItemMenuUC { get; set; }
        /// <summary>
        /// Lớp học đang chủ nhiệm
        /// </summary>
        public LopHoc MyClass { get; set; }
        /// <summary>
        /// Danh sách lớp học được phân công giảng dạy
        /// </summary>
        public List<LopHoc> AssignmentClasses { get; set; }

        public MainViewModel()
        {
            User = DataProvider.Instance.My;
            InitMenu();
        }


        /// <summary>
        /// Khởi tạo menu tùy chọn dựa theo chức vụ của user
        /// </summary>
        private void InitMenu()
        {
            switch(User.ChucVu.Id)
            {
                case (int)Role.Admin:
                    InitAdminMenu();
                    break;
                case (int)Role.Teacher:
                    InitTeacherMenu();
                    break;
                case (int)Role.Ministry:
                    InitMinistryMenu();
                    break;
            }
        }

        /// <summary>
        /// Khởi tạo menu tùy chọn cho phân hệ giáo viên
        /// </summary>
        private void InitTeacherMenu()
        {
            LoadDataForTeacher();

            List<SubItem> classes = null;
            foreach (var i in AssignmentClasses)
            {
                SubItem subItem = new SubItem(i.TenLop);
                classes.Add(subItem);
            }

            // Menu danh sách lớp được phân công
            var assignment = new ItemMenu("Phân công",
                classes,
                PackIconKind.CastEducation);

            // Menu chủ nhiệm
            var homeroom = new ItemMenu("Chủ nhiệm",
                MyClass == null ? null : new List<SubItem> { new SubItem(MyClass.TenLop) },
                PackIconKind.Room);

            ItemMenus = new List<ItemMenuControl>
            {
                new ItemMenuControl(assignment, this),
                new ItemMenuControl(homeroom, this),
            };
        }

        /// <summary>
        /// Lấy dữ liệu cần thiết cho Giáo Viên
        /// </summary>
        private void LoadDataForTeacher()
        {
            List<LopHoc> result = null;
            result = DataProvider.Instance.DB.LopHocs.Where(c => c.GiaoVien.Id == DataProvider.Instance.My.Id).ToList();
            if (result.Count > 0)
            {
                MyClass = result[0];
            }

            AssignmentClasses = DataProvider.Instance.DB.LopHocs.Where(c => c.IdGiaoVien == DataProvider.Instance.My.Id).ToList();
        }

        /// <summary>
        /// Khởi tạo menu tùy chọn cho phân hệ Ban Giám Hiệu
        /// </summary>
        private void InitAdminMenu()
        {
            LoadDataForAdmin();
        }

        /// <summary>
        /// Lấy dữ liệu cần thiết cho Admin
        /// </summary>
        private void LoadDataForAdmin()
        {

        }

        /// <summary>
        /// Khởi tạo menu tùy chọn cho phân hệ Giáo Vụ
        /// </summary>
        private void InitMinistryMenu()
        {
            LoadDataForMinistry();
        }

        /// <summary>
        /// Lấy dữ liệu cần thiết cho Giáo Vụ
        /// </summary>
        private void LoadDataForMinistry()
        {

        }

        /// <summary>
        /// Chuyển đổi màn hình khi click một item trong menu
        /// </summary>
        /// <param name="sender"></param>
        internal void SwitchScreen(object sender)
        {
            var screen = (UserControl)sender;

            if (screen != null)
            {
                CurrentItemMenuUC = screen;
                OnPropertyChanged(CurrentItemMenuUC.Name);
            }
        }
    }

    /// <summary>
    /// Liệt kê loại chức vụ theo database
    /// </summary>
    public enum Role
    {
        Admin = 1,
        Ministry = 2,
        Teacher = 3
    }
}
