namespace MongoDBLabb_Webbshop.Models;

public class WebbshopDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string ProductCollectionName { get; set; } = null!;
}
