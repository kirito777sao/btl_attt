using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATTT
{
    public partial class Affine : Form
    {
        public Affine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string plainText = txtInput.Text;

            // Kiểm tra và xử lý khóa a
            if (!int.TryParse(txtKeyA.Text, out int a))
            {
                MessageBox.Show("Vui lòng nhập khóa a hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra và xử lý khóa b
            if (!int.TryParse(txtKeyB.Text, out int b))
            {
                MessageBox.Show("Vui lòng nhập khóa b hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xử lý trường hợp khóa âm hoặc quá lớn
            a = NormalizeKey(a);
            b = NormalizeKey(b);

            // Kiểm tra điều kiện a và n(26) phải có ước số chung là 1
            int n = 26;
            if (UCLN(a, n) != 1)
            {
                MessageBox.Show("a và n(26) phải có ước số chung là 1.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mã hóa
            string cipherText = Encode(plainText, a, b);
            txtOutput.Text = cipherText;

            // Hiển thị bảng tính a^-1
            txtExtendedEuclidean.Text = GetExtendedEuclideanTable(a, n);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cipherText = txtInput.Text;

            // Kiểm tra và xử lý khóa a
            if (!int.TryParse(txtKeyA.Text, out int a))
            {
                MessageBox.Show("Vui lòng nhập khóa a hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra và xử lý khóa b
            if (!int.TryParse(txtKeyB.Text, out int b))
            {
                MessageBox.Show("Vui lòng nhập khóa b hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xử lý trường hợp khóa âm hoặc quá lớn
            a = NormalizeKey(a);
            b = NormalizeKey(b);

            // Kiểm tra điều kiện a và n(26) phải có ước số chung là 1
            int n = 26;
            if (UCLN(a, n) != 1)
            {
                MessageBox.Show("a và n(26) phải có ước số chung là 1.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Giải mã
            string plainText = Decode(cipherText, a, b);
            txtOutput.Text = plainText;

            // Hiển thị bảng tính a^-1
            txtExtendedEuclidean.Text = GetExtendedEuclideanTable(a, n);        
        }

        // Hàm chuẩn hóa khóa
        private int NormalizeKey(int key)
        {
            if (key < 0)
            {
                return key % 26 + 26; // Chuyển về khóa dương tương đương
            }
            else if (key > 26)
            {
                return key % 26; // Chuyển về khóa trong khoảng 0-25
            }
            return key;
        }

        // Hàm mã hóa Affine
        public static string Encode(string plainText, int a, int b)
        {
            StringBuilder cipherText = new StringBuilder();
            foreach (char ch in plainText)
            {
                if (char.IsLetter(ch))
                {
                    // Chuyển chữ cái sang số theo bảng chữ cái (A=0, B=1, ..., Z=25)
                    int charCode = char.ToLower(ch) - 'a';
                    // Áp dụng công thức mã hóa Affine
                    int encodedCharCode = ((a % 26) * charCode + (b % 26)) % 26;
                    // Chuyển số về chữ cái
                    char encodedChar = (char)(encodedCharCode + 'a');
                    cipherText.Append(encodedChar);
                }
                else
                {
                    // Giữ nguyên các kí tự không phải chữ cái
                    cipherText.Append(ch);
                }
            }
            return cipherText.ToString();
        }

        // Hàm giải mã Affine
        public static string Decode(string cipherText, int a, int b)
        {
            // Tìm a^-1 bằng thuật toán Euclid mở rộng
            int aInverse = ExtendedEuclidean(a, 26);
            StringBuilder plainText = new StringBuilder();
            foreach (char ch in cipherText)
            {
                if (char.IsLetter(ch))
                {
                    // Chuyển chữ cái sang số theo bảng chữ cái (A=0, B=1, ..., Z=25)
                    int charCode = char.ToLower(ch) - 'a';
                    // Áp dụng công thức giải mã Affine
                    int decodedCharCode = (aInverse * (charCode - b + 26)) % 26;
                    // Chuyển số về chữ cái
                    char decodedChar = (char)(decodedCharCode + 'a');
                    plainText.Append(decodedChar);
                }
                else
                {
                    // Giữ nguyên các kí tự không phải chữ cái
                    plainText.Append(ch);
                }
            }
            return plainText.ToString();
        }

        // Hàm tìm ước số chung
        public static int UCLN(int a, int b)
        {
            if (b == 0) return a;
            return UCLN(b, a % b);
        }

        // Thuật toán Euclid mở rộng để tìm a^-1
        public static int ExtendedEuclidean(int a, int n)
        {
            int r1 = n, r2 = a, t1 = 0, t2 = 1;
            int q, r, t;
            while (r2 > 0)
            {
                q = r1 / r2;
                r = r1 - q * r2;
                t = t1 - q * t2;
                r1 = r2;
                r2 = r;
                t1 = t2;
                t2 = t;
            }
            // Khi r2 = 0, t1 chính là a^-1
            return (t1 % n + n) % n;
        }

        // Lấy bảng tính thu ật toán Euclid mở rộng
        public static string GetExtendedEuclideanTable(int a, int n)
        {
            StringBuilder table = new StringBuilder();
            int r1 = n, r2 = a, t1 = 0, t2 = 1;
            int q, r, t;
            table.AppendLine("q\tr1\tr2\tr\tt1\tt2\tt");
            table.AppendLine("-------------------------------------------------------");
            while (r2 > 0)
            {
                q = r1 / r2;
                r = r1 - q * r2;
                t = t1 - q * t2;
                table.AppendLine($"{q}\t{r1}\t{r2}\t{r}\t{t1}\t{t2}\t{t}");
                r1 = r2;
                r2 = r;
                t1 = t2;
                t2 = t;
            }
            table.AppendLine($"a^-1 = {(t1 % n + n) % n}");
            return table.ToString();
        }
    }
}
