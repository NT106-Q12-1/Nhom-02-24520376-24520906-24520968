namespace Bai1
{
    partial class Bai1
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
            txtURL = new TextBox();
            btnGET = new Button();
            rtbhtml = new RichTextBox();
            lblURL = new Label();
            SuspendLayout();
            // 
            // txtURL
            // 
            txtURL.BackColor = Color.FromArgb(240, 248, 255);
            txtURL.BorderStyle = BorderStyle.FixedSingle;
            txtURL.Font = new Font("Segoe UI", 10F);
            txtURL.Location = new Point(79, 32);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(510, 25);
            txtURL.TabIndex = 0;
            txtURL.KeyPress += txtURL_KeyPress;
            // 
            // btnGET
            // 
            btnGET.BackColor = Color.FromArgb(200, 220, 255);
            btnGET.Cursor = Cursors.Hand;
            btnGET.FlatAppearance.BorderColor = Color.FromArgb(150, 180, 230);
            btnGET.FlatStyle = FlatStyle.Flat;
            btnGET.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGET.ForeColor = Color.FromArgb(50, 80, 150);
            btnGET.Location = new Point(611, 31);
            btnGET.Name = "btnGET";
            btnGET.Size = new Size(131, 27);
            btnGET.TabIndex = 1;
            btnGET.Text = "GET";
            btnGET.UseVisualStyleBackColor = false;
            btnGET.Click += btnGET_Click;
            // 
            // rtbhtml
            // 
            rtbhtml.BackColor = Color.FromArgb(248, 252, 255);
            rtbhtml.BorderStyle = BorderStyle.FixedSingle;
            rtbhtml.Font = new Font("Consolas", 9F);
            rtbhtml.Location = new Point(39, 96);
            rtbhtml.Name = "rtbhtml";
            rtbhtml.Size = new Size(703, 354);
            rtbhtml.TabIndex = 2;
            rtbhtml.Text = "";
            // 
            // lblURL
            // 
            lblURL.AutoSize = true;
            lblURL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblURL.ForeColor = Color.FromArgb(80, 100, 140);
            lblURL.Location = new Point(42, 37);
            lblURL.Name = "lblURL";
            lblURL.Size = new Size(33, 15);
            lblURL.TabIndex = 3;
            lblURL.Text = "URL:";
            // 
            // Bai1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 240, 250);
            ClientSize = new Size(770, 477);
            Controls.Add(lblURL);
            Controls.Add(rtbhtml);
            Controls.Add(btnGET);
            Controls.Add(txtURL);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Bai1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bai1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtURL;
        private Button btnGET;
        private RichTextBox rtbhtml;
        private Label lblURL;
    }
}