namespace ArmysalgClientWeb.Models
{
    public class Customer : Person
    {
        public int CustomerNo { get; set; }
        public Cart Cart { get; set; }

        public Customer()
        {
        }


    }
}
