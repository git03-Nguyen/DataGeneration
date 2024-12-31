namespace MDataGeneration.Models.Dtos;

public class GenerationRequest
{
    public int NUsers { get; set; }
    public int NBrands { get; set; }
    public int NCategories { get; set; }
    public int NProducts { get; set; }
    public int NInvoices { get; set; }
}

public enum FileFormat
{
    CSV,
    SQL,
    JSON
}