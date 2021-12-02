
namespace SalesWinApp
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lbMemberManagement = new System.Windows.Forms.ToolStripLabel();
            this.lbProductManagement = new System.Windows.Forms.ToolStripLabel();
            this.lbOrderManagement = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbMemberManagement,
            this.lbProductManagement,
            this.lbOrderManagement});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1188, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lbMemberManagement
            // 
            this.lbMemberManagement.Name = "lbMemberManagement";
            this.lbMemberManagement.Size = new System.Drawing.Size(65, 22);
            this.lbMemberManagement.Text = "Member";
            this.lbMemberManagement.Click += new System.EventHandler(this.btnMemberManagement_Click);
            // 
            // lbProductManagement
            // 
            this.lbProductManagement.Name = "lbProductManagement";
            this.lbProductManagement.Size = new System.Drawing.Size(60, 22);
            this.lbProductManagement.Text = "Product";
            this.lbProductManagement.Click += new System.EventHandler(this.btnProductManagement_Click);
            // 
            // lbOrderManagement
            // 
            this.lbOrderManagement.Name = "lbOrderManagement";
            this.lbOrderManagement.Size = new System.Drawing.Size(47, 22);
            this.lbOrderManagement.Text = "Order";
            this.lbOrderManagement.Click += new System.EventHandler(this.btnOrderManagement_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 664);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Management";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lbMemberManagement;
        private System.Windows.Forms.ToolStripLabel lbProductManagement;
        private System.Windows.Forms.ToolStripLabel lbOrderManagement;
    }
}

