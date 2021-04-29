using ArmysalgClientDesktop.ModelLayer;
using ArmysalgClientDesktop.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientDesktop.ControlLayer
{
    public class SupplierControl
    {
        SupplierServiceAccess _sAccess;

        public SupplierControl()
        {
            _sAccess = new SupplierServiceAccess();
        }

        public async Task<int> SaveSupplier(string name, string address, string zipCode,
            string city, string country, string phone, string email)
        {
            Supplier newSupplier = new(name, address, zipCode,
            city, country, phone, email);
            int insertedid = await _sAccess.SaveSupplier(newSupplier);
            return insertedid;
        }
    }
}
