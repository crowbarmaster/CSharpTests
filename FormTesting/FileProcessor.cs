using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormTesting
{
    public class FileProcessor
    {
        public static List<string> fileList = new List<string>();
        public static Stopwatch stopwatch = new Stopwatch();

        public static Task ProcessAllVolumes(IProgress<int> progress, SimpleFileProcessor parent)
        {
            return Task.Run(() =>
            {
                stopwatch.Start();
                string[] systemVolumes = Environment.GetLogicalDrives();
                for (int i = 1; i < systemVolumes.Length + 1; i++)
                {
                    progress.Report(i);
                    fileList = GetDirectoryFileList(systemVolumes[i - 1], fileList);
                    Console.WriteLine($"Drive {systemVolumes[i - 1]} has {fileList.Count} files.");
                }
                parent.Invoke((MethodInvoker)delegate { progress.Report(-1); });
                for (int i = 0; i < fileList.Count; i++)
                {
                    Task.Delay(20); // This is just an empty task that runs for 20ms to delay the loop and avoid freezing UI. Put code here to do your scanning on files and you may not need it.
                    parent.Invoke((MethodInvoker)delegate
                    {
                        progress.Report(i / 10000);
                    });
                }
                stopwatch.Stop();
                parent.UpdateInfoLabel($"Opperation completed in {stopwatch.Elapsed.TotalSeconds} seconds. Found {fileList.Count} files.");
            });
        }

        static List<string> GetDirectoryFileList(string folder, List<string> fileList)
        {
            foreach (string file in Directory.GetFiles(folder))
            {
                fileList.Add(file);
            }
            foreach (string subDir in Directory.GetDirectories(folder))
            {
                try
                {
                    GetDirectoryFileList(subDir, fileList);
                }
                catch
                {
                    // swallow errors.
                }
            }
            return fileList;
        }
    }
}
