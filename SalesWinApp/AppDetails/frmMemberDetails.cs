﻿using System;
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
    public partial class frmMemberDetails : Form
    {
        public frmMemberDetails()
        {
            InitializeComponent();
        }
        public IMemberRepository MemberRepository { get; set; }

        public bool InsertOrUpdate { get; set; }

        public Member MemberInfo { get; set; }
        private void frmMemberDetails_Load(object sender, EventArgs e)
        {
            txtMemberId.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtMemberId.Text = MemberInfo.MemberId.ToString();
                txtEmail.Text = MemberInfo.Email;
                txtCompanyName.Text = MemberInfo.CompanyName;
                txtCity.Text = MemberInfo.City;
                txtCountry.Text = MemberInfo.Country;
                txtPassword.Text = MemberInfo.Password;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var member = new Member
                {
                    MemberId = int.Parse(txtMemberId.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text
                };
                if (InsertOrUpdate == false)
                {
                    MemberRepository.InsertMember(member);
                }
                else
                {
                    MemberRepository.UpdateMember(member);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new Member" : "Update a Member");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

    }
}
