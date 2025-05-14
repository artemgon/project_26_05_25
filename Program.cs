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
            Console.Write("Enter base number: ");
            double baseNum = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter exponent: ");
            double exponent = double.Parse(Console.ReadLine() ?? "0");

            double result = await CalculatePowerAsync(baseNum, exponent);
            Console.WriteLine($"{baseNum}^{exponent} = {result}");
        }

        static async Task<double> CalculatePowerAsync(double b, double e)
        {
            return await Task.Run(() => Math.Pow(b, e));
        }
    }
}
