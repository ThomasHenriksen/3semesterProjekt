namespace ArmysalgDataAccess.Model
{
    public class SalesLineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Products { get; set; }

        public SalesLineItem()
        {
        }

        public SalesLineItem(int quantity, Product products)
        {
            Quantity = quantity;
            Products = products;
        }
        public SalesLineItem(int id, int quantity, Product products)
        {
            Id = id;
            Quantity = quantity;
            Products = products;
        }
    }
}
