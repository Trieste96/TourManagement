using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourCommon.Model;

namespace TourCommon.BUS
{
    public class DiaDiemThamQuanBUS
    {
        public DiaDiem SetValues(int ID, string TenDiaDiem, int TinhID) //Setvalues method for binding field values to StudentInformation Model class
        {
            DiaDiem dd = new DiaDiem();
            dd.ID = ID;
            dd.TenDiaDiem = TenDiaDiem;
            dd.TinhID = TinhID;
            return dd;
        }
        public bool SaveDiaDiemThamQuan(DiaDiem dd) // calling SaveStudentMethod for insert a new record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                _entity.DiaDiems.Add(dd);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool UpdateDiaDiemThamQuan(DiaDiem dd) // UpdateStudentDetails method for update a existing Record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                DiaDiem _diadiem = _entity.DiaDiems.Where(x => x.ID == dd.ID).Select(x => x).FirstOrDefault();
                _diadiem.TenDiaDiem = dd.TenDiaDiem;
                _diadiem.TinhID = dd.TinhID;
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool DeleteDiaDiemThamQuan(DiaDiem dd) // DeleteStudentDetails method to delete record from table  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                DiaDiem _diadiem = _entity.DiaDiems.Where(x => x.ID == dd.ID).Select(x => x).FirstOrDefault();
                _entity.DiaDiems.Remove(_diadiem);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
