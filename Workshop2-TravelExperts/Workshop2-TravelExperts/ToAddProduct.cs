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
    public partial class ToAddProduct : Form
    {
        List<Product> products;
        public Product product;
        public Package packages;
       
        public ToAddProduct(Package pack)
        {
            InitializeComponent();
            packages = pack;
        }

        private void ToAddProduct_Load(object sender, EventArgs e)
        {
            this.DisplayPackage();
            DBO.GetObjectListFromDB(out products);
            this.LoadComboBox();
           

        }

        private void LoadComboBox()
        {
            try
            {
                cmbProducts.DataSource = products;
                cmbProducts.DisplayMember = "ProdName";
                cmbProducts.ValueMember = "ProductId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString()); ;
            }
        }

        private void DisplayPackage()
        {
            lblPackId.Text = Convert.ToString(packages.PackageId);
            lblName.Text = Convert.ToString(packages.PkgName);
        }

    }
}
