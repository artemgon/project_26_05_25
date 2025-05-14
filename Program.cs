using System;
using System.Threading;
using System.IO;

namespace project_26_05_25
{
    public class Program
    {
        static void Main()
        {
            Console.Write("Enter source directory: ");
            string source = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter destination directory: ");
            string dest = Console.ReadLine() ?? string.Empty;

            CopyDirectory(source, dest);
            Console.WriteLine("Directory is copied!");
        }

        static void CopyDirectory(string source, string dest)
        {
            Directory.CreateDirectory(dest);

            foreach (string file in Directory.GetFiles(source))
            {
                string fileName = Path.GetFileName(file);
                File.Copy(file, Path.Combine(dest, fileName), true);
                Console.WriteLine($"Copied: {fileName}");
            }

            foreach (string dir in Directory.GetDirectories(source))
            {
                string dirName = Path.GetFileName(dir);
                CopyDirectory(dir, Path.Combine(dest, dirName));
            }
        }
    }
}
