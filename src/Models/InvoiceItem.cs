namespace MDataGeneration.Models;

public class InvoiceItem
{
    public ulong Id { get; set; }
    public ulong InvoiceId { get; set; }
    public ulong ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}