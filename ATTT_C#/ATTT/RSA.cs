using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;

namespace ATTT
{
    public partial class RSA : Form
    {
        public RSA()
        {
            InitializeComponent();
        }

        private void RSA_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs m)
        {
            long plaintext = long.Parse(txtPlaintext.Text);
            long e = long.Parse(txtE.Text);
            long n = long.Parse(txtP.Text) * long.Parse(txtQ.Text); 


            long ciphertext = Encrypt(plaintext, e, n);
            txtOutput.Text = $"Bản mã: {ciphertext}";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            long ciphertext = long.Parse(txtPlaintext.Text.Split(':')[1].Trim());
            long d = long.Parse(lblPrivateKey.Text.Split(',')[0].Split('(')[1]);
            long n = long.Parse(lblPublicKey.Text.Split(',')[1].Split(')')[0].Trim());


            long decryptedText = Decrypt(ciphertext, d, n);
            txtOutput.Text = $"Bản giải mã: {decryptedText}";
        }

        private void button3_Click(object sender, EventArgs m)
        {

            long p = long.Parse(txtP.Text);
            long q = long.Parse(txtQ.Text);
            long e = long.Parse(txtE.Text);

            if (p != q)
            {
                if (!IsPrime(e))
                {
                    MessageBox.Show("Khóa mã hóa e không phải là số nguyên tố.");
                    return;
                }

                long n = p * q;
                long phiN = (p - 1) * (q - 1);
                long d = ModInverse(e, phiN);

                
                lblPublicKey.Text = $"Khóa công khai (e, n): ({e}, {n})";
                lblPrivateKey.Text = $"Khóa bí mật (d, n): ({d}, {n})";
                
            }else
                {
                MessageBox.Show("q và p phải khác nhau");
                }
            
        }


        public static long Encrypt(long message, long e, long n)
        {
            return ModPow(message, e, n); 
        }


        public static long Decrypt(long encryptedMessage, long d, long n)
        {
            return ModPow(encryptedMessage, d, n); 
        }


        public static long ModPow(long baseValue, long exponent, long modulus)
        {
            long result = 1;
            baseValue = baseValue % modulus;

            while (exponent > 0)
            {

                if ((exponent & 1) == 1)
                {
                    result = (result * baseValue) % modulus;
                }

                exponent >>= 1; 
                baseValue = (baseValue * baseValue) % modulus; 
            }
            return result;
        }


        public static long ModInverse(long a, long m)
        {
            long m0 = m, t, q;
            long x0 = 0, x1 = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {

                q = a / m;
                t = m;

                m = a % m;
                a = t;
                t = x0;

                x0 = x1 - q * x0;
                x1 = t;
            }


            if (x1 < 0)
                x1 += m0;

            return x1;
        }

        private bool IsPrime(long number)
        {
            if (number <= 1) return false;
            if (number <= 3) return true;
            if (number % 2 == 0 || number % 3 == 0) return false;

            for (long i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
            }
            return true;
        }
    }
}
