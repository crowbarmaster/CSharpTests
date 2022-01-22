using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchJarFile {
    internal class JarLauncher {

        private Process _process;
        private string _jarPath;
        private FileInfo _jarFileInfo;

        public JarLauncher(string jarPath) {
            _jarPath = jarPath;
            _jarFileInfo = new FileInfo(jarPath);
        }

        public void Run() {
            ProcessStartInfo processStartInfo = new ProcessStartInfo() {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                CreateNoWindow = true,
                FileName = @"Java",
                WorkingDirectory = _jarFileInfo.Directory.FullName,
                Arguments = @"-Xmx1024M -Xms1024M -jar "+ _jarPath + " nogui"
            };
            _process = Process.Start(processStartInfo);
            _process.OutputDataReceived += _process_OutputDataReceived;
            _process.BeginOutputReadLine();
            _process.WaitForExit();
        }

        private void _process_OutputDataReceived(object sender, DataReceivedEventArgs e) {
            Console.WriteLine(e.Data);
        }

        public void Stop() {
            _process.StandardInput.WriteLine("stop");
        }
    }
}
