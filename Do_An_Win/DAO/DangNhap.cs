using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Win.DAO
{
    public class DangNhap
    {
        private static DangNhap instance;
        public static DangNhap Instance
        {
            get { if (instance == null) instance = new DangNhap(); return instance; }
            private set { DangNhap.instance = value; }
        }
        private DangNhap() { }

        public bool Login(string username, string password)
        {
            return DangNhap.instance.Login(username, password);
        }
        public bool Logind(string username, string password)
        {
            string query = "exec USP_GetLogin @Username , @Password ";
            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] { username, password });
            return result.Rows.Count > 0;
        }

    }
}
