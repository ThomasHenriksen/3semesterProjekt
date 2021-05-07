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
        public Cart Get(Customer customer)
        {
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
            int i = 0;
            foreach (SalesLineItem salesLineItem in aCurrCart.SalesLineItems)
            {
               
                bool exiting = false;
                if (_salesLineItemAcces.CheckSalesLineItem(salesLineItem, aCurrCart))
                {
                    if (i == 1) {
                        salesLineItem.Quantity = i + salesLineItem.Quantity;
                    }
                    _salesLineItemAcces.UpdateSalesLineItem(salesLineItem, aCurrCart, null);
                    _cartAccess.UpdateCart(aCurrCart);
                    exiting = true;
                    i++;
                }
                if (!exiting)
                {
                    _salesLineItemAcces.CreateSalesLineItem(salesLineItem, aCurrCart);
                }
            }
            return aCurrCart;
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
