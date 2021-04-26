using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmysalgDataAccess.ModelLayer;

namespace ArmysalgDataAccess.DatabaseLayer
{
    public interface ICustomerAccess
    {
        Customer GetCustomerByCustomerNo(int customerNo);
        int CreateCustomer(Customer customerToAdd);
        bool DeleteCustomerByCustomerNo(int customerNo);
        bool CheckIfCustomerHasAspNetUser(Customer aCustomer);
    }
}
