using ArmysalgDataAccess.Model;
using System.Collections.Generic;

namespace ArmysalgService.BusinessLogic
{
    public interface ISupplierLogic
    {
        int CreateSupplier(Supplier supplierToCreate);
        List<Supplier> GetAllSuppliers();
    }
}
