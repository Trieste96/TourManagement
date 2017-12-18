using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourCommon.DAL;
using TourCommon.Model;

namespace TourCommon.BUS
{
    public class TinhThamQuanBUS
    {
        public bool SaveTinh(Tinh tinh) // calling SaveStudentMethod for insert a new record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                _entity.Tinhs.Add(tinh);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public Tinh SetValues(int ID, string TenTinh) //Setvalues method for binding field values to StudentInformation Model class
        {
            Tinh tinh = new Tinh();
            tinh.ID = ID;
            tinh.TenTinh = TenTinh;
            return tinh;
        }
        public bool DeleteTinh(Tinh tinh) // DeleteStudentDetails method to delete record from table  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                Tinh _tinh = _entity.Tinhs.Where(x => x.ID == tinh.ID).Select(x => x).FirstOrDefault();
                _entity.Tinhs.Remove(_tinh);
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool UpdateTinh(Tinh tinh) // UpdateStudentDetails method for update a existing Record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                Tinh _tinh = _entity.Tinhs.Where(x => x.ID == tinh.ID).Select(x => x).FirstOrDefault();
                _tinh.TenTinh = tinh.TenTinh;
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
