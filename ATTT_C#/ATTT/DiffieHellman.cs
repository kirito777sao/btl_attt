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
    public partial class DiffieHellman : Form
    {
        public DiffieHellman()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                long q = long.Parse(txtQ.Text);
                long alpha = long.Parse(txtAlpha.Text);

                long alicePrivateKey = long.Parse(txtAlicePrivateKey.Text);

                long alicePublicKey = ModPow(alpha, alicePrivateKey, q);


                long bobPrivateKey = long.Parse(txtBobPrivateKey.Text);

                long bobPublicKey = ModPow(alpha, bobPrivateKey, q);

                long aliceSharedSecret = ModPow(bobPublicKey, alicePrivateKey, q);
                long bobSharedSecret = ModPow(alicePublicKey, bobPrivateKey, q);


                txtOutput.Text = $"Khóa công khai của Alice: {alicePublicKey}"+ $"\nKhóa công khai của Bob: {bobPublicKey}"
                    +$"\nKhóa bí mật chung (Alice): {aliceSharedSecret}"+ $"\nKhóa bí mật chung (Bob): {bobSharedSecret}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }


        private long ModPow(long baseValue, long exponent, long modulus)
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
    }
}
