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
        public EditPackage()
        {
            InitializeComponent();
        }

        public Package package;
        private void EditPackage_Load(object sender, EventArgs e)
        {
            this.DisplayPackage();

        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }
        private void DisplayPackage()
        {

            //label1.Text = Convert.ToString(cmbPackages.SelectedValue);
            txtPkgName.Text = package.PkgName;
            dtpStart.Value = package.PkgStartDate;
            dtpEnd.Value = package.PkgEndDate;
            txtDesc.Text = package.PkgDesc;
            txtBase.Text = Convert.ToString(package.PkgBasePrice);
            txtAgency.Text =Convert.ToString(package.PkgAgencyCommision);
        }

       
    }
}
