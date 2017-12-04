using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourApplication.DAL
{
    public class ThongTinTour
    {
        public int ID { get; set; }
        public string MaTour { get; set; }
        public string TenTour { get; set; }
        public string DacDiem { get; set; }
        public int Gia { get; set; }
        public int LoaiHinhID { get; set; }
    }
}
