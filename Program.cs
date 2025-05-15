using Microsoft.Data.SqlClient;

namespace SimpleInventoryManagementSystem;

internal class Program
{
    private static string _connectionString = "Server=localhost;Database=SimpleInventoryManagementSystem;Trusted_Connection=True;Encrypt=False;";
    public static MssqlProductRepository Repository = new MssqlProductRepository(_connectionString);

    private static void Main()
    {
        Utilities utilities =  new Utilities(Repository);
        utilities.PrintMainMenu();
    }
}