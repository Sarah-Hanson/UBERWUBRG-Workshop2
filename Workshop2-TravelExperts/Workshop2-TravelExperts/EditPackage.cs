using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workshop2_TravelExperts
{
    public partial class EditPackage : Form
    {
        public Package package;
        public EditPackage(Package pack) {
            InitializeComponent();
            package = pack;
        }
        private void EditPackage_Load(object sender, EventArgs e) {
            this.DisplayPackage();
        }
        private void btnSubmit_Click(object sender, EventArgs e) {

        }
        private void DisplayPackage() {
            label1.Text = Convert.ToString(package.PackageId);
            txtPkgName.Text = package.PkgName;
            dtpStart.Text = Convert.ToString(package.PkgStartDate);
            dtpEnd.Text =Convert.ToString(package.PkgEndDate);
            txtDesc.Text = package.PkgDesc;
            txtBase.Text = Convert.ToString(package.PkgBasePrice);

            txtAgency.Text = Convert.ToString(package.PkgAgencyCommision);
        }

        private void btnBack_Click(object sender, EventArgs e){ //Added by BC
            this.Close();
        }
    }
}
