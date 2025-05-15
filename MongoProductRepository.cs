using MongoDB.Driver;

namespace SimpleInventoryManagementSystem;

public class MongoProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _products;
    
    public MongoProductRepository(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _products = database.GetCollection<Product>("Products");
    }
    
    public void AddProduct(Product product)
    {
        _products.InsertOne(product);
    }

    public List<Product> GetAllProducts()
    {
        return _products.Find(product => true).ToList();
    }

    public void DeleteProduct(string id)
    {
        _products.DeleteOne(p => p.Id == id);
    }

    public void UpdateProduct(string productId, string name, decimal price, int quantity)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Id, productId);

        var update = Builders<Product>.Update
            .Set(p => p.Name, name)
            .Set(p => p.Price, price)
            .Set(p => p.Quantity, quantity);

        _products.UpdateOne(filter, update);
    }

    public Product? GetProductByName(string name)
    {
        return _products.Find(p => p.Name == name).FirstOrDefault();
    }
}