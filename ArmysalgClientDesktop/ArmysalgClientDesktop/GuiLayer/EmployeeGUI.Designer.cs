
namespace ArmysalgClientDesktop.GuiLayer
{
    partial class EmployeeGUI
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
            this.Employees = new System.Windows.Forms.Label();
            this.EmployeeByID = new System.Windows.Forms.Label();
            this.listOfEmployees = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.firstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblErrorEmpNotFound = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Employees
            // 
            this.Employees.AutoSize = true;
            this.Employees.Location = new System.Drawing.Point(64, 29);
            this.Employees.Name = "Employees";
            this.Employees.Size = new System.Drawing.Size(64, 15);
            this.Employees.TabIndex = 0;
            this.Employees.Text = "Employees";
            // 
            // EmployeeByID
            // 
            this.EmployeeByID.AutoSize = true;
            this.EmployeeByID.Location = new System.Drawing.Point(433, 26);
            this.EmployeeByID.Name = "EmployeeByID";
            this.EmployeeByID.Size = new System.Drawing.Size(59, 15);
            this.EmployeeByID.TabIndex = 1;
            this.EmployeeByID.Text = "Employee";
            // 
            // listOfEmployees
            // 
            this.listOfEmployees.FormattingEnabled = true;
            this.listOfEmployees.ItemHeight = 15;
            this.listOfEmployees.Location = new System.Drawing.Point(68, 77);
            this.listOfEmployees.Name = "listOfEmployees";
            this.listOfEmployees.Size = new System.Drawing.Size(120, 94);
            this.listOfEmployees.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(435, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 3;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(560, 78);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 4;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(433, 148);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(100, 23);
            this.firstName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "First name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(354, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Last name";
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(433, 189);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(100, 23);
            this.lastName.TabIndex = 9;
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(433, 237);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(100, 23);
            this.phone.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Phone";
            // 
            // lblErrorEmpNotFound
            // 
            this.lblErrorEmpNotFound.AutoSize = true;
            this.lblErrorEmpNotFound.Location = new System.Drawing.Point(231, 26);
            this.lblErrorEmpNotFound.Name = "lblErrorEmpNotFound";
            this.lblErrorEmpNotFound.Size = new System.Drawing.Size(0, 15);
            this.lblErrorEmpNotFound.TabIndex = 12;
            // 
            // EmployeeGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblErrorEmpNotFound);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listOfEmployees);
            this.Controls.Add(this.EmployeeByID);
            this.Controls.Add(this.Employees);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeGUI";
            this.Text = "Employee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Employees;
        private System.Windows.Forms.Label EmployeeByID;
        private System.Windows.Forms.ListBox listOfEmployees;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblErrorEmpNotFound;
    }
}