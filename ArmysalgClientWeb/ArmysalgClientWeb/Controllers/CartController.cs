using ArmysalgClientWeb.BusinessLogicLayer;
using ArmysalgClientWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ArmysalgClientWeb.Controllers
{
    public class CartController : Controller
    {

        private CartLogic _cmdAccess;
        private CustomerLogic _customerLogic;

        public CartController()
        {
            _cmdAccess = new CartLogic();
            _customerLogic = new CustomerLogic();
        }

        // GET: CartController
        public async Task<IActionResult> Index()
        {
            string customerEmail = User.Identity.Name;
            Task<Customer> customer = _customerLogic.GetCustomerByEmail(customerEmail);

            Cart foundCart = (Cart)await _cmdAccess.GetCartByCustomerNo(customer.Result.CustomerNo);
            return View(foundCart);
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cart inCart)
        {
            try
            {
                return RedirectToAction();
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
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

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
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
