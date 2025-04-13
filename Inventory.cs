using System.Text;

namespace SimpleInventoryManagementSystem;

public class Inventory
{
    public static readonly List<Product> Products = new();

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
        return Products.FirstOrDefault(p => p.Name!.ToUpper() == productName.ToUpper());
    }

    public static void RemoveProduct(Product product)
    {
        Products.Remove(product);
    }
}