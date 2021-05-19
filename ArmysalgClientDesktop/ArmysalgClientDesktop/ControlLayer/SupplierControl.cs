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

        //  Save a new supplier object.
        /// <summary>
        /// Save a new supplier object.
        /// </summary>
        /// <returns>Supplier id of saved Supplier object.</returns>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="zipCode"></param>
        /// <param name="city"></param>
        /// <param name="country"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        public async Task<int> SaveSupplier(string name, string address, string zipCode,
            string city, string country, string phone, string email)
        {
            Supplier newSupplier = new(name, address, zipCode,
            city, country, phone, email);
            int insertedid = await _sAccess.SaveSupplier(newSupplier);
            return insertedid;
        }

        // Find and return all supplier objects.
        /// <summary>
        /// Find and return all supplier objects.
        /// </summary>
        /// <returns>
        /// A list of category objects.
        /// </returns>
        public async Task<List<Supplier>> GetAllSuppliers()
        {
            List<Supplier> foundSuppliers = await _sAccess.GetAllSuppliers();
            return foundSuppliers;
        }
    }
}
