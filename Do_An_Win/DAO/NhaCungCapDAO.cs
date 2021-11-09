using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Win.DAO
{
    public class NhaCungCapDAO
    {
        private static NhaCungCapDAO instance;
        public static NhaCungCapDAO Instance
        {
            get { if (instance == null) instance = new NhaCungCapDAO(); return instance; }
            private set { NhaCungCapDAO.instance = value; }
        }
        private NhaCungCapDAO() { }

        public DataTable loadNCC()
        {
            string query = "select * from NCC";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            return dt;
        }
        public void insertNCC(string id, string TenNCC, string SDT, string DiaChi)
        {
            string query = "exec USP_insertNCC @id , @TenNCC , @SDT , @DiaChi";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { id, TenNCC, SDT, DiaChi });
        }

        public void updateNCC(string id, string TenNCC, string SDT, string DiaChi)
        {
            string query = "exec USP_UpdateNCC @id , @TenNCC , @SDT , @DiaChi";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { id, TenNCC, SDT, DiaChi });
        }
        public void deleteNCC(string id)
        {
            string query = "exec USP_DeleteNCC @id";
            DataProvider.Instance.ExcuteNonQuery(query,new object[] { id });
        }

    }
}
