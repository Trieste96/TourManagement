//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TourCommon.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DoanDuLich
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoanDuLich()
        {
            this.ChiPhiDoans = new HashSet<ChiPhiDoan>();
            this.NhanVienDoans = new HashSet<NhanVienDoan>();
            this.ThanhVienDoans = new HashSet<ThanhVienDoan>();
        }
    
        public int ID { get; set; }
        public string TenDoan { get; set; }
        public System.DateTime NgayKhoiHanh { get; set; }
        public System.DateTime NgayKetThuc { get; set; }
        public string ChiTietND { get; set; }
        public int GiaTour { get; set; }
        public string MaDoan { get; set; }
        public int TinhTrangID { get; set; }
        public int TourID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiPhiDoan> ChiPhiDoans { get; set; }
        public virtual TinhTrangDoan TinhTrangDoan { get; set; }
        public virtual Tour Tour { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVienDoan> NhanVienDoans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhVienDoan> ThanhVienDoans { get; set; }
    }
}
