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

namespace ArmysalgClientDesktop.GuiLayer
{
    public partial class Products : Form
    {
        private ProductControl productController;
        private CategoryControl categoryController;
        private SupplierControl supplierController;
        public Products()
        {
            InitializeComponent();
            productController = new();
            categoryController = new();
            supplierController = new();
            GetAllProductsAsync();
            ListAllCategoriesInCheckBox();
            ListSupplierInComboBox();
        }

        private async void CreateNewProduct()
        {
            /*
             * New Product
             *
             */
            string name = txtBName.Text;
            string description = txtBDescription.Text;
            decimal purchasePrice = decimal.Parse(txtBPurchasePrice.Text);
            int stock = int.Parse(txtBStock.Text);
            int minStock = int.Parse(txtBMinStock.Text);
            int maxStock = int.Parse(txtBMaxStock.Text);
            bool isDeleted = false;
            /*
             * Add category to product 
             */
            List<Category> categories = new();
            foreach (Category indexCheked in checkedListBoxCategory.CheckedItems)
            {
                categories.Add(indexCheked);
            }
            /*
             * Add supplier to product
             */


            /*
             * New price
             * 
             */
            decimal value = decimal.Parse(txtBPrice.Text);
            DateTime startDate = DateTime.Now;
           
            DateTime? endDate = null ;
            _ = await productController.SaveProduct(name, description, purchasePrice,  stock, minStock, maxStock, isDeleted, value, startDate, endDate, categories);
            GetAllProductsAsync();
        }

        private async void GetAllProductsAsync()
        {
            List<Product> products = await productController.GetAllProducts();
            listBoxProducts.DataSource = products;

        }

        private async void ListAllCategoriesInCheckBox()
        {
            List<Category> categories = await categoryController.GetAllCategories();
            foreach (var category in categories)
            {
                checkedListBoxCategory.Items.Add(category);
            }
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateNewProduct();
            GetAllProductsAsync();
        }

        private void listBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product test = (Product)listBoxProducts.SelectedItem;
        }

        private async void ListSupplierInComboBox()
        {
            var listOfSuppliers = await supplierController.GetAllSuppliers();
            foreach (var supplier in listOfSuppliers)
            {
                comboBoxSupplier.Items.Add(supplier);
            }
        }
    }
}
