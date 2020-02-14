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
        public EditPackage(Package pack)
        {
            InitializeComponent();
            package = pack;
        }
        private void EditPackage_Load(object sender, EventArgs e)
        {
            this.DisplayPackage();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Package newPack = new Package();
            newPack.PackageId = package.PackageId;
            this.PutPackageData(newPack);
            try
            {
                if (!TravelExpertsDB.UpdatePackage(package,newPack))
                {
                    MessageBox.Show("Another user has updated or " +
                        "deleted that customer.", "Database Error");
                    this.DialogResult = DialogResult.Retry;
                }
                else // success
                {
                    package = newPack;
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            Application.Restart();//You have to reload the form when you submit
        }
    

        private void DisplayPackage() {
            label1.Text = Convert.ToString(package.PackageId);
            txtPkgName.Text = package.PkgName;
            dtpStart.Text = Convert.ToString(package.PkgStartDate);
            dtpEnd.Text =Convert.ToString(package.PkgEndDate);
            txtDesc.Text = package.PkgDesc;
            txtBase.Text = Convert.ToString(package.PkgBasePrice);

            txtAgency.Text = Convert.ToString(package.PkgAgencyCommission);
        }

        private void btnBack_Click(object sender, EventArgs e){ //Added by BC
            this.Close();
            
        }
        private void PutPackageData(Package package)
        {
            package.PkgName = txtPkgName.Text;
            package.PkgStartDate = dtpStart.Value;
            package.PkgEndDate = dtpEnd.Value;
            package.PkgDesc = txtDesc.Text;
            package.PkgBasePrice = Convert.ToDecimal(txtBase.Text);
            package.PkgAgencyCommission = Convert.ToDecimal(txtAgency.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPkgName.Text = "";
            dtpStart.Text = "";
            dtpEnd.Text = "";
            txtBase.Text = "";
            txtDesc.Text = "";
            txtAgency.Text = "";
        }
    }
}
