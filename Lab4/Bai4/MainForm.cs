using HtmlAgilityPack;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4
{
    public class Movie
    {
        public string Title { get; set; }
        public string DetailUrl { get; set; }
        public string PosterUrl { get; set; }
    }

    public class MainForm : Form
    {
        private const string BaseUrl = "https://betacinemas.vn/phim.htm";
        private const string JsonFileName = "movies.json";

        private readonly HttpClient _http = new HttpClient();
        private List<Movie> _movies = new List<Movie>();

        private FlowLayoutPanel _flowPanel;
        private ProgressBar pb_Progress;
        private WebView2 wv_CinemaWeb;
        private Panel leftPanel;

        public MainForm()
        {
            Text = "Quản lý phòng vé - Bài 4";
            Width = 950;
            Height = 720;
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 9);

            InitUI();
            Load += MainForm_Load;
        }

        private void InitUI()
        {
            BackColor = Color.FromArgb(244, 234, 230);
            Padding = new Padding(0);

            // Header
            Label lblHeader = new Label
            {
                Text = "Phim Đang Chiếu",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(125, 80, 60),
                Height = 60,
                Padding = new Padding(12, 8, 0, 0)
            };
            Controls.Add(lblHeader);

            // Left panel: contains flowpanel and progressbar
            leftPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 420,
                BackColor = Color.FromArgb(244, 234, 230),
                Padding = new Padding(10, 8, 8, 8)
            };
            Controls.Add(leftPanel);

            _flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.FromArgb(244, 234, 230)
            };
            leftPanel.Controls.Add(_flowPanel);

            pb_Progress = new ProgressBar
            {
                Dock = DockStyle.Bottom,
                Height = 18,
                MarqueeAnimationSpeed = 0
            };
            leftPanel.Controls.Add(pb_Progress);

            // Right: WebView2
            wv_CinemaWeb = new WebView2
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(wv_CinemaWeb);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                await wv_CinemaWeb.EnsureCoreWebView2Async();
            }
            catch { /* ignore if webview init delayed */ }

            // If JSON exists, load from file first (fast)
            if (File.Exists(JsonFileName))
            {
                try
                {
                    string json = File.ReadAllText(JsonFileName);
                    var loaded = JsonSerializer.Deserialize<List<Movie>>(json);
                    if (loaded != null && loaded.Count > 0)
                    {
                        _movies = loaded;
                        foreach (var m in _movies) AddMovieTile(m);
                        // Navigate first if any
                        if (_movies.Count > 0 && wv_CinemaWeb.CoreWebView2 != null)
                            wv_CinemaWeb.CoreWebView2.Navigate(_movies[0].DetailUrl);
                    }
                }
                catch { /* ignore read errors, fall back to scraping */ }
            }

            // Always try to refresh from web (user wants latest)
            await LoadMoviesFromWeb();
        }

        private async Task LoadMoviesFromWeb()
        {
            try
            {
                string html = await _http.GetStringAsync(BaseUrl);
                var doc = new HtmlAgilityPack.HtmlDocument(); doc.LoadHtml(html);

                var nodes = doc.DocumentNode.SelectNodes("//a[contains(@href,'chi-tiet-phim')]");
                if (nodes == null)
                {
                    MessageBox.Show("Không tìm thấy danh sách phim trên website.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _movies.Clear();
                _flowPanel.Controls.Clear();

                pb_Progress.Maximum = nodes.Count;
                pb_Progress.Value = 0;

                foreach (var a in nodes)
                {
                    string link = a.GetAttributeValue("href", "");
                    if (string.IsNullOrEmpty(link)) continue;
                    if (link.StartsWith("/")) link = "https://betacinemas.vn" + link;

                    var img = a.Descendants("img").FirstOrDefault();
                    string imgSrc = img?.GetAttributeValue("src", "");
                    // Some img src is relative
                    if (!string.IsNullOrEmpty(imgSrc) && imgSrc.StartsWith("/"))
                        imgSrc = "https://betacinemas.vn" + imgSrc;

                    string title = img?.GetAttributeValue("alt", "Không rõ");

                    Movie m = new Movie { Title = title, PosterUrl = imgSrc ?? "", DetailUrl = link };
                    _movies.Add(m);
                    AddMovieTile(m);

                    pb_Progress.Value = Math.Min(pb_Progress.Maximum, pb_Progress.Value + 1);
                    await Task.Delay(20); // small yield for UI
                }

                // Save to JSON
                try
                {
                    var opts = new JsonSerializerOptions { WriteIndented = true };
                    string json = JsonSerializer.Serialize(_movies, opts);
                    File.WriteAllText(JsonFileName, json);
                }
                catch { }

                if (_movies.Count > 0 && wv_CinemaWeb.CoreWebView2 != null)
                    wv_CinemaWeb.CoreWebView2.Navigate(_movies[0].DetailUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pb_Progress.Value = 0;
            }
        }

        private async Task LoadImageAsync(string url, PictureBox pic)
        {
            if (string.IsNullOrEmpty(url)) return;
            try
            {
                byte[] data = await _http.GetByteArrayAsync(url);
                using var ms = new MemoryStream(data);
                var img = Image.FromStream(ms);
                pic.Image = img;
            }
            catch { /* ignore image failures */ }
        }

        private void AddMovieTile(Movie movie)
        {
            Panel item = new Panel
            {
                Width = _flowPanel.ClientSize.Width - 25,
                Height = 125,
                BackColor = Color.FromArgb(244, 234, 230),
                Margin = new Padding(0, 4, 0, 4)
            };

            // bottom line
            Panel line = new Panel
            {
                Height = 1,
                Dock = DockStyle.Bottom,
                BackColor = Color.FromArgb(200, 200, 200)
            };

            // poster
            PictureBox pic = new PictureBox
            {
                Location = new Point(8, 8),
                Size = new Size(82, 104),
                SizeMode = PictureBoxSizeMode.Zoom,
                Cursor = Cursors.Hand,
                BorderStyle = BorderStyle.FixedSingle
            };
            _ = LoadImageAsync(movie.PosterUrl, pic);
            pic.Click += (s, e) => OpenMovie(movie.DetailUrl);
            item.Controls.Add(pic);

            // Title label
            Label lblTitle = new Label
            {
                Text = movie.Title,
                Location = new Point(100, 8),
                AutoSize = false,
                Width = item.Width - 210,
                Height = 44,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(215, 115, 65),
                Cursor = Cursors.Hand
            };
            lblTitle.Click += (s, e) => OpenMovie(movie.DetailUrl);
            item.Controls.Add(lblTitle);

            // Url label (small)
            Label lblUrl = new Label
            {
                Text = movie.DetailUrl,
                Location = new Point(100, 56),
                AutoSize = false,
                Width = item.Width - 210,
                Height = 44,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(95, 95, 95),
                Cursor = Cursors.Hand
            };
            lblUrl.Click += (s, e) => OpenMovie(movie.DetailUrl);
            item.Controls.Add(lblUrl);

            // Button Đặt vé
            Button btnBook = new Button
            {
                Text = "Đặt vé",
                Location = new Point(item.Width - 95, 36),
                Size = new Size(80, 32),
                BackColor = Color.FromArgb(58, 142, 91),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnBook.FlatAppearance.BorderSize = 0;
            btnBook.Click += (s, e) =>
            {
                // Open booking form
                var booking = new BookingForm(movie);
                if (booking.ShowDialog(this) == DialogResult.OK)
                {
                    // Show confirmation (already shown in booking), optional: log sale
                }
            };
            item.Controls.Add(btnBook);

            // hover effect
            item.MouseEnter += (s, e) => item.BackColor = Color.FromArgb(255, 248, 244);
            item.MouseLeave += (s, e) => item.BackColor = Color.FromArgb(244, 234, 230);

            item.Controls.Add(line);
            _flowPanel.Controls.Add(item);
        }

        private void OpenMovie(string url)
        {
            if (string.IsNullOrEmpty(url)) return;
            if (wv_CinemaWeb.CoreWebView2 != null)
                wv_CinemaWeb.CoreWebView2.Navigate(url);
            else
            {
                // If not ready, try to init
                _ = wv_CinemaWeb.EnsureCoreWebView2Async().ContinueWith(t =>
                {
                    if (wv_CinemaWeb.CoreWebView2 != null)
                        wv_CinemaWeb.CoreWebView2.Navigate(url);
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
    }
}