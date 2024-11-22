using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Models
{
    internal class Order
    {
        private int orderId;
        private int userId;
        private int productId;
        private int quantity;

        public Order(int orderId, int userId, int productId, int quantity)
        {
            this.OrderId = orderId;
            this.UserId = userId;
            this.ProductId = productId;
            this.Quantity = quantity;
        }

        public int OrderId { get => orderId; set => orderId = value; }
        public int UserId { get => userId; set => userId = value; }
        public int ProductId { get => productId; set => productId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
