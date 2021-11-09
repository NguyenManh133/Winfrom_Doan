using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Win.DAO
{
    public class AdminDAO
    {
        private static AdminDAO instance;
        public static AdminDAO Instance
        {
            get { if (instance == null) instance = new AdminDAO(); return instance; }
            private set { AdminDAO.instance = value; }
        }
        private AdminDAO() { }
        #region NhanVien
        public DataTable loadNV()
        {
            string query = "select * from NHANVIEN";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            return dt;
        }
        public void insertNV()
        {
            string query = "";
            DataProvider.Instance.ExcuteNonQuery(query);
        }
        public void updateNV()
        {
            string query = "";
            DataProvider.Instance.ExcuteNonQuery(query);
        }
        public void deleteNV()
        {
            string query = "";
            DataProvider.Instance.ExcuteNonQuery(query);
        }
        #endregion
        #region TaiKhoan
        public DataTable loadTK()
        {
            string query = "select username, password , HoTen from TAIKHOAN, NHANVIEN where TAIKHOAN.MaNV = NHANVIEN.id";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            return dt;
        }
        public void insertTK()
        {
            string query = "";
            DataProvider.Instance.ExcuteNonQuery(query);
        }
        public void updateTK()
        {
            string query = "";
            DataProvider.Instance.ExcuteNonQuery(query);
        }
        public void deleteTK()
        {
            string query = "";
            DataProvider.Instance.ExcuteNonQuery(query);
        }
        #endregion
        #region BangLuong
        public DataTable loadBL()
        {
            string query = "";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            return dt;
        }
        public void insertBL()
        {
            string query = "";
            DataProvider.Instance.ExcuteNonQuery(query);
        }
        public void updateBL()
        {
            string query = "";
            DataProvider.Instance.ExcuteNonQuery(query);
        }
        public void deleteBL()
        {
            string query = "";
            DataProvider.Instance.ExcuteNonQuery(query);
        }
        #endregion
    }
}
