using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Win.DAO
{
    public class NghiepVuDAO
    {
        private static NghiepVuDAO instance;
        public static NghiepVuDAO Instance
        {
            get { if (instance == null) instance = new NghiepVuDAO(); return instance; }
            private set { NghiepVuDAO.instance = value; }
        }
        private NghiepVuDAO() { }
        #region HoaDon
        public DataTable LoadDSBan()
        {
            string query = "select * from BAN";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            return dt;
        }
        public void insertHD(int Tongtien, string MaNV, int MaBan, int MaKH)
        {
            string query = "exec USP_insertHD @Tongtien , @MaNV , @MaBan , @MaKH";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { Tongtien, MaNV, MaBan, MaKH });
        }
        public void insertCT_HD( int MaHD, string MaSP , int SL, int Thanhtien) 
        {
            string query = "exec USP_insertCTHD @MaHD , @MaSP , @SLuong , @ThanhTien";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { MaHD, MaSP, SL, Thanhtien});
            
        }
        public void insertKH(string sdt, string tenKH)
        {
            string query = "exec USP_InsertKhachHang @sdt , @hoten";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { sdt, tenKH });

        }
        public int getIDKH()
        {
            string quyer = "checkID_KH";
            DataTable dt = DataProvider.Instance.ExcuteQuery(quyer);
            int idKH = int.Parse(dt.Rows[0][0].ToString());
            return idKH;
        }
        public string getIDNV(string user)
        {
            string query = " exec USP_getIDNV @user";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query, new object[] { user});
            string idNV = dt.Rows[0][0].ToString();
            return idNV;
        }
        public int getIDHD()
        {
            string query = " select max(id) from HOADON";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            int idHD = int.Parse(dt.Rows[0][0].ToString());
            return idHD;
        }
        #endregion
        #region PhieuNhap
        public DataTable LoadDSHH()
        {
            string query = "USP_LoadHH";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            return dt;
        }
        public  void insertPN(string idNV, int TongSL)
        {
            string query = "exec USP_insertPN @MaNV , @TongSL";
            DataProvider.Instance.ExcuteNonQuery(query,new object[] { idNV,TongSL});
        }
        public void insertCT_PN(string MaHH, int MaPN, int SL)
        {
            string query = "exec USP_insertCT_PN @MaHH , @MaPN , @SL";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { MaHH,MaPN,SL});
        }
        public int getIDPN()
        {
            string query = "select max(id) from PHIEUNHAP";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            int idPN = int.Parse(dt.Rows[0][0].ToString());
            return idPN;
        }
        #endregion
        #region PhieuXuat
        public void insertPX(string idNV, int TongSL)
        {
            string query = "exec USP_insertPX @MaNV , @TongSL";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { idNV, TongSL });
        }
        public void insertCT_PX(string MaHH, int MaPN, int SL)
        {
            string query = "exec USP_insertCT_PX @MaHH , @MaPX , @SL";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { MaHH, MaPN, SL });
        }
        public int getIDPX()
        {
            string query = "select max(id) from PHIEUXUAT";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            int idPN = int.Parse(dt.Rows[0][0].ToString());
            return idPN;
        }
        #endregion

        public void updateSLHH(string id, int sl)
        {
            string query = "exec USP_updateSLHH @id , @SL";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { id,sl });
        }
    }
}
