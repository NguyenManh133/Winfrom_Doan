using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Win.DAO
{
    public class SanPhamDAO
    {
        private static SanPhamDAO instance;
        public static SanPhamDAO Instance
        {
            get { if (instance == null) instance = new SanPhamDAO(); return instance; }
            private set { SanPhamDAO.instance = value; }
        }
        private SanPhamDAO() { }
        public DataTable LoadSP()
        {
            string query = "USP_LoadSP";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            return dt;
        }
        public void insertSP(string id , string Ten , int DonGia , string Loai)
        {
            string query = "exec USP_InsertSP @id , @Ten , @DonGia , @Loai";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { id, Ten, DonGia, Loai });
        }
        public void deleteSP(string id)
        {
            string query = "exec USP_DeleteSP @id";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { id });
        }
        public void updateSP(string id, string Ten, int DonGia, string Loai)
        {
            string query = "exec USP_UpdateSP @id ,  @Ten , @DonGia , @Loai";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { id, Ten, DonGia, Loai });
        }
    }
}
