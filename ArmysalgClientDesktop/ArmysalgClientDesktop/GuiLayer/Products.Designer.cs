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
            this.txtBStock = new System.Windows.Forms.TextBox();
            this.txtBMinStock = new System.Windows.Forms.TextBox();
            this.txtBMaxStock = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblMinStock = new System.Windows.Forms.Label();
            this.lblMaxStock = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtBPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.labelChooseCat = new System.Windows.Forms.Label();
            this.checkedListBoxCategory = new System.Windows.Forms.CheckedListBox();
            this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
            this.labelSupplier = new System.Windows.Forms.Label();
            this.lblProdukter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxProducts
            // 
            this.listBoxProducts.FormattingEnabled = true;
            this.listBoxProducts.ItemHeight = 15;
            this.listBoxProducts.Location = new System.Drawing.Point(26, 78);
            this.listBoxProducts.Name = "listBoxProducts";
            this.listBoxProducts.Size = new System.Drawing.Size(183, 259);
            this.listBoxProducts.TabIndex = 0;
            this.listBoxProducts.SelectedIndexChanged += new System.EventHandler(this.listBoxProducts_SelectedIndexChanged);
            // 
            // txtBName
            // 
            this.txtBName.Location = new System.Drawing.Point(304, 81);
            this.txtBName.Name = "txtBName";
            this.txtBName.Size = new System.Drawing.Size(166, 23);
            this.txtBName.TabIndex = 1;
            // 
            // txtBDescription
            // 
            this.txtBDescription.Location = new System.Drawing.Point(304, 110);
            this.txtBDescription.Name = "txtBDescription";
            this.txtBDescription.Size = new System.Drawing.Size(166, 23);
            this.txtBDescription.TabIndex = 2;
            // 
            // txtBPurchasePrice
            // 
            this.txtBPurchasePrice.Location = new System.Drawing.Point(304, 139);
            this.txtBPurchasePrice.Name = "txtBPurchasePrice";
            this.txtBPurchasePrice.Size = new System.Drawing.Size(166, 23);
            this.txtBPurchasePrice.TabIndex = 3;
            // 
            // txtBStock
            // 
            this.txtBStock.Location = new System.Drawing.Point(304, 168);
            this.txtBStock.Name = "txtBStock";
            this.txtBStock.Size = new System.Drawing.Size(166, 23);
            this.txtBStock.TabIndex = 5;
            // 
            // txtBMinStock
            // 
            this.txtBMinStock.Location = new System.Drawing.Point(304, 197);
            this.txtBMinStock.Name = "txtBMinStock";
            this.txtBMinStock.Size = new System.Drawing.Size(166, 23);
            this.txtBMinStock.TabIndex = 6;
            // 
            // txtBMaxStock
            // 
            this.txtBMaxStock.Location = new System.Drawing.Point(304, 226);
            this.txtBMaxStock.Name = "txtBMaxStock";
            this.txtBMaxStock.Size = new System.Drawing.Size(166, 23);
            this.txtBMaxStock.TabIndex = 7;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(263, 84);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 15);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Navn";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(234, 113);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(64, 15);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Beskrivelse";
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Location = new System.Drawing.Point(230, 142);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(68, 15);
            this.lblPurchasePrice.TabIndex = 11;
            this.lblPurchasePrice.Text = "Indkøbspris";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(236, 171);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(62, 15);
            this.lblStock.TabIndex = 13;
            this.lblStock.Text = "Lagerantal";
            // 
            // lblMinStock
            // 
            this.lblMinStock.AutoSize = true;
            this.lblMinStock.Location = new System.Drawing.Point(241, 200);
            this.lblMinStock.Name = "lblMinStock";
            this.lblMinStock.Size = new System.Drawing.Size(57, 15);
            this.lblMinStock.TabIndex = 14;
            this.lblMinStock.Text = "Min lager";
            // 
            // lblMaxStock
            // 
            this.lblMaxStock.AutoSize = true;
            this.lblMaxStock.Location = new System.Drawing.Point(239, 229);
            this.lblMaxStock.Name = "lblMaxStock";
            this.lblMaxStock.Size = new System.Drawing.Size(59, 15);
            this.lblMaxStock.TabIndex = 15;
            this.lblMaxStock.Text = "Max lager";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(529, 308);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 29);
            this.btnCreate.TabIndex = 17;
            this.btnCreate.Text = "Opret produkt";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtBPrice
            // 
            this.txtBPrice.Location = new System.Drawing.Point(304, 255);
            this.txtBPrice.Name = "txtBPrice";
            this.txtBPrice.Size = new System.Drawing.Size(166, 23);
            this.txtBPrice.TabIndex = 18;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(272, 258);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(26, 15);
            this.lblPrice.TabIndex = 19;
            this.lblPrice.Text = "Pris";
            // 
            // labelChooseCat
            // 
            this.labelChooseCat.AutoSize = true;
            this.labelChooseCat.Location = new System.Drawing.Point(537, 131);
            this.labelChooseCat.Name = "labelChooseCat";
            this.labelChooseCat.Size = new System.Drawing.Size(51, 15);
            this.labelChooseCat.TabIndex = 22;
            this.labelChooseCat.Text = "Kategori";
            // 
            // checkedListBoxCategory
            // 
            this.checkedListBoxCategory.FormattingEnabled = true;
            this.checkedListBoxCategory.Location = new System.Drawing.Point(497, 148);
            this.checkedListBoxCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBoxCategory.Name = "checkedListBoxCategory";
            this.checkedListBoxCategory.Size = new System.Drawing.Size(132, 130);
            this.checkedListBoxCategory.TabIndex = 23;
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Location = new System.Drawing.Point(496, 81);
            this.comboBoxSupplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(133, 23);
            this.comboBoxSupplier.TabIndex = 24;
            // 
            // labelSupplier
            // 
            this.labelSupplier.AutoSize = true;
            this.labelSupplier.Location = new System.Drawing.Point(529, 64);
            this.labelSupplier.Name = "labelSupplier";
            this.labelSupplier.Size = new System.Drawing.Size(66, 15);
            this.labelSupplier.TabIndex = 25;
            this.labelSupplier.Text = "Leverandør";
            this.labelSupplier.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblProdukter
            // 
            this.lblProdukter.AutoSize = true;
            this.lblProdukter.Location = new System.Drawing.Point(87, 60);
            this.lblProdukter.Name = "lblProdukter";
            this.lblProdukter.Size = new System.Drawing.Size(59, 15);
            this.lblProdukter.TabIndex = 26;
            this.lblProdukter.Text = "Produkter";
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.lblProdukter);
            this.Controls.Add(this.labelSupplier);
            this.Controls.Add(this.comboBoxSupplier);
            this.Controls.Add(this.checkedListBoxCategory);
            this.Controls.Add(this.labelChooseCat);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtBPrice);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblMaxStock);
            this.Controls.Add(this.lblMinStock);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblPurchasePrice);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtBMaxStock);
            this.Controls.Add(this.txtBMinStock);
            this.Controls.Add(this.txtBStock);
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
        private System.Windows.Forms.TextBox txtBStock;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblMinStock;
        private System.Windows.Forms.Label lblMaxStock;
        private System.Windows.Forms.TextBox txtBPurchasePrice;
        private System.Windows.Forms.TextBox txtBMinStock;
        private System.Windows.Forms.TextBox txtBMaxStock;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtBPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label labelChooseCat;
        private System.Windows.Forms.CheckedListBox checkedListBoxCategory;
        private System.Windows.Forms.ComboBox comboBoxSupplier;
        private System.Windows.Forms.Label labelSupplier;
        private System.Windows.Forms.Label lblProdukter;
    }
}