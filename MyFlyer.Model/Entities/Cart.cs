using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFlyer.Model.Entities
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public string UserName { get; set; }
        public virtual List<CartItem> CartItems { get; set; }
        public decimal CartTotal { get { return CartItems.Sum(s => s.Quantity * s.UnitPrice); } }

        public void AddCart(Product product)
        {
            var existingProduct = CartItems.FirstOrDefault(i => i.ProductId == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Quantity++;
            }
            else
            {
                var item = new CartItem
                {
                    Product = product,
                    Quantity = 1
                };
                CartItems.Add(item);
            }
        }
        public void RemoveCartItem(int cartItemId)
        {
            var removedItem = CartItems.FirstOrDefault(x => x.Id == cartItemId);
            if (removedItem != null)
            {
                CartItems.Remove(removedItem);
            }
        }
        public void RemoveCartItemWithProduct(int productId)
        {
            var removedItem = CartItems.FirstOrDefault(x => x.ProductId == productId);
            if (removedItem != null)
            {
                CartItems.Remove(removedItem);
            }
        }
        public void ClearItems()
        {
            CartItems.Clear();
        }
    }
}