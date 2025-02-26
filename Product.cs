namespace SimpleInventoryManagementSystem;

public class Product
{
    private string name = string.Empty;
    private float price;
    private int quantity;
    
    public string Name { get => name; set => name = value; }
    public float Price { get => price; set => price = value; }
    public int Quantity { get => quantity; set => quantity = value; }

    public Product(string name, float price, int quantity)
    {
        this.Name = name;
        this.Price = price;
        this.Quantity = quantity;
    }
}