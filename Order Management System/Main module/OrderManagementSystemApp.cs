using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order_Management_System.Service_layer;
namespace Order_Management_System.Main_module
{
    internal class OrderManagementSystemApp
    {
        public void StartApp()
        {
            OrderManagementServiceLayer serviceLayer = new OrderManagementServiceLayer();
            String again = "yes";
            while(again=="yes")
            {
                Console.WriteLine("1. Create User ");
                Console.WriteLine("2. Create Product");
                Console.WriteLine("3. Cancel Order");
                Console.WriteLine("4. Get All Products");
                Console.WriteLine("5. Get Order By user");
                Console.WriteLine("6. Create Order");
                Console.WriteLine("7. Exit");

                int choice = int.Parse(Console.ReadLine()); 
                switch(choice)
                {
                    case 1:
                        serviceLayer.createUser(); break;
                    case 2:
                        serviceLayer.createProduct(); break;
                    case 3:
                        serviceLayer.cancelOrder(); break;
                    case 4:
                        serviceLayer.getAllProducts(); break;
                    case 5:
                        serviceLayer.getOrderByUser(); break;
                    case 6:
                        serviceLayer.createOrder(); break;
                    case 7:
                        again = "no"; break;
                }
            }
        }



    }
}
