using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Win.DAO
{
    public class HangHoaDAO
    {
        private static HangHoaDAO instance;
        public static HangHoaDAO Instance
        {
            get { if (instance == null) instance = new HangHoaDAO(); return instance; }
            private set { HangHoaDAO.instance = value; }
        }
        private HangHoaDAO() { }
        public DataTable LoadHH()
        {
            string query = "USP_LoadHH";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            return dt;
        }
        public DataTable LoadNCC()
        {
            string query = "select * from NCC";
            DataTable dt = DataProvider.Instance.ExcuteQuery(query);
            return dt;
        }
        public void InsertHH(string id,string TenHH,string MaNCC,int TonKho,string Dvt)
        {
            string query = "exec USP_InsertHH @id , @TenHH , @MaNCC , @TonKho , @DonViTinh";
            DataProvider.Instance.ExcuteNonQuery(query,new object[] { id, TenHH,  MaNCC, TonKho,  Dvt });
        }
        public void deleteHH(string id)
        {
            string query = "exec USP_deleteHH @id";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { id });
        }
        public void updateHH(string id , string TenHH , int TonKho , string dvt)
        {
            string query = "exec USP_updateHH @id , @TenHH ,  @TonKho , @dvt";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { id, TenHH, TonKho, dvt });
        }
        public void insertPK(string idNV)
        {
            string query = "exec  USP_insertPK @MaNV";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { idNV });
        }
        public void insertCT_PK()
        {
            string query = "USP_insertCT_PK";
            DataProvider.Instance.ExcuteNonQuery(query);
        }
    }
}
