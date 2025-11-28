namespace Bai2
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
            tb_URL = new TextBox();
            tb_FileURL = new TextBox();
            rtb_HTML = new RichTextBox();
            btn_Download = new Button();
            SuspendLayout();
            // 
            // tb_URL
            // 
            tb_URL.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_URL.Location = new Point(22, 19);
            tb_URL.Name = "tb_URL";
            tb_URL.Size = new Size(587, 35);
            tb_URL.TabIndex = 0;
            // 
            // tb_FileURL
            // 
            tb_FileURL.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_FileURL.Location = new Point(22, 78);
            tb_FileURL.Name = "tb_FileURL";
            tb_FileURL.Size = new Size(587, 35);
            tb_FileURL.TabIndex = 2;
            // 
            // rtb_HTML
            // 
            rtb_HTML.Location = new Point(22, 140);
            rtb_HTML.Name = "rtb_HTML";
            rtb_HTML.ReadOnly = true;
            rtb_HTML.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtb_HTML.Size = new Size(757, 298);
            rtb_HTML.TabIndex = 3;
            rtb_HTML.Text = "";
            // 
            // btn_Download
            // 
            btn_Download.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Download.Location = new Point(636, 12);
            btn_Download.Name = "btn_Download";
            btn_Download.Size = new Size(143, 46);
            btn_Download.TabIndex = 4;
            btn_Download.Text = "Download";
            btn_Download.UseVisualStyleBackColor = true;
            btn_Download.Click += btn_Download_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Download);
            Controls.Add(rtb_HTML);
            Controls.Add(tb_FileURL);
            Controls.Add(tb_URL);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_URL;
        private TextBox tb_FileURL;
        private RichTextBox rtb_HTML;
        private Button btn_Download;
    }
}
