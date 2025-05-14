using System;
using System.IO;
using System.Threading;

namespace project_26_05_25
{
    public class Program
    {
        static bool _paused = false;
        static bool _stopped = false;
        static int _filesCopied = 0;

        static void Main()
        {
            Console.WriteLine("Directory Copy with Pause/Stop");
            Console.WriteLine("Commands: [2] Pause, [3] Resume, [4] Stop");

            Console.Write("Enter source directory: ");
            string sourceDir = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter destination directory: ");
            string destDir = Console.ReadLine() ?? string.Empty;

            Thread copyThread = new (() => CopyDirectoryWithControl(sourceDir, destDir));
            copyThread.Start();

            while (copyThread.IsAlive)
            {
                string input = Console.ReadLine() ?? string.Empty;
                switch (input)
                {
                    case "2": _paused = true; break;
                    case "3": _paused = false; break;
                    case "4": _stopped = true; break;
                }
            }
        }

        static void CopyDirectoryWithControl(string source, string dest)
        {
            try
            {
                Directory.CreateDirectory(dest);
                foreach (string file in Directory.GetFiles(source))
                {
                    if (_stopped) break;
                    while (_paused && !_stopped) Thread.Sleep(500);

                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(dest, fileName);
                    File.Copy(file, destFile, true);
                    _filesCopied++;
                    Console.WriteLine($"Copied: {fileName} (Total: {_filesCopied})");
                }

                if (!_stopped)
                {
                    foreach (string dir in Directory.GetDirectories(source))
                    {
                        string dirName = Path.GetFileName(dir);
                        CopyDirectoryWithControl(dir, Path.Combine(dest, dirName));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine(_stopped ? "Copy stopped!" : "Copy completed!");
        }
    }
}
