using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmysalgDataAccess.Model;

namespace ArmysalgDataAccess.Database
{
    public interface ICustomerDatabaseAccess
    {
        Customer GetCustomerByCustomerNo(int? customerNo);
        Customer GetCustomerByCustomerEmail(string findCustomerEmail);
        int CreateCustomer(Customer customerToAdd);
        bool DeleteCustomerByCustomerNo(int customerNo);
        bool CustomerHasAspNetUser(Customer aCustomer);
        void ConnectCustomerToAspNetUser(Customer aCustomer);

    }
}
