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
            this.btRefresh = new System.Windows.Forms.Button();
            this.btGuiMail = new System.Windows.Forms.Button();
            this.btDangNhap = new System.Windows.Forms.Button();
            this.tbMatKhau = new System.Windows.Forms.TextBox();
            this.tbTaiKhoan = new System.Windows.Forms.TextBox();
            this.lbMatKhau = new System.Windows.Forms.Label();
            this.lbTaiKhoan = new System.Windows.Forms.Label();
            this.btDangXuat = new System.Windows.Forms.Button();
            this.gbCaiDat = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbPort1 = new System.Windows.Forms.Label();
            this.nudPort2 = new System.Windows.Forms.NumericUpDown();
            this.tbSMTP = new System.Windows.Forms.TextBox();
            this.lbSMTP = new System.Windows.Forms.Label();
            this.nudPort1 = new System.Windows.Forms.NumericUpDown();
            this.tbIMAP = new System.Windows.Forms.TextBox();
            this.lbIMAP = new System.Windows.Forms.Label();
            this.lbPort2 = new System.Windows.Forms.Label();
            this.lvMails = new System.Windows.Forms.ListView();
            this.gbDangNhap.SuspendLayout();
            this.gbCaiDat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDangNhap
            // 
            this.gbDangNhap.Controls.Add(this.btRefresh);
            this.gbDangNhap.Controls.Add(this.btGuiMail);
            this.gbDangNhap.Controls.Add(this.btDangNhap);
            this.gbDangNhap.Controls.Add(this.tbMatKhau);
            this.gbDangNhap.Controls.Add(this.tbTaiKhoan);
            this.gbDangNhap.Controls.Add(this.lbMatKhau);
            this.gbDangNhap.Controls.Add(this.lbTaiKhoan);
            this.gbDangNhap.Controls.Add(this.btDangXuat);
            this.gbDangNhap.Location = new System.Drawing.Point(12, 12);
            this.gbDangNhap.Name = "gbDangNhap";
            this.gbDangNhap.Size = new System.Drawing.Size(245, 105);
            this.gbDangNhap.TabIndex = 0;
            this.gbDangNhap.TabStop = false;
            this.gbDangNhap.Text = "Đăng nhập";
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(83, 74);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 13;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Visible = false;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // btGuiMail
            // 
            this.btGuiMail.Location = new System.Drawing.Point(0, 74);
            this.btGuiMail.Name = "btGuiMail";
            this.btGuiMail.Size = new System.Drawing.Size(75, 23);
            this.btGuiMail.TabIndex = 11;
            this.btGuiMail.Text = "Gửi mail";
            this.btGuiMail.UseVisualStyleBackColor = true;
            this.btGuiMail.Visible = false;
            // 
            // btDangNhap
            // 
            this.btDangNhap.Location = new System.Drawing.Point(164, 74);
            this.btDangNhap.Name = "btDangNhap";
            this.btDangNhap.Size = new System.Drawing.Size(75, 23);
            this.btDangNhap.TabIndex = 3;
            this.btDangNhap.Text = "Đăng nhập";
            this.btDangNhap.UseVisualStyleBackColor = true;
            this.btDangNhap.Click += new System.EventHandler(this.btDangNhap_Click);
            // 
            // tbMatKhau
            // 
            this.tbMatKhau.Location = new System.Drawing.Point(76, 48);
            this.tbMatKhau.Name = "tbMatKhau";
            this.tbMatKhau.PasswordChar = '*';
            this.tbMatKhau.Size = new System.Drawing.Size(163, 20);
            this.tbMatKhau.TabIndex = 10;
            // 
            // tbTaiKhoan
            // 
            this.tbTaiKhoan.Location = new System.Drawing.Point(76, 22);
            this.tbTaiKhoan.Name = "tbTaiKhoan";
            this.tbTaiKhoan.Size = new System.Drawing.Size(163, 20);
            this.tbTaiKhoan.TabIndex = 9;
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
            // lbTaiKhoan
            // 
            this.lbTaiKhoan.AutoSize = true;
            this.lbTaiKhoan.Location = new System.Drawing.Point(6, 25);
            this.lbTaiKhoan.Name = "lbTaiKhoan";
            this.lbTaiKhoan.Size = new System.Drawing.Size(55, 13);
            this.lbTaiKhoan.TabIndex = 2;
            this.lbTaiKhoan.Text = "Tài khoản";
            // 
            // btDangXuat
            // 
            this.btDangXuat.Location = new System.Drawing.Point(164, 74);
            this.btDangXuat.Name = "btDangXuat";
            this.btDangXuat.Size = new System.Drawing.Size(75, 23);
            this.btDangXuat.TabIndex = 12;
            this.btDangXuat.Text = "Đăng xuất";
            this.btDangXuat.UseVisualStyleBackColor = true;
            this.btDangXuat.Click += new System.EventHandler(this.btDangXuat_Click);
            // 
            // gbCaiDat
            // 
            this.gbCaiDat.Controls.Add(this.progressBar1);
            this.gbCaiDat.Controls.Add(this.lbPort1);
            this.gbCaiDat.Controls.Add(this.nudPort2);
            this.gbCaiDat.Controls.Add(this.tbSMTP);
            this.gbCaiDat.Controls.Add(this.lbSMTP);
            this.gbCaiDat.Controls.Add(this.nudPort1);
            this.gbCaiDat.Controls.Add(this.tbIMAP);
            this.gbCaiDat.Controls.Add(this.lbIMAP);
            this.gbCaiDat.Controls.Add(this.lbPort2);
            this.gbCaiDat.Location = new System.Drawing.Point(263, 12);
            this.gbCaiDat.Name = "gbCaiDat";
            this.gbCaiDat.Size = new System.Drawing.Size(444, 105);
            this.gbCaiDat.TabIndex = 1;
            this.gbCaiDat.TabStop = false;
            this.gbCaiDat.Text = "Cài đặt";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(272, 74);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(163, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 14;
            this.progressBar1.Visible = false;
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
            // nudPort2
            // 
            this.nudPort2.Location = new System.Drawing.Point(272, 48);
            this.nudPort2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPort2.Name = "nudPort2";
            this.nudPort2.Size = new System.Drawing.Size(163, 20);
            this.nudPort2.TabIndex = 13;
            this.nudPort2.Value = new decimal(new int[] {
            587,
            0,
            0,
            0});
            // 
            // tbSMTP
            // 
            this.tbSMTP.Location = new System.Drawing.Point(272, 22);
            this.tbSMTP.Name = "tbSMTP";
            this.tbSMTP.Size = new System.Drawing.Size(163, 20);
            this.tbSMTP.TabIndex = 12;
            this.tbSMTP.Text = "smtp.gmail.com";
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
            // nudPort1
            // 
            this.nudPort1.Location = new System.Drawing.Point(45, 48);
            this.nudPort1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPort1.Name = "nudPort1";
            this.nudPort1.Size = new System.Drawing.Size(163, 20);
            this.nudPort1.TabIndex = 9;
            this.nudPort1.Value = new decimal(new int[] {
            993,
            0,
            0,
            0});
            // 
            // tbIMAP
            // 
            this.tbIMAP.Location = new System.Drawing.Point(45, 22);
            this.tbIMAP.Name = "tbIMAP";
            this.tbIMAP.Size = new System.Drawing.Size(163, 20);
            this.tbIMAP.TabIndex = 11;
            this.tbIMAP.Text = "imap.gmail.com";
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
            // lbPort2
            // 
            this.lbPort2.AutoSize = true;
            this.lbPort2.Location = new System.Drawing.Point(6, 51);
            this.lbPort2.Name = "lbPort2";
            this.lbPort2.Size = new System.Drawing.Size(26, 13);
            this.lbPort2.TabIndex = 8;
            this.lbPort2.Text = "Port";
            // 
            // lvMails
            // 
            this.lvMails.HideSelection = false;
            this.lvMails.Location = new System.Drawing.Point(12, 123);
            this.lvMails.Name = "lvMails";
            this.lvMails.Size = new System.Drawing.Size(695, 315);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudPort2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort1)).EndInit();
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
        private System.Windows.Forms.NumericUpDown nudPort1;
        private System.Windows.Forms.TextBox tbSMTP;
        private System.Windows.Forms.TextBox tbIMAP;
        private System.Windows.Forms.NumericUpDown nudPort2;
        private System.Windows.Forms.ListView lvMails;
        private System.Windows.Forms.Button btDangNhap;
        private System.Windows.Forms.Button btGuiMail;
        private System.Windows.Forms.Button btDangXuat;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

