using Microsoft.Data.SqlClient;

namespace SimpleInventoryManagementSystem;

internal class Program
{
    private static string _mongoConnectionString = "mongodb+srv://mahmoud_shouli:mahmoud123@villagemanagementsystem.6xqa7.mongodb.net/";
    private static string _mongoDbName = "SimpleInventoryManagementSystem";

    public static MongoProductRepository Repository = new MongoProductRepository(_mongoConnectionString, _mongoDbName);
    private static void Main()
    {
        Utilities utilities =  new Utilities(Repository);
        utilities.PrintMainMenu();
    }
}