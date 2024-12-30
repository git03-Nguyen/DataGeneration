using Bogus;
using MDataGeneration.Helpers;
using MDataGeneration.Model;
using MDataGeneration.Model.Dtos;
using Database = MDataGeneration.Database;

namespace MDataGeneration.Generators;

public static class DataGenerator
{
    public static Database GenerateDatabase(GenerationRequest request)
    {
        // Generate Accounts
        var userFaker = new Faker<User>("en")
            .RuleFor(u => u.Id, f => f.Random.ULong(1))
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName().ToLimitString(20))
            .RuleFor(u => u.Address, f => f.Address.StreetAddress().ToLimitString(70))
            .RuleFor(u => u.City, f => f.Address.City())
            .RuleFor(u => u.State, f => f.Address.State())
            .RuleFor(u => u.Country, f => f.Address.Country())
            .RuleFor(u => u.Postcode, f => f.Address.ZipCode())
            .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(u => u.Dob, f => f.Date.Past(40, DateTime.Now.AddYears(-18)))
            .RuleFor(u => u.Email, f => f.Internet.Email())
            // .RuleFor(u => u.Password, f => f.Internet.Password())
            .RuleFor(u => u.Role, f => f.PickRandom("admin", "user"))
            .RuleFor(u => u.Enabled, f => f.Random.Int(0, 4) > 0)
            .RuleFor(u => u.FailedLoginAttempts, f => f.Random.Int(0, 3))
            .RuleFor(u => u.CreatedAt, f => f.Date.Past())
            .RuleFor(u => u.UpdatedAt, f => f.Date.Past());
        var users = userFaker.Generate(request.NUsers);
        
        // Generate Brands
        var brandFaker = new Faker<Brand>("en")
            .RuleFor(b => b.Id, f => f.Random.ULong(1))
            .RuleFor(b => b.Name, f => f.Company.CompanyName())
            .RuleFor(b => b.Slug, (f, b) => b.Name.ToSlugString(f))
            .RuleFor(b => b.CreatedAt, f => f.Date.Past())
            .RuleFor(b => b.UpdatedAt, f => f.Date.Past());
        var brands = brandFaker.Generate(request.NBrands);
        
        // Generate Categories
        var categoryFaker = new Faker<Category>("en")
            .RuleFor(c => c.Id, f => f.Random.ULong(1))
            .RuleFor(c => c.ParentId, f => f.Random.Bool() ? f.Random.ULong(1, 10) : null)
            .RuleFor(c => c.Name, f => f.Commerce.Categories(1).First())
            .RuleFor(c => c.Slug, (f, c) => c.Name.ToSlugString(f))
            .RuleFor(c => c.CreatedAt, f => f.Date.Past())
            .RuleFor(c => c.UpdatedAt, f => f.Date.Past());
        var categories = categoryFaker.Generate(request.NCategories);
        
        // Generate Product Images
        var productImageFaker = new Faker<ProductImage>("en")
            .RuleFor(p => p.Id, f => f.Random.ULong(1))
            .RuleFor(p => p.ByName, f => f.Lorem.Word())
            .RuleFor(p => p.ByUrl, f => f.Internet.Url())
            .RuleFor(p => p.SourceName, f => f.Company.CompanyName())
            .RuleFor(p => p.SourceUrl, f => f.Image.PicsumUrl())
            .RuleFor(p => p.FileName, f => f.System.FileName())
            .RuleFor(p => p.Title, f => f.Lorem.Sentence())
            .RuleFor(p => p.CreatedAt, f => f.Date.Past())
            .RuleFor(p => p.UpdatedAt, f => f.Date.Past());
        var productImages = productImageFaker.Generate(request.NProducts);
        
        // Generate Products
        var productFaker = new Faker<Product>("en")
            .RuleFor(p => p.Id, f => f.Random.ULong(1))
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Lorem.Sentence())
            .RuleFor(p => p.Stock, f => f.Random.Int(0, 100))
            .RuleFor(p => p.Price, f => f.Finance.Amount(1, 1000, 2))
            .RuleFor(p => p.IsLocationOffer, f => f.Random.Bool())
            .RuleFor(p => p.IsRental, f => f.Random.Bool())
            .RuleFor(p => p.BrandId, f => f.PickRandom(brands).Id)
            .RuleFor(p => p.CategoryId, f => f.PickRandom(categories).Id)
            .RuleFor(p => p.ProductImageId, f => f.PickRandom(productImages).Id)
            .RuleFor(p => p.CreatedAt, f => f.Date.Past())
            .RuleFor(p => p.UpdatedAt, f => f.Date.Past());
        var products = productFaker.Generate(request.NProducts);
        
        // Generate Invoices
        var invoiceFaker = new Faker<Invoice>("en")
            .RuleFor(i => i.Id, f => f.Random.ULong(1))
            .RuleFor(i => i.UserId, f => f.PickRandom(users).Id)
            .RuleFor(i => i.InvoiceDate, f => f.Date.Recent())
            .RuleFor(i => i.InvoiceNumber, f => "INV" + f.Random.Guid())
            .RuleFor(i => i.BillingAddress, f => f.Address.StreetAddress().ToLimitString(70))
            .RuleFor(i => i.BillingCity, f => f.Address.City())
            .RuleFor(i => i.BillingState, f => f.Address.State())
            .RuleFor(i => i.BillingCountry, f => f.Address.Country())
            .RuleFor(i => i.BillingPostcode, f => f.Address.ZipCode())
            .RuleFor(i => i.Total, f => f.Finance.Amount(50, 5000))
            .RuleFor(i => i.PaymentMethod, f => f.PickRandom("Credit Card", "PayPal", "Bank Transfer"))
            .RuleFor(i => i.PaymentAccountName, f => f.Finance.AccountName())
            .RuleFor(i => i.PaymentAccountNumber, f => f.Finance.Account(10))
            .RuleFor(i => i.Status, f => f.PickRandom("AWAITING_FULFILLMENT", "ON_HOLD", "AWAITING_SHIPMENT", "SHIPPED", "COMPLETED"))
            .RuleFor(i => i.StatusMessage, f => f.Lorem.Sentence())
            .RuleFor(i => i.CreatedAt, f => f.Date.Past())
            .RuleFor(i => i.UpdatedAt, f => f.Date.Past());
        var invoices = invoiceFaker.Generate(request.NInvoices);

        // Generate Invoice Items
        var invoiceItemFaker = new Faker<InvoiceItem>("en")
            .RuleFor(ii => ii.Id, f => f.Random.ULong(1))
            .RuleFor(ii => ii.InvoiceId, f => f.PickRandom(invoices).Id)
            .RuleFor(ii => ii.ProductId, f => f.PickRandom(products).Id)
            .RuleFor(ii => ii.UnitPrice, f => f.Finance.Amount(1, 1000, 2))
            .RuleFor(ii => ii.Quantity, f => f.Random.Int(1, 5))
            .RuleFor(ii => ii.CreatedAt, f => f.Date.Past())
            .RuleFor(ii => ii.UpdatedAt, f => f.Date.Past());
        var invoiceItems = invoiceItemFaker.Generate(request.NInvoices * 5);
        
        return new Database
        {
            Users = users,
            Brands = brands,
            Categories = categories,
            ProductImages = productImages,
            Products = products,
            Invoices = invoices,
            InvoiceItems = invoiceItems
        };
    }
}