//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TourModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiPhiTour
    {
        public int ID { get; set; }
        public string TenChiPhi { get; set; }
        public int ChiPhiUocTinh { get; set; }
        public string GhiChu { get; set; }
        public int TourID { get; set; }
        public int LoaiCP { get; set; }
    
        public virtual LoaiChiPhi LoaiChiPhi { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
