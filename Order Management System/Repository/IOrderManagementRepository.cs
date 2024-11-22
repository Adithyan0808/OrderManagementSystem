using Order_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Repository
{
    internal interface IOrderManagementRepository
    {

        public bool createOrder(string UserName, string productName);

        public bool cancelOrder(int userId, int orderId);
        public bool createProduct(User user , Product product);
        public bool createUser(User user);
        public List<Product> getAllProducts();
        public List<Product> getOrderByUser(User user);




    }
}
