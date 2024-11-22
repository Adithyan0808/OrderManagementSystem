using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Models
{
    internal class clothing : Product
    {

        private string size;
        private string color;

        public clothing(string productName, string Description, double price, int quantityInStock, string type, string size, string color)
                        : base(productName, Description, price, quantityInStock, type)
        {
            this.Size = size;
            this.Color = color;
        }

        public string Size { get => size; set => size = value; }
        public string Color { get => color; set => color = value; }
    }
}
