using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormTesting
{
    public partial class SimpleFileProcessor : Form
    {
        public SimpleFileProcessor()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Environment.GetLogicalDrives().Length+1;
        }

        private void processFilesBtn_Click(object sender, EventArgs e)
        {
            infoLabel.Text = "Gathering system file information, please wait!";
            Progress<int> progress = new Progress<int>(prog =>
            {
                if(prog == -1)
                {
                    progressBar1.Maximum = FileProcessor.fileList.Count / 10000;
                    progressBar1.Value = 0;
                    prog = 0;
                    Invoke((MethodInvoker)delegate { infoLabel.Text = "Now scanning files on all disks..."; });
                    //Delay(10).Wait();
                    return;
                }
                progressBar1.Value = prog;
            });
            FileProcessor.ProcessAllVolumes(progress, this);
        }

        public void UpdateInfoLabel (string text)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { infoLabel.Text = text; });
                return;
            }
            infoLabel.Text = text;
        }
    }
}
