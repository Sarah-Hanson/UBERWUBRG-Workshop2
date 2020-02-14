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
    public partial class AddPackage : Form
    {
        public AddPackage()
        {
            InitializeComponent();
        }
        public Package package;
        //to add new packages to the database
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            package = new Package();
            this.PutPackage(package);
            try
            {
                package.PackageId = TravelExpertsDB.AddPackage(package);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            Application.Restart();//You have to reload the form when you submit
        }

        public void PutPackage(Package package)
        {
            package.PkgName = txtName.Text;
            package.PkgStartDate = dtpStart.Value;
            package.PkgEndDate = dtpEnd.Value;
            package.PkgDesc = txtDesc.Text;
            package.PkgBasePrice =Convert.ToDecimal(txtBase.Text);
            package.PkgAgencyCommission =Convert.ToDecimal(txtCommission.Text);
        }
       //to clear the text added before
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            dtpStart.Text = "";
            dtpEnd.Text = "";
            txtDesc.Text = "";
            txtBase.Text = "";
            txtCommission.Text = "";
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
