namespace MDataGeneration.Model;

public class Category
{
    public ulong Id { get; set; }
    public ulong? ParentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
