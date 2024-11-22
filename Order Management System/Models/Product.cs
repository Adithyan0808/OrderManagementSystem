using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Models
{
    internal class Product
    {
        private int productId;
        private string productName;
        private string  Description;
        private double price;
        private int quantityInStock;
        private String type;

        public Product()
        {
        }

        public Product(string productName, string description, double price, int quantityInStock, string type)
        {
            //this.ProductId = productId;
            this.ProductName = productName;
            Description1 = description;
            this.Price = price;
            this.QuantityInStock = quantityInStock;
            this.Type = type;
        }

        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string Description1 { get => Description; set => Description = value; }
        public double Price { get => price; set => price = value; }
        public int QuantityInStock { get => quantityInStock; set => quantityInStock = value; }
        public string Type { get => type; set => type = value; }



        public override string ToString()
        {
            return $"productId : {productId}\nproductName : {productName}\nDescription:{Description}\nprice : {price}\nquantityInStock : {quantityInStock}\ntype : {type}";
        }



    }
}
