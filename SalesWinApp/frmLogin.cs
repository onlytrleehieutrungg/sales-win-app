using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject;
using DataAccess.Repository;
using SalesWinApp.AppDetails;

namespace SalesWinApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        IMemberRepository memberRepository = new MemberRepository();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string Email = txtEmail.Text;
                string Password = txtPassword.Text;
                Member loginMember = memberRepository.Login(Email, Password);
              
                if (loginMember != null)
                {
                    MessageBox.Show("Login successfully", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string email = loginMember.Email;
                    if (email.Equals("admin@fstore.com"))
                    {
                        frmMain frmMain = new frmMain();                                              
                        frmMain.Show();
                    }
                    else
                    {
                        frmMemberDetails frmMemberDetails = new frmMemberDetails
                        {
                            Text = "Member Details",
                            MemberInfo = loginMember,
                            InsertOrUpdate = true,
                            MemberRepository = memberRepository
                          

                        };
                        frmMemberDetails.Show();
                    }
                    
                }
                else
                {
                    if (MessageBox.Show("Login failed!!", "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                    {
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
