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
    /// Program Jobs: 
    ///     Neel:
    ///         -Add/Edit Packages
    ///  Brandon:
    ///         -Validation
    ///         -Gui layout
    ///    Sarah:
    ///         -Database Integration
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
            dtpStart.Value = Convert.ToDateTime(pack.PkgStartDate);
            dtpEnd.Text = Convert.ToString(pack.PkgEndDate);
            //lblStart.Text = Convert.ToString(pack.PkgStartDate);
           // lblEnd.Text = Convert.ToString(pack.PkgEndDate);
            lblDesc.Text = pack.PkgDesc;
            decimal price = decimal.Round(pack.PkgBasePrice, 2, MidpointRounding.AwayFromZero);//Rounds to the nearest Decimal Value
            lblPrice.Text = price.ToString("c");//Converts to currenct
            decimal Commision = decimal.Round(pack.PkgAgencyCommision, 2, MidpointRounding.AwayFromZero);
            lblCommision.Text = Commision.ToString("c");
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

       

        private void cmbPackages_SelectedValueChanged(object sender, EventArgs e)//Removed Search Button for a removed index changed
        {
            string val;
            val = Convert.ToString(cmbPackages.SelectedItem);
            if (val != null)
            {
                this.DisplayPacks();

            }

            else
            {
                MessageBox.Show("Error\n Selected Value Error: VALUE NULL", "ERROR");
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)//added by bc
        {
            Close();
        }
    }
}
