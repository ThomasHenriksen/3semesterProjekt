using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArmysalgClientDesktop.GuiLayer
{
    public partial class Frame : Form
    {
        enum Buttons { Unknown, btnHomeMenu, btn2Menu, btn3Menu, btnSupplierMenu }
        public Frame()
        {
            InitializeComponent();
            btnHomeMenu_Click(null,null);
        }

        private void btnHomeMenu_Click(object sender, EventArgs e)
        {
 
        }

        private void btnProductsMenu_Click(object sender, EventArgs e)
        {
            Products product = new Products();
            NavigateTo(product, ContentPanel);
        }
        public void NavigateTo(Form form, Panel panel)
        {
            form.TopLevel = false;
            form.Size = panel.Size; // for responsive size
            panel.Controls.Clear();
            panel.Controls.Add(form);
            form.Show();
        }

        private void btnEmployeeMenu_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            NavigateTo(employee, ContentPanel);
        }

        private void btnSupplierMenu_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            NavigateTo(supplier, ContentPanel);
        }
    }
}
