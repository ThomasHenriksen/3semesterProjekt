using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgDataAccess.Database
{
    public interface ISupplierDatabaseAccess
    {
        int CreateSupplier(Supplier aSupplier);
        Supplier GetSupplierById(int supplierId);
        bool DeleteSupplierById(int supplierId);
        List<Supplier> GetAllSuppliers();
    }
}