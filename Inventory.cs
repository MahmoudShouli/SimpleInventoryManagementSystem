namespace SimpleInventoryManagementSystem;

public class Inventory
{
    public static List<Product> Products = new();

    public static void AddProduct(Product product)
    {
        Products.Add(product);
    }
    
}