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
using DataAccess.Repository;
using SalesWinApp.AppDetails;
using BusinessObject;

namespace SalesWinApp
{
    public partial class frmOrders : Form
    {
        public frmOrders()
        {
            InitializeComponent();
        }


        IOrderRepository orderRepository = new OrderRepository();
        BindingSource source;

        private void frmOrders_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            dgvOrderList.CellDoubleClick += dgvOrderList_CellDoubleClick;
        }
        private void dgvOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmOrderDetails frmOrderDetails = new frmOrderDetails
            {
                Text = "Update Order",
                InsertOrUpdate = true,
                OrderInfo = GetOrderObject(),
                OrderRepository = orderRepository
            };
            if (frmOrderDetails.ShowDialog() == DialogResult.OK)
            {
                LoadOrderList();
                source.Position = source.Count - 1;
            }
        }

        private void ClearText()
        {
            txtOrderId.Text = string.Empty;
            txtMemberId.Text = string.Empty;
            txtOrderDate.Text = string.Empty;
            txtRequiredDate.Text = string.Empty;
            txtShippedDate.Text = string.Empty;
            txtFreight.Text = string.Empty;
        }

        private Order GetOrderObject()
        {
            Order order = null;
            try
            {
                order = new Order
                {
                    OrderId = Convert.ToInt32(txtOrderId.Text),
                    MemberId = Convert.ToInt32(txtMemberId.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    ShippedDate = DateTime.Parse(txtShippedDate.Text),
                    Freight = Convert.ToDecimal(txtFreight.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get order");
            }
            return order;
        }

        public void LoadOrderList()
        {
            var orders = orderRepository.GetOrder();
            try
            {
                source = new BindingSource();
                source.DataSource = orders;

                txtOrderId.DataBindings.Clear();
                txtMemberId.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtShippedDate.DataBindings.Clear();
                txtFreight.DataBindings.Clear();

                txtOrderId.DataBindings.Add("Text", source, "OrderId");
                txtMemberId.DataBindings.Add("Text", source, "MemberId");
                txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");
                txtFreight.DataBindings.Add("Text", source, "Freight");

                dgvOrderList.DataSource = null;
                dgvOrderList.DataSource = source;
                if (orders.Count() == 0)
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
                MessageBox.Show(ex.Message, "Load Order List");
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadOrderList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmOrderDetails frmOrderDetails = new frmOrderDetails
            {
                Text = "Add order",
                InsertOrUpdate = false,
                OrderRepository = orderRepository
            };
            if (frmOrderDetails.ShowDialog() == DialogResult.OK)
            {
                LoadOrderList();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var order = GetOrderObject();
                orderRepository.DeleteOrder(order.OrderId);
                LoadOrderList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a Product");
            }
        }
    }
}
