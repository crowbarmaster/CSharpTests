
namespace FormTesting
{
    partial class SimpleFileProcessor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.processFilesBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.infoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // processFilesBtn
            // 
            this.processFilesBtn.Location = new System.Drawing.Point(313, 207);
            this.processFilesBtn.Name = "processFilesBtn";
            this.processFilesBtn.Size = new System.Drawing.Size(133, 23);
            this.processFilesBtn.TabIndex = 0;
            this.processFilesBtn.Text = "Process all files.";
            this.processFilesBtn.UseVisualStyleBackColor = true;
            this.processFilesBtn.Click += new System.EventHandler(this.processFilesBtn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(71, 158);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(607, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(71, 128);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(56, 15);
            this.infoLabel.TabIndex = 2;
            this.infoLabel.Text = "Info label";
            // 
            // SimpleFileProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.processFilesBtn);
            this.Name = "SimpleFileProcessor";
            this.Text = "File Processor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button processFilesBtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label infoLabel;
    }
}

