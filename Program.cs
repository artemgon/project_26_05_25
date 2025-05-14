using System;
using System.Threading;

namespace project_26_05_25
{
    public class Program
    {
        static void Main()
        {
            Thread numThread = new (GenerateNumbers) { Priority = ThreadPriority.Normal };
            Thread letterThread = new(GenerateLetters) { Priority = ThreadPriority.AboveNormal };
            Thread symbThread = new(GenerateSymbols) { Priority = ThreadPriority.BelowNormal };

            numThread.Start();
            letterThread.Start();
            symbThread.Start();

            numThread.Join();
            letterThread.Join();
            symbThread.Join();
        }

        static void GenerateNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }

        static void GenerateLetters()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                Console.WriteLine(c);
                Thread.Sleep(100);
            }
        }

        static void GenerateSymbols()
        {
            for (char c = '!'; c <= '/'; c++)
            {
                Console.WriteLine(c);
                Thread.Sleep(100);
            }
        }
    }
}
