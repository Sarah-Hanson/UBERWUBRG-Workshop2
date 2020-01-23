using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Author: Sarah Hanson
 * Holds data for the packages table as well as the rows from the products table that are tied to the package
 */
namespace Workshop2_TravelExperts {
    class Package {
        public int PackageID { get; set; }
        public string PackageName { get; set; }
        public DateTime PkgStartDate { get; set; }
        public DateTime PkgEndDate { get; set; }
        public string PkgDesc { get; set; }
        public decimal PkgBasePrice { get; set; }
        public decimal PkgAgencyCommision { get; set; }
        public BindingList<Product> ProductsList { get; set; }
        public DataTable ProductsTable { get; set; }

    }

}
