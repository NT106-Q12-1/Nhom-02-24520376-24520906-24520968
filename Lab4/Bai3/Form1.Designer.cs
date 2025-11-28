namespace Bai3
{
    partial class Form1
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
            wv_Web = new Microsoft.Web.WebView2.WinForms.WebView2();
            tb_URL = new TextBox();
            btn_Load = new Button();
            btn_DownloadFile = new Button();
            btn_DownloadResource = new Button();
            ((System.ComponentModel.ISupportInitialize)wv_Web).BeginInit();
            SuspendLayout();
            // 
            // wv_Web
            // 
            wv_Web.AllowExternalDrop = true;
            wv_Web.CreationProperties = null;
            wv_Web.DefaultBackgroundColor = Color.White;
            wv_Web.Location = new Point(12, 105);
            wv_Web.Name = "wv_Web";
            wv_Web.Size = new Size(776, 333);
            wv_Web.TabIndex = 0;
            wv_Web.ZoomFactor = 1D;
            // 
            // tb_URL
            // 
            tb_URL.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_URL.Location = new Point(20, 13);
            tb_URL.Name = "tb_URL";
            tb_URL.Size = new Size(629, 35);
            tb_URL.TabIndex = 1;
            // 
            // btn_Load
            // 
            btn_Load.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Load.Location = new Point(655, 7);
            btn_Load.Name = "btn_Load";
            btn_Load.Size = new Size(133, 45);
            btn_Load.TabIndex = 2;
            btn_Load.Text = "Load";
            btn_Load.UseVisualStyleBackColor = true;
            btn_Load.Click += btn_Load_Click;
            // 
            // btn_DownloadFile
            // 
            btn_DownloadFile.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_DownloadFile.Location = new Point(89, 54);
            btn_DownloadFile.Name = "btn_DownloadFile";
            btn_DownloadFile.Size = new Size(252, 45);
            btn_DownloadFile.TabIndex = 3;
            btn_DownloadFile.Text = "Download File";
            btn_DownloadFile.UseVisualStyleBackColor = true;
            btn_DownloadFile.Click += btn_DownloadFile_Click;
            // 
            // btn_DownloadResource
            // 
            btn_DownloadResource.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_DownloadResource.Location = new Point(444, 54);
            btn_DownloadResource.Name = "btn_DownloadResource";
            btn_DownloadResource.Size = new Size(252, 45);
            btn_DownloadResource.TabIndex = 4;
            btn_DownloadResource.Text = "Download Resource";
            btn_DownloadResource.UseVisualStyleBackColor = true;
            btn_DownloadResource.Click += btn_DownloadResource_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_DownloadResource);
            Controls.Add(btn_DownloadFile);
            Controls.Add(btn_Load);
            Controls.Add(tb_URL);
            Controls.Add(wv_Web);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)wv_Web).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 wv_Web;
        private TextBox tb_URL;
        private Button btn_Load;
        private Button btn_DownloadFile;
        private Button btn_DownloadResource;
    }
}
