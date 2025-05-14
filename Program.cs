using System;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace project_26_05_25
{
    public class Program
    {
        static async Task Main()
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine() ?? "0";

            (int vowels, int consonants, int symbols) = await AnalyzeTextAsync(text);
            Console.WriteLine($"Vowels: {vowels}, Consonants: {consonants}, Symbols: {symbols}");
        }

        static async Task<(int vowels, int consonants, int symbols)> AnalyzeTextAsync(string text)
        {
            return await Task.Run(() =>
            {
                int vowels = 0, consonants = 0, symbols = 0;
                string vowelsStr = "AEIOUaeiou";
                string consonantsStr = "BCDFGHJKLMNPQRSTVWXYZbcdfghjklmnpqrstvwxyz";

                foreach (char c in text)
                {
                    if (vowelsStr.Contains(c)) vowels++;
                    else if (consonantsStr.Contains(c)) consonants++;
                    else if (!char.IsWhiteSpace(c)) symbols++;
                }

                return (vowels, consonants, symbols);
            });
        }
    }
}
