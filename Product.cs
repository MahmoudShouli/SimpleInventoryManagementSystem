namespace SimpleInventoryManagementSystem;

public class Product
{
    public string Name { get; private set; } = "";
    private double Price { get; set; }
    private int Quantity { get; set; }

    public Product(string name, double price, int quantity)
    {
        EditProduct(name, price, quantity);
    }
    
    public override string ToString()
    {
        return $"Name: {this.Name}, Price: ${this.Price}, Quantity: {this.Quantity}";
    }

    public void EditProduct(string name, double price, int quantity)
    {
        this.Name = name;
        this.Price = price;
        this.Quantity = quantity;
    }
}