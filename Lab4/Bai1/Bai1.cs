using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private async Task<string> getHTML(string szURL)
        {
            try
            {
                WebRequest request = WebRequest.Create(szURL);
                WebResponse response = await request.GetResponseAsync();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = await reader.ReadToEndAsync();

                response.Close();

                return responseFromServer;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        private async void btnGET_Click(object sender, EventArgs e)
        {
            try
            {
                string url = txtURL.Text.Trim();

                if (string.IsNullOrEmpty(url) || string.IsNullOrWhiteSpace(url))
                {
                    MessageBox.Show("Vui lòng nhập URL", "Không thể truy cập URL trống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtURL.Focus();
                    return;
                }

                if (!url.StartsWith("http://") && !url.StartsWith(("https://")))
                {
                    url = "https://" + url;
                    txtURL.Text = url;
                }

                rtbhtml.Text = "Đang tải dữ liệu";
                btnGET.Enabled = false;

                string html = await getHTML(url);
                rtbhtml.Text = html;

                btnGET.Enabled = true;
            }
            catch (Exception ex)
            {
                rtbhtml.Text = $"Lỗi {ex.Message}";
            }
        }

        private void txtURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnGET_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
