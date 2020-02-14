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
    class DBO {
        /*
         * The get ObjectListFromDB function overlaod all serve to accept an object list from the caller and
         * fill that list from the DB with the appropriate data from the table, they handle the queries and 
         * data creation based on the inputed list type;
         */
        public static void GetObjectListFromDB(out List<Product> products) {
            products = new List<Product>();
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
        public static void GetObjectListFromDB(out List<Product> products, Package target) {
            products = new List<Product>();
            using (SqlConnection dbConnect = TravelExpertsDB.GetConnection()) {
                dbConnect.Open();
                string query = "SELECT products.ProductId,ProdName FROM Packages_Products_Suppliers,Packages,Products,Products_Suppliers WHERE(Packages_Products_Suppliers.PackageId = Packages.PackageId) and(Packages_Products_Suppliers.ProductSupplierId = Products_Suppliers.ProductSupplierId) and(Products_Suppliers.ProductId = Products.ProductId) and(Packages.PackageId = " + target.PackageId + "); ";
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
        public static void GetObjectListFromDB(out List<Package> packages) {
            packages = new List<Package>();
            using (SqlConnection dbConnect = TravelExpertsDB.GetConnection()) {
                dbConnect.Open();
                string query = "select * from packages";
                using (SqlCommand cmd = new SqlCommand(query, dbConnect)) {
                    //run command and process results
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                        while (reader.Read()) {
                            Package o = new Package();
                            { ReadFromDB(reader, "PackageId", out int output);              o.PackageId          = output; }
                            { ReadFromDB(reader, "PkgName", out string output);         o.PkgName        = output; }
                            { ReadFromDB(reader, "PkgAgencyCommission", out decimal output); o.PkgAgencyCommission = output; }
                            { ReadFromDB(reader, "PkgBasePrice", out decimal output);       o.PkgBasePrice       = output; }
                            { ReadFromDB(reader, "PkgDesc", out string output);             o.PkgDesc            = output; }
                            { ReadFromDB(reader, "PkgEndDate", out DateTime output);        o.PkgEndDate         = output; }
                            { ReadFromDB(reader, "PkgStartDate", out DateTime output);      o.PkgStartDate       = output; }
                           // { GetObjectListFromDB(out BindingList<Product> output, o);      o.ProductsList       = output; }
                            { GetTableFromDB(out DataTable output, o);                      o.ProductsTable      = output; }
                            packages.Add(o);
                        }
                    }
                }
                dbConnect.Close();
            }
        }
        public static void GetObjectListFromDB(out List<Supplier> suppliers) {
            suppliers = new List<Supplier>();
            using (SqlConnection dbConnect = TravelExpertsDB.GetConnection()) {
                dbConnect.Open();
                string query = "select * from products";
                try {
                    using (SqlCommand cmd = new SqlCommand(query, dbConnect)) {
                        //run command and process results
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                            while (reader.Read()) {
                                Supplier o = new Supplier();
                                { ReadFromDB(reader, "SupplierID", out int output); o.SupplierID = output; }
                                { ReadFromDB(reader, "SupName", out string output); o.SupName    = output; }
                                suppliers.Add(o);
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
        public static void GetObjectListFromDB(out List<ProductSupplier> prodSup) {
            prodSup = new List<ProductSupplier>();
            using (SqlConnection dbConnect = TravelExpertsDB.GetConnection()) {
                dbConnect.Open();
                string query = "select * from products";
                try {
                    using (SqlCommand cmd = new SqlCommand(query, dbConnect)) {
                        //run command and process results
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                            while (reader.Read()) {
                                ProductSupplier o = new ProductSupplier();
                                { ReadFromDB(reader, "ProductID", out int output);         o.ProductID         = output; }
                                { ReadFromDB(reader, "ProductSupplierID", out int output); o.ProductSupplierID = output; }
                                prodSup.Add(o);
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
        /*
         * The get ObjectListFromDB function overlaod all serve to accept an object list from the caller and
         * fill that list from the DB with the appropriate data from the table, they handle the queries and 
         * data creation based on the inputed list type;
         */
        public static void GetTableFromDB(out DataTable products, Package target) {
            using (SqlConnection dbConnect = TravelExpertsDB.GetConnection()) {
                dbConnect.Open();
                products = new DataTable();
                string query = "SELECT products.ProductId,ProdName FROM Packages_Products_Suppliers,Packages,Products,Products_Suppliers WHERE(Packages_Products_Suppliers.PackageId = Packages.PackageId) and(Packages_Products_Suppliers.ProductSupplierId = Products_Suppliers.ProductSupplierId) and(Products_Suppliers.ProductId = Products.ProductId) and(Packages.PackageId = " + target.PackageId + "); ";
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
        //To fill the combo box
        public static List<Package> GetPackage()
        {
            List<Package> pack = new List<Package>();// an empty list
            Package pk; // auxiliary for reading
                        //create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                // create command
                string query = "SELECT PackageId,PkgName " +
                    "FROM Packages " +
                               "ORDER BY PkgName";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run the command and process results
                    connection.Open();
                    using (SqlDataReader reader =
                        cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            // process next record from data reader
                            pk = new Package();
                            pk.PackageId =Convert.ToInt32(reader["PackageId"]);
                            pk.PkgName = Convert.ToString(reader["PkgName"]);
                            pack.Add(pk);
                        }
                    } // closes reader & recycles object
                } // cmd object recycled
            } // connection object recycled
            return pack;

        }
        //to get the data from database
       public static Package GetPacks(int packID)
        {
            Package pack = null;
            using(SqlConnection connection= TravelExpertsDB.GetConnection())
            {
                string query = "SELECT PackageId,PkgName,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission " +
                    "FROM Packages " + 
                    "WHERE PackageId= @PackageId " ;
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", packID);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read()) // if there is data
                        {
                            pack = new Package();
                            pack.PackageId = (int)reader["PackageId"];
                            pack.PkgName = Convert.ToString(reader["PkgName"]);
                            pack.PkgStartDate = Convert.ToDateTime(reader["PkgStartDate"]);
                            pack.PkgEndDate =Convert.ToDateTime(reader["PkgEndDate"]);
                            pack.PkgDesc = reader["PkgDesc"].ToString();
                            pack.PkgBasePrice = Convert.ToDecimal(reader["PkgBasePrice"]);
                            pack.PkgAgencyCommission = Convert.ToDecimal(reader["PkgAgencyCommission"]);
                            
                        }
                    }
                }
            }
            return pack;
        } 

        public static int AddPackage(Package pack)
        {
            int pacakgeId = -1;
            using(SqlConnection conn= TravelExpertsDB.GetConnection())
            {
                string Query = "INSERT INTO Packages(PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission) " +
                    " OUTPUT inserted.PackageId " +
                    "VALUES(@PkgName, @PkgStartDate, @PkgEndDate, @PkgDesc, @PkgBasePrice, @PkgAgencyCommission)";
               
                using(SqlCommand cmd= new SqlCommand(Query, conn))
                {
                    cmd.Parameters.AddWithValue("@PkgName", pack.PkgName);
                    cmd.Parameters.AddWithValue("@PkgStartDate", pack.PkgStartDate);
                    cmd.Parameters.AddWithValue("@PkgEndDate", pack.PkgEndDate);
                    cmd.Parameters.AddWithValue("@PkgDesc", pack.PkgDesc);
                    cmd.Parameters.AddWithValue("@PkgBasePrice", pack.PkgBasePrice);
                    cmd.Parameters.AddWithValue("@PkgAgencyCommission", pack.PkgAgencyCommission);
                    conn.Open();
                    pacakgeId = (int)cmd.ExecuteScalar();
                }
            }
            return pacakgeId;
        }

        public static bool UpdatePackage(Package oldPack, Package newPack)
        {
            int count; // how many rows updated
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string updateStatement =
                    "UPDATE Packages SET " +
                    " PkgName = @newPkgName, " +
                    " PkgStartDate = @newPkgStartDate, " +
                    " PkgEndDate = @newPkgEndDate, " +
                    " PkgDesc = @newPkgDesc, " +
                    " PkgBasePrice = @newPkgBasePrice, " +
                    " PkgAgencyCommission = @newPkgAgencyCommission " +
                    " WHERE PackageId = @oldPackageId " + 
                    " AND PkgName = @oldPkgName " + 
                    " AND PkgStartDate = @oldPkgStartDate " +
                    " AND PkgEndDate = @oldPkgEndDate " +
                    " AND PkgDesc = @oldPkgDesc " +
                    " AND PkgBasePrice = @oldPkgBasePrice " +
                    " AND PkgAgencyCommission = @oldPkgAgencyCommission " ;
                using (SqlCommand cmd = new SqlCommand(updateStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@newPkgName", newPack.PkgName);
                    cmd.Parameters.AddWithValue("@newPkgStartDate", newPack.PkgStartDate);
                    cmd.Parameters.AddWithValue("@newPkgEndDate", newPack.PkgEndDate);
                    cmd.Parameters.AddWithValue("@newPkgDesc", newPack.PkgDesc);
                    cmd.Parameters.AddWithValue("@newPkgBasePrice", newPack.PkgBasePrice);
                    cmd.Parameters.AddWithValue("@newPkgAgencyCommission", newPack.PkgAgencyCommission);
                    cmd.Parameters.AddWithValue("@oldPackageId", oldPack.PackageId);
                    cmd.Parameters.AddWithValue("@oldPkgName", oldPack.PkgName);
                    cmd.Parameters.AddWithValue("@oldPkgStartDate", oldPack.PkgStartDate);
                    cmd.Parameters.AddWithValue("@oldPkgEndDate", oldPack.PkgEndDate);
                    cmd.Parameters.AddWithValue("@oldPkgDesc", oldPack.PkgDesc);
                    cmd.Parameters.AddWithValue("@oldPkgBasePrice", oldPack.PkgBasePrice);
                    cmd.Parameters.AddWithValue("@oldPkgAgencyCommission", oldPack.PkgAgencyCommission);
                    connection.Open();
                    count = cmd.ExecuteNonQuery(); // returns how many rows updated
                }
            }

            return (count > 0);
        }

    } // end class
}

    

    

