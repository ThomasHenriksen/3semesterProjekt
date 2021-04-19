using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmysalgClientWeb.BusinessLogicLayer;
using ArmysalgClientWeb.Models;
using ArmysalgClientWeb.BusinessLogic;

namespace ArmysalgClientWeb.Controllers
{
    public class SalesOrderController1 : Controller
    {
        private SalesOrderLogic _salesOrderLogic;
        // GET: SalesOrderController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: SalesOrderController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalesOrderController1/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: SalesOrderController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesOrder inSalesOrder)
        {
            try
            {
                _salesOrderLogic = new SalesOrderLogic();
                _salesOrderLogic.InsertSalesOrder(inSalesOrder);
                return RedirectToAction();
            }
            catch
            {
                return View();
            }
        }

        // GET: SalesOrderController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalesOrderController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalesOrderController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalesOrderController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
