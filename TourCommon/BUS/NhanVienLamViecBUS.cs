using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourCommon.Model;

namespace TourCommon.BUS
{
    public class NhanVienLamViecBUS
    {
        public bool SaveNhanVien(NhanVien nv) // calling SaveStudentMethod for insert a new record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                _entity.NhanViens.Add(nv);
                _entity.SaveChanges();
                result = true;

            }
            return result;
        }
        public bool UpdateNhanVien(NhanVien nv) // UpdateStudentDetails method for update a existing Record  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                NhanVien _nhanvien = _entity.NhanViens.Where(x => x.ID == nv.ID).Select(x => x).FirstOrDefault();
                _nhanvien.MaNhanVien = nv.MaNhanVien;
                _nhanvien.HoTen = nv.HoTen;
                _entity.SaveChanges();
                result = true;
            }
            return result;
        }
        public NhanVien SetValues(int ID, string MaNhanVien, string HoTen) //Setvalues method for binding field values to StudentInformation Model class
        {
            NhanVien nv = new NhanVien();
            nv.ID = ID;
            nv.MaNhanVien = MaNhanVien;
            nv.HoTen = HoTen;
            return nv;
        }
        public bool DeleteNhanVien(NhanVien nv) // DeleteStudentDetails method to delete record from table  
        {
            bool result = false;
            using (TourDBEntities _entity = new TourDBEntities())
            {
                NhanVien _nhanvien = _entity.NhanViens.Where(x => x.ID == nv.ID).Select(x => x).FirstOrDefault();
                //if (_nhanvien != null)
                //{
                _entity.NhanViens.Remove(_nhanvien);
                _entity.SaveChanges();
                result = true;
                //}            
            }
            return result;
        }
    }
}
