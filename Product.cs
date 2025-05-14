namespace SimpleInventoryManagementSystem;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(int id, string name, decimal price, int quantity)
    {
        this.Id = id;
        this.Name = name;
        this.Price = price;
        this.Quantity = quantity;
    }
    
    public override string ToString()
    {
        return $"ID: {this.Id}, Name: {this.Name}, Price: ${this.Price}, Quantity: {this.Quantity}";
    }
}