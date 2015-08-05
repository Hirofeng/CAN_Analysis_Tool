namespace Fengyuan.CatForm
{
    partial class SplashForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
            this.splashPicture = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.processBarTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splashPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // splashPicture
            // 
            this.splashPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splashPicture.Image = ((System.Drawing.Image)(resources.GetObject("splashPicture.Image")));
            this.splashPicture.Location = new System.Drawing.Point(0, 0);
            this.splashPicture.Name = "splashPicture";
            this.splashPicture.Size = new System.Drawing.Size(599, 371);
            this.splashPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.splashPicture.TabIndex = 0;
            this.splashPicture.TabStop = false;
            this.splashPicture.Tag = "timer1";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 359);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(599, 12);
            this.progressBar.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tag = "splashPicture";
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // processBarTimer
            // 
            this.processBarTimer.Enabled = true;
            this.processBarTimer.Interval = 20;
            this.processBarTimer.Tick += new System.EventHandler(this.processBarTimer_Tick);
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 371);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.splashPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashForm";
            this.TopMost = true;
            this.UseWaitCursor = true;
            ((System.ComponentModel.ISupportInitialize)(this.splashPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox splashPicture;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer processBarTimer;
    }
}