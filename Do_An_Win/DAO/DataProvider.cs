using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Win.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { DataProvider.instance = value; }
        }
        private DataProvider() { }
        public string sql = "Data Source=.\\SQLEXPRESS;Initial Catalog=Do_An;Persist Security Info=True;User ID=sa; PWD=1332001";
        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection Connection  = new SqlConnection(sql))
            {
                Connection.Open();
                SqlCommand command = new SqlCommand(query, Connection);
                if(parameter != null)
                {
                    string[] listdata = query.Split(' ');
                    int  i = 0;
                    foreach(string item in listdata)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                Connection.Close();
            }
            return data;
        }

        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection Connection = new SqlConnection(sql))
            {
                Connection.Open();
                SqlCommand command = new SqlCommand(query, Connection);
                if (parameter != null)
                {
                    string[] listdata = query.Split(' ');
                    int i = 0;
                    foreach (string item in listdata)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                Connection.Close();
            }
            return data;
        }
        public object ExcuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection Connection = new SqlConnection(sql))
            {
                Connection.Open();
                SqlCommand command = new SqlCommand(query, Connection);
                if (parameter != null)
                {
                    string[] listdata = query.Split(' ');
                    int i = 0;
                    foreach (string item in listdata)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                Connection.Close();
            }
            return data;
        }

    }
}
