using System;
using System.Diagnostics;
using System.IO;

namespace testing
{
    class Program
    {
        static int fileCount = 0;
        static Stopwatch stopwatch = new Stopwatch();

        static void Main(string[] args)
        {
            stopwatch.Start();
            foreach (string volume in Environment.GetLogicalDrives())
            {

                Console.WriteLine($"Drive {volume} has {ProcessAllFiles(volume)} files.");
                fileCount = 0;
            }
            stopwatch.Stop();

            Console.WriteLine($"Opperation completed in {stopwatch.Elapsed.TotalSeconds} seconds.");
        }

        static int ProcessAllFiles(string folder)
        {
            foreach (string file in Directory.GetFiles(folder))
            {
                fileCount++;
            }
            foreach (string subDir in Directory.GetDirectories(folder))
            {
                try
                {
                    ProcessAllFiles(subDir);
                }
                catch
                {
                    // swallow, log, whatever
                }
            }
            return fileCount;
        }
    }
}
