using MDataGeneration.Model;

namespace MDataGeneration;

public class Database
{
    public List<User> Users { get; set; }
    public List<Brand> Brands { get; set; }
    public List<Category> Categories { get; set; }
    public List<ProductImage> ProductImages { get; set; }
    public List<Product> Products { get; set; }
    public List<Invoice> Invoices { get; set; }
    public List<InvoiceItem> InvoiceItems { get; set; }
    
    
}