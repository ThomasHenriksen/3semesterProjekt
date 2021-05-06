using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.Models
{
    public enum SalesOrderStatus
    {
        New = 0,
        Hold = 1,
        Shipped = 2,
        Delivered = 3,
        Closed = 4
    }
}
