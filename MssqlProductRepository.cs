using Microsoft.Data.SqlClient;

namespace SimpleInventoryManagementSystem;

public class MssqlProductRepository(SqlConnection conn) : IProductRepository
{
    public void AddProduct(Product product)
    {
        using (conn)
        {
            conn.Open();
            var query = "INSERT INTO Products (Name, Price, Quantity) VALUES (@name, @price, @quantity)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@quantity", product.Quantity);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public List<Product> GetAllProducts()
    {
        var products = new List<Product>();
        
        using (conn)
        {
            conn.Open();
            
            var query = "SELECT * FROM Products";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);        
                    string name = reader.GetString(1);  
                    decimal price = reader.GetDecimal(2); 
                    int quantity = reader.GetInt32(3);  

                    products.Add(new Product(id, name, price, quantity));
                }
            }
        }
        
        return products;
    }

    public void DeleteProduct(int id)
    {
        using (conn)
        {
            conn.Open();
            var query = "DELETE FROM Products WHERE Id = @id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void UpdateProduct(Product product)
    {
        using (conn)
        {
            conn.Open();
            var query = "UPDATE Products SET Name = @name, Price = @price, Quantity = @quantity WHERE Id = @id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@quantity", product.Quantity);
                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public Product? GetProductByName(string name)
    {
        using (conn)
        {
            conn.Open();

            var query = "SELECT * FROM Products WHERE Name = @name";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", name);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string productName = reader.GetString(1);
                            decimal price = reader.GetDecimal(2);
                            int quantity = reader.GetInt32(3);

                            return new Product(id, productName, price, quantity);
                        }
                    }

                    return null;
                }
            }
        }
    }

}