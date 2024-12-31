# Fake Data Generator

This tool generates fake data for various entities such as users, brands, categories, products, and invoices. The generated data can be exported in formats such as `csv`, `sql` and `json`.

## Prerequisites

If you want to build the tool and run with `dotnet run`, you must install this:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)

It is unnecessary for you to install .NET SDK if you want to run the tool by executable file.

## Getting Started

### 1. **Clone the repository and navigate to the project folder:**

```bash
git clone <repository-url>
cd <project-folder>
```

### 2. **Build the Application**

To build and publish the application as a single executable, run the `build.sh` script. This will clean, rebuild, and publish the application to the `./publish` directory:

```bash
cd scripts
./build.sh
```

### 3. **Run the Application**

You can run the application in two ways:

#### **Option 1: Running with `dotnet run`**

To run the application directly without publishing, use the following command:

```bash
dotnet run --users <number> --brands <number> --categories <number> --products <number> --invoices <number> --export <filetypes>
```

Where:

- `--users`       : Number of users to generate (1–1000).
- `--brands`      : Number of brands to generate (1–1000).
- `--categories`  : Number of categories to generate (1–1000).
- `--products`    : Number of products to generate (1–1000).
- `--invoices`    : Number of invoices to generate (1–1000).
- `--export`      : File types to export, separated by commas (e.g., `csv,sql,json`).

#### **Option 2: Running the Published Executable**

1. After running `build.sh`, the published executable will be located in the `./publish` folder.

2. To run the executable with specific options:

```bash
cd publish
./MDataGeneration.exe --users <number> --brands <number> --categories <number> --products <number> --invoices <number> --export <filetypes>
```

Example:

```bash
./MDataGeneration.exe --users 50 --brands 5 --categories 50 --products 1000 --invoices 1000 --export csv
```

#### **Option 3: Running the Example Script**

For a quicker execution, you can use the `example.sh` script, which runs the application with predefined options and retrieves the generated data. The script assumes the build step has already been executed.

1. First, make sure the `./publish` directory contains the executable (`MDataGeneration.exe`).

2. Then, run the `example.sh` script from the project root folder:

```bash
cd scripts
./example.sh
```

This will execute the `.exe` file from the `./publish` directory and pass the following parameters:

```sh
--users 50 --brands 5 --categories 50 --products 1000 --invoices 1000 --export json
```

## Output

The generated data will be saved to the `output/<timestamp>` directory in the specified file format(s), such as `csv`, `sql` or `json`.
