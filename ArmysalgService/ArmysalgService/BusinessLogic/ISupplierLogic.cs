using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgService.BusinessLogic
{
    public interface ISupplierLogic
    {
        // Add supplier to the database.
        /// <summary>
        /// Add supplier to the database.
        /// </summary>
        /// <returns>
        /// Supplier id of inserted supplier object.
        /// </returns>
        /// <param name="aSupplier">Supplier object.</param>
        int AddSupplier(Supplier aSupplier);

        // Find and return all suppliers from database.
        /// <summary>
        /// Find and return all suppliers from database.
        /// </summary>
        /// <returns>
        /// A list of supplier objects.
        /// </returns>
        List<Supplier> GetAllSuppliers();
    }
}
