using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinessLogic
{
    public class CartLogic : ICartLogic
    {
        ICartDatabaseAccess _cartAccess;
        ISalesLineItemDatabaseAcces _salesLineItemAcces;

        public CartLogic(IConfiguration inConfiguration)
        {
            _cartAccess = new CartDatabaseAccess(inConfiguration);
            _salesLineItemAcces = new SalesLineItemDatabaseAccess(inConfiguration);
        }
        public Cart Get(Customer customer) {
            return _cartAccess.GetCartByCustomerNo(customer.CustomerNo);
        }
        public int AddCart(Cart cartToAdd, Customer customer)
        {
            int insertedId;

            try
            {
                insertedId = _cartAccess.CreateCart(cartToAdd, customer);
            }
            catch
            {
                insertedId = -1;
            }
            return insertedId;
        }
        public Cart UpdateCart(Cart aCurrCart)
        {

            List<SalesLineItem> CartListFromDatabase = _cartAccess.GetCartById(aCurrCart).SalesLineItems;
            Cart currCart = aCurrCart;
            SalesLineItem aSalesLineItem = null;
            bool exiting = false;
            foreach (SalesLineItem dataCart in CartListFromDatabase)
            {
                foreach (SalesLineItem salesLineItem in currCart.SalesLineItems)
                {
                    if (salesLineItem.Products.Id == dataCart.Products.Id)
                    {
                        if (salesLineItem.Quantity == 0)
                        {
                            RemoveSalesLineItem(salesLineItem);
                            currCart.SalesLineItems.Remove(salesLineItem);
                        }
                        else
                        {
                            _salesLineItemAcces.UpdateSalesLineItem(salesLineItem, aCurrCart, null);
                        }

                        exiting = true;
                    }
                    else
                    {
                        aSalesLineItem = salesLineItem;
                    }
                }
            }
            if (!exiting)
            {
                _salesLineItemAcces.CreateSalesLineItem(aSalesLineItem, aCurrCart);
            }
            return currCart;
        }
        private bool RemoveSalesLineItem(SalesLineItem aSalesLineItem)
        {
            return _salesLineItemAcces.DeleteSaleLineItem(aSalesLineItem);
        }
        public bool DeleteCart(int id)
        {
            return _cartAccess.DeleteCartByCartId(id);
        }
    }
}
