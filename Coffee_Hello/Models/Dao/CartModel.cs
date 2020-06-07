using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.Dao
{
    public class CartItem
    {
        public PRODUCT product { get; set; }
        public int Quantity { set; get; }
    }
     public class CartModel
    {
        private List<CartItem> lineCollection = new List<CartItem>();

        public void AddItem(PRODUCT sp, int quantity)
        {
            CartItem line = lineCollection
                .Where(p => p.product.ProductID == sp.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartItem
                {
                    product = sp,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
                if (line.Quantity <= 0)
                {
                    lineCollection.RemoveAll(l => l.product.ProductID == sp.ProductID);
                }
            }
        }
        public void UpdateItem(PRODUCT sp, int quantity)
        {
            CartItem line = lineCollection
                .Where(p => p.product.ProductID == sp.ProductID)
                .FirstOrDefault();

            if (line != null)
            {
                if (quantity > 0)
                {
                    line.Quantity = quantity;
                }
                else
                {
                    lineCollection.RemoveAll(l => l.product.ProductID == sp.ProductID);
                }
            }
        }
        public void RemoveLine(PRODUCT sp)
        {
            lineCollection.RemoveAll(l => l.product.ProductID == sp.ProductID);
        }

        public int ComputeTotalValue()
        {
            
            return lineCollection.Sum(e => (int)e.product.ProductPrice * e.Quantity);

        }
        public int? ComputeTotalProduct()
        {
            return lineCollection.Sum(e => e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartItem> Lines
        {
            get { return lineCollection; }
        }
    }
}
