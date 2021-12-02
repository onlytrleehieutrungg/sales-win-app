
namespace SalesWinApp.AppDetails
{
    partial class frmOrderDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbOrderId = new System.Windows.Forms.Label();
            this.lbMemberId = new System.Windows.Forms.Label();
            this.lbOrderDate = new System.Windows.Forms.Label();
            this.lbRequiredDate = new System.Windows.Forms.Label();
            this.lbShippedDate = new System.Windows.Forms.Label();
            this.lbFreight = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.txtOrderDate = new System.Windows.Forms.DateTimePicker();
            this.txtRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.txtShippedDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lbOrderId
            // 
            this.lbOrderId.AutoSize = true;
            this.lbOrderId.Location = new System.Drawing.Point(102, 53);
            this.lbOrderId.Name = "lbOrderId";
            this.lbOrderId.Size = new System.Drawing.Size(60, 20);
            this.lbOrderId.TabIndex = 0;
            this.lbOrderId.Text = "OrderId";
            // 
            // lbMemberId
            // 
            this.lbMemberId.AutoSize = true;
            this.lbMemberId.Location = new System.Drawing.Point(102, 92);
            this.lbMemberId.Name = "lbMemberId";
            this.lbMemberId.Size = new System.Drawing.Size(78, 20);
            this.lbMemberId.TabIndex = 1;
            this.lbMemberId.Text = "MemberId";
            // 
            // lbOrderDate
            // 
            this.lbOrderDate.AutoSize = true;
            this.lbOrderDate.Location = new System.Drawing.Point(102, 132);
            this.lbOrderDate.Name = "lbOrderDate";
            this.lbOrderDate.Size = new System.Drawing.Size(79, 20);
            this.lbOrderDate.TabIndex = 2;
            this.lbOrderDate.Text = "OrderDate";
            // 
            // lbRequiredDate
            // 
            this.lbRequiredDate.AutoSize = true;
            this.lbRequiredDate.Location = new System.Drawing.Point(102, 167);
            this.lbRequiredDate.Name = "lbRequiredDate";
            this.lbRequiredDate.Size = new System.Drawing.Size(101, 20);
            this.lbRequiredDate.TabIndex = 3;
            this.lbRequiredDate.Text = "RequiredDate";
            // 
            // lbShippedDate
            // 
            this.lbShippedDate.AutoSize = true;
            this.lbShippedDate.Location = new System.Drawing.Point(102, 206);
            this.lbShippedDate.Name = "lbShippedDate";
            this.lbShippedDate.Size = new System.Drawing.Size(96, 20);
            this.lbShippedDate.TabIndex = 4;
            this.lbShippedDate.Text = "ShippedDate";
            // 
            // lbFreight
            // 
            this.lbFreight.AutoSize = true;
            this.lbFreight.Location = new System.Drawing.Point(102, 242);
            this.lbFreight.Name = "lbFreight";
            this.lbFreight.Size = new System.Drawing.Size(55, 20);
            this.lbFreight.TabIndex = 5;
            this.lbFreight.Text = "Freight";
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(224, 46);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(125, 27);
            this.txtOrderId.TabIndex = 6;
            // 
            // txtMemberId
            // 
            this.txtMemberId.Location = new System.Drawing.Point(224, 89);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.Size = new System.Drawing.Size(125, 27);
            this.txtMemberId.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(102, 325);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(288, 325);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(224, 239);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(125, 27);
            this.txtFreight.TabIndex = 13;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtOrderDate.Location = new System.Drawing.Point(224, 132);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(250, 27);
            this.txtOrderDate.TabIndex = 14;
            // 
            // txtRequiredDate
            // 
            this.txtRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtRequiredDate.Location = new System.Drawing.Point(224, 168);
            this.txtRequiredDate.Name = "txtRequiredDate";
            this.txtRequiredDate.Size = new System.Drawing.Size(250, 27);
            this.txtRequiredDate.TabIndex = 15;
            // 
            // txtShippedDate
            // 
            this.txtShippedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtShippedDate.Location = new System.Drawing.Point(224, 201);
            this.txtShippedDate.Name = "txtShippedDate";
            this.txtShippedDate.Size = new System.Drawing.Size(250, 27);
            this.txtShippedDate.TabIndex = 16;
            // 
            // frmOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 450);
            this.Controls.Add(this.txtShippedDate);
            this.Controls.Add(this.txtRequiredDate);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.txtFreight);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtMemberId);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.lbFreight);
            this.Controls.Add(this.lbShippedDate);
            this.Controls.Add(this.lbRequiredDate);
            this.Controls.Add(this.lbOrderDate);
            this.Controls.Add(this.lbMemberId);
            this.Controls.Add(this.lbOrderId);
            this.Name = "frmOrderDetails";
            this.Text = "Order Details";
            this.Load += new System.EventHandler(this.frmOrderDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbOrderId;
        private System.Windows.Forms.Label lbMemberId;
        private System.Windows.Forms.Label lbOrderDate;
        private System.Windows.Forms.Label lbRequiredDate;
        private System.Windows.Forms.Label lbShippedDate;
        private System.Windows.Forms.Label lbFreight;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtFreight;
        private System.Windows.Forms.DateTimePicker txtOrderDate;
        private System.Windows.Forms.DateTimePicker txtRequiredDate;
        private System.Windows.Forms.DateTimePicker txtShippedDate;
    }
}