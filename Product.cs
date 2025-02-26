namespace SimpleInventoryManagementSystem;

public class Product
{
    private string name = string.Empty;
    private double price;
    private int quantity;
    
    public string Name { get => name; set => name = value; }
    public double Price { get => price; set => price = value; }
    public int Quantity { get => quantity; set => quantity = value; }

    public Product(string name, double price, int quantity)
    {
        this.Name = name;
        this.Price = price;
        this.Quantity = quantity;
    }
    
    public override string ToString()
    {
        return $"Product: {this.Name}, Price: ${this.Price}, Quantity: {this.Quantity}";
    }
}