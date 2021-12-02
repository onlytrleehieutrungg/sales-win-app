using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject;

namespace SalesWinApp.AppDetails
{
    public partial class frmProductDetails : Form
    {
        public frmProductDetails()
        {
            InitializeComponent();
        }
        public IProductRepository ProductRepository { get; set; }

        public bool InsertOrUpdate { get; set; }

        public Product ProductInfo { get; set; }

        private void frmProductDetails_Load(object sender, EventArgs e)
        {
            txtProductId.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtProductId.Text = ProductInfo.ProductId.ToString();
                txtCategoryId.Text = ProductInfo.CategoryId.ToString();
                txtProductName.Text = ProductInfo.ProductName;
                txtWeight.Text = ProductInfo.Weight;
                txtUnitPrice.Text = ProductInfo.UnitPrice.ToString();
                txtUnitsInStock.Text = ProductInfo.UnitsInStock.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var product = new Product
                {
                    ProductId = Convert.ToInt32(txtProductId.Text),
                    CategoryId = Convert.ToInt32(txtCategoryId.Text),
                    ProductName = txtProductName.Text,
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock = Convert.ToInt32(txtUnitsInStock.Text)
                };
                if (InsertOrUpdate == false)
                {
                    ProductRepository.InsertProduct(product);
                }
                else
                {
                    ProductRepository.UpdateProduct(product);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new product" : "Update a product");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

       
   
    }
}
