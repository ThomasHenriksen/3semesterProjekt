namespace ArmysalgClientWeb.Models
{
    public class SalesLineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Products { get; set; }
        //Method to calculate a sub total value of SaleLineItem.
        /// <summary>
        /// Method to calculate a sub total value of SaleLineItem.
        /// </summary>
        /// <returns>
        /// decimal
        /// </returns>
        public decimal TotalPrice
        {
            get { return Products.price.Value * Quantity; }
        }



        public SalesLineItem(int quantity, Product products)
        {
            Quantity = quantity;
            Products = products;
        }

    }
}
