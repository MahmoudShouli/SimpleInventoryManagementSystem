namespace SimpleInventoryManagementSystem;

public interface IProductRepository
{
    void AddProduct(Product product);
    List<Product> GetAllProducts();
    void DeleteProduct(int id);
    void UpdateProduct(Product product);
    Product? GetProductByName(string productName);
}