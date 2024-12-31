namespace MDataGeneration.Models;

public class ProductImage
{
    public ulong Id { get; set; }
    public string? ByName { get; set; }
    public string? ByUrl { get; set; }
    public string? SourceName { get; set; }
    public string? SourceUrl { get; set; }
    public string? FileName { get; set; }
    public string? Title { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}