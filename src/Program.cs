using System.CommandLine;
using MDataGeneration.Handlers;
using MDataGeneration.Models.Dtos;

namespace MDataGeneration;

class Program
{
    static async Task Main(string[] args)
    {
        var rootCommand = new RootCommand("Command-line argument parser");

        var usersOption = new Option<int?>("--users", "Specify number of users");
        var brandsOption = new Option<int?>("--brands", "Specify number of brands");
        var categoriesOption = new Option<int?>("--categories", "Specify number of categories");
        var productsOption = new Option<int?>("--products", "Specify number of products");
        var invoicesOption = new Option<int?>("--invoices", "Specify number of invoices");
        var exportOption = new Option<string>("--export", "Specify export file types");

        rootCommand.AddOption(usersOption);
        rootCommand.AddOption(brandsOption);
        rootCommand.AddOption(categoriesOption);
        rootCommand.AddOption(productsOption);
        rootCommand.AddOption(invoicesOption);
        rootCommand.AddOption(exportOption);

        rootCommand.SetHandler((users, brands, categories, products, invoices, export) =>
        {
            if (!users.HasValue || !brands.HasValue || !categories.HasValue || !products.HasValue || !invoices.HasValue || string.IsNullOrEmpty(export))
            {
                Console.WriteLine("Please specify all options");
                return;
            }
            
            if (users.Value < 1 || brands.Value < 1 || categories.Value < 1 || products.Value < 1 || invoices.Value < 1)
            {
                Console.WriteLine("Please specify a value greater than 0");
                return;
            }
            
            if (users.Value > 1000 || brands.Value > 1000 || categories.Value > 1000 || products.Value > 1000 || invoices.Value > 1000)
            {
                Console.WriteLine("Please specify a value less than 1000");
                return;
            }
            
            var request = new GenerationRequest
            {
                NUsers = users.Value,
                NBrands = brands.Value,
                NCategories = categories.Value,
                NProducts = products.Value,
                NInvoices = invoices.Value
            };
            
            var formats = new List<FileFormat>();
            foreach (var format in export.Split(","))
            {
                if (Enum.TryParse<FileFormat>(format, true, out var fileFormat))
                {
                    formats.Add(fileFormat);
                }
            }

            request.GenerateDatabase().ExportToFile(formats);
            Console.WriteLine("Data generated successfully");
        }, usersOption, brandsOption, categoriesOption, productsOption, invoicesOption, exportOption);

        await rootCommand.InvokeAsync(args);
    }
}
