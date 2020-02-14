using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workshop2_TravelExperts {

    /// <summary>
    /// Project by: Team 8 -- Brandon Cuthbertson, Neel Pandya, Sara Hanson
    /// See Update Notes for non-programming based updates
    /// </summary>
    public partial class FrmTravel : Form {

        List<Package> packages;
        public FrmTravel() {
            InitializeComponent();
        }
        public Package Package;

        private void FrmTravel_Load(object sender, EventArgs e)
        {
            this.LoadComboBox();
            
        }

        private void LoadComboBox()
        {
             packages = new List<Package>();
            try
            {
                packages = TravelExpertsDB.GetPackage();
                cmbPackages.DataSource = packages;
                cmbPackages.DisplayMember = "PkgName";
                cmbPackages.ValueMember = "PackageId";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString()); ;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
            string val;
             val = Convert.ToString(cmbPackages.SelectedItem);
             if (val != null)
            {
                this.DisplayPacks();

            }
           
            else
            {
               
            }
               

            
        }
        private void GetPacks(int PackageID)
        {
            Package package;
            try
            {
                package = TravelExpertsDB.GetPacks(PackageID);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
        private void DisplayPacks()
        {
            Package pack = new Package();
            int packIndex = cmbPackages.SelectedIndex;
            pack = packages[packIndex];
            pack = TravelExpertsDB.GetPacks(pack.PackageId);
            lblPackID.Text = Convert.ToString(pack.PackageId);
            dateTimePicker1.Value = Convert.ToDateTime(pack.PkgStartDate);
            dateTimePicker2.Text = Convert.ToString(pack.PkgEndDate);
            //lblStart.Text = Convert.ToString(pack.PkgStartDate);
           // lblEnd.Text = Convert.ToString(pack.PkgEndDate);
            lblDesc.Text = pack.PkgDesc;
            lblPrice.Text = Convert.ToString(pack.PkgBasePrice);
            lblCommision.Text = Convert.ToString(pack.PkgAgencyCommision);
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            AddPackage addPackageform = new AddPackage();
           // addPackage.addPackage = true;
            DialogResult result = addPackageform.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditPackage editpackform = new EditPackage(packages[cmbPackages.SelectedIndex]);
            DialogResult result = editpackform.ShowDialog();
           
            editpackform.package = Package;
           
            if (result == DialogResult.OK)
            {
                Package = editpackform.package;
                //this.DisplayPacks(p);
            }
            else if (result == DialogResult.Retry)
            {
                this.GetPacks(Package.PackageId);
                if (Package != null)
                {
                    this.DisplayPacks();
                }
                else
                {
                    //this.ClearControls();
                }
            }
        }
    }
}
