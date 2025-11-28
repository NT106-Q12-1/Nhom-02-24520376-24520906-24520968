using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Bai4
{
    public class BookingForm : Form
    {
        private Movie _movie;
        private NumericUpDown nudQuantity;
        private TextBox txtCustomer;
        private Label lblTotal;
        private ComboBox cbPrice;

        public BookingForm(Movie movie)
        {
            _movie = movie;
            Text = "Đặt vé - " + movie.Title;
            Width = 420;
            Height = 320;
            StartPosition = FormStartPosition.CenterParent;
            Font = new Font("Segoe UI", 9);

            InitUI();
        }

        private void InitUI()
        {
            var p = new Padding(12);

            Label lblMovie = new Label
            {
                Text = "Phim:",
                Location = new Point(12, 18),
                AutoSize = true
            };
            Controls.Add(lblMovie);

            Label lblMovieVal = new Label
            {
                Text = _movie.Title,
                Location = new Point(100, 18),
                AutoSize = false,
                Width = 280,
                Height = 36,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            Controls.Add(lblMovieVal);

            Label lblPrice = new Label { Text = "Giá vé (VNĐ):", Location = new Point(12, 70), AutoSize = true };
            Controls.Add(lblPrice);

            cbPrice = new ComboBox
            {
                Location = new Point(100, 66),
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            // some sample prices
            cbPrice.Items.Add("55000");
            cbPrice.Items.Add("70000");
            cbPrice.Items.Add("90000");
            cbPrice.SelectedIndex = 0;
            cbPrice.SelectedIndexChanged += Recalc;
            Controls.Add(cbPrice);

            Label lblQty = new Label { Text = "Số vé:", Location = new Point(12, 110), AutoSize = true };
            Controls.Add(lblQty);

            nudQuantity = new NumericUpDown { Location = new Point(100, 106), Width = 80, Minimum = 1, Maximum = 20, Value = 1 };
            nudQuantity.ValueChanged += Recalc;
            Controls.Add(nudQuantity);

            Label lblCustomer = new Label { Text = "Khách hàng:", Location = new Point(12, 150), AutoSize = true };
            Controls.Add(lblCustomer);

            txtCustomer = new TextBox { Location = new Point(100, 146), Width = 270 };
            Controls.Add(txtCustomer);

            Label lblTotalText = new Label { Text = "Tổng tiền:", Location = new Point(12, 190), AutoSize = true };
            Controls.Add(lblTotalText);

            lblTotal = new Label { Text = "0 VNĐ", Location = new Point(100, 190), AutoSize = false, Width = 200, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            Controls.Add(lblTotal);

            Button btnConfirm = new Button { Text = "Xác nhận", Location = new Point(220, 230), Size = new Size(110, 34), BackColor = Color.FromArgb(58, 142, 91), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.Click += BtnConfirm_Click;
            Controls.Add(btnConfirm);

            Button btnCancel = new Button { Text = "Hủy", Location = new Point(90, 230), Size = new Size(110, 34) };
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
            Controls.Add(btnCancel);

            Recalc(null, null);
        }

        private void Recalc(object sender, EventArgs e)
        {
            if (!int.TryParse(cbPrice.SelectedItem?.ToString() ?? "0", out int price)) price = 0;
            int qty = (int)nudQuantity.Value;
            long total = (long)price * qty;
            lblTotal.Text = total.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            string customer = txtCustomer.Text.Trim();
            if (string.IsNullOrEmpty(customer))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cbPrice.SelectedItem?.ToString() ?? "0", out int price)) price = 0;
            int qty = (int)nudQuantity.Value;
            long total = (long)price * qty;

            string msg =
                $"Khách hàng: {customer}\n" +
                $"Phim: {_movie.Title}\n" +
                $"Số vé: {qty}\n" +
                $"Giá vé: {price.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"))} VNĐ\n" +
                $"Tổng tiền: {total.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"))} VNĐ\n\n" +
                "Xác nhận đặt vé?";

            var dr = MessageBox.Show(msg, "Xác nhận đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // Here you could save transaction to file / DB. For demo we'll show success.
                MessageBox.Show("Đặt vé thành công!\n" + msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
        }
    }
}