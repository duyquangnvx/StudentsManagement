﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Students_Management.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StudentManagementEntities : DbContext
    {
        public StudentManagementEntities()
            : base("name=StudentManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BangDiem> BangDiems { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<GiaoVien> GiaoViens { get; set; }
        public virtual DbSet<HeSo> HeSoes { get; set; }
        public virtual DbSet<HocKy> HocKies { get; set; }
        public virtual DbSet<HocSinh> HocSinhs { get; set; }
        public virtual DbSet<Khoi> Khois { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<NamHoc> NamHocs { get; set; }
        public virtual DbSet<PhanCong> PhanCongs { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
