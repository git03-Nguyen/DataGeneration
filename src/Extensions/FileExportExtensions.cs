using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using MDataGeneration.Helpers;
using MDataGeneration.Models.Dtos;

namespace MDataGeneration.Extensions;

public static class FileExportExtensions
{
    private const string AccountTableName = "users";
    private const string BrandTableName = "brands";
    private const string CategoryTableName = "categories";
    private const string ProductTableName = "products";
    private const string ProductImageTableName = "product_images";
    private const string InvoiceTableName = "invoices";
    
    public static Database ExportToFile(this Database database, List<FileFormat> formats)
    {
        var currentTimestamp = DateTime.Now.ToString("yyyyMMdd-HHmmss");
        var folder = Path.Combine("output", currentTimestamp);
        Directory.CreateDirectory(folder);
        
        if (formats.Contains(FileFormat.CSV))
        {
            database.Users.WriteToCsv(AccountTableName, folder);
            database.Brands.WriteToCsv(BrandTableName, folder);
            database.Categories.WriteToCsv(CategoryTableName, folder);
            database.ProductImages.WriteToCsv(ProductImageTableName, folder);
            database.Products.WriteToCsv(ProductTableName, folder);
            database.Invoices.WriteToCsv(InvoiceTableName, folder);
        }

        if (formats.Contains(FileFormat.SQL))
        {
            database.Users.WriteToSql(AccountTableName, folder);
            database.Brands.WriteToSql(BrandTableName, folder);
            database.Categories.WriteToSql(CategoryTableName, folder);
            database.ProductImages.WriteToSql(ProductImageTableName, folder);
            database.Products.WriteToSql(ProductTableName, folder);
            database.Invoices.WriteToSql(InvoiceTableName, folder);
        }

        if (formats.Contains(FileFormat.JSON))
        {
            database.Users.WriteToJson(AccountTableName, folder);
            database.Brands.WriteToJson(BrandTableName, folder);
            database.Categories.WriteToJson(CategoryTableName, folder);
            database.ProductImages.WriteToJson(ProductImageTableName, folder);
            database.Products.WriteToJson(ProductTableName, folder);
            database.Invoices.WriteToJson(InvoiceTableName, folder);
        }
        
        return database;
    }

    private static void WriteToCsv<T>(this List<T> data, string tableName, string folder, string delimiter = ",")
    {
        var path = Path.Combine(folder, $"{tableName}.csv");
        using var writer = new StreamWriter(path);
        using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = delimiter,
            HasHeaderRecord = true
        });
        csv.WriteRecords(data);
    }

    private static void WriteToSql<T>(this List<T> data, string tableName, string folder)
    {
        var path = Path.Combine(folder, $"{tableName}.sql");
        var sb = new StringBuilder();
        var valuesList = new List<string>();

        foreach (var item in data)
        {
            valuesList.Add($"({string.Join(", ", FileExportHelpers.GetPropertyValues(item))})");
        }

        sb.AppendLine($"INSERT INTO `{tableName}` ({string.Join(", ", FileExportHelpers.GetPropertyNames(data.First()))})");
        sb.AppendLine($"VALUES {string.Join(", ", valuesList)} ON DUPLICATE KEY UPDATE id=id;");

        File.WriteAllText(path, sb.ToString());
    }

    private static void WriteToJson<T>(this List<T> data, string tableName, string folder)
    {
        var path = Path.Combine(folder, $"{tableName}.json");
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(data, new Newtonsoft.Json.JsonSerializerSettings
        {
            Formatting = Newtonsoft.Json.Formatting.Indented,
            ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver
            {
                NamingStrategy = new Newtonsoft.Json.Serialization.SnakeCaseNamingStrategy()
            }
        });
        File.WriteAllText(path, json);
    }
}