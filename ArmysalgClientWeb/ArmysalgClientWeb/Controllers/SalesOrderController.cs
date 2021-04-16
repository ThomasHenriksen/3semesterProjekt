using ArmysalgClientWeb.BusinessLogic;
using ArmysalgClientWeb.Models;
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

        [HttpPost]
        public async Task<ActionResult> Save(SalesOrder orderToSave)
        {
            try
            {
                SalesOrder salesSave = new SalesOrder(orderToSave.SalesDate, orderToSave.PaymentAmount, orderToSave.Status, orderToSave.SalesLineItem);
                int wasOk = await _salesOrderLogic.InsertSalesOrder(salesSave);

                if (wasOk > 0)
                {
                    TempData["ProcessText"] = "Error inserting salesOrder";
                }
                return null; // HER MANGLER NOGET
            }
            catch 
            {
                TempData["ProcessText"] = "Error in server!";
                return View();
            }
        }

    }
}
