namespace ATTT
{
    partial class Vegenere
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
            this.btn_gm = new System.Windows.Forms.Button();
            this.btn_mh = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_gm
            // 
            this.btn_gm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_gm.Location = new System.Drawing.Point(489, 250);
            this.btn_gm.Margin = new System.Windows.Forms.Padding(2);
            this.btn_gm.Name = "btn_gm";
            this.btn_gm.Size = new System.Drawing.Size(214, 57);
            this.btn_gm.TabIndex = 15;
            this.btn_gm.Text = "Giải Mã";
            this.btn_gm.UseVisualStyleBackColor = true;
            this.btn_gm.Click += new System.EventHandler(this.btn_gm_Click);
            // 
            // btn_mh
            // 
            this.btn_mh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mh.Location = new System.Drawing.Point(156, 250);
            this.btn_mh.Margin = new System.Windows.Forms.Padding(2);
            this.btn_mh.Name = "btn_mh";
            this.btn_mh.Size = new System.Drawing.Size(214, 57);
            this.btn_mh.TabIndex = 14;
            this.btn_mh.Text = "Mã Hóa";
            this.btn_mh.UseVisualStyleBackColor = true;
            this.btn_mh.Click += new System.EventHandler(this.btn_mh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(468, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "input";
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(472, 58);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(2);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(298, 31);
            this.txtOutput.TabIndex = 10;
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.Location = new System.Drawing.Point(63, 156);
            this.txtKey.Margin = new System.Windows.Forms.Padding(2);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(298, 31);
            this.txtKey.TabIndex = 9;
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(62, 58);
            this.txtInput.Margin = new System.Windows.Forms.Padding(2);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(298, 31);
            this.txtInput.TabIndex = 8;
            // 
            // Vegenere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 364);
            this.Controls.Add(this.btn_gm);
            this.Controls.Add(this.btn_mh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txtInput);
            this.Name = "Vegenere";
            this.Text = "Vegenere";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_gm;
        private System.Windows.Forms.Button btn_mh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtInput;
    }
}