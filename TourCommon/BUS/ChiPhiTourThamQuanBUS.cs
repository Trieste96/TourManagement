using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourCommon.Model;

namespace TourCommon.BUS
{
    public class ChiPhiTourThamQuanBUS
    {
        public ChiPhiTour SetValues(int ID, string TenChiPhi, int ChiPhiUocTinh,string GhiChu, int TourID, int LoaiCP) //Setvalues method for binding field values to StudentInformation Model class
        {
            ChiPhiTour cpt = new ChiPhiTour();
            cpt.ID = ID;
            cpt.TenChiPhi = TenChiPhi;
            cpt.ChiPhiUocTinh = ChiPhiUocTinh;
            cpt.GhiChu = GhiChu;
            cpt.TourID = TourID;
            cpt.LoaiCP = LoaiCP;
            return cpt;
        }
        public bool SaveChiPhiTour(ChiPhiTour cpt) // calling SaveStudentMethod for insert a new record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                _entity.ChiPhiTours.Add(cpt);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool UpdateChiPhiTour(ChiPhiTour cpt) // UpdateStudentDetails method for update a existing Record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                ChiPhiTour _cpt = _entity.ChiPhiTours.Where(x => x.ID == cpt.ID).Select(x => x).FirstOrDefault();
                _cpt.ID = cpt.ID;
                _cpt.TenChiPhi = cpt.TenChiPhi;
                _cpt.ChiPhiUocTinh = cpt.ChiPhiUocTinh;
                _cpt.GhiChu = cpt.GhiChu;
                _cpt.TourID = cpt.TourID;
                _cpt.LoaiCP = cpt.LoaiCP;
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool DeleteChiPhiTour(ChiPhiTour cpt) // DeleteStudentDetails method to delete record from table  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                ChiPhiTour _cpt = _entity.ChiPhiTours.Where(x => x.ID == cpt.ID).Select(x => x).FirstOrDefault();
                _entity.ChiPhiTours.Remove(_cpt);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
