namespace SimpleInventoryManagementSystem;

public class Inventory
{
    public List<Product> Products { get; }

    public Inventory()
    {
        Products = new List<Product>();
    }
    
}