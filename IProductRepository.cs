namespace SimpleInventoryManagementSystem;

public interface IProductRepository
{
    void AddProduct(Product product);
    List<Product> GetAllProducts();
    void DeleteProduct(int id);
    void UpdateProduct(int productId, string name, decimal price, int quantity);
    Product? GetProductByName(string productName);
}