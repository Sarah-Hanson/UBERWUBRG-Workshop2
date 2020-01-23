using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop2_TravelExperts {
    class DBO<T> {
        public static BindingList<T> GetObjectListFromDB(string query) {
            using (SqlConnection dbConnect = TravelExpertsDB.GetConnection()) {
                dbConnect.Open();

                dbConnect.Close();
                return null;
            }
        }
        public static BindingList<T> GetTableFromDB(string query) {
            using (SqlConnection dbConnect = TravelExpertsDB.GetConnection()) {
                dbConnect.Open();

                dbConnect.Close();
                return null;
            }
        }
        static private string readFromDB(SqlDataReader r, string column, string val) {
            if (r[column] != DBNull.Value) {
                return r[column].ToString();
            }
            else {
                return null;
            }
        }
        static private Nullable<DateTime> readFromDB(SqlDataReader r, String column, Nullable<DateTime> val) {
            if (r[column] != DBNull.Value) {
                return Convert.ToDateTime(r[column].ToString());
            }
            else {
                return null;
            }
        }
        static private Nullable<decimal> readFromDB(SqlDataReader r, String column, Nullable<decimal> val) {
            if (r[column] != DBNull.Value) {
                return Convert.ToDecimal(r[column].ToString());
            }
            else {
                return null;
            }
        }
        static private Nullable<int> readFromDB(SqlDataReader r, String column, Nullable<int> val) {
            if (r[column] != DBNull.Value) {
                return Convert.ToInt32(r[column].ToString());
            }
            else {
                return null;
            }
        }
    }
    class TravelExpertsDB {
        public static SqlConnection GetConnection() {
            string connectionString =
                @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TravelExperts;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
    }
}
