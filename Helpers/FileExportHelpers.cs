using System.Text;

namespace MDataGeneration.Helpers;

public static class FileExportHelpers
{
    public static IEnumerable<string> GetPropertyNames<T>(T obj)
    {
        foreach (var prop in obj!.GetType().GetProperties())
        {
            yield return $"`{ToSnakeCase(prop.Name)}`";
        }
    }

    public static IEnumerable<string> GetPropertyValues<T>(T obj)
    {
        foreach (var prop in obj!.GetType().GetProperties())
        {
            var value = prop.GetValue(obj);
            if (value == null) yield return "NULL";
            else if (value is string) yield return $"'{value.ToString()?.Replace("'", "''")}'";
            else if (value is DateTime dt) yield return $"'{dt:yyyy-MM-dd HH:mm:ss}'";
            else if (value is bool b) yield return b ? "1" : "0";
            else yield return value.ToString()!;
        }
    }
    
    private static string ToSnakeCase(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var stringBuilder = new StringBuilder();
        for (var i = 0; i < input.Length; i++)
        {
            if (char.IsUpper(input[i]))
            {
                if (i > 0) stringBuilder.Append('_');
                stringBuilder.Append(char.ToLower(input[i]));
            }
            else
            {
                stringBuilder.Append(input[i]);
            }
        }
        return stringBuilder.ToString();
    }
}