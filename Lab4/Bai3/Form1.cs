using System.Net;
using System.Security.Policy;
using Microsoft.Web.WebView2.Core;

namespace Bai3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            wv_Web.NavigationStarting += EnsureHttps;
            InitializeAsync();
        }

        async void InitializeAsync()
        {
            await wv_Web.EnsureCoreWebView2Async(null);
            wv_Web.CoreWebView2.WebMessageReceived += UpdateAddressBar;
            await wv_Web.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.location.href);");
        }

        void UpdateAddressBar(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            String uri = args.TryGetWebMessageAsString();
            tb_URL.Text = uri;
        }

        void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                wv_Web.CoreWebView2.ExecuteScriptAsync($"alert('{uri} is not safe, try an https link')");
                args.Cancel = true;
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            if (wv_Web != null && wv_Web.CoreWebView2 != null)
            {
                wv_Web.CoreWebView2.Navigate(tb_URL.Text);
            }
        }

        private async void btn_DownloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string url = tb_URL.Text;
                HttpClient client = new HttpClient();
                string html = await client.GetStringAsync(url);
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "HTML File|*.html";
                dialog.FileName = "download.html";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(dialog.FileName, html);
                    MessageBox.Show("Tai HTML thanh cong!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi tai HTML: " + ex.Message);
            }
        }

        private async void btn_DownloadResource_Click(object sender, EventArgs e)
        {
            try
            {
                string url = tb_URL.Text;
                using (HttpClient client = new HttpClient())
                {
                    string html = await client.GetStringAsync(url);
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);
                    var nodes = doc.DocumentNode.SelectNodes("//img[@src]");
                    if (nodes == null)
                    {
                        MessageBox.Show("Khong tim thay anh!");
                        return;
                    }
                    using FolderBrowserDialog fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() != DialogResult.OK) return;
                    string folder = fbd.SelectedPath;
                    foreach (var node in nodes)
                    {
                        string src = node.GetAttributeValue("src", "");
                        Uri baseUri = new Uri(url);
                        Uri fullUri = new Uri(baseUri, src);
                        byte[] data = await client.GetByteArrayAsync(fullUri);
                        string fileName = Path.GetFileName(fullUri.LocalPath);
                        string savePath = Path.Combine(folder, fileName);
                        File.WriteAllBytes(savePath, data);
                    }
                    MessageBox.Show("Tai anh xong!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi Download Resource: " + ex.Message);
            }
        }
    }
}
