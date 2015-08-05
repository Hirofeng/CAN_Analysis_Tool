namespace Fengyuan.CatForm
{
    partial class AboutBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.imageIcons = new System.Windows.Forms.ImageList(this.components);
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblAboutText = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageIcons
            // 
            this.imageIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageIcons.ImageStream")));
            this.imageIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageIcons.Images.SetKeyName(0, "yirui-img2ico.net.ico");
            // 
            // lblIcon
            // 
            this.lblIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIcon.ImageIndex = 0;
            this.lblIcon.ImageList = this.imageIcons;
            this.lblIcon.Location = new System.Drawing.Point(12, 18);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(51, 40);
            this.lblIcon.TabIndex = 0;
            // 
            // lblAboutText
            // 
            this.lblAboutText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAboutText.Location = new System.Drawing.Point(69, 18);
            this.lblAboutText.Multiline = true;
            this.lblAboutText.Name = "lblAboutText";
            this.lblAboutText.ReadOnly = true;
            this.lblAboutText.Size = new System.Drawing.Size(303, 40);
            this.lblAboutText.TabIndex = 1;
            this.lblAboutText.Text = "Copyright 2009-2015 YIRUI AUTO TEC.LTD\r\nEditor : Feng yuan ";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(297, 71);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // AboutBox
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 106);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblAboutText);
            this.Controls.Add(this.lblIcon);
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About CAT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageIcons;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.TextBox lblAboutText;
        private System.Windows.Forms.Button btnOK;
    }
}