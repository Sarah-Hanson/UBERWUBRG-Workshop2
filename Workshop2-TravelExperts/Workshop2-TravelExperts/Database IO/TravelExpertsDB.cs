using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop2_TravelExperts {
    static class TravelExpertsDB {
        public static SqlConnection GetConnection() {
            string connectionString =
                @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TravelExperts;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
        //To fill the combo box
        public static List<Packages> GetPackage() {
            List<Packages> pack = new List<Packages>();// an empty list
            Packages pk; // auxiliary for reading
                        //create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection()) {
                // create command
                string query = "SELECT PackageId,PkgName " +
                    "FROM Packages " +
                               "ORDER BY PkgName";
                using (SqlCommand cmd = new SqlCommand(query, connection)) {
                    // run the command and process results
                    connection.Open();
                    using (SqlDataReader reader =
                        cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                        while (reader.Read()) {
                            // process next record from data reader
                            pk = new Packages();
                            pk.PackageId = Convert.ToInt32(reader["PackageId"]);
                            pk.PkgName = Convert.ToString(reader["PkgName"]);
                            pack.Add(pk);
                        }
                    } // closes reader & recycles object
                } // cmd object recycled
            } // connection object recycled
            return pack;

        }
        //to get the data from database
        public static Packages GetPacks(int packID) {
            Packages pack = null;
            using (SqlConnection connection = TravelExpertsDB.GetConnection()) {
                string query = "SELECT PackageId,PkgName,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission " +
                    "FROM Packages " +
                    "WHERE PackageId= @PackageId ";
                using (SqlCommand cmd = new SqlCommand(query, connection)) {
                    cmd.Parameters.AddWithValue("@PackageId", packID);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow)) {
                        if (reader.Read()) // if there is data
                        {
                            pack = new Packages();
                            pack.PackageId = (int)reader["PackageId"];
                            pack.PkgName = Convert.ToString(reader["PkgName"]);
                            pack.PkgStartDate = Convert.ToDateTime(reader["PkgStartDate"]);
                            pack.PkgEndDate = Convert.ToDateTime(reader["PkgEndDate"]);
                            pack.PkgDesc = reader["PkgDesc"].ToString();
                            pack.PkgBasePrice = Convert.ToDecimal(reader["PkgBasePrice"]);
                            pack.PkgAgencyCommission = Convert.ToDecimal(reader["PkgAgencyCommission"]);

                        }
                    }
                }
            }
            return pack;
        }
        public static int AddPackage(Packages pack) {
            int pacakgeId = -1;
            using (SqlConnection conn = TravelExpertsDB.GetConnection()) {
                string Query = "INSERT INTO Packages(PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission) " +
                    " OUTPUT inserted.PackageId " +
                    "VALUES(@PkgName, @PkgStartDate, @PkgEndDate, @PkgDesc, @PkgBasePrice, @PkgAgencyCommission)";

                using (SqlCommand cmd = new SqlCommand(Query, conn)) {
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
        public static bool UpdatePackage(Packages oldPack, Packages newPack) {
            int count; // how many rows updated
            using (SqlConnection connection = TravelExpertsDB.GetConnection()) {
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
                    " AND PkgAgencyCommission = @oldPkgAgencyCommission ";
                using (SqlCommand cmd = new SqlCommand(updateStatement, connection)) {
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
