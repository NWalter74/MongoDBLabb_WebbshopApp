using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDBLabb_Webbshop.Models;

namespace MongoDBLabb_Webbshop.Services;

public class ProductService
{
    private readonly IMongoCollection<Product> _productCollection;

    //Connection to the database
    public ProductService(IOptions<WebbshopDatabaseSettings> webbshopDatabaseSettings)
    {
        var mongoClient = new MongoClient(webbshopDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(webbshopDatabaseSettings.Value.DatabaseName);
        _productCollection = mongoDatabase.GetCollection<Product>(webbshopDatabaseSettings.Value.ProductCollectionName);
    }

    public async Task<List<Product>> GetAsync() => await _productCollection.Find(_ => true).ToListAsync();

    public async Task<Product?> GetAsync(string id) => await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
     
    public async Task CreateAsync(Product newProduct) => await _productCollection.InsertOneAsync(newProduct);

    public async Task UpdateAsync(string id, Product updatedProduct) => await _productCollection.ReplaceOneAsync(x => x.Id == id, updatedProduct);

    public async Task RemoveAsync(string id) => await _productCollection.DeleteOneAsync(x => x.Id == id);
}
