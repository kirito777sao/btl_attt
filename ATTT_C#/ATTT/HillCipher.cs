using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATTT
{
    public partial class HillCipher : Form
    {
        private const int MOD = 26;
        public HillCipher()
        {
            InitializeComponent();
        }

        private void HillCipher_Load(object sender, EventArgs e)
        {

        }        

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string plaintext = txtInput.Text;
                int m = int.Parse(txtKeySize.Text);
                int[,] key = ParseKeyMatrix(m);

                int del = Determinant(key);
                int delInv = ModInverse(del, MOD);
                int delMod = del % MOD;

                if (del == 0 || delInv == 0)
                {
                    MessageBox.Show("Ma trận khóa không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string ciphertext = Encrypt(plaintext, key);
                txtOutput.Text = ciphertext;


                MessageBox.Show($"del = {del}\ndel^-1 = {delInv}\ndel % 26 = {delMod}", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string ciphertext = txtInput.Text;
                int m = int.Parse(txtKeySize.Text);
                int[,] key = ParseKeyMatrix(m);

                int del = Determinant(key);
                int delInv = ModInverse(del, MOD);
                int delMod = del % MOD;

                if (del == 0 || delInv == 0)
                {
                    MessageBox.Show("Ma trận khóa không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string plaintext = Decrypt(ciphertext, key);
                txtOutput.Text = plaintext;


                MessageBox.Show($"del = {del}\ndel^-1 = {delInv}\ndel % 26 = {delMod}", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int[,] ParseKeyMatrix(int m)
        {
            string[] rows = txtKeyMatrix.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int[,] key = new int[m, m];

            for (int i = 0; i < m; i++)
            {
                string[] cols = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                {
                    key[i, j] = int.Parse(cols[j]);
                }
            }
            return key;
        }

        public static string Encrypt(string plaintext, int[,] key)
        {
            int m = key.GetLength(0);
            plaintext = plaintext.ToUpper();

 
            char[] specialChars = new char[plaintext.Length];
            int[] specialCharPositions = new int[plaintext.Length];
            int specialCharCount = 0;

            string plain = "";

            for (int i = 0; i < plaintext.Length; i++)
            {
                char c = plaintext[i];
                if (char.IsLetter(c))
                {
                    plain += c;
                }
                else
                {
                    specialChars[specialCharCount] = c;
                    specialCharPositions[specialCharCount++] = i;
                }
            }


            while (plain.Length % m != 0)
            {
                plain += 'X';
            }

            int[] digitizedPlaintext = new int[plain.Length];
            for (int i = 0; i < plain.Length; i++)
            {
                digitizedPlaintext[i] = plain[i] - 'A';
            }

            int[] ciphertext = new int[plain.Length];
            for (int i = 0; i < plain.Length; i += m)
            {
                int[,] vector = new int[1, m];
                for (int j = 0; j < m; j++)
                {
                    vector[0, j] = digitizedPlaintext[i + j];
                }

                int[,] result = MultiplyMatrix(vector, key);
                for (int j = 0; j < m; j++)
                {
                    ciphertext[i + j] = result[0, j];
                }
            }

            char[] cipherChar = new char[plain.Length];
            for (int i = 0; i < plain.Length; i++)
            {
                cipherChar[i] = char.ToUpper((char)(ciphertext[i] + 'A'));
            }


            char[] resultCipher = new char[plaintext.Length + (plain.Length - plaintext.Length)];
            int cipherIndex = 0;
            int specialIndex = 0;

            for (int i = 0; i < resultCipher.Length; i++)
            {
                if (specialIndex < specialCharCount && specialCharPositions[specialIndex] == i)
                {
                    resultCipher[i] = specialChars[specialIndex++];
                }
                else
                {
                    resultCipher[i] = cipherChar[cipherIndex++];
                }
            }

            return new string(resultCipher);
        }

        public static string Decrypt(string ciphertext, int[,] key)
        {
            int m = key.GetLength(0);
            ciphertext = ciphertext.ToUpper();


            char[] specialChars = new char[ciphertext.Length];
            int[] specialCharPositions = new int[ciphertext.Length];
            int specialCharCount = 0;

            string cipher = "";

            for (int i = 0; i < ciphertext.Length; i++)
            {
                char c = ciphertext[i];
                if (char.IsLetter(c))
                {
                    cipher += c;
                }
                else
                {
                    specialChars[specialCharCount] = c;
                    specialCharPositions[specialCharCount++] = i;
                }
            }

 
            while (cipher.Length % m != 0)
            {
                cipher += 'X';
            }

            int det = Determinant(key);
            int detInv = ModInverse(det, MOD);
            int[,] keyInverse = InverseMatrix(key, detInv);

            int[] digitizedCiphertext = new int[cipher.Length];
            for (int i = 0; i < cipher.Length; i++)
            {
                digitizedCiphertext[i] = cipher[i] - 'A';
            }

            int[] plaintext = new int[cipher.Length];
            for (int i = 0; i < cipher.Length; i += m)
            {
                int[,] vector = new int[1, m];
                for (int j = 0; j < m; j++)
                {
                    vector[0, j] = digitizedCiphertext[i + j];
                }

                int[,] result = MultiplyMatrix(vector, keyInverse);
                for (int j = 0; j < m; j++)
                {
                    plaintext[i + j] = result[0, j];
                }
            }

            char[] plainChar = new char[cipher.Length];
            for (int i = 0; i < cipher.Length; i++)
            {
                plainChar[i] = (char)(plaintext[i] + 'A');
            }

 
            char[] resultPlain = new char[ciphertext.Length];
            int plainIndex = 0;
            int specialIndex = 0;

            for (int i = 0; i < ciphertext.Length; i++)
            {
                if (specialIndex < specialCharCount && specialCharPositions[specialIndex] == i)
                {
                    resultPlain[i] = specialChars[specialIndex++];
                }
                else
                {
                    resultPlain[i] = plainChar[plainIndex++];
                }
            }

            return new string(resultPlain);
        }

        private static int[,] MultiplyMatrix(int[,] a, int[,] b)
        {
            int rowsA = a.GetLength(0);
            int colsA = a.GetLength(1);
            int colsB = b.GetLength(1);

            int[,] result = new int[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, j] = (result[i, j] + a[i, k] * b[k, j]) % MOD;
                    }
                }
            }
            return result;
        }

        private static int Determinant(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (n == 1) return matrix[0, 0];
            if (n == 2) return (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]) % MOD;

            int det = 0;
            for (int j = 0; j < n; j++)
            {
                int[,] submatrix = CreateSubMatrix(matrix, 0, j);
                det = (det + (int)(Math.Pow(-1, j) * matrix[0, j] * Determinant(submatrix))) % MOD;
            }
            return (det + MOD) % MOD;
        }

        private static int[,] CreateSubMatrix(int[,] matrix, int excludingRow, int excludingCol)
        {
            int n = matrix.GetLength(0);
            int[,] submatrix = new int[n - 1, n - 1];
            int row = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == excludingRow) continue;
                int col = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == excludingCol) continue;
                    submatrix[row, col] = matrix[i, j];
                    col++;
                }
                row++;
            }
            return submatrix;
        }

        private static int ModInverse(int a, int m)
        {
            a = (a % m + m) % m;
            for (int x = 1; x < m; x++)
            {
                if ((a * x) % m == 1) return x;
            }
            return 0;
        }

        private static int[,] InverseMatrix(int[,] matrix, int detInv)
        {
            int m = matrix.GetLength(0);
            int[,] cofactorMatrix = Cofactor(matrix);
            int[,] transposedMatrix = Transpose(cofactorMatrix);
            int[,] inverse = new int[m, m];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    inverse[i, j] = (transposedMatrix[i, j] * detInv) % MOD;
                    if (inverse[i, j] < 0)
                    {
                        inverse[i, j] += MOD;
                    }
                }
            }
            return inverse;
        }

        private static int[,] Transpose(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int[,] transposedMatrix = new int[m, m];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    transposedMatrix[i, j] = matrix[j, i];
                }
            }
            return transposedMatrix;
        }

        private static int[,] Cofactor(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[,] cofactorMatrix = new int[n, n];

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    int[,] submatrix = CreateSubMatrix(matrix, r, c);
                    cofactorMatrix[r, c] = (int)(Math.Pow(-1, r + c) * Determinant(submatrix));
                    cofactorMatrix[r, c] = (cofactorMatrix[r, c] % MOD + MOD) % MOD;
                }
            }
            return cofactorMatrix;
        }
    }
}
