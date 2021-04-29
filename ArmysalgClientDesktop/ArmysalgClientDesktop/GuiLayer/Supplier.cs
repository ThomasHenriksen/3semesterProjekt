using ArmysalgClientDesktop.ControlLayer;
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
    public partial class Supplier : Form
    {
        private SupplierControl supplierController; 
        public Supplier()
        {
            InitializeComponent();
            supplierController = new();
        }

        /*
         * Greate new supplier
         */
        private async void CreateNewSupplier()
        {
            string name = textBoxName.Text;
            string address = textBoxAddress.Text;
            string zipCode = textBoxZipCode.Text;
            string city = textBoxCity.Text;
            string country = textBoxCountry.Text;
            string phone = textBoxPhone.Text;
            string email = textBoxEmail.Text;
            int insertedId = await supplierController.SaveSupplier(name, address, zipCode, city, country, phone, email);

            labelInserted.Text = insertedId.ToString();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            CreateNewSupplier();
        }
    }
}
