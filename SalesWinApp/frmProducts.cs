using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Repository;
using SalesWinApp.AppDetails;
using BusinessObject;


namespace SalesWinApp
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

         IProductRepository productRepository= new ProductRepository();
         BindingSource source;

        private void frmProducts_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            dgvProductList.CellDoubleClick += dgvProductList_CellDoubleClick;
        }

        private void dgvProductList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmProductDetails frmProductDetails = new frmProductDetails
            {
                Text = "Update product",
                InsertOrUpdate = true,
                ProductInfo = GetProductObject(),
                ProductRepository = productRepository
            };
            if (frmProductDetails.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }
        }

        private void ClearText()
        {
            txtProductId.Text = string.Empty;
            txtCategoryId.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtUnitsInStock.Text = string.Empty;
        }

        private Product GetProductObject()
        {
            Product product = null;
            try
            {
                product = new Product
                {
                    ProductId = int.Parse(txtProductId.Text),
                    CategoryId = int.Parse(txtCategoryId.Text),
                    ProductName = txtProductName.Text,
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock = int.Parse(txtUnitsInStock.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get product");
            }
            return product;
        }

        
        public void LoadProductList()
        {
            var products = productRepository.GetProduct();
            try
            {
                source = new BindingSource();
                source.DataSource = products;
                
                txtProductId.DataBindings.Clear();
                txtCategoryId.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitsInStock.DataBindings.Clear();

                txtProductId.DataBindings.Add("Text", source, "ProductId");
                txtCategoryId.DataBindings.Add("Text", source, "CategoryId");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitsInStock.DataBindings.Add("Text", source, "UnitsInStock");

                dgvProductList.DataSource = null;
                dgvProductList.DataSource = source;
                if (products.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Product List");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmProductDetails frmProductDetails = new frmProductDetails
            {
                Text = "Add Product",
                InsertOrUpdate = false,
                ProductRepository = productRepository
            };
            if (frmProductDetails.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                var product = GetProductObject();
                productRepository.DeleteProduct(product.ProductId);
                LoadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a Product");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtSearchValue.Text;
                if (radioId.Checked)
                {
                    int searchID = int.Parse(searchValue);
                    IEnumerable<Product> searchResult = productRepository.Search(searchID);
                    if (searchResult.Any())
                    {
                        source = new BindingSource();
                        source.DataSource = searchResult;

                        txtProductId.DataBindings.Clear();
                        txtCategoryId.DataBindings.Clear();
                        txtProductName.DataBindings.Clear();
                        txtWeight.DataBindings.Clear();
                        txtUnitPrice.DataBindings.Clear();
                        txtUnitsInStock.DataBindings.Clear();

                        txtProductId.DataBindings.Add("Text", source, "ProductId");
                        txtCategoryId.DataBindings.Add("Text", source, "CategoryId");
                        txtProductName.DataBindings.Add("Text", source, "ProductName");
                        txtWeight.DataBindings.Add("Text", source, "Weight");
                        txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                        txtUnitsInStock.DataBindings.Add("Text", source, "UnitsInStock");

                        dgvProductList.DataSource = null;
                        dgvProductList.DataSource = source;

                    }
                    else
                    {
                        MessageBox.Show("No result found!", "Search product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else if (radioName.Checked)
                {
                    string searchName = searchValue;
                    IEnumerable<Product> searchResult = productRepository.Search(searchName);
                    if (searchResult.Any())
                    {
                        source = new BindingSource();
                        source.DataSource = searchResult;

                        txtProductId.DataBindings.Clear();
                        txtCategoryId.DataBindings.Clear();
                        txtProductName.DataBindings.Clear();
                        txtWeight.DataBindings.Clear();
                        txtUnitPrice.DataBindings.Clear();
                        txtUnitsInStock.DataBindings.Clear();

                        txtProductId.DataBindings.Add("Text", source, "ProductId");
                        txtCategoryId.DataBindings.Add("Text", source, "CategoryId");
                        txtProductName.DataBindings.Add("Text", source, "ProductName");
                        txtWeight.DataBindings.Add("Text", source, "Weight");
                        txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                        txtUnitsInStock.DataBindings.Add("Text", source, "UnitsInStock");

                        dgvProductList.DataSource = null;
                        dgvProductList.DataSource = source;
                    }
                    else
                    {
                        MessageBox.Show("No result found!", "Search product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
