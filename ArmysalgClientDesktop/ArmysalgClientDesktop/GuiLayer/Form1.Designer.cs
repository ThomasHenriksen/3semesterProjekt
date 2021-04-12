
namespace ArmysalgClientDesktop
{
    partial class Form1
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
            this.btnClickGetAllProducts = new System.Windows.Forms.Button();
            this.btnClickAddProduct = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnClickGetAllProducts
            // 
            this.btnClickGetAllProducts.Location = new System.Drawing.Point(62, 61);
            this.btnClickGetAllProducts.Name = "btnClickGetAllProducts";
            this.btnClickGetAllProducts.Size = new System.Drawing.Size(121, 23);
            this.btnClickGetAllProducts.TabIndex = 0;
            this.btnClickGetAllProducts.Text = "getAllProducts";
            this.btnClickGetAllProducts.UseVisualStyleBackColor = true;
            this.btnClickGetAllProducts.Click += new System.EventHandler(this.btnClickGetAllProducts_Click);
            // 
            // btnClickAddProduct
            // 
            this.btnClickAddProduct.Location = new System.Drawing.Point(542, 61);
            this.btnClickAddProduct.Name = "btnClickAddProduct";
            this.btnClickAddProduct.Size = new System.Drawing.Size(120, 23);
            this.btnClickAddProduct.TabIndex = 1;
            this.btnClickAddProduct.Text = "addProduct";
            this.btnClickAddProduct.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(62, 125);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(375, 49);
            this.listBox1.TabIndex = 2;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(542, 125);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 94);
            this.listBox2.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnClickAddProduct);
            this.Controls.Add(this.btnClickGetAllProducts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClickGetAllProducts;
        private System.Windows.Forms.Button btnClickAddProduct;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
    }
}

