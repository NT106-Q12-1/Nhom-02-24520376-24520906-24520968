using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_Download_Click(object sender, EventArgs e)
        {
            string url = tb_URL.Text.Trim();
            string savePath = tb_FileURL.Text.Trim();

            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(savePath))
            {
                MessageBox.Show("Vui lòng nhập URL và đường dẫn lưu file!");
                return;
            }
            rtb_HTML.Text = "Loading ....";
            try
            {
                using (WebClient web = new WebClient())
                {
                    web.DownloadFile(url, savePath);
                    string htmlText = File.ReadAllText(savePath);
                    rtb_HTML.Text = htmlText;
                    MessageBox.Show("Download thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
