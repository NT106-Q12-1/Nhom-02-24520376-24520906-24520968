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
    public partial class Form1 : Form
    {
        public class Movie
        {
            public string Title { get; set; }
            public string DetailUrl { get; set; }
            public string PosterUrl { get; set; }
        }

        private readonly HttpClient _http = new HttpClient();
        private List<Movie> _movies = new List<Movie>();
        private FlowLayoutPanel _flowPanel;

        private const string BaseUrl = "https://betacinemas.vn/phim.htm";

        public Form1()
        {
            InitializeComponent();
            InitUI();
            this.Load += Form1_Load;
        }

        // =================== UI SETUP ===========================
        private void InitUI()
        {
            this.BackColor = Color.FromArgb(244, 234, 230); // Nền hồng nhạt

            // ==== HEADER ====
            Label lblHeader = new Label
            {
                Text = "Phim Đang Chiếu",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(125, 80, 60),   // Nâu tím giống hình
                Height = 55,
                Padding = new Padding(10, 10, 0, 0)
            };
            Controls.Add(lblHeader);

            // ==== LEFT PANEL ====
            _flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Left,
                Width = 380,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.FromArgb(244, 234, 230), // nền hồng nhạt
            };
            Controls.Add(_flowPanel);

            pb_Progress.Dock = DockStyle.Bottom;
            wv_CinemaWeb.Dock = DockStyle.Fill;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await wv_CinemaWeb.EnsureCoreWebView2Async();
            await LoadMovies();
        }

        // ============== LOAD PHIM ====================
        private async Task LoadMovies()
        {
            try
            {
                string html = await _http.GetStringAsync(BaseUrl);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var nodes = doc.DocumentNode.SelectNodes("//a[contains(@href,'chi-tiet-phim')]");
                if (nodes == null)
                {
                    MessageBox.Show("Không tìm thấy danh sách phim.");
                    return;
                }

                pb_Progress.Maximum = nodes.Count;
                pb_Progress.Value = 0;

                foreach (var a in nodes)
                {
                    string link = a.GetAttributeValue("href", "");
                    if (link.StartsWith("/"))
                        link = "https://betacinemas.vn" + link;

                    var img = a.Descendants("img").FirstOrDefault();
                    string imgSrc = img?.GetAttributeValue("src", "");
                    string title = img?.GetAttributeValue("alt", "Không rõ");

                    Movie m = new Movie
                    {
                        Title = title,
                        PosterUrl = imgSrc,
                        DetailUrl = link
                    };

                    _movies.Add(m);
                    AddMovieTile(m);

                    pb_Progress.Value++;
                }

                if (_movies.Count > 0)
                    wv_CinemaWeb.CoreWebView2.Navigate(_movies[0].DetailUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // =================== ADD MOVIE TILE =====================
        private void AddMovieTile(Movie movie)
        {
            Panel item = new Panel
            {
                Width = _flowPanel.Width - 20,
                Height = 120,
                BackColor = Color.FromArgb(244, 234, 230), // Nền giống form
                Margin = new Padding(5, 0, 5, 0)
            };

            // đường line giống hình
            Panel line = new Panel
            {
                Height = 1,
                Dock = DockStyle.Bottom,
                BackColor = Color.FromArgb(210, 210, 210)
            };

            // Poster
            PictureBox pic = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(10, 10),
                Size = new Size(90, 100),
                Cursor = Cursors.Hand
            };
            _ = LoadImageAsync(movie.PosterUrl, pic);
            pic.Click += (s, e) => OpenMovie(movie.DetailUrl);

            // Title
            Label lblTitle = new Label
            {
                Text = movie.Title,
                Location = new Point(110, 10),
                AutoSize = false,
                Width = item.Width - 130,
                Height = 30,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(215, 115, 65), // Cam như hình
                Cursor = Cursors.Hand
            };
            lblTitle.Click += (s, e) => OpenMovie(movie.DetailUrl);

            // URL
            Label lblUrl = new Label
            {
                Text = movie.DetailUrl,
                Location = new Point(110, 50),
                AutoSize = false,
                Width = item.Width - 130,
                Height = 40,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(95, 95, 95),
                Cursor = Cursors.Hand
            };
            lblUrl.Click += (s, e) => OpenMovie(movie.DetailUrl);

            item.Controls.Add(pic);
            item.Controls.Add(lblTitle);
            item.Controls.Add(lblUrl);
            item.Controls.Add(line);

            _flowPanel.Controls.Add(item);
        }

        // ============== LOAD ẢNH ====================
        private async Task LoadImageAsync(string url, PictureBox pic)
        {
            try
            {
                byte[] data = await _http.GetByteArrayAsync(url);
                using var ms = new MemoryStream(data);
                pic.Image = Image.FromStream(ms);
            }
            catch { }
        }

        private void OpenMovie(string url)
        {
            if (wv_CinemaWeb.CoreWebView2 != null)
                wv_CinemaWeb.CoreWebView2.Navigate(url);
        }
    }
}