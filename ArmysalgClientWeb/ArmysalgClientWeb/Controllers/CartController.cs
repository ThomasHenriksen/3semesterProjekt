using ArmysalgClientWeb.BusinessLogic;
using ArmysalgClientWeb.BusinessLogicLayer;
using ArmysalgClientWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.Controllers
{
    public class CartController : Controller
    {

        private CartLogic _cartLogic;
        private CustomerLogic _customerLogic;
        private SalesOrderLogic _salesOrderLogic;

        public CartController()
        {
            _cartLogic = new CartLogic();
            _customerLogic = new CustomerLogic();
            _salesOrderLogic = new SalesOrderLogic();
        }

        // GET: CartController
        [Authorize]
        public async Task<IActionResult> Index()
        {
            string customerEmail = User.Identity.Name;
            Task<Customer> customer = _customerLogic.GetCustomerByEmail(customerEmail);

            Cart foundCart = (Cart)await _cartLogic.GetCartByCustomerNo(customer.Result.CustomerNo);
            return View(foundCart);
        }

        // GET: CartController
        [Authorize]
        public async Task<IActionResult> CompleteOrder()
        {
            List<SalesLineItem> saleLineItems = new List<SalesLineItem>();
            decimal paymentAmount = 0;

            //Find Customer by email
            string customerEmail = User.Identity.Name;
            Customer customer = await _customerLogic.GetCustomerByEmail(customerEmail);

            //Find Cart by customernumber
            Cart cart = (Cart)await _cartLogic.GetCartByCustomerNo(customer.CustomerNo);

            //Generate list of saleline items and total payment amount based on cart content
            foreach (SalesLineItem item in cart.SalesLineItems)
            {
                saleLineItems.Add(item);
                paymentAmount += (item.Products.price.Value) * (item.Quantity);
            }

            //Create the order
            SalesOrder salesOrder = new SalesOrder(paymentAmount, saleLineItems, customer);
            int salesOrderNo = await _salesOrderLogic.InsertSalesOrder(salesOrder);

            salesOrder.SalesNo = salesOrderNo;

            return View(salesOrder);
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
