using ArmysalgClientWeb.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.Controllers
{
    public class SalesOrderController : Controller
    {
        readonly SalesOrderLogic _salesOrderLogic;

        public SalesOrderController()
        {
            _salesOrderLogic = new SalesOrderLogic();
        }


    }
}
