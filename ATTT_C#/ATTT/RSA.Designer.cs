namespace ATTT
{
    partial class RSA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPlaintext = new System.Windows.Forms.RichTextBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQ = new System.Windows.Forms.TextBox();
            this.txtE = new System.Windows.Forms.TextBox();
            this.lblPrivateKey = new System.Windows.Forms.TextBox();
            this.lblPublicKey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NHẬP p:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "INPUT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "OUTPUT";
            // 
            // txtPlaintext
            // 
            this.txtPlaintext.Location = new System.Drawing.Point(289, 319);
            this.txtPlaintext.Name = "txtPlaintext";
            this.txtPlaintext.Size = new System.Drawing.Size(398, 67);
            this.txtPlaintext.TabIndex = 8;
            this.txtPlaintext.Text = "";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(289, 402);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(398, 59);
            this.txtOutput.TabIndex = 9;
            this.txtOutput.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(238, 515);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 47);
            this.button1.TabIndex = 10;
            this.button1.Text = "MÃ HÓA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(454, 515);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 47);
            this.button2.TabIndex = 11;
            this.button2.Text = "GIẢI MÃ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtP
            // 
            this.txtP.Location = new System.Drawing.Point(289, 38);
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(335, 20);
            this.txtP.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "NHẬP e:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "NHẬP q:";
            // 
            // txtQ
            // 
            this.txtQ.Location = new System.Drawing.Point(289, 79);
            this.txtQ.Name = "txtQ";
            this.txtQ.Size = new System.Drawing.Size(335, 20);
            this.txtQ.TabIndex = 6;
            // 
            // txtE
            // 
            this.txtE.Location = new System.Drawing.Point(289, 116);
            this.txtE.Name = "txtE";
            this.txtE.Size = new System.Drawing.Size(335, 20);
            this.txtE.TabIndex = 7;
            // 
            // lblPrivateKey
            // 
            this.lblPrivateKey.Location = new System.Drawing.Point(289, 245);
            this.lblPrivateKey.Name = "lblPrivateKey";
            this.lblPrivateKey.Size = new System.Drawing.Size(335, 20);
            this.lblPrivateKey.TabIndex = 15;
            // 
            // lblPublicKey
            // 
            this.lblPublicKey.Location = new System.Drawing.Point(289, 206);
            this.lblPublicKey.Name = "lblPublicKey";
            this.lblPublicKey.Size = new System.Drawing.Size(335, 20);
            this.lblPublicKey.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "KHÓA CÔNG KHAI:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "KHÓA BÍ MẬT:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(673, 515);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 47);
            this.button3.TabIndex = 16;
            this.button3.Text = "TẠO KHÓA";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // RSA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 598);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblPrivateKey);
            this.Controls.Add(this.lblPublicKey);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtPlaintext);
            this.Controls.Add(this.txtE);
            this.Controls.Add(this.txtQ);
            this.Controls.Add(this.txtP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RSA";
            this.Text = "RSA";
            this.Load += new System.EventHandler(this.RSA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtPlaintext;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQ;
        private System.Windows.Forms.TextBox txtE;
        private System.Windows.Forms.TextBox lblPrivateKey;
        private System.Windows.Forms.TextBox lblPublicKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
    }
}