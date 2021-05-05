using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmysalgDataAccess.Model;

namespace ArmysalgService.BusinessLogic
{
    public interface ICustomerLogic
    {
        Customer GetCustomer(int customerNo);
        int AddCustomer(Customer customerToAdd);
    }
}
