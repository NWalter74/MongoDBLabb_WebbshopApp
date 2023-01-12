using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MongoDBLabb_Webbshop.Models;

public class Product
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    [MaxLength(50), Required]
    public string Produktname { get; set; }

    public string Category { get; set; }

    [BsonElement("Quantity")]
    [Required]
    public int Stockquantity { get; set; }

    public decimal Price { get; set; }
}
