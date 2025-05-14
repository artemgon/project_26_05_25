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
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            long result = await CalculateFactorialAsync(n);
            Console.WriteLine($"Factorial of {n} is {result}");
        }

        static async Task<long> CalculateFactorialAsync(int n)
        {
            return await Task.Run(() =>
            {
                long result = 1;
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }
                return result;
            });
        }
    }
}
