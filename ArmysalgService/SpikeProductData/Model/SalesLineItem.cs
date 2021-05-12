namespace ArmysalgDataAccess.Model
{
    public class SalesLineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Products { get; set; }

        // Constuct a salesLineItem object
        /// <summary>
        /// Constuct a salesLineItem object
        /// </summary>
        public SalesLineItem()
        {
        }
        // Constuct a salesLineItem object
        /// <summary>
        /// Constuct a salesLineItem object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <param name="products"></param>
        public SalesLineItem(int id, int quantity, Product products)
        {
            Id = id;
            Quantity = quantity;
            Products = products;
        }
    }
}
