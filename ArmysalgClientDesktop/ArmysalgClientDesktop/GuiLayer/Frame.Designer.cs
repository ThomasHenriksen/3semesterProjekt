
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
            this.labelHeadLine = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.BtnCustomerMenu = new System.Windows.Forms.Button();
            this.BtnOrderMenu = new System.Windows.Forms.Button();
            this.btnSupplierMenu = new System.Windows.Forms.Button();
            this.btnEmployeeMenu = new System.Windows.Forms.Button();
            this.btnProductsMenu = new System.Windows.Forms.Button();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContentPanel.Location = new System.Drawing.Point(12, 87);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(650, 350);
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
            this.MenuPanel.Location = new System.Drawing.Point(12, 5);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(650, 81);
            this.MenuPanel.TabIndex = 6;
            // 
            // labelHeadLine
            // 
            this.labelHeadLine.AutoSize = true;
            this.labelHeadLine.Font = new System.Drawing.Font("Stencil", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelHeadLine.ForeColor = System.Drawing.Color.OliveDrab;
            this.labelHeadLine.Location = new System.Drawing.Point(243, 4);
            this.labelHeadLine.Name = "labelHeadLine";
            this.labelHeadLine.Size = new System.Drawing.Size(206, 44);
            this.labelHeadLine.TabIndex = 0;
            this.labelHeadLine.Text = "ArmySalg";
            this.labelHeadLine.Click += new System.EventHandler(this.labelHeadLine_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(454, 62);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(116, 15);
            this.labelLogin.TabIndex = 5;
            this.labelLogin.Text = "Du er ikke logget ind";
            this.labelLogin.Click += new System.EventHandler(this.labelLogin_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(576, 58);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // BtnCustomerMenu
            // 
            this.BtnCustomerMenu.Location = new System.Drawing.Point(324, 58);
            this.BtnCustomerMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCustomerMenu.Name = "BtnCustomerMenu";
            this.BtnCustomerMenu.Size = new System.Drawing.Size(75, 23);
            this.BtnCustomerMenu.TabIndex = 0;
            this.BtnCustomerMenu.Text = "Kunder";
            this.BtnCustomerMenu.UseVisualStyleBackColor = true;
            // 
            // BtnOrderMenu
            // 
            this.BtnOrderMenu.Location = new System.Drawing.Point(162, 58);
            this.BtnOrderMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnOrderMenu.Name = "BtnOrderMenu";
            this.BtnOrderMenu.Size = new System.Drawing.Size(75, 23);
            this.BtnOrderMenu.TabIndex = 4;
            this.BtnOrderMenu.Text = "Ordre";
            this.BtnOrderMenu.UseVisualStyleBackColor = true;
            // 
            // btnSupplierMenu
            // 
            this.btnSupplierMenu.Location = new System.Drawing.Point(81, 58);
            this.btnSupplierMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSupplierMenu.Name = "btnSupplierMenu";
            this.btnSupplierMenu.Size = new System.Drawing.Size(75, 23);
            this.btnSupplierMenu.TabIndex = 3;
            this.btnSupplierMenu.Text = "Leverandør";
            this.btnSupplierMenu.UseVisualStyleBackColor = true;
            this.btnSupplierMenu.Click += new System.EventHandler(this.btnSupplierMenu_Click);
            // 
            // btnEmployeeMenu
            // 
            this.btnEmployeeMenu.Location = new System.Drawing.Point(243, 58);
            this.btnEmployeeMenu.Name = "btnEmployeeMenu";
            this.btnEmployeeMenu.Size = new System.Drawing.Size(75, 23);
            this.btnEmployeeMenu.TabIndex = 2;
            this.btnEmployeeMenu.Text = "Ansatte";
            this.btnEmployeeMenu.UseVisualStyleBackColor = true;
            this.btnEmployeeMenu.Click += new System.EventHandler(this.btnEmployeeMenu_Click);
            // 
            // btnProductsMenu
            // 
            this.btnProductsMenu.Location = new System.Drawing.Point(0, 58);
            this.btnProductsMenu.Name = "btnProductsMenu";
            this.btnProductsMenu.Size = new System.Drawing.Size(75, 23);
            this.btnProductsMenu.TabIndex = 1;
            this.btnProductsMenu.Text = "Produkter";
            this.btnProductsMenu.UseVisualStyleBackColor = true;
            this.btnProductsMenu.Click += new System.EventHandler(this.btnProductsMenu_Click);
            // 
            // Frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(672, 443);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.ContentPanel);
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
        private System.Windows.Forms.Button btnSupplierMenu;
        private System.Windows.Forms.Label labelHeadLine;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button BtnCustomerMenu;
        private System.Windows.Forms.Button BtnOrderMenu;
    }
}