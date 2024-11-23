namespace Bai6
{
    partial class Main
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
            this.gbDangNhap = new System.Windows.Forms.GroupBox();
            this.gbCaiDat = new System.Windows.Forms.GroupBox();
            this.lbTaiKhoan = new System.Windows.Forms.Label();
            this.lbMatKhau = new System.Windows.Forms.Label();
            this.lbPort1 = new System.Windows.Forms.Label();
            this.lbIMAP = new System.Windows.Forms.Label();
            this.lbSMTP = new System.Windows.Forms.Label();
            this.lbPort2 = new System.Windows.Forms.Label();
            this.tbTaiKhoan = new System.Windows.Forms.TextBox();
            this.tbMatKhau = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.lvMails = new System.Windows.Forms.ListView();
            this.gbDangNhap.SuspendLayout();
            this.gbCaiDat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDangNhap
            // 
            this.gbDangNhap.Controls.Add(this.tbMatKhau);
            this.gbDangNhap.Controls.Add(this.tbTaiKhoan);
            this.gbDangNhap.Controls.Add(this.lbMatKhau);
            this.gbDangNhap.Controls.Add(this.lbTaiKhoan);
            this.gbDangNhap.Location = new System.Drawing.Point(12, 12);
            this.gbDangNhap.Name = "gbDangNhap";
            this.gbDangNhap.Size = new System.Drawing.Size(245, 100);
            this.gbDangNhap.TabIndex = 0;
            this.gbDangNhap.TabStop = false;
            this.gbDangNhap.Text = "Đăng nhập";
            // 
            // gbCaiDat
            // 
            this.gbCaiDat.Controls.Add(this.lbPort1);
            this.gbCaiDat.Controls.Add(this.numericUpDown2);
            this.gbCaiDat.Controls.Add(this.textBox2);
            this.gbCaiDat.Controls.Add(this.lbSMTP);
            this.gbCaiDat.Controls.Add(this.numericUpDown1);
            this.gbCaiDat.Controls.Add(this.textBox1);
            this.gbCaiDat.Controls.Add(this.lbIMAP);
            this.gbCaiDat.Controls.Add(this.lbPort2);
            this.gbCaiDat.Location = new System.Drawing.Point(263, 12);
            this.gbCaiDat.Name = "gbCaiDat";
            this.gbCaiDat.Size = new System.Drawing.Size(444, 100);
            this.gbCaiDat.TabIndex = 1;
            this.gbCaiDat.TabStop = false;
            this.gbCaiDat.Text = "Cài đặt";
            // 
            // lbTaiKhoan
            // 
            this.lbTaiKhoan.AutoSize = true;
            this.lbTaiKhoan.Location = new System.Drawing.Point(6, 25);
            this.lbTaiKhoan.Name = "lbTaiKhoan";
            this.lbTaiKhoan.Size = new System.Drawing.Size(55, 13);
            this.lbTaiKhoan.TabIndex = 2;
            this.lbTaiKhoan.Text = "Tài khoản";
            // 
            // lbMatKhau
            // 
            this.lbMatKhau.AutoSize = true;
            this.lbMatKhau.Location = new System.Drawing.Point(6, 51);
            this.lbMatKhau.Name = "lbMatKhau";
            this.lbMatKhau.Size = new System.Drawing.Size(52, 13);
            this.lbMatKhau.TabIndex = 3;
            this.lbMatKhau.Text = "Mật khẩu";
            // 
            // lbPort1
            // 
            this.lbPort1.AutoSize = true;
            this.lbPort1.Location = new System.Drawing.Point(229, 51);
            this.lbPort1.Name = "lbPort1";
            this.lbPort1.Size = new System.Drawing.Size(26, 13);
            this.lbPort1.TabIndex = 5;
            this.lbPort1.Text = "Port";
            // 
            // lbIMAP
            // 
            this.lbIMAP.AutoSize = true;
            this.lbIMAP.Location = new System.Drawing.Point(6, 25);
            this.lbIMAP.Name = "lbIMAP";
            this.lbIMAP.Size = new System.Drawing.Size(33, 13);
            this.lbIMAP.TabIndex = 6;
            this.lbIMAP.Text = "IMAP";
            // 
            // lbSMTP
            // 
            this.lbSMTP.AutoSize = true;
            this.lbSMTP.Location = new System.Drawing.Point(229, 25);
            this.lbSMTP.Name = "lbSMTP";
            this.lbSMTP.Size = new System.Drawing.Size(37, 13);
            this.lbSMTP.TabIndex = 7;
            this.lbSMTP.Text = "SMTP";
            // 
            // lbPort2
            // 
            this.lbPort2.AutoSize = true;
            this.lbPort2.Location = new System.Drawing.Point(6, 51);
            this.lbPort2.Name = "lbPort2";
            this.lbPort2.Size = new System.Drawing.Size(26, 13);
            this.lbPort2.TabIndex = 8;
            this.lbPort2.Text = "Port";
            // 
            // tbTaiKhoan
            // 
            this.tbTaiKhoan.Location = new System.Drawing.Point(76, 22);
            this.tbTaiKhoan.Name = "tbTaiKhoan";
            this.tbTaiKhoan.Size = new System.Drawing.Size(163, 20);
            this.tbTaiKhoan.TabIndex = 9;
            // 
            // tbMatKhau
            // 
            this.tbMatKhau.Location = new System.Drawing.Point(76, 48);
            this.tbMatKhau.Name = "tbMatKhau";
            this.tbMatKhau.PasswordChar = '*';
            this.tbMatKhau.Size = new System.Drawing.Size(163, 20);
            this.tbMatKhau.TabIndex = 10;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(45, 48);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(163, 20);
            this.numericUpDown1.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(163, 20);
            this.textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(272, 22);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(163, 20);
            this.textBox2.TabIndex = 12;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(272, 48);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(163, 20);
            this.numericUpDown2.TabIndex = 13;
            // 
            // lvMails
            // 
            this.lvMails.HideSelection = false;
            this.lvMails.Location = new System.Drawing.Point(12, 118);
            this.lvMails.Name = "lvMails";
            this.lvMails.Size = new System.Drawing.Size(695, 320);
            this.lvMails.TabIndex = 2;
            this.lvMails.UseCompatibleStateImageBehavior = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 450);
            this.Controls.Add(this.lvMails);
            this.Controls.Add(this.gbCaiDat);
            this.Controls.Add(this.gbDangNhap);
            this.Name = "Main";
            this.Text = "Main";
            this.gbDangNhap.ResumeLayout(false);
            this.gbDangNhap.PerformLayout();
            this.gbCaiDat.ResumeLayout(false);
            this.gbCaiDat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDangNhap;
        private System.Windows.Forms.GroupBox gbCaiDat;
        private System.Windows.Forms.Label lbMatKhau;
        private System.Windows.Forms.Label lbTaiKhoan;
        private System.Windows.Forms.Label lbPort1;
        private System.Windows.Forms.Label lbIMAP;
        private System.Windows.Forms.Label lbSMTP;
        private System.Windows.Forms.TextBox tbMatKhau;
        private System.Windows.Forms.TextBox tbTaiKhoan;
        private System.Windows.Forms.Label lbPort2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.ListView lvMails;
    }
}

