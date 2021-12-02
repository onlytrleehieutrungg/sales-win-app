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
using DataAccess.Repository;

namespace SalesWinApp.AppDetails
{
    public partial class frmOrderDetails : Form
    {
        public frmOrderDetails()
        {
            InitializeComponent();
        }
        public IOrderRepository OrderRepository { get; set; }

        public bool InsertOrUpdate { get; set; }

        public Order OrderInfo { get; set; }
        private void frmOrderDetails_Load(object sender, EventArgs e)
        {
            txtOrderId.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtOrderId.Text = OrderInfo.OrderId.ToString();
                txtMemberId.Text = OrderInfo.MemberId.ToString();
                txtOrderDate.Text = OrderInfo.OrderDate.ToString();
                txtRequiredDate.Text = OrderInfo.RequiredDate.ToString();
                txtShippedDate.Text = OrderInfo.ShippedDate.ToString();
                txtFreight.Text = OrderInfo.Freight.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var order = new Order
                {
                    OrderId = Convert.ToInt32(txtOrderId.Text),
                    MemberId = Convert.ToInt32(txtMemberId.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    ShippedDate = DateTime.Parse(txtShippedDate.Text),
                    Freight = Convert.ToDecimal(txtFreight.Text)
                };
                if (InsertOrUpdate == false)
                {
                    OrderRepository.InsertOrder(order);
                }
                else
                {
                    OrderRepository.UpdateOrder(order);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new order" : "Update a order");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

    }
}
