namespace SimpleInventoryManagementSystem;

public class Utilities
{
    public static void InitializeInventory()
    {
        var p1 = new Product("Chair", 20.55, 5);
        var p2 = new Product("Table", 50, 3);
        var p3 = new Product("Pen", 5.4, 20);
        
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
        
        var userInput = Console.ReadLine();
        switch (userInput)
        {
            case "1":
                ShowAddProductDetails();
                break;
            case "2":
                ShowAllProducts();
                break;
            case "3":
                ShowEditProductDetails();
                break;
            case "4":
                ShowRemoveProductDetails();
                break;
            case "5":
                ShowSearchProductDetails();
                break;
            case "6":
                ShowExitMessage();
                break;
            default:
                ShowMainMenu();
                break;
            
        }
    }

    private static void ShowExitMessage()
    {
        Console.WriteLine("Thank you for using our system!");
    }

    private static Product? IsProductExist()
    {
        Console.Clear();
        
        Console.WriteLine("Enter the product name:");
        var name = Console.ReadLine();
        
        return Inventory.GetProduct(name!);
        
    }
    private static void ShowSearchProductDetails()
    {
        var p = IsProductExist();

        if (p != null)
        {
            Console.WriteLine("Product details:");
            Console.WriteLine(p);
            Console.WriteLine();
            
            ShowAnyKeyMessage("");
        }
        else
        {
            ShowAnyKeyMessage("Product not found! ");
        }
    }

    private static void ShowRemoveProductDetails()
    {
        var p = IsProductExist();

        if (p != null)
        {
            Inventory.RemoveProduct(p);
            
            ShowAnyKeyMessage("Product deleted! ");
        }
        else
        {
            ShowAnyKeyMessage("Product not found! ");
        }
    }

    private static void ShowEditProductDetails()
    {
        var p = IsProductExist();

        if (p != null)
        {
            Console.WriteLine("Enter the new name:");
            var newName = Console.ReadLine();
        
            Console.WriteLine("Enter the new price:");
            var newPrice = double.Parse(Console.ReadLine()!);
        
            Console.WriteLine("Enter the new product quantity:");
            var newQuantity = int.Parse(Console.ReadLine()!);
            
            p.EditProduct(newName!, newPrice, newQuantity);
            
            ShowAnyKeyMessage("Product edited! ");

        }
        else
        {
            ShowAnyKeyMessage("Product not found! ");
        }
    }

    private static void ShowAllProducts()
    {
        Console.Clear();
        Console.WriteLine("All products:");
        
        Console.WriteLine(Inventory.ViewProducts());
        
        ShowAnyKeyMessage("");
    }

    private static void ShowAddProductDetails()
    {
        Console.Clear();
        
        Console.WriteLine("Enter the new product name:");
        var name = Console.ReadLine();
        
        Console.WriteLine("Enter the new product price:");
        var price = double.Parse(Console.ReadLine()!);
        
        Console.WriteLine("Enter the new product quantity:");
        var quantity = int.Parse(Console.ReadLine()!);
        
        Inventory.AddProduct(new Product(name!, price, quantity));
        
        ShowAnyKeyMessage("Product added! ");
    }

    private static void ShowAnyKeyMessage(string message)
    {
        Console.WriteLine(message + "Press any key to continue...");
        Console.ReadLine();
        ShowMainMenu();
    }
}