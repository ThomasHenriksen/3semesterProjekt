using ArmysalgClientWeb.BusinessLogicLayer;
using ArmysalgClientWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.Controllers
{
    public class CustomerController : Controller
    {

        private CustomerLogic _cmdAcces;


        // GET: CustomerController
        public ActionResult Index()
        {
            _cmdAcces = new CustomerLogic();
            IEnumerable<Customer> allCustomers = (IEnumerable<Customer>)_cmdAcces.GetAllCustomer();
            return View();
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer inCustomer)
        {
            try
            {
                _cmdAcces = new CustomerLogic();
                _cmdAcces.SaveCustomer(inCustomer);

                return RedirectToAction();
            }
            catch
            {
                return View();
            }



        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
