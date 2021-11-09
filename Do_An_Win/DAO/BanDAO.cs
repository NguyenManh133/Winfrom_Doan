using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Win.DAO
{
    public class BanDAO
    {
        private static BanDAO instance;
        public static BanDAO Instance
        {
            get { if (instance == null) instance = new BanDAO(); return instance; }
            private set { BanDAO.instance = value; }
        }
        private BanDAO() { }
        public DataTable LoadBan()
        {
            string query = "select id , Ten , iif(TrangThai = 1,N'Hoạt động',N'Không hoạt đông') from BAN";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            return dt;
        }
        public void insertBan(string tenBan, int trangThai)
        {
            string query = "exec USP_insertBan @tenBan , @trangThai";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { tenBan, trangThai});
        }
        public void deleteBan(int idBan)
        {
            string query = "exec USP_deleteBan @idBan";
            DataProvider.Instance.ExcuteNonQuery(query,new object[] { idBan});
        }
        public void updataBan(int idBan, string tenBan, int trangThai)
        {
            string query = "exec USP_updataBan @idBan , @tenBan , @trangThai";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { idBan,tenBan,trangThai});
        }
    }
}
