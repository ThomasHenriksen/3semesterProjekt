
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
            this.btn3Menu = new System.Windows.Forms.Button();
            this.btnProductsMenu = new System.Windows.Forms.Button();
            this.btnHomeMenu = new System.Windows.Forms.Button();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContentPanel.Location = new System.Drawing.Point(12, 57);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(776, 386);
            this.ContentPanel.TabIndex = 5;
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.btn3Menu);
            this.MenuPanel.Controls.Add(this.btnProductsMenu);
            this.MenuPanel.Controls.Add(this.btnHomeMenu);
            this.MenuPanel.Location = new System.Drawing.Point(12, 5);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(775, 46);
            this.MenuPanel.TabIndex = 6;
            // 
            // btn3Menu
            // 
            this.btn3Menu.Location = new System.Drawing.Point(162, 23);
            this.btn3Menu.Name = "btn3Menu";
            this.btn3Menu.Size = new System.Drawing.Size(75, 23);
            this.btn3Menu.TabIndex = 2;
            this.btn3Menu.Text = "button";
            this.btn3Menu.UseVisualStyleBackColor = true;
            // 
            // btnProductsMenu
            // 
            this.btnProductsMenu.Location = new System.Drawing.Point(81, 23);
            this.btnProductsMenu.Name = "btnProductsMenu";
            this.btnProductsMenu.Size = new System.Drawing.Size(75, 23);
            this.btnProductsMenu.TabIndex = 1;
            this.btnProductsMenu.Text = "Products";
            this.btnProductsMenu.UseVisualStyleBackColor = true;
            this.btnProductsMenu.Click += new System.EventHandler(this.btnProductsMenu_Click);
            // 
            // btnHomeMenu
            // 
            this.btnHomeMenu.Location = new System.Drawing.Point(0, 23);
            this.btnHomeMenu.Name = "btnHomeMenu";
            this.btnHomeMenu.Size = new System.Drawing.Size(75, 23);
            this.btnHomeMenu.TabIndex = 0;
            this.btnHomeMenu.Text = "butto";
            this.btnHomeMenu.UseVisualStyleBackColor = true;
            this.btnHomeMenu.Click += new System.EventHandler(this.btnHomeMenu_Click);
            // 
            // Frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.ContentPanel);
            this.Name = "Frame";
            this.Text = "Frame";
            this.MenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button btn3Menu;
        private System.Windows.Forms.Button btnProductsMenu;
        private System.Windows.Forms.Button btnHomeMenu;
    }
}