using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArmysalgClientWeb.Data;
using ArmysalgClientWeb.Models;
using ArmysalgClientWeb.BusinessLogic;
using ArmysalgClientWeb.BusinessLogicLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ArmysalgClientWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ProductLogic _productLogic;
        private CartLogic _cartLogic;
        private CustomerLogic _customerLogic;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
            _productLogic = new ProductLogic();
            _cartLogic = new CartLogic();
            _customerLogic = new CustomerLogic();
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            List<Product> foundProducts = (List<Product>)await _productLogic.GetAllProducts();
            // IEnumerable<Product> allProducts = (IEnumerable<Product>)_cmdAccess.GetAllProducts();
            return View(foundProducts);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,PurchasePrice,Stock,MinStock,MaxStock,IsDeleted")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddToCart(int id, int quantity)
        {
            try
            {
                Product productToAdd = await _productLogic.GetProductById(id);

                string customerEmail = User.Identity.Name;
                Task<Customer> customer = _customerLogic.GetCustomerByEmail(customerEmail);
                Cart cart = (Cart)await _cartLogic.GetCartByCustomerNo(customer.Result.CustomerNo);

                int cartSize = cart.SalesLineItems.Count;
                int i = 0;
                SalesLineItem salesLineItemToAdd = null;
                bool found = false;
                if (cartSize > 0)
                {
                    while (!found && cartSize > i)
                    {
                        SalesLineItem tempSale = cart.SalesLineItems.ElementAt(i);
                        Product tempProduct = cart.SalesLineItems.ElementAt(i).Products;
                        if (tempProduct.Id == id)
                        {
                            if (productToAdd.Stock > tempSale.Quantity)
                            {
                                tempSale.Quantity += quantity;
                            }
                            found = true;
                        }
                        i++;
                    }
                }
                if(!found)
                {
                    salesLineItemToAdd = new SalesLineItem(quantity, productToAdd);
                    cart.SalesLineItems.Add(salesLineItemToAdd);
                }

                bool ok = await _cartLogic.UpdateCart(cart);

                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }


        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,PurchasePrice,Stock,MinStock,MaxStock,IsDeleted")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
