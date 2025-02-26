namespace SimpleInventoryManagementSystem;

public class Utilities
{
    public void ShowMainMenu()
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
                //logic
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
}