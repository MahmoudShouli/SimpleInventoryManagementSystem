namespace SimpleInventoryManagementSystem;

public class Utilities(IProductRepository repository)
{
    public void PrintMainMenu()
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
    
    private void PrintAddProductDetails()
    {
        Console.Clear();

        var newProductValues = GetNewProductValues();

        var p = repository.GetProductByName((newProductValues.name));

        if (p is not null)
        {
            PrintContinueMessage("This product already exists.");
            return;
        }
        
        repository.AddProduct(new Product(newProductValues.name, newProductValues.price, newProductValues.quantity));
        
        PrintContinueMessage("Product added! ");
    }
    
    private void PrintAllProducts()
    {
        Console.Clear();
        Console.WriteLine("All products:");
        
        List<Product> products = repository.GetAllProducts();
        products.ForEach(Console.WriteLine);
        
        PrintContinueMessage("");
    }
    
    private void PrintEditProductDetails()
    {
        var product = repository.GetProductByName(ReadProductName());

        if (product != null)
        {
            var newProductValues = GetNewProductValues();
            
            repository.UpdateProduct(product.Id, newProductValues.name, newProductValues.price, newProductValues.quantity);
            
            PrintContinueMessage("Product edited! ");

        }
        else
        {
            PrintContinueMessage("Product not found! ");
        }
    }
    
    private void PrintRemoveProductDetails()
    {
        var product = repository.GetProductByName(ReadProductName());

        if (product != null)
        {
            repository.DeleteProduct(product.Id);
            
            PrintContinueMessage("Product deleted! ");
        }
        else
        {
            PrintContinueMessage("Product not found! ");
        }
    }
    
    private void PrintSearchProductDetails()
    {
        var product = repository.GetProductByName(ReadProductName());

        if (product != null)
        {
            Console.WriteLine("Product details:");
            Console.WriteLine(product);
            Console.WriteLine();
            
            PrintContinueMessage("");
        }
        else
        {
            PrintContinueMessage("Product not found! ");
        }
    }
    
    private (string name, decimal price, int quantity) GetNewProductValues()
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

        decimal price;
        while (true)
        {
            Console.WriteLine("Enter the new price:");
            var priceInput = Console.ReadLine();
            if (decimal.TryParse(priceInput, out price) && price >= 0)
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