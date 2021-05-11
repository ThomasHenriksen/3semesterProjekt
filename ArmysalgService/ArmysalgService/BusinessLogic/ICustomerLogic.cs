using ArmysalgDataAccess.Model;

namespace ArmysalgService.BusinessLogic
{
    public interface ICustomerLogic
    {
        Customer GetCustomer(int customerNo);
        Customer GetCustomer(string customerEmailToMatch);
        int AddCustomer(Customer customerToAdd);

    }
}
