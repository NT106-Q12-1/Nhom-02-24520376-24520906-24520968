namespace Bai56
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
            richTextBox1 = new RichTextBox();
            tb_Username = new TextBox();
            tb_Password = new TextBox();
            btn_Login = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // tb_URL
            // 
            tb_URL.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_URL.Location = new Point(162, 27);
            tb_URL.Name = "tb_URL";
            tb_URL.Size = new Size(626, 35);
            tb_URL.TabIndex = 0;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 186);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(776, 252);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // tb_Username
            // 
            tb_Username.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_Username.Location = new Point(162, 80);
            tb_Username.Name = "tb_Username";
            tb_Username.Size = new Size(435, 35);
            tb_Username.TabIndex = 2;
            // 
            // tb_Password
            // 
            tb_Password.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_Password.Location = new Point(162, 134);
            tb_Password.Name = "tb_Password";
            tb_Password.PasswordChar = '*';
            tb_Password.Size = new Size(435, 35);
            tb_Password.TabIndex = 3;
            tb_Password.UseSystemPasswordChar = true;
            // 
            // btn_Login
            // 
            btn_Login.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Login.Location = new Point(639, 91);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(124, 63);
            btn_Login.TabIndex = 4;
            btn_Login.Text = "Login";
            btn_Login.UseVisualStyleBackColor = true;
            btn_Login.Click += btn_Login_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(59, 27);
            label1.TabIndex = 5;
            label1.Text = "URL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 83);
            label2.Name = "label2";
            label2.Size = new Size(108, 27);
            label2.TabIndex = 6;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 137);
            label3.Name = "label3";
            label3.Size = new Size(104, 27);
            label3.TabIndex = 7;
            label3.Text = "Password";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_Login);
            Controls.Add(tb_Password);
            Controls.Add(tb_Username);
            Controls.Add(richTextBox1);
            Controls.Add(tb_URL);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_URL;
        private RichTextBox richTextBox1;
        private TextBox tb_Username;
        private TextBox tb_Password;
        private Button btn_Login;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
