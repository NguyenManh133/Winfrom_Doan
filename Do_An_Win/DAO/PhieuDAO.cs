using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Win.DAO
{
    public class PhieuDAO
    {
        private static PhieuDAO instance;
        public static PhieuDAO Instance
        {
            get { if (instance == null) instance = new PhieuDAO(); return instance; }
            private set { PhieuDAO.instance = value; }
        }
        private PhieuDAO() { }
        #region HoaDon
        public DataTable LoadDSHD()
        {
            string query = "USP_LoadListHD";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            return dt;
        }
        public DataTable LoadTT(int id)
        {
            string query = "exec USP_LoadTTHD @id";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { id});
            return dt;
        }
       
        public DataTable LoadCT_HD(int id)
        {
            string query = "exec USP_LoadCT_HD @id ";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { id });
            return dt;
        }
        #endregion

        #region PhieuNhap
        public DataTable LoadDSPN()
        {
            string query = "USP_LoadPN";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            return dt;
        }
        public DataTable LoadCT_PN(int id)
        {
            string query = "exec USP_LoadCT_PN @id";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { id});
            return dt;
        }
        #endregion

        #region PhieuXuat 
        public DataTable LoadDSPX()
        {
            string query = "USP_LoadPX";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            return dt;
        }
        public DataTable LoadCT_PX(int id)
        {
            string query = "exec USP_LoadCT_PX @id";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { id });
            return dt;
        }
        #endregion
        #region PhieuKiem
        public DataTable LoadDSPK()
        {
            string query = "USP_LoadPK";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            return dt;
        }
        public DataTable LoadCT_PK(int id)
        {
            string query = "exec USP_LoadCT_PK @id";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { id });
            return dt;
        }
        #endregion

    }
}
