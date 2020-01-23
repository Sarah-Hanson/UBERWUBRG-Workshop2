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
                string query = "select * from products";
                try {
                    using (SqlCommand cmd = new SqlCommand(query, dbConnect)) {
                        //run command and process results
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                            while (reader.Read()) {
                                Product o = new Product();
                                { ReadFromDB(reader, "ProductID", out int output);      o.ProductID     = output; }
                                { ReadFromDB(reader, "ProductName", out string output); o.ProductName   = output; }
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
        public static void GetObjectListFromDB(out BindingList<Product> products, Package target) {
            products = new BindingList<Product>();
            using (SqlConnection dbConnect = TravelExpertsDB.GetConnection()) {
                dbConnect.Open();
                string query = "SELECT products.ProductId,ProdName FROM Packages_Products_Suppliers,Packages,Products,Products_Suppliers WHERE(Packages_Products_Suppliers.PackageId = Packages.PackageId) and(Packages_Products_Suppliers.ProductSupplierId = Products_Suppliers.ProductSupplierId) and(Products_Suppliers.ProductId = Products.ProductId) and(Packages.PackageId = " + target.PackageID + "); ";
                try {
                    using (SqlCommand cmd = new SqlCommand(query, dbConnect)) {
                        //run command and process results
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                            while (reader.Read()) {
                                Product o = new Product();
                                { ReadFromDB(reader, "ProductID", out int output);      o.ProductID     = output; }
                                { ReadFromDB(reader, "ProductName", out string output); o.ProductName   = output; }
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
                string query = "select * from products";
                using (SqlCommand cmd = new SqlCommand(query, dbConnect)) {
                    //run command and process results
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                        while (reader.Read()) {
                            Package o = new Package();
                            { ReadFromDB(reader, "PackageID", out int output);              o.PackageID          = output; }
                            { ReadFromDB(reader, "PackageName", out string output);         o.PackageName        = output; }
                            { ReadFromDB(reader, "PkgAgencyCommision", out decimal output); o.PkgAgencyCommision = output; }
                            { ReadFromDB(reader, "PkgBasePrice", out decimal output);       o.PkgBasePrice       = output; }
                            { ReadFromDB(reader, "PkgBasePrice", out string output);        o.PkgDesc            = output; }
                            { ReadFromDB(reader, "PkgBasePrice", out DateTime output);      o.PkgEndDate         = output; }
                            { ReadFromDB(reader, "PkgBasePrice", out DateTime output);      o.PkgStartDate       = output; }
                            { GetObjectListFromDB(out BindingList<Product> output, o);      o.ProductsList       = output; }
                            { GetTableFromDB(out DataTable output, o);                      o.ProductsTable      = output; }
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
        public static void GetTableFromDB(out DataTable products, Package target) {
            using (SqlConnection dbConnect = TravelExpertsDB.GetConnection()) {
                dbConnect.Open();
                products = new DataTable();
                string query = "SELECT products.ProductId,ProdName FROM Packages_Products_Suppliers,Packages,Products,Products_Suppliers WHERE(Packages_Products_Suppliers.PackageId = Packages.PackageId) and(Packages_Products_Suppliers.ProductSupplierId = Products_Suppliers.ProductSupplierId) and(Products_Suppliers.ProductId = Products.ProductId) and(Packages.PackageId = " + target.PackageID + "); ";
                using (SqlCommand cmd = new SqlCommand(query, dbConnect)) {
                    //run command and process results
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) {
                        adapter.Fill(products);
                    }
                }
                dbConnect.Close();
            }
        }
        /*
         * The ReadFromDB functions all return a given column to the type given for the out value
         * Overloads for both regular and nullable types available,
         */
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
        static private void ReadFromDB(SqlDataReader r, string column, out string val) {
            if (r[column] != DBNull.Value) {
                val = r[column].ToString();
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
    // Connection string obejct class for the TavelExpertsDB
    static class TravelExpertsDB {
        public static SqlConnection GetConnection() {
            string connectionString =
                @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TravelExperts;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
    }
}
