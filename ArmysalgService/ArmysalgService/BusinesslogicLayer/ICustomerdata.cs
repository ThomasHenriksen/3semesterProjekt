using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmysalgDataAccess.ModelLayer;

namespace ArmysalgService.BusinesslogicLayer
{
    public interface ICustomerdata
    {
        Customer GetCustomer(int customerNo);
        int AddCustomer(Customer customerToAdd);
    }
}
