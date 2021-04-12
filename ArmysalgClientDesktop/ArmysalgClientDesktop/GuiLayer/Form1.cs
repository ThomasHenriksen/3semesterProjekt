using ArmysalgClientDesktop.ControlLayer;
using ArmysalgClientDesktop.ModelLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArmysalgClientDesktop
{
    public partial class Form1 : Form
    {

        ProductControl productController;

        public Form1()
        {
            InitializeComponent();
            productController = new();
        }

        private async void btnClickGetAllProducts_Click(object sender, EventArgs e)
        {
            List<Product> products = await productController.GetAllProducts();
            List<String> nameOfProducts = new();
            foreach(var p in products)
            {
                nameOfProducts.Add(p.Name);
            }
            listBox1.DataSource = nameOfProducts;
        }

        private void btnClickAddProduct_Click(object sender, EventArgs e)
        {

        }

        //public async Task<List<string>> CreateListOfProducts()
        //{
        //    List<String> namesOfProducts = new List<String>();
        //    List<Product> productsFound = await productController.GetAllProducts();
        //    foreach (var p in productsFound)
        //    {
        //        namesOfProducts.Add(p.Name);
        //    }
        //    return namesOfProducts;
        //}
    }
}
