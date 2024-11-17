namespace ATTT
{
    partial class DiffieHellman
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
            this.button3 = new System.Windows.Forms.Button();
            this.txtBobPrivateKey = new System.Windows.Forms.TextBox();
            this.txtAlicePrivateKey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.txtAlpha = new System.Windows.Forms.TextBox();
            this.txtQ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(372, 458);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 47);
            this.button3.TabIndex = 33;
            this.button3.Text = "TẠO KHÓA";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtBobPrivateKey
            // 
            this.txtBobPrivateKey.Location = new System.Drawing.Point(267, 228);
            this.txtBobPrivateKey.Name = "txtBobPrivateKey";
            this.txtBobPrivateKey.Size = new System.Drawing.Size(335, 20);
            this.txtBobPrivateKey.TabIndex = 32;
            // 
            // txtAlicePrivateKey
            // 
            this.txtAlicePrivateKey.Location = new System.Drawing.Point(267, 189);
            this.txtAlicePrivateKey.Name = "txtAlicePrivateKey";
            this.txtAlicePrivateKey.Size = new System.Drawing.Size(335, 20);
            this.txtAlicePrivateKey.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "KHÓA RIÊNG ALICE:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "KHÓA RIÊNG BOB:";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(267, 300);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(398, 100);
            this.txtOutput.TabIndex = 26;
            this.txtOutput.Text = "";
            // 
            // txtAlpha
            // 
            this.txtAlpha.Location = new System.Drawing.Point(267, 99);
            this.txtAlpha.Name = "txtAlpha";
            this.txtAlpha.Size = new System.Drawing.Size(335, 20);
            this.txtAlpha.TabIndex = 24;
            // 
            // txtQ
            // 
            this.txtQ.Location = new System.Drawing.Point(267, 62);
            this.txtQ.Name = "txtQ";
            this.txtQ.Size = new System.Drawing.Size(335, 20);
            this.txtQ.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "OUTPUT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "NHẬP q:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "NHẬP ALPHA:";
            // 
            // DiffieHellman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 553);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtBobPrivateKey);
            this.Controls.Add(this.txtAlicePrivateKey);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtAlpha);
            this.Controls.Add(this.txtQ);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "DiffieHellman";
            this.Text = "DiffieHellman";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtBobPrivateKey;
        private System.Windows.Forms.TextBox txtAlicePrivateKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.TextBox txtAlpha;
        private System.Windows.Forms.TextBox txtQ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}