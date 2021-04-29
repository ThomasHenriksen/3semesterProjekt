
namespace ArmysalgClientDesktop.GuiLayer
{
    partial class Frame
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
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.btnSupplierMenu = new System.Windows.Forms.Button();
            this.btnEmployeeMenu = new System.Windows.Forms.Button();
            this.btnProductsMenu = new System.Windows.Forms.Button();
            this.btnHomeMenu = new System.Windows.Forms.Button();
            this.BtnOrderMenu = new System.Windows.Forms.Button();
            this.BtnCustomerMenu = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelHeadLine = new System.Windows.Forms.Label();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContentPanel.Location = new System.Drawing.Point(14, 92);
            this.ContentPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(887, 499);
            this.ContentPanel.TabIndex = 5;
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.labelHeadLine);
            this.MenuPanel.Controls.Add(this.labelLogin);
            this.MenuPanel.Controls.Add(this.btnLogin);
            this.MenuPanel.Controls.Add(this.BtnCustomerMenu);
            this.MenuPanel.Controls.Add(this.BtnOrderMenu);
            this.MenuPanel.Controls.Add(this.btnSupplierMenu);
            this.MenuPanel.Controls.Add(this.btnEmployeeMenu);
            this.MenuPanel.Controls.Add(this.btnProductsMenu);
            this.MenuPanel.Controls.Add(this.btnHomeMenu);
            this.MenuPanel.Location = new System.Drawing.Point(14, 7);
            this.MenuPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(886, 77);
            this.MenuPanel.TabIndex = 6;
            // 
            // btnSupplierMenu
            // 
            this.btnSupplierMenu.Location = new System.Drawing.Point(185, 46);
            this.btnSupplierMenu.Name = "btnSupplierMenu";
            this.btnSupplierMenu.Size = new System.Drawing.Size(86, 31);
            this.btnSupplierMenu.TabIndex = 3;
            this.btnSupplierMenu.Text = "Leverandør";
            this.btnSupplierMenu.UseVisualStyleBackColor = true;
            this.btnSupplierMenu.Click += new System.EventHandler(this.btnSupplierMenu_Click);
            // 
            // btnEmployeeMenu
            // 
            this.btnEmployeeMenu.Location = new System.Drawing.Point(369, 46);
            this.btnEmployeeMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmployeeMenu.Name = "btnEmployeeMenu";
            this.btnEmployeeMenu.Size = new System.Drawing.Size(86, 31);
            this.btnEmployeeMenu.TabIndex = 2;
            this.btnEmployeeMenu.Text = "Ansatte";
            this.btnEmployeeMenu.UseVisualStyleBackColor = true;
            this.btnEmployeeMenu.Click += new System.EventHandler(this.btnEmployeeMenu_Click);
            // 
            // btnProductsMenu
            // 
            this.btnProductsMenu.Location = new System.Drawing.Point(93, 46);
            this.btnProductsMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnProductsMenu.Name = "btnProductsMenu";
            this.btnProductsMenu.Size = new System.Drawing.Size(86, 31);
            this.btnProductsMenu.TabIndex = 1;
            this.btnProductsMenu.Text = "Produkter";
            this.btnProductsMenu.UseVisualStyleBackColor = true;
            this.btnProductsMenu.Click += new System.EventHandler(this.btnProductsMenu_Click);
            // 
            // btnHomeMenu
            // 
            this.btnHomeMenu.Location = new System.Drawing.Point(1, 46);
            this.btnHomeMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHomeMenu.Name = "btnHomeMenu";
            this.btnHomeMenu.Size = new System.Drawing.Size(86, 31);
            this.btnHomeMenu.TabIndex = 0;
            this.btnHomeMenu.Text = "Forside";
            this.btnHomeMenu.UseVisualStyleBackColor = true;
            this.btnHomeMenu.Click += new System.EventHandler(this.btnHomeMenu_Click);
            // 
            // BtnOrderMenu
            // 
            this.BtnOrderMenu.Location = new System.Drawing.Point(277, 46);
            this.BtnOrderMenu.Name = "BtnOrderMenu";
            this.BtnOrderMenu.Size = new System.Drawing.Size(86, 31);
            this.BtnOrderMenu.TabIndex = 4;
            this.BtnOrderMenu.Text = "Ordre";
            this.BtnOrderMenu.UseVisualStyleBackColor = true;
            // 
            // BtnCustomerMenu
            // 
            this.BtnCustomerMenu.Location = new System.Drawing.Point(461, 46);
            this.BtnCustomerMenu.Name = "BtnCustomerMenu";
            this.BtnCustomerMenu.Size = new System.Drawing.Size(86, 31);
            this.BtnCustomerMenu.TabIndex = 0;
            this.BtnCustomerMenu.Text = "Kunder";
            this.BtnCustomerMenu.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(800, 46);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(86, 31);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(646, 51);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(148, 20);
            this.labelLogin.TabIndex = 5;
            this.labelLogin.Text = "Du er ikke logget ind";
            // 
            // labelHeadLine
            // 
            this.labelHeadLine.AutoSize = true;
            this.labelHeadLine.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelHeadLine.Location = new System.Drawing.Point(369, 2);
            this.labelHeadLine.Name = "labelHeadLine";
            this.labelHeadLine.Size = new System.Drawing.Size(153, 35);
            this.labelHeadLine.TabIndex = 0;
            this.labelHeadLine.Text = "ArmySalg.dk";
            // 
            // Frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.ContentPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frame";
            this.Text = "Frame";
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button btnEmployeeMenu;
        private System.Windows.Forms.Button btnProductsMenu;
        private System.Windows.Forms.Button btnHomeMenu;
        private System.Windows.Forms.Button btnSupplierMenu;
        private System.Windows.Forms.Label labelHeadLine;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button BtnCustomerMenu;
        private System.Windows.Forms.Button BtnOrderMenu;
    }
}