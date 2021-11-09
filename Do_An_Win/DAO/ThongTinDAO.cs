using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Win.DAO
{
    public class ThongTinDAO
    {
        private static ThongTinDAO instance;
        public static ThongTinDAO Instance
        {
            get { if (instance == null) instance = new ThongTinDAO(); return instance; }
            private set { ThongTinDAO.instance = value; }
        }
        private ThongTinDAO() { }
        public DataTable LoadTTTK(string user)
        {
            string query = "exec USP_LoadTTTK @user";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { user });
            return dt;
        }
        public void updateTT(string id , string  HoTen , string CMND , string DiaChi , string NgaySinh , string SDT)
        {
            string query = "exec USP_UpdateTT @id , @HoTen , @CMND , @DiaChi , @NgaySinh ,  @SDT";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { id, HoTen, CMND, DiaChi, NgaySinh, SDT });
        }
    }
}
