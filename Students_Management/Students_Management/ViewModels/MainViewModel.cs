﻿using MaterialDesignThemes.Wpf;
using Students_Management.Controls;
using Students_Management.Dialogs;
using Students_Management.Menu;
using Students_Management.Models;
using Students_Management.Utils;
using Students_Management.Views;
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
        /// Danh sách lớp quản lý của Giáo Vụ
        /// </summary>
        public List<LopHoc> Classes { get; set; }
        /// <summary>
        /// Danh sách học sinh quản lý của Giáo vụ
        /// </summary>
        public List<HocSinh> Students { get; set; }
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
            bool isSuperTeacher = DataProvider.Instance.DB.LopHocs.Any(c => c.IdGiaoVien == User.Id);

            // Menu danh sách lớp được phân công
            var assignmentMenu = new ItemMenu("Phân công",
                new List<SubItem>
                { 
                    new SubItem("Danh sách lớp") , 
                    new SubItem("Bảng điểm")
                },
                PackIconKind.ViewList);

            // Menu chủ nhiệm
            var homeroomMenu = new ItemMenu("Chủ nhiệm",
                isSuperTeacher == false ? null : new List<SubItem> 
                { 
                    new SubItem("Thông tin lớp học"),
                    new SubItem("Danh sách học sinh"),
                    new SubItem("Bảng điểm")
                },
                PackIconKind.Room);

            ItemMenus = new List<ItemMenuControl>
            {
                new ItemMenuControl(assignmentMenu, this),
                new ItemMenuControl(homeroomMenu, this),
            };
        }

        /// <summary>
        /// Khởi tạo menu tùy chọn cho phân hệ Ban Giám Hiệu
        /// </summary>
        private void InitAdminMenu()
        {
            var userManagement = new ItemMenu("Quản lý người dùng",
                new List<SubItem>
                {
                    new SubItem("Danh sách người dùng"),
                    new SubItem("Thêm người dùng", new AddUserUC()),
                    new SubItem("Danh sách chặn")
                },
                PackIconKind.User
                );

            var teacherManagement = new ItemMenu("Quản lý giáo viên",
                new List<SubItem>
                {
                    new SubItem("Danh sách giáo viên"),
                    new SubItem("Phân công giảng dạy"),
                    new SubItem("Phân công chủ nhiệm")
                },
                PackIconKind.Teacher
                );

            var classManagement = new ItemMenu("Quản lý lớp học",
                new List<SubItem>
                {
                    new SubItem("Danh sách lớp học"),
                    new SubItem("Thêm lớp học"),
                },
                PackIconKind.Teacher
                );

            var subjectManagement = new ItemMenu("Quản lý môn học",
                new List<SubItem>
                {
                    new SubItem("Danh sách môn học"),
                    new SubItem("Thêm môn học"),
                },
                PackIconKind.Teacher
                );

            var reportManagement = new ItemMenu("Báo cáo",
                new List<SubItem>
                {
                    new SubItem("Báo cáo tổng kết môn học"),
                    new SubItem("Báo cáo tổng kết học kỳ")
                },
                PackIconKind.Report
                );

            var ruleManagement = new ItemMenu("Quy định",
                new List<SubItem>
                {
                    new SubItem("Quy định độ tuổi"),
                },
                PackIconKind.Ruler
                );

            ItemMenus = new List<ItemMenuControl>
            {
                new ItemMenuControl(userManagement, this),
                new ItemMenuControl(teacherManagement, this),
                new ItemMenuControl(classManagement, this),
                new ItemMenuControl(subjectManagement, this),
                new ItemMenuControl(reportManagement, this),
                new ItemMenuControl(ruleManagement, this)
            };
        }

        /// <summary>
        /// Khởi tạo menu tùy chọn cho phân hệ Giáo Vụ
        /// </summary>
        private void InitMinistryMenu()
        {
            var studentMenu = new ItemMenu("Quản lý học sinh",
                new List<SubItem> 
                { 
                    new SubItem("Danh sách học sinh"),
                    new SubItem("Thêm học sinh")
                },
                PackIconKind.Room);

            var classMenu = new ItemMenu("Quản lý lớp học",
                new List<SubItem> 
                { 
                    new SubItem("Danh sách lớp"),
                    new SubItem("Lập danh sách lớp")
                },
                PackIconKind.Class);

            ItemMenus = new List<ItemMenuControl>
            {
                new ItemMenuControl(classMenu, this),
                new ItemMenuControl(studentMenu, this),
            };
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