using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ArmysalgService.BusinessLogic
{
    public class SupplierLogic : ISupplierLogic
    {
        ISupplierDatabaseAccess _suppliberAccess;

        public SupplierLogic(IConfiguration inConfiguration)
        {
            _suppliberAccess = new SupplierDatabaseAccess(inConfiguration);
        }

        // Add supplier to the database.
        /// <inheritdoc/>
        public int AddSupplier(Supplier aSupplier)
        {
            int insertedSupplierId;

            try
            {
                insertedSupplierId = _suppliberAccess.AddSupplier(aSupplier);
            }
            catch
            {
                insertedSupplierId = -1;
            }
            return insertedSupplierId;
        }

        // Find and return all suppliers from database.
        /// <inheritdoc/>
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
