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
    
    public partial class KhachDuLich
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachDuLich()
        {
            this.ThanhVienDoans = new HashSet<ThanhVienDoan>();
        }
    
        public int ID { get; set; }
        public string MaKhach { get; set; }
        public string HoTen { get; set; }
        public string CMND { get; set; }
        public string DiaChi { get; set; }
        public bool GioiTinh { get; set; }
        public string SDT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhVienDoan> ThanhVienDoans { get; set; }
    }
}
