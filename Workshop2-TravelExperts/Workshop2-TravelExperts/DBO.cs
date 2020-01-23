using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workshop2_TravelExperts {
    /*
     * Author: Sarah Hanson
     * Object for handling the input and retreival of data from the DB to object classes to be used within the program
     * Visible Functions: GetObjectListFromDB(5 Overloads), GetTableFromTB(5 Overloads)
     */
    class DBO<T> {
        /*
         * The get ObjectListFromDB function overlaod all serve to accept an object list from the caller and
         * fill that list from the DB with the appropriate data from the table, they handle the queries and 
         * data creation based on the inputed list type;
         */
        public static void GetObjectListFromDB(out BindingList<Product> products) {
            products = new BindingList<Product>();
            using (SqlConnection dbConnect = TravelExpertsDB.GetConnection()) {
                dbConnect.Open();
                string query = "";
                try {
                    using (SqlCommand cmd = new SqlCommand(query, dbConnect)) {
                        //run command and process results
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                            while (reader.Read()) {
                                Product o = new Product();
                                { ReadFromDB(reader, "ProductID", out int output); o.ProductID = output; }
                                { ReadFromDB(reader, "ProductName", out string output); o.ProductName = output; }
                                products.Add(o);
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                dbConnect.Close();
            }
        }
        public static void GetObjectListFromDB(out BindingList<Package> packages) {
            packages = new BindingList<Package>();
            using (SqlConnection dbConnect = TravelExpertsDB.GetConnection()) {
                dbConnect.Open();
                string query = "";
                using (SqlCommand cmd = new SqlCommand(query, dbConnect)) {
                    //run command and process results
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                        while (reader.Read()) {
                            Package o = new Package();
                            { ReadFromDB(reader, "PackageID", out int output); o.PackageID = output; }
                            { ReadFromDB(reader, "PackageName", out string output); o.PackageName = output; }
                            { ReadFromDB(reader, "PackageName", out string output); o.PackageName = output; }
                            packages.Add(o);
                        }
                        
                    }
                }
                dbConnect.Close();
            }
        }
        /*
         * The get ObjectListFromDB function overlaod all serve to accept an object list from the caller and
         * fill that list from the DB with the appropriate data from the table, they handle the queries and 
         * data creation based on the inputed list type;
         */
        public static BindingList<T> GetTableFromDB(string query) {
            using (SqlConnection dbConnect = TravelExpertsDB.GetConnection()) {
                dbConnect.Open();

                dbConnect.Close();
                return null;
            }
        }
        /*
         * The ReadFromDB functions all return a given column to the type given for the out value;
         */
        static private void ReadFromDB(SqlDataReader r, string column, out string val) {
            if (r[column] != DBNull.Value) {
                val = r[column].ToString();
            }
            else {
                val = null;
            }
        }
        static private void ReadFromDB(SqlDataReader r, String column, out Nullable<DateTime> val) {
            if (r[column] != DBNull.Value) {
                val = Convert.ToDateTime(r[column].ToString());
            }
            else {
                val = null;
            }
        }
        static private void ReadFromDB(SqlDataReader r, String column, out Nullable<decimal> val) {
            if (r[column] != DBNull.Value) {
                val = Convert.ToDecimal(r[column].ToString());
            }
            else {
                val = null;
            }
        }
        static private void ReadFromDB(SqlDataReader r, String column, out Nullable<int> val) {
            if (r[column] != DBNull.Value) {
                val = Convert.ToInt32(r[column].ToString());
            }
            else {
                val = null;
            }
        }
        static private void ReadFromDB(SqlDataReader r, String column, out DateTime val) {
            val = Convert.ToDateTime(r[column].ToString());
        }
        static private void ReadFromDB(SqlDataReader r, String column, out decimal val) {
            val = Convert.ToDecimal(r[column].ToString());
        }
        static private void ReadFromDB(SqlDataReader r, String column, out int val) {
            val = Convert.ToInt32(r[column].ToString());
        }
    }
    // Connection string class for the TavelExpertsDB
    class TravelExpertsDB {
        public static SqlConnection GetConnection() {
            string connectionString =
                @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TravelExperts;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
    }
}
