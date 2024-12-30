
# Fake Data Generator

This is a tool for generating fake data for various entities such as users, brands, categories, products, and invoices. The data can be exported in `csv` and `sql` formats.

## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)

## Usage

Run the application with the following options:

```sh
dotnet run --users <number> --brands <number> --categories <number> --products <number> --invoices <number> --export <filetypes>
```

### Options

- `--users`       : Number of users to generate (1–1000).
- `--brands`      : Number of brands to generate (1–1000).
- `--categories`  : Number of categories to generate (1–1000).
- `--products`    : Number of products to generate (1–1000).
- `--invoices`    : Number of invoices to generate (1–1000).
- `--export`      : File types to export (e.g., `csv,sql`).

### Example

```sh
dotnet run --users 50 --brands 5 --categories 50 --products 1000 --invoices 1000 --export sql
```

The output files will be saved in the application's `output/` directory.
