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
    public partial class Vegenere : Form
    {
        public Vegenere()
        {
            InitializeComponent();
        }

        private void btn_mh_Click(object sender, EventArgs e)
        {
            // Lấy văn bản và khóa, chuyển thành chữ in hoa
            string plainText = txtInput.Text.ToUpper();
            string key = txtKey.Text.ToUpper();

            // Kiểm tra khóa
            if (string.IsNullOrWhiteSpace(key))
            {
                MessageBox.Show("Vui lòng nhập khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mã hóa văn bản
            string cipherText = Encrypt(plainText, key);
            txtOutput.Text = cipherText;
        }

        private void btn_gm_Click(object sender, EventArgs e)
        {
            // Lấy văn bản và khóa, chuyển thành chữ in hoa
            string cipherText = txtInput.Text.ToUpper();
            string key = txtKey.Text.ToUpper();

            // Kiểm tra khóa
            if (string.IsNullOrWhiteSpace(key))
            {
                MessageBox.Show("Vui lòng nhập khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Giải mã văn bản
            string decryptedText = Decrypt(cipherText, key);
            txtOutput.Text = decryptedText;
        }

        // Hàm mã hóa Vigenère
        public static string Encrypt(string plainText, string key)
        {
            StringBuilder cipherText = new StringBuilder();
            int keyIndex = 0;

            foreach (char plainChar in plainText)
            {
                if (char.IsLetter(plainChar))
                {
                    // Tìm vị trí của ký tự trong bảng chữ cái
                    int plainCharIndex = plainChar - 'A';
                    int keyCharIndex = key[keyIndex] - 'A';

                    // Thực hiện mã hóa Vigenère
                    int cipherCharIndex = (plainCharIndex + keyCharIndex) % 26;
                    char cipherChar = (char)(cipherCharIndex + 'A');
                    cipherText.Append(cipherChar);

                    // Di chuyển đến ký tự tiếp theo trong khóa
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    // Giữ nguyên ký tự không phải chữ cái
                    cipherText.Append(plainChar);
                }
            }

            return cipherText.ToString();
        }

        // Hàm giải mã Vigenère
        public static string Decrypt(string cipherText, string key)
        {
            StringBuilder decryptedText = new StringBuilder();
            int keyIndex = 0;

            foreach (char cipherChar in cipherText)
            {
                if (char.IsLetter(cipherChar))
                {
                    // Tìm vị trí của ký tự trong bảng chữ cái
                    int cipherCharIndex = cipherChar - 'A';
                    int keyCharIndex = key[keyIndex] - 'A';

                    // Thực hiện giải mã Vigenère
                    int decryptedCharIndex = (cipherCharIndex - keyCharIndex + 26) % 26;
                    char decryptedChar = (char)(decryptedCharIndex + 'A');
                    decryptedText.Append(decryptedChar);

                    // Di chuyển đến ký tự tiếp theo trong khóa
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    // Giữ nguyên ký tự không phải chữ cái
                    decryptedText.Append(cipherChar);
                }
            }

            return decryptedText.ToString();
        }
    }
}
