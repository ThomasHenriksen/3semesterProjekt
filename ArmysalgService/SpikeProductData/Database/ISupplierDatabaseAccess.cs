using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgDataAccess.Database
{
    public interface ISupplierDatabaseAccess
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

        // Find and return supplier from database by supplier id.
        /// <summary>
        /// Find and return supplier from database by supplier id.
        /// </summary>
        /// <returns>
        /// Supplier object.
        /// </returns>
        /// <param name="supplierId">Supplier id.</param>
        Supplier GetSupplierById(int supplierId);

        // Find and return all suppliers from database.
        /// <summary>
        /// Find and return all suppliers from database.
        /// </summary>
        /// <returns>
        /// A list of supplier objects.
        /// </returns>
        List<Supplier> GetAllSuppliers();

        // Delete supplier from database based on supplier id.
        /// <summary>
        /// Delete supplier from database based on supplier id.
        /// </summary>
        /// <returns>
        /// Bool statement whether supplier was deleted or not.
        /// </returns>
        /// <param name="supplierId">Supplier id.</param>
        bool DeleteSupplierById(int supplierId);
    }
}