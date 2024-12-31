using Bogus;

namespace MDataGeneration.Helpers;

public static class DataGenerationHelpers
{
    public static string ToSlugString(this string name, Faker f)
    {
        const int maxLength = 50; 
        string baseSlug = name.ToLower() 
            .Replace(" ", "-") 
            .Replace(",", "") 
            .Replace(".", "") 
            .Replace("&", "and") 
            .Replace("'", "")
            .Trim('-');

        if (baseSlug.Length > maxLength - 5)
        {
            baseSlug = baseSlug.Substring(0, maxLength - 5).Trim('-');
        }
        
        var randomNumber = f.Random.Int(100, 9999);
        return $"{baseSlug}-{randomNumber}";
    }
    
    public static string ToLimitString(this string text, int maxLength)
    {
        if (text.Length > maxLength)
        {
            return text.Substring(0, maxLength - 3) + "...";
        }
        return text;
    }
}