namespace ArmysalgClientDesktop.GuiLayer
{
    partial class Products
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
            this.listBoxProducts = new System.Windows.Forms.ListBox();
            this.txtBName = new System.Windows.Forms.TextBox();
            this.txtBDescription = new System.Windows.Forms.TextBox();
            this.txtBPurchasePrice = new System.Windows.Forms.TextBox();
            this.txtBStatus = new System.Windows.Forms.TextBox();
            this.txtBStock = new System.Windows.Forms.TextBox();
            this.txtBMinStock = new System.Windows.Forms.TextBox();
            this.txtBMaxStock = new System.Windows.Forms.TextBox();
            this.cbIsDeleted = new System.Windows.Forms.CheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblMinStock = new System.Windows.Forms.Label();
            this.lblMaxStock = new System.Windows.Forms.Label();
            this.lblIsDeleted = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxProducts
            // 
            this.listBoxProducts.FormattingEnabled = true;
            this.listBoxProducts.ItemHeight = 15;
            this.listBoxProducts.Location = new System.Drawing.Point(39, 66);
            this.listBoxProducts.Name = "listBoxProducts";
            this.listBoxProducts.Size = new System.Drawing.Size(120, 244);
            this.listBoxProducts.TabIndex = 0;
            this.listBoxProducts.SelectedIndexChanged += new System.EventHandler(this.listBoxProducts_SelectedIndexChanged);
            // 
            // txtBName
            // 
            this.txtBName.Location = new System.Drawing.Point(331, 66);
            this.txtBName.Name = "txtBName";
            this.txtBName.Size = new System.Drawing.Size(100, 23);
            this.txtBName.TabIndex = 1;
            // 
            // txtBDescription
            // 
            this.txtBDescription.Location = new System.Drawing.Point(331, 95);
            this.txtBDescription.Name = "txtBDescription";
            this.txtBDescription.Size = new System.Drawing.Size(100, 23);
            this.txtBDescription.TabIndex = 2;
            // 
            // txtBPurchasePrice
            // 
            this.txtBPurchasePrice.Location = new System.Drawing.Point(331, 124);
            this.txtBPurchasePrice.Name = "txtBPurchasePrice";
            this.txtBPurchasePrice.Size = new System.Drawing.Size(100, 23);
            this.txtBPurchasePrice.TabIndex = 3;
            // 
            // txtBStatus
            // 
            this.txtBStatus.Location = new System.Drawing.Point(331, 153);
            this.txtBStatus.Name = "txtBStatus";
            this.txtBStatus.Size = new System.Drawing.Size(100, 23);
            this.txtBStatus.TabIndex = 4;
            // 
            // txtBStock
            // 
            this.txtBStock.Location = new System.Drawing.Point(331, 182);
            this.txtBStock.Name = "txtBStock";
            this.txtBStock.Size = new System.Drawing.Size(100, 23);
            this.txtBStock.TabIndex = 5;
            // 
            // txtBMinStock
            // 
            this.txtBMinStock.Location = new System.Drawing.Point(331, 211);
            this.txtBMinStock.Name = "txtBMinStock";
            this.txtBMinStock.Size = new System.Drawing.Size(100, 23);
            this.txtBMinStock.TabIndex = 6;
            // 
            // txtBMaxStock
            // 
            this.txtBMaxStock.Location = new System.Drawing.Point(331, 240);
            this.txtBMaxStock.Name = "txtBMaxStock";
            this.txtBMaxStock.Size = new System.Drawing.Size(100, 23);
            this.txtBMaxStock.TabIndex = 7;
            // 
            // cbIsDeleted
            // 
            this.cbIsDeleted.AutoSize = true;
            this.cbIsDeleted.Location = new System.Drawing.Point(331, 270);
            this.cbIsDeleted.Name = "cbIsDeleted";
            this.cbIsDeleted.Size = new System.Drawing.Size(15, 14);
            this.cbIsDeleted.TabIndex = 8;
            this.cbIsDeleted.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(242, 69);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 15);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Name";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(242, 98);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 15);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Description";
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Location = new System.Drawing.Point(242, 127);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(84, 15);
            this.lblPurchasePrice.TabIndex = 11;
            this.lblPurchasePrice.Text = "Purchase price";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(243, 156);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 15);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Status";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(242, 185);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(36, 15);
            this.lblStock.TabIndex = 13;
            this.lblStock.Text = "Stock";
            // 
            // lblMinStock
            // 
            this.lblMinStock.AutoSize = true;
            this.lblMinStock.Location = new System.Drawing.Point(242, 214);
            this.lblMinStock.Name = "lblMinStock";
            this.lblMinStock.Size = new System.Drawing.Size(59, 15);
            this.lblMinStock.TabIndex = 14;
            this.lblMinStock.Text = "Min stock";
            // 
            // lblMaxStock
            // 
            this.lblMaxStock.AutoSize = true;
            this.lblMaxStock.Location = new System.Drawing.Point(242, 243);
            this.lblMaxStock.Name = "lblMaxStock";
            this.lblMaxStock.Size = new System.Drawing.Size(61, 15);
            this.lblMaxStock.TabIndex = 15;
            this.lblMaxStock.Text = "Max stock";
            // 
            // lblIsDeleted
            // 
            this.lblIsDeleted.AutoSize = true;
            this.lblIsDeleted.Location = new System.Drawing.Point(243, 269);
            this.lblIsDeleted.Name = "lblIsDeleted";
            this.lblIsDeleted.Size = new System.Drawing.Size(57, 15);
            this.lblIsDeleted.TabIndex = 16;
            this.lblIsDeleted.Text = "Is deleted";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(331, 302);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 23);
            this.btnCreate.TabIndex = 17;
            this.btnCreate.Text = "Create product";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 385);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblIsDeleted);
            this.Controls.Add(this.lblMaxStock);
            this.Controls.Add(this.lblMinStock);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPurchasePrice);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cbIsDeleted);
            this.Controls.Add(this.txtBMaxStock);
            this.Controls.Add(this.txtBMinStock);
            this.Controls.Add(this.txtBStock);
            this.Controls.Add(this.txtBStatus);
            this.Controls.Add(this.txtBPurchasePrice);
            this.Controls.Add(this.txtBDescription);
            this.Controls.Add(this.txtBName);
            this.Controls.Add(this.listBoxProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Products";
            this.Text = "Products";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxProducts;
        private System.Windows.Forms.TextBox txtBName;
        private System.Windows.Forms.TextBox txtBDescription;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtBStock;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.CheckBox cbIsDeleted;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblMinStock;
        private System.Windows.Forms.Label lblMaxStock;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtBPurchasePrice;
        private System.Windows.Forms.TextBox txtBStatus;
        private System.Windows.Forms.TextBox txtBMinStock;
        private System.Windows.Forms.TextBox txtBMaxStock;
        private System.Windows.Forms.Label lblIsDeleted;
        private System.Windows.Forms.Button btnCreate;
    }
}