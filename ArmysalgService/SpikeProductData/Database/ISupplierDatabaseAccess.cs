using ArmysalgDataAccess.Model;

namespace ArmysalgDataAccess.Database
{
    public interface ISupplierDatabaseAccess
    {
        int CreateSupplier(Supplier aSupplier);
        Supplier GetSupplierById(int supplierId);
        bool DeleteSupplierById(int supplierId);
    }
}