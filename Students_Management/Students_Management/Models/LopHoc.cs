//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class LopHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LopHoc()
        {
            this.PhanCongs = new HashSet<PhanCong>();
            this.HocSinhs = new HashSet<HocSinh>();
        }
    
        public int Id { get; set; }
        public string TenLop { get; set; }
        public Nullable<int> IdGiaoVien { get; set; }
        public Nullable<int> IdKhoi { get; set; }
        public Nullable<int> IdNamHoc { get; set; }
    
        public virtual GiaoVien GiaoVien { get; set; }
        public virtual Khoi Khoi { get; set; }
        public virtual NamHoc NamHoc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanCong> PhanCongs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocSinh> HocSinhs { get; set; }
    }
}
