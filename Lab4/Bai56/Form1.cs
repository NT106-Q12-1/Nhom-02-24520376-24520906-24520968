using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Bai56
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tb_URL.Text = "https://nt106.uitiot.vn/auth/token";
        }

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            string url = tb_URL.Text;
            string username = tb_Username.Text;
            string password = tb_Password.Text;
            if (string.IsNullOrWhiteSpace(url) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui long nhap URL, Username va Password!");
                return;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new MultipartFormDataContent
                    {
                        { new StringContent(username), "username" },
                        { new StringContent(password), "password" }
                    };

                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    var responseObject = JObject.Parse(responseString);

                    if (!response.IsSuccessStatusCode)
                    {
                        string detail = responseObject["detail"]?.ToString();
                        richTextBox1.Text = "Đang nhap that bai!\nDetail: " + detail;
                        return;
                    }

                    string tokenType = responseObject["token_type"]?.ToString();
                    string accessToken = responseObject["access_token"]?.ToString();

                    richTextBox1.Text =
                        "Đang nhap thanh cong!\n\n" +
                        $"Token Type: {tokenType}\n" +
                        $"Access Token: {accessToken}\n\n";

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                    var getUserUrl = "https://nt106.uitiot.vn/api/v1/user/me";
                    var getUserResponse = await client.GetAsync(getUserUrl);
                    var getUserString = await getUserResponse.Content.ReadAsStringAsync();

                    richTextBox1.AppendText("User Info:\n" + getUserString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ket noi: " + ex.Message);
            }
        }
    }
}
