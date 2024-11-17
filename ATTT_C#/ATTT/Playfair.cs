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
    public partial class Playfair : Form
    {
        public Playfair()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbpp.SelectedItem.Equals("Mã hóa"))
            {
                string plainText = txtInput.Text.ToUpper().Replace("J", "I");
                string key = txtKey.Text.ToUpper().Replace("J", "I");

                // Loại bỏ ký tự trùng lặp trong khóa
                key = RemoveDuplicateChars(key);

                // Chèn "X" vào giữa các cặp chữ cái lặp lại
                plainText = InsertXForDuplicates(plainText);

                char[,] matrix = CreateMatrix(key);

                // Hiển thị ma trận khóa
                richTextBox1.Text = GetMatrixString(matrix);

                string cipherText = Encrypt(plainText, matrix);
                txtOutput.Text = cipherText;
            }
            else if (cbpp.SelectedItem.Equals("Giải mã"))
            {
                string cipherText = txtInput.Text.ToUpper().Replace("J", "I");
                string key = txtKey.Text.ToUpper().Replace("J", "I");

                // Loại bỏ ký tự trùng lặp trong khóa
                key = RemoveDuplicateChars(key);

                char[,] matrix = CreateMatrix(key);

                string decryptedText = Decrypt(cipherText, matrix);
                txtOutput.Text = decryptedText;
            }
        }

        // Lấy chuỗi biểu diễn ma trận
        private static string GetMatrixString(char[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sb.Append(matrix[i, j]).Append(" ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        // Tìm vị trí của ký tự trong ma trận
        private static int[] FindPosition(char[,] matrix, char character)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] == character)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            throw new Exception($"Không tìm thấy ký tự '{character}' trong ma trận.");
        }

        // Chèn "X" vào giữa các cặp chữ cái lặp lại
        private static string InsertXForDuplicates(string plainText)
        {
            StringBuilder sb = new StringBuilder(plainText);

            for (int i = 0; i < sb.Length - 1; i += 2)
            {
                char char1 = sb[i];
                char char2 = sb[i + 1];
                if (char1 == char2)
                {
                    sb.Insert(i + 1, 'X');
                }
            }

            if (sb.Length % 2 != 0)
            {
                sb.Append('X');
            }
            return sb.ToString();
        }

        // Mã hóa Playfair
        public static string Encrypt(string plainText, char[,] matrix)
        {
            string originalPlainText = plainText;
            plainText = System.Text.RegularExpressions.Regex.Replace(plainText, @"[^A-Z]", "");

            StringBuilder numbersAndSymbols = new StringBuilder();
            for (int i = 0; i < originalPlainText.Length; i++)
            {
                if (!char.IsLetter(originalPlainText[i]))
                {
                    numbersAndSymbols.Append(originalPlainText[i]);
                }
            }

            string cipherText = "";

            for (int i = 0; i < plainText.Length; i += 2)
            {
                char char1 = plainText[i];
                char char2 = (i + 1 < plainText.Length) ? plainText[i + 1] : 'X';

                int[] pos1 = FindPosition(matrix, char1);
                int[] pos2 = FindPosition(matrix, char2);

                if (pos1[0] == pos2[0]) // Cùng hàng
                {
                    cipherText += matrix[pos1[0], (pos1[1] + 1) % 5];
                    cipherText += matrix[pos2[0], (pos2[1] + 1) % 5];
                }
                else if (pos1[1] == pos2[1]) // Cùng cột
                {
                    cipherText += matrix[(pos1[0] + 1) % 5, pos1[1]];
                    cipherText += matrix[(pos2[0] + 1) % 5, pos2[1]];
                }
                else // Khác hàng, khác cột
                {
                    cipherText += matrix[pos1[0], pos2[1]];
                    cipherText += matrix[pos2[0], pos1[1]];
                }
            }

            // Thêm lại số và ký tự đặc biệt vào bản mã
            int j = 0, k = 0;
            while (j < numbersAndSymbols.Length)
            {
                if (k < cipherText.Length && char.IsLetter(cipherText[k]))
                {
                    k++;
                }
                else
                {
                    cipherText = cipherText.Insert(k, numbersAndSymbols[j].ToString());
                    k++;
                    j++;
                }
            }

            return cipherText;
        }

        // Giải mã Playfair
        public static string Decrypt(string cipherText, char[,] matrix)
        {
            StringBuilder numbersAndSymbols = new StringBuilder();
            for (int i = 0; i < cipherText.Length; i++)
            {
                if (!char.IsLetter(cipherText[i]))
                {
                    numbersAndSymbols.Append(cipherText[i]);
                    cipherText = cipherText.Remove(i, 1);
                    i--;
                }
            }

            string decryptedText = "";

            for (int i = 0; i < cipherText.Length; i += 2)
            {
                char char1 = cipherText[i];
                char char2 = cipherText[i + 1];

                int[] pos1 = FindPosition(matrix, char1);
                int[] pos2 = FindPosition(matrix, char2);

                if (pos1[0] == pos2[0]) // Cùng hàng
                {
                    decryptedText += matrix[pos1[0], (pos1[1] - 1 + 5) % 5];
                    decryptedText += matrix[pos2[0], (pos2[1] - 1 + 5) % 5];
                }
                else if (pos1[1] == pos2[1]) // Cùng cột
                {
                    decryptedText += matrix[(pos1[0] - 1 + 5) % 5, pos1[1]];
                    decryptedText += matrix[(pos2[0] - 1 + 5) % 5, pos2[1]];
                }
                else // Khác hàng, khác cột
                {
                    decryptedText += matrix[pos1[0], pos2[1]];
                    decryptedText += matrix[pos2[0], pos1[1]];
                }
            }

            // Thêm lại số và ký tự đặc biệt vào bản giải mã
            int j = 0, k = 0;
            while (j < numbersAndSymbols.Length)
            {
                if (k < decryptedText.Length && char.IsLetter(decryptedText[k]))
                {
                    k++;
                }
                else
                {
                    decryptedText = decryptedText.Insert(k, numbersAndSymbols[j].ToString());
                    k++;
                    j++;
                }
            }

            return decryptedText;
        }

        // Tạo ma trận Playfair
        private static char[,] CreateMatrix(string key)
        {
            char[,] matrix = new char[5, 5];
            string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ"; // Bảng chữ cái
            int index = 0;

            // Thêm khóa vào ma trận
            for (int i = 0; i < key.Length; i++)
            {
                if (!char.IsWhiteSpace(key[i]) && !Contains(matrix, key[i]))
                {
                    matrix[index / 5, index % 5] = key[i];
                    index++;
                }
            }

            // Thêm các chữ cái còn lại vào ma trận
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (!char.IsWhiteSpace(alphabet[i]) && !Contains(matrix, alphabet[i]))
                {
                    matrix[index / 5, index % 5] = alphabet[i];
                    index++;
                }
            }

            return matrix;
        }

        // Kiểm tra xem một ký tự có tồn tại trong ma trận hay không
        private static bool Contains(char[,] matrix, char character)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] == character)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Loại bỏ ký tự trùng lặp trong khóa
        private static string RemoveDuplicateChars(string key)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < key.Length; i++)
            {
                if (!sb.ToString().Contains(key[i].ToString()))
                {
                    sb.Append(key[i]);
                }
            }
            return sb.ToString();
        }
    }
}
