namespace SimpleInventoryManagementSystem;

public static class Utilities
{
    public static void PrintMainMenu()
    {
        while (true)
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
                    PrintAddProductDetails();
                    break;
                case "2":
                    PrintAllProducts();
                    break;
                case "3":
                    PrintEditProductDetails();
                    break;
                case "4":
                    PrintRemoveProductDetails();
                    break;
                case "5":
                    PrintSearchProductDetails();
                    break;
                case "6":
                    Console.WriteLine("Thank you for using our system!");
                    return;
                default:
                    Console.WriteLine("Invalid input. Try again.");
                    break;
            }
        }
    }
    
    private static void PrintAddProductDetails()
    {
        Console.Clear();

        var newProductValues = GetNewProductValues();

        var p = Inventory.GetProduct((newProductValues.name));

        if (p is not null)
        {
            PrintContinueMessage("This product already exists.");
            return;
        }
        
        Inventory.AddProduct(new Product(newProductValues.name, newProductValues.price, newProductValues.quantity));
        
        PrintContinueMessage("Product added! ");
    }
    
    private static void PrintAllProducts()
    {
        Console.Clear();
        Console.WriteLine("All products:");
        
        Console.WriteLine(Inventory.ViewProducts());
        
        PrintContinueMessage("");
    }
    
    private static void PrintEditProductDetails()
    {
        var p = Inventory.GetProduct(ReadProductName());

        if (p != null)
        {
            var newProductValues = GetNewProductValues();
            
            p.EditProduct(newProductValues.name, newProductValues.price, newProductValues.quantity);
            
            PrintContinueMessage("Product edited! ");

        }
        else
        {
            PrintContinueMessage("Product not found! ");
        }
    }
    
    private static void PrintRemoveProductDetails()
    {
        var p = Inventory.GetProduct(ReadProductName());

        if (p != null)
        {
            Inventory.RemoveProduct(p);
            
            PrintContinueMessage("Product deleted! ");
        }
        else
        {
            PrintContinueMessage("Product not found! ");
        }
    }
    
    private static void PrintSearchProductDetails()
    {
        var p = Inventory.GetProduct(ReadProductName());

        if (p != null)
        {
            Console.WriteLine("Product details:");
            Console.WriteLine(p);
            Console.WriteLine();
            
            PrintContinueMessage("");
        }
        else
        {
            PrintContinueMessage("Product not found! ");
        }
    }
    
    private static (string name, double price, int quantity) GetNewProductValues()
    {
        Console.Clear();

        string? name;
        while (true)
        {
            Console.WriteLine("Enter the new name:");
            name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                break;
            Console.WriteLine("Name cannot be empty. Please try again.");
        }

        double price;
        while (true)
        {
            Console.WriteLine("Enter the new price:");
            var priceInput = Console.ReadLine();
            if (double.TryParse(priceInput, out price) && price >= 0)
                break;
            Console.WriteLine("Invalid price. Please enter a valid non-negative number.");
        }

        int quantity;
        while (true)
        {
            Console.WriteLine("Enter the new quantity:");
            var quantityInput = Console.ReadLine();
            if (int.TryParse(quantityInput, out quantity) && quantity >= 0)
                break;
            Console.WriteLine("Invalid quantity. Please enter a valid non-negative integer.");
        }

        return (name, price, quantity);
    }

    
    private static string ReadProductName()
    {
        Console.Clear();
        
        Console.WriteLine("Enter the product name:");
        var name = Console.ReadLine();
        
        return name!;
        
    }
    
    private static void PrintContinueMessage(string message)
    {
        Console.WriteLine();
        Console.WriteLine(message + " Press any key to continue...");
        Console.ReadLine();
    }
}