namespace MDataGeneration.Model;

public class Invoice
{
    public ulong Id { get; set; }
    public ulong UserId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string? InvoiceNumber { get; set; }
    public string BillingAddress { get; set; } = string.Empty;
    public string BillingCity { get; set; } = string.Empty;
    public string? BillingState { get; set; }
    public string BillingCountry { get; set; } = string.Empty;
    public string? BillingPostcode { get; set; }
    public decimal Total { get; set; }
    public string? PaymentMethod { get; set; }
    public string? PaymentAccountName { get; set; }
    public string? PaymentAccountNumber { get; set; }
    public string Status { get; set; } = "AWAITING_FULFILLMENT";
    public string? StatusMessage { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}