using System.Text.RegularExpressions;

namespace App.Application.Extensions
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            // Türkçe karakterleri dönüştür
            input = input.Replace("ç", "c")
                         .Replace("ğ", "g")
                         .Replace("ı", "i")
                         .Replace("ö", "o")
                         .Replace("ş", "s")
                         .Replace("ü", "u")
                         .Replace("Ç", "C")
                         .Replace("Ğ", "G")
                         .Replace("İ", "I")
                         .Replace("Ö", "O")
                         .Replace("Ş", "S")
                         .Replace("Ü", "U");

            // Tüm harfleri küçük yap
            input = input.ToLowerInvariant();

            // Geçersiz karakterleri kaldır
            input = Regex.Replace(input, @"[^a-z0-9\s-]", "");

            // Boşlukları tek tire ile değiştir
            input = Regex.Replace(input, @"\s+", "-").Trim();

            // Birden fazla ardışık tireyi tek bir tire yap
            input = Regex.Replace(input, @"-+", "-");

            return input;
        }
    }
}
