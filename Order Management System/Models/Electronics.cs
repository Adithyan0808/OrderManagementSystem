using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Models
{
    internal class Electronics : Product
    {
        private String brand;
        private int warrantyPeriod;

        public Electronics(String productName, String Description, double price , int quantityInStock , String type ,string brand, int warrantyPeriod)
                        :base(productName,Description,price,quantityInStock,type)
        {
            this.brand = brand;
            this.warrantyPeriod = warrantyPeriod;
        }

        public string Brand { get => brand; set => brand = value; }
        public int WarrantyPeriod { get => warrantyPeriod; set => warrantyPeriod = value; }
    }
}
