using ArmysalgDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinessLogic
{
    public interface ISupplierLogic
    {
        int CreateSupplier(Supplier supplierToCreate);
        List<Supplier> GetAllSuppliers();
    }
}
