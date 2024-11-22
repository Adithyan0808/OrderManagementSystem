
using Order_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order_Management_System.Utility;

namespace Order_Management_System.Repository
{
    internal class OrderProcessor : IOrderManagementRepository
    {
        public bool cancelOrder(int userId, int orderId)
        {
            if(!checkUserId(userId))
            {
                Console.WriteLine("User Not Exists!");
                return false;
            }
            if(!checkOrder(orderId))
            {
                Console.WriteLine("Order Do Not Exist!");
                return false;
            }
            String query = "delete from Order where orderId = @OrderId";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        // Helper method for cancelOrder method , checks the user existence
        public static bool checkUserId(int userId)
        {
            string query = "select * from [user] where userId = @userId";
            using (SqlConnection conn = DBConnection.getConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //Helper method for cancelOrder method , checks the existence of order
        public static bool checkOrder(int orderId)
        {
            String query = "select * from [Order] where orderId = @orderId";
            using(SqlConnection conn = new SqlConnection(query))
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Parameters.AddWithValue("@orderId",orderId);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool createOrder(String UserName, string product)
        {
            int userId = checkUser(UserName);
            if(userId == -1)
            {
                Console.WriteLine("User is not in Database");
                return false;
            }
            int productId = checkProduct(product);
            if (productId == -1)
            {
                Console.WriteLine("Product not available");
                return false;
            }

            string query = "insert into [orders] values(@userId,@productId,1)";
            using(SqlConnection conn = DBConnection.getConnection())
            {
                conn.Open();
                using(SqlCommand cmd =  new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("@userId",userId);
                    cmd.Parameters.AddWithValue("@productId",productId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            
       
        }
        // Helper class for create Order , check product
        public static int checkProduct(String product_name)
        {
            string query = "select productId from product where productName = @productName";
            int productId = -1;
            using (SqlConnection conn = DBConnection.getConnection())
            {
                conn.Open();
                using( SqlCommand cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.AddWithValue("productName", product_name);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            productId = (int)reader["productId"];
                        }
                    }
                }
            }
            return productId;
        }
        // Helper class for create Order , check user
        public static int checkUser(String userName)
        {
            string query = "select * from [user] where UserName = @UserName";
            using(SqlConnection conn = DBConnection.getConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName",userName);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            return (int)reader["userId"];
                        }
                    }
                }
            }
            return -1;
        }

        public bool createProduct(User user, Product product)
        {
            String role = user.Role;
            if(role!="Admin")
            {
                Console.WriteLine("Login with Admin");
                return false;
            }

            String query = "insert into product values(@productName , @Description , @price , @quantityInStock , @type)";
            using (SqlConnection conn = DBConnection.getConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@productName", product.ProductName);
                    cmd.Parameters.AddWithValue("@Description", product.Description1);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@quantityInStock", product.QuantityInStock);
                    cmd.Parameters.AddWithValue("@type", product.Type);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }    
        }

        public bool createUser(User user)
        {

            String query = "insert into [user] values(@userName,@password,@role)";
            using(SqlConnection conn = DBConnection.getConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userName",user.UserName);
                    cmd.Parameters.AddWithValue("@password",user.Password);
                    cmd.Parameters.AddWithValue("@role",user.Role);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public List<Product> getAllProducts()
        {
            String query = "Select * from dbo.product";
            List<Product> products = new List<Product>();
            using(SqlConnection conn = DBConnection.getConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Product p = new Product();
                            p.ProductName = (String)reader["productName"];
                            p.Description1 = (String)reader["Description"];
                            p.Price = (double)reader["price"];
                            p.QuantityInStock = (int)reader["quantityInStock"];
                            p.Type = (String)reader["type"];
                            products.Add(p);
                        }

                            
                    }
                }
            }
            return products;
        }

        public List<Product> getOrderByUser(User user)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("select * from Product as p ");
            query.AppendLine("join Orders as o on p.productId = o.productId");
            query.AppendLine("where o.userId = @userId");

            List<Product> products = new List<Product>();
            using(SqlConnection conn = DBConnection.getConnection())
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(query.ToString(),conn))
                {
                    cmd.Parameters.AddWithValue("@userId", user.UserId);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Product p = new Product();
                        p.ProductName = (String)reader["productName"];
                        p.Description1 = (String)reader["Description"];
                        p.Price = (double)reader["price"];
                        p.QuantityInStock = (int)reader["quantityInStock"];
                        p.Type = (String)reader["type"];
                        products.Add(p);
                    }
                }
            }

            return products ;
        }









    }
}
