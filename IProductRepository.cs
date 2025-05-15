namespace SimpleInventoryManagementSystem;

public interface IProductRepository
{
    void AddProduct(Product product);
    List<Product> GetAllProducts();
    void DeleteProduct(string id);
    void UpdateProduct(string productId, string name, decimal price, int quantity);
    Product? GetProductByName(string name);
}