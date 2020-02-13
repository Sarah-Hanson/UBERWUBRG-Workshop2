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
        public FrmTravel() {
            InitializeComponent();
        }

        private void FrmTravel_Load(object sender, EventArgs e)
        {
            this.LoadComboBox();
            
        }

        private void LoadComboBox()
        {
            List<Package> packages = new List<Package>();
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
        /*private void GetPacks(int PackageID)
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
        }*/
        private void DisplayPacks()
        {
            Package packs = new Package();
            int packID = Convert.ToInt32(cmbPackages.SelectedValue);
            packs = TravelExpertsDB.GetPacks(packID);
            lblPackID.Text = Convert.ToString(packs.PackageId);
            lblStart.Text = Convert.ToString(packs.PkgStartDate);
            lblEnd.Text = Convert.ToString(packs.PkgEndDate);
            lblDesc.Text = packs.PkgDesc;
            lblPrice.Text = Convert.ToString(packs.PkgBasePrice);
            lblCommision.Text = Convert.ToString(packs.PkgAgencyCommision);
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            AddPackage addPackageform = new AddPackage();
           // addPackage.addPackage = true;
            DialogResult result = addPackageform.ShowDialog();
        }
    }
}
