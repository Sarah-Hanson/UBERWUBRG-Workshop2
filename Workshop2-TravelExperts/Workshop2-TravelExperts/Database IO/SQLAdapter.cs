using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Author: Sarah
 * A class library for handling sql data, allows users to get tables from the DB, insert items to the db and remove items from the DB
 * The classes use properly formatted objects to interact with the databases, The object must have a couple things to work with the
 * Library:
 * Class name: Matches the table name
 * Properties: 1 property for each column you would like to pull, name matches column name. The first property must be the primary key and no other values may be identity values.
 * You may not include properties that do not correspond to a column name as the method will attempt to pull all properties
 */

namespace SQLAdapter {
    public static class SQLAdapter {
        /*
         * Gets a list of the supplied type from the database, allows specifying the query to narrow down the pull results
         * List<T> Outlist: The list of objects passed back by the method, if an exception is encountered, an empty list is passed
         *     SQLDB dbcon: The database connection. Must implement the SQLDB interface
         * string sqlQuery: Sql query to be run.
         *          return: boolean value to indicate if an error has occurred
         */
        public static bool GetFromDB<T>(out List<T> outList, SQLDB dbCon, string sqlQuery) where T : class, new() {
            outList = new List<T>();
            PropertyInfo[] fields = typeof(T).GetProperties();

            using (SqlConnection dbConnect = dbCon.GetConnection()) {
                dbConnect.Open();
                string query = sqlQuery;
                try {
                    using (SqlCommand cmd = new SqlCommand(query, dbConnect)) {
                        //run command and process results
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                            while (reader.Read()) {
                                T o = new T();
                                foreach (PropertyInfo prop in fields) {
                                    if (reader[prop.Name] != DBNull.Value) {
                                        string column = prop.Name;
                                        string readO = reader[column].ToString();
                                        Type propType = prop.PropertyType;

                                        prop.SetValue(o, Convert.ChangeType(readO, propType), null);
                                    }
                                    else
                                        prop.SetValue(o, null, null);
                                    //prop.SetValue(o, default(), null);
                                }
                                outList.Add(o);
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    outList = new List<T>();
                    return false;
                }
                dbConnect.Close();
                return true;
            }
        }
        /*
         * Gets a list of the supplied type from the database, automatically generates a "select * " query for the object
         * List<T> Outlist: The list of objects passed back by the method, if an exception is encountered, an empty list is passed
         *     SQLDB dbcon: The database connection. Must implement the SQLDB interface
         *          return: boolean value to indicate if an error has occurred
         */
        public static bool GetFromDB<T>(out List<T> outList, SQLDB dbCon) where T : class, new() {
            outList = new List<T>();
            PropertyInfo[] fields = typeof(T).GetProperties();
            T tableType = new T();
            using (SqlConnection dbConnect = dbCon.GetConnection()) {
                dbConnect.Open();
                string query = "select * from " + tableType.GetType().Name;
                try {
                    using (SqlCommand cmd = new SqlCommand(query, dbConnect)) {
                        //run command and process results
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                            while (reader.Read()) {
                                T o = new T();
                                foreach (PropertyInfo prop in fields) {
                                    if (reader[prop.Name] != DBNull.Value) {
                                        string column = prop.Name;
                                        string readO = reader[column].ToString();
                                        Type propType = prop.PropertyType;

                                        prop.SetValue(o, Convert.ChangeType(readO, propType), null);
                                    }
                                    else
                                        prop.SetValue(o, null, null);
                                    //prop.SetValue(o, default(), null);
                                }
                                outList.Add(o);
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    outList = new List<T>();
                    return false;
                }
                dbConnect.Close();
                return true;
            }
        }
        /*
         * Inserts the passed object into the database, generates query automatically based on object
         *     T insertObj: The object to be inserted 
         *     SQLDB dbcon: The database connection. Must implement the SQLDB interface
         *          return: boolean value to indicate if an error has occurred
         */
        public static bool InsertToDB<T>(T insertObj, SQLDB dbCon) where T : class, new() {
            PropertyInfo[] fields = typeof(T).GetProperties();
            T tableType = new T();
            using (SqlConnection dbConnect = dbCon.GetConnection()) {
                dbConnect.Open();
                // Crafting the SQL Query
                string query = "INSERT INTO " + tableType.GetType().Name + "(";
                int i = 0;
                int last = fields.Length - 1;
                foreach (PropertyInfo prop in fields) {
                    if (i != 0) {
                        query += prop.Name;
                        if (i < last)
                            query += ", ";
                    }
                    i++;
                }
                query += ") Values (";
                i = 0;
                foreach (PropertyInfo prop in fields) {
                    if (i != 0) {
                        query += "@" + prop.Name;
                        if (i < last)
                            query += ", ";
                    }
                    i++;
                }
                query += ")";
                // Running the Query
                try {
                    using (SqlCommand cmd = new SqlCommand(query, dbConnect)) {
                        foreach (PropertyInfo prop in fields) {
                            cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(insertObj));
                        }
                        cmd.ExecuteScalar();
                        dbConnect.Close();
                        return true;
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    return false;
                }

            }
        }
        /*
         * Inserts the passed list of objects into the database, generates query automatically based on object
         *     T insertObj: The objects to be inserted 
         *     SQLDB dbcon: The database connection. Must implement the SQLDB interface
         *          return: boolean value to indicate if an error has occurred
         */
        public static bool InsertToDB<T>(List<T> insertList, SQLDB dbCon) where T : class, new() {
            bool success = true;
            foreach (T o in insertList) {
                if (!InsertToDB<T>(o, dbCon))
                    success = false;
            }

            return success;
        }
        /*
         * Removes the specified object from the database
         * List<T> Outlist: The list of objects passed back by the method, if an exception is encountered, an empty list is passed
         *     SQLDB dbcon: The database connection. Must implement the SQLDB interface
         *          return: boolean value to indicate if an error has occurred
         */
        public static bool RemoveFromDB<T>(T deleteObj, SQLDB dbCon) where T : class, new() {
            PropertyInfo[] fields = typeof(T).GetProperties();
            T tableType = new T();
            using (SqlConnection dbConnect = dbCon.GetConnection()) {
                dbConnect.Open();
                // Crafting the SQL Query
                string query = "DELETE FROM " + tableType.GetType().Name + " WHERE ";
                int i = 0;
                int last = fields.Length - 1;
                foreach (PropertyInfo prop in fields) {
                    query += prop.Name + " = \'" + prop.GetValue(deleteObj) + "\'";
                    if (i++ < last) query += " and ";
                }
                // Running the Query
                try {
                    using (SqlCommand cmd = new SqlCommand(query, dbConnect)) {
                        cmd.ExecuteScalar();
                        dbConnect.Close();
                        return true;
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    return false;
                }

            }
        }
    }
    public interface SQLDB {
        SqlConnection GetConnection();
    }
}

