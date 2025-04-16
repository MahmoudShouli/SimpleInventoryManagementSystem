using System.Text;

namespace SimpleInventoryManagementSystem;

public static class Inventory
{
    private static readonly List<Product> Products = [
    
        new Product("Chair", 20.55, 5),
        new Product("Table", 50, 3),
        new Product("Pen", 5.4, 20)
    ];

    public static void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public static string ViewProducts()
    {
        var sb = new StringBuilder();

        foreach (var product in Products)
        {
            sb.AppendLine(product.ToString());
        }

        return sb.ToString();
    }

    public static Product? GetProduct(string productName)
    {
        return Products.FirstOrDefault(p => string.Equals(p.Name, productName, StringComparison.OrdinalIgnoreCase));
    }

    public static void RemoveProduct(Product product)
    {
        Products.Remove(product);
    }
    
    
}