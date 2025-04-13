namespace SimpleInventoryManagementSystem;

public class Product
{ 
    public string? Name { get; private set; } 
    public double Price { get; private set; }
    public int Quantity { get; private set; }

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