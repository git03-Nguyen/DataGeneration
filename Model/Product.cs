namespace MDataGeneration.Model;

public class Product
{
    public ulong Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int? Stock { get; set; }
    public decimal Price { get; set; }
    public bool IsLocationOffer { get; set; }
    public bool IsRental { get; set; }
    public ulong BrandId { get; set; }
    public ulong? CategoryId { get; set; }
    public ulong? ProductImageId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}