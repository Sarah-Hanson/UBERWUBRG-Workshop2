using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop2_TravelExperts {
    class Package {
        public int PackageID { get; set; }
        public string PackageName { get; set; }
        public DateTime PkgStartDate { get; set; }
        public DateTime PkgEndDate { get; set; }
        public string PkgDesc { get; set; }
        public decimal PkgBasePrice { get; set; }
        public decimal PkgAgencyCommision { get; set; }
        public BindingList<Product> Products { get; set; }

    }

}
