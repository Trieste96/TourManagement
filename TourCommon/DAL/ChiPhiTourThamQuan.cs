using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourCommon.DAL
{
    public class ChiPhiTourThamQuan
    {
        public int ID { get; set; }
        public string TenChiPhi { get; set; }
        public int ChiPhiUocTinh { get; set; }
        public string GhiChu { get; set; }
        public int TourID { get; set; }
        public int LoaiCP { get; set; }
    }
}
