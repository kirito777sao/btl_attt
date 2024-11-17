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
    public partial class Caesar : Form
    {
        public Caesar()
        {
            InitializeComponent();
        }

        private void check_caesar_Click(object sender, EventArgs e)
        {
            if (thucthi_caesar.SelectedItem.Equals("Mã hóa"))
            {
                string plainText = txtInput.Text;


                if (!int.TryParse(txtKey.Text, out int key))
                {
                    MessageBox.Show("Vui lòng nhập khóa hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (key < 0)
                {
                    key = key % 26 + 26; 
                }
                else if (key > 26)
                {
                    key = key % 26; // Chuyển về khóa trong khoảng 0-25
                }

                // Mã hóa
                string cipherText = Encrypt(plainText, key);
                txtOutput.Text = cipherText;
            }

            else if (thucthi_caesar.SelectedItem.Equals("Giải mã"))
            {
                string cipherText = txtInput.Text;

                // Kiểm tra và xử lý khóa
                if (!int.TryParse(txtKey.Text, out int key))
                {
                    MessageBox.Show("Vui lòng nhập khóa hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xử lý trường hợp khóa âm hoặc quá lớn
                if (key < 0)
                {
                    key = key % 26 + 26; // Chuyển về khóa dương tương đương
                }
                else if (key > 26)
                {
                    key = key % 26; // Chuyển về khóa trong khoảng 0-25
                }

                // Giải mã
                string plainText = Decrypt(cipherText, key);
                txtOutput.Text = plainText;
            }          
        }
        public static string Encrypt(string plainText, int key)
        {
            string cipherText = "";

            foreach (char character in plainText)
            {
                if (char.IsLetter(character))
                {
                    bool isUpperCase = char.IsUpper(character);
                    char loweredChar = char.ToLower(character);
                    int charIndex = loweredChar - 'a';
                    int encryptedIndex = (charIndex + key) % 26;
                    char encryptedChar = (char)(encryptedIndex + 'a');

                    if (isUpperCase)
                    {
                        encryptedChar = char.ToUpper(encryptedChar);
                    }

                    cipherText += encryptedChar;
                }
                else
                {
                    cipherText += character;
                }
            }

            return cipherText;
        }

        public static string Decrypt(string cipherText, int key)
        {
            string plainText = "";

            foreach (char character in cipherText)
            {
                if (char.IsLetter(character))
                {
                    bool isUpperCase = char.IsUpper(character);
                    char loweredChar = char.ToLower(character);
                    int charIndex = loweredChar - 'a';
                    int decryptedIndex = (charIndex - key + 26) % 26;
                    char decryptedChar = (char)(decryptedIndex + 'a');

                    if (isUpperCase)
                    {
                        decryptedChar = char.ToUpper(decryptedChar);
                    }

                    plainText += decryptedChar;
                }
                else
                {
                    plainText += character;
                }
            }

            return plainText;
        }
    }
}
