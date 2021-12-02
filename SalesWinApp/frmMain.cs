using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnMemberManagement_Click(object sender, EventArgs e)
        {
            frmMembers frmMembers = new frmMembers();
            frmMembers.Show();
        }

        private void btnProductManagement_Click(object sender, EventArgs e)
        {
            frmProducts frmProducts = new frmProducts();
            frmProducts.Show();
        }
        private void btnOrderManagement_Click(object sender, EventArgs e)
        {
            frmOrders frmOrders = new frmOrders();
            frmOrders.Show();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
