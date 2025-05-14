namespace SimpleInventoryManagementSystem;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Product(int id, string name, double price, int quantity)
    {
        this.Id = id;
        this.Name = name;
        this.Price = price;
        this.Quantity = quantity;
    }
    
    public override string ToString()
    {
        return $"Name: {this.Name}, Price: ${this.Price}, Quantity: {this.Quantity}";
    }
}