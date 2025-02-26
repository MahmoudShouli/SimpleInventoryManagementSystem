namespace SimpleInventoryManagementSystem;

public class Utilities
{
    public static void InitializeInventory()
    {
        Product p1 = new Product("Chair", 20.55, 5);
        Product p2 = new Product("Table", 50, 3);
        Product p3 = new Product("Pen", 5.4, 20);
        
        Inventory.Products.Add(p1);
        Inventory.Products.Add(p2);
        Inventory.Products.Add(p3);
    }
    public static void ShowMainMenu()
    {
        Console.Clear();
        
        Console.WriteLine("Welcome to the Simple Inventory Management System!");
        Console.WriteLine("Select an option please:");
        Console.WriteLine("1. Add a new product");
        Console.WriteLine("2. View all the products");
        Console.WriteLine("3. Edit a product");
        Console.WriteLine("4. Delete a product");
        Console.WriteLine("5. Search for a product");
        Console.WriteLine("6. Exit");
        
        Console.WriteLine("Your choice: ");
        
        string? userInput = Console.ReadLine();
        switch (userInput)
        {
            case "1":
                ShowAddProductDetails();
                break;
            case "2":
                //logic
                break;
            case "3":
                //logic
                break;
            case "4":
                //logic
                break;
            case "5":
                //logic
                break;
            case "6":
                break;
            default:
                Console.WriteLine("Invalid input. Try again.");
                break;
            
        }
    }

    private static void ShowAddProductDetails()
    {
        Console.Clear();
        
        Console.WriteLine("Enter the new product name:");
        string name = Console.ReadLine();
        
        Console.WriteLine("Enter the new product price:");
        double price = double.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter the new product quantity:");
        int quantity = int.Parse(Console.ReadLine());
        
        Inventory.AddProduct(new Product(name, price, quantity));
        
        Console.WriteLine("Product added! Press any key to continue...");
        Console.ReadLine();
        ShowMainMenu();
    }
}