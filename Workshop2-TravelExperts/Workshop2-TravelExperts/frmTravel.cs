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
    /// Set Roles:
    /// Neel:   - Add/Edit Tables
    /// Brandon:- Gui design and validation
    /// Sarah:  - Database Integration
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

            decimal price = decimal.Round(packs.PkgBasePrice, 2, MidpointRounding.AwayFromZero);//Rounds to the nearest Decimal Value
            lblPrice.Text = price.ToString("c");//Converts to currenct
            decimal Commision = decimal.Round(packs.PkgAgencyCommision, 2, MidpointRounding.AwayFromZero);
            lblCommision.Text = Commision.ToString("c");
        }

   

        private void cmbPackages_DropDownClosed(object sender, EventArgs e)//Changed To Drop Down Close to remove he search button
        {
            string val;
            val = Convert.ToString(cmbPackages.SelectedItem);
            if (val != null)
            {
                this.DisplayPacks();

            }

            else
            {
                MessageBox.Show("Invalid Search Entry.\n Please add a Valid entry", "Error");
            }
        }
    }
}
