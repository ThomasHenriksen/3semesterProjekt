using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinessLogic
{
    public class SupplierLogic : ISupplierLogic
    {
        ISupplierDatabaseAccess _suppliberAccess;
        
        public SupplierLogic(IConfiguration inConfiguration)
        {
            _suppliberAccess = new SupplierDatabaseAccess(inConfiguration);
        }

        /*
         * Create a new supplier in the database
         * @param Supplier
         * 
         * @return insertedSupplierId
         */
        public int CreateSupplier(Supplier supplierToCreate)
        {
            int insertedSupplierId;
            try
            {
                insertedSupplierId = _suppliberAccess.CreateSupplier(supplierToCreate);
            }
            catch
            {
                insertedSupplierId = -1;
            }
            return insertedSupplierId;
        }

        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> foundSuppliers;

            try
            {
                foundSuppliers = _suppliberAccess.GetAllSuppliers();
            }
            catch 
            {
                foundSuppliers = null;
            }
            return foundSuppliers;
        }
    }
}
