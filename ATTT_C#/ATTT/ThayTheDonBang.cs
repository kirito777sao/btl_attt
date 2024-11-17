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
    public partial class ThayTheDonBang : Form
    {
        public ThayTheDonBang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (thucthi_thaythe.SelectedItem.Equals("Mã hóa"))
            {
                string key = txtKey.Text.ToUpper();
                string inputText = txtInput.Text;

                // Kiểm tra tính hợp lệ của khóa
                if (!IsValidKey(key))
                {
                    MessageBox.Show("Khóa không hợp lệ. Khóa phải chứa 26 ký tự chữ cái khác nhau.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mã hóa văn bản
                string encodedText = Encode(inputText, key.ToCharArray());
                txtOutput.Text = encodedText;
            }
            else if (thucthi_thaythe.SelectedItem.Equals("Giải mã"))
            {
                string key = txtKey.Text.ToUpper();
                string inputText = txtInput.Text;

                // Kiểm tra tính hợp lệ của khóa
                if (!IsValidKey(key))
                {
                    MessageBox.Show("Khóa không hợp lệ. Khóa phải chứa 26 ký tự chữ cái khác nhau.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Giải mã văn bản
                string decodedText = Decode(inputText, key.ToCharArray());
                txtOutput.Text = decodedText;
            }
        }

                // Hàm kiểm tra tính hợp lệ của khóa
                public static bool IsValidKey(string key)
        {
            // Kiểm tra độ dài khóa
            if (key.Length != 26)
            {
                return false;
            }

            // Kiểm tra các ký tự có phải là chữ cái không
            if (!key.All(char.IsLetter))
            {
                return false;
            }

            // Kiểm tra các ký tự có bị trùng lặp không
            return key.Distinct().Count() == 26;
        }

        // Hàm mã hóa
        public static string Encode(string text, char[] keyArray)
        {
            StringBuilder encodedText = new StringBuilder();

            foreach (char ch in text)
            {
                if (char.IsLetter(ch))
                {
                    // Chuyển chữ cái thành chữ hoa
                    char upperCh = char.ToUpper(ch);
                    // Tìm vị trí của chữ cái trong bảng chữ cái
                    int index = upperCh - 'A';
                    // Mã hóa chữ cái bằng ký tự trong khóa
                    encodedText.Append(keyArray[index]);
                }
                else
                {
                    // Giữ nguyên các ký tự không phải chữ cái
                    encodedText.Append(ch);
                }
            }

            return encodedText.ToString();
        }

        // Hàm giải mã
        public static string Decode(string text, char[] keyArray)
        {
            StringBuilder decodedText = new StringBuilder();

            foreach (char ch in text)
            {
                if (char.IsLetter(ch))
                {
                    // Chuyển chữ cái thành chữ hoa
                    char upperCh = char.ToUpper(ch);
                    // Tìm vị trí của chữ cái trong khóa
                    int index = Array.IndexOf(keyArray, upperCh);
                    // Giải mã chữ cái bằng ký tự trong bảng chữ cái
                    decodedText.Append((char)('A' + index));
                }
                else
                {
                    // Giữ nguyên các ký tự không phải chữ cái
                    decodedText.Append(ch);
                }
            }

            return decodedText.ToString();
        }
    }
}
