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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void caesarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Caesar f = new Caesar();
            f.MdiParent = this;
            f.Show();
        }

        private void affineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Affine f = new Affine();
            f.MdiParent = this;
            f.Show();
        }

        private void thayTheDonBangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThayTheDonBang f = new ThayTheDonBang();
            f.MdiParent = this;
            f.Show();
        }

        private void vegenereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vegenere f = new Vegenere();
            f.MdiParent = this;
            f.Show();
        }

        private void playfairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Playfair f = new Playfair();
            f.MdiParent = this;
            f.Show();
        }

        private void hillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HillCipher f = new HillCipher();
            f.MdiParent = this;
            f.Show();
        }

        private void rSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RSA f = new RSA();
            f.MdiParent = this;
            f.Show();
        }

        private void diffieHellmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiffieHellman f = new DiffieHellman();
            f.MdiParent = this;
            f.Show();
        }
    }
}
