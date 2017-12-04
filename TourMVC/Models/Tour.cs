//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TourMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            this.ChiPhiTours = new HashSet<ChiPhiTour>();
            this.DoanDuLiches = new HashSet<DoanDuLich>();
            this.DiaDiemTours = new HashSet<DiaDiemTour>();
        }
    
        public int ID { get; set; }
        public string MaTour { get; set; }
        public string TenTour { get; set; }
        public string DacDiem { get; set; }
        public int Gia { get; set; }
        public int LoaiHinhID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiPhiTour> ChiPhiTours { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoanDuLich> DoanDuLiches { get; set; }
        public virtual LoaiHinh LoaiHinh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiaDiemTour> DiaDiemTours { get; set; }
    }
}
