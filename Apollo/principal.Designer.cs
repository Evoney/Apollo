namespace Apollo
{
    partial class principal
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
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txt1 = new System.Windows.Forms.TextBox();
            this.eyeD = new System.Windows.Forms.Button();
            this.Sit1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn3 = new System.Windows.Forms.PictureBox();
            this.btn2 = new System.Windows.Forms.PictureBox();
            this.btn1 = new System.Windows.Forms.PictureBox();
            this.web1 = new Emgu.CV.UI.ImageBox();
            this.imag = new System.Windows.Forms.PictureBox();
            this.oit2 = new System.Windows.Forms.Button();
            this.oit1 = new System.Windows.Forms.Button();
            this.oit3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.web1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imag)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txt1
            // 
            this.txt1.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.txt1.Location = new System.Drawing.Point(172, 179);
            this.txt1.Multiline = true;
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(849, 29);
            this.txt1.TabIndex = 13;
            // 
            // eyeD
            // 
            this.eyeD.BackColor = System.Drawing.Color.Red;
            this.eyeD.Location = new System.Drawing.Point(952, 485);
            this.eyeD.Name = "eyeD";
            this.eyeD.Size = new System.Drawing.Size(29, 29);
            this.eyeD.TabIndex = 14;
            this.eyeD.UseVisualStyleBackColor = false;
            // 
            // Sit1
            // 
            this.Sit1.BackColor = System.Drawing.Color.Red;
            this.Sit1.Location = new System.Drawing.Point(987, 485);
            this.Sit1.Name = "Sit1";
            this.Sit1.Size = new System.Drawing.Size(29, 29);
            this.Sit1.TabIndex = 15;
            this.Sit1.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(365, 249);
            this.progressBar1.Maximum = 500;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(424, 23);
            this.progressBar1.TabIndex = 16;
            this.progressBar1.Visible = false;
            // 
            // btn3
            // 
            this.btn3.Image = global::Apollo.Properties.Resources.SAIR1;
            this.btn3.Location = new System.Drawing.Point(12, 498);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(143, 141);
            this.btn3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn3.TabIndex = 19;
            this.btn3.TabStop = false;
            this.btn3.Visible = false;
            // 
            // btn2
            // 
            this.btn2.Image = global::Apollo.Properties.Resources.APRENDIZADO1;
            this.btn2.Location = new System.Drawing.Point(12, 337);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(143, 141);
            this.btn2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn2.TabIndex = 18;
            this.btn2.TabStop = false;
            this.btn2.Visible = false;
            // 
            // btn1
            // 
            this.btn1.Image = global::Apollo.Properties.Resources.LIVRE2;
            this.btn1.Location = new System.Drawing.Point(12, 179);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(143, 141);
            this.btn1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn1.TabIndex = 17;
            this.btn1.TabStop = false;
            this.btn1.Visible = false;
            // 
            // web1
            // 
            this.web1.Location = new System.Drawing.Point(801, 520);
            this.web1.Name = "web1";
            this.web1.Size = new System.Drawing.Size(215, 150);
            this.web1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.web1.TabIndex = 2;
            this.web1.TabStop = false;
            // 
            // imag
            // 
            this.imag.Image = global::Apollo.Properties.Resources._1;
            this.imag.Location = new System.Drawing.Point(-1, 0);
            this.imag.Name = "imag";
            this.imag.Size = new System.Drawing.Size(1044, 700);
            this.imag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imag.TabIndex = 12;
            this.imag.TabStop = false;
            // 
            // oit2
            // 
            this.oit2.BackColor = System.Drawing.Color.Turquoise;
            this.oit2.Location = new System.Drawing.Point(517, 424);
            this.oit2.Name = "oit2";
            this.oit2.Size = new System.Drawing.Size(86, 90);
            this.oit2.TabIndex = 20;
            this.oit2.UseVisualStyleBackColor = false;
            this.oit2.Visible = false;
            // 
            // oit1
            // 
            this.oit1.BackColor = System.Drawing.Color.Teal;
            this.oit1.Location = new System.Drawing.Point(334, 424);
            this.oit1.Name = "oit1";
            this.oit1.Size = new System.Drawing.Size(86, 90);
            this.oit1.TabIndex = 20;
            this.oit1.UseVisualStyleBackColor = false;
            this.oit1.Visible = false;
            // 
            // oit3
            // 
            this.oit3.BackColor = System.Drawing.Color.Turquoise;
            this.oit3.Location = new System.Drawing.Point(703, 424);
            this.oit3.Name = "oit3";
            this.oit3.Size = new System.Drawing.Size(86, 90);
            this.oit3.TabIndex = 21;
            this.oit3.UseVisualStyleBackColor = false;
            this.oit3.Visible = false;
            // 
            // principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1028, 682);
            this.Controls.Add(this.oit3);
            this.Controls.Add(this.oit1);
            this.Controls.Add(this.oit2);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.web1);
            this.Controls.Add(this.Sit1);
            this.Controls.Add(this.eyeD);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.imag);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apollo";
            this.Load += new System.EventHandler(this.principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.web1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox imag;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Button eyeD;
        private System.Windows.Forms.Button Sit1;
        private Emgu.CV.UI.ImageBox web1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox btn1;
        private System.Windows.Forms.PictureBox btn2;
        private System.Windows.Forms.PictureBox btn3;
        private System.Windows.Forms.Button oit2;
        private System.Windows.Forms.Button oit1;
        private System.Windows.Forms.Button oit3;
    }
}

