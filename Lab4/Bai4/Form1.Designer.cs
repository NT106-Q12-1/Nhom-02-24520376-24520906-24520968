namespace Bai4
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
            pb_Progress = new ProgressBar();
            wv_CinemaWeb = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)wv_CinemaWeb).BeginInit();
            SuspendLayout();
            // 
            // pb_Progress
            // 
            pb_Progress.Location = new Point(12, 404);
            pb_Progress.Name = "pb_Progress";
            pb_Progress.Size = new Size(776, 34);
            pb_Progress.TabIndex = 1;
            // 
            // wv_CinemaWeb
            // 
            wv_CinemaWeb.AllowExternalDrop = true;
            wv_CinemaWeb.CreationProperties = null;
            wv_CinemaWeb.DefaultBackgroundColor = Color.White;
            wv_CinemaWeb.Location = new Point(13, 12);
            wv_CinemaWeb.Name = "wv_CinemaWeb";
            wv_CinemaWeb.Size = new Size(775, 386);
            wv_CinemaWeb.TabIndex = 2;
            wv_CinemaWeb.ZoomFactor = 1D;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(wv_CinemaWeb);
            Controls.Add(pb_Progress);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)wv_CinemaWeb).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar pb_Progress;
        private Microsoft.Web.WebView2.WinForms.WebView2 wv_CinemaWeb;
    }
}
