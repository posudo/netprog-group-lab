namespace Bai5
{
    partial class Email_Setting
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
            this.btn_SaveExit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txb_Password = new System.Windows.Forms.TextBox();
            this.txb_Username = new System.Windows.Forms.TextBox();
            this.txb_Nickname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_TestConnection = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_SMTPPort = new System.Windows.Forms.ComboBox();
            this.cmb_IMAPPort = new System.Windows.Forms.ComboBox();
            this.cb_SSLSMTP = new System.Windows.Forms.CheckBox();
            this.cb_SSLIMAP = new System.Windows.Forms.CheckBox();
            this.txb_SMTP = new System.Windows.Forms.TextBox();
            this.txb_IMAP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_SaveExit
            // 
            this.btn_SaveExit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_SaveExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveExit.Location = new System.Drawing.Point(569, 454);
            this.btn_SaveExit.Name = "btn_SaveExit";
            this.btn_SaveExit.Size = new System.Drawing.Size(156, 71);
            this.btn_SaveExit.TabIndex = 26;
            this.btn_SaveExit.Text = "Save and Exit";
            this.btn_SaveExit.UseVisualStyleBackColor = false;
            this.btn_SaveExit.Click += new System.EventHandler(this.btn_SaveExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txb_Password);
            this.groupBox2.Controls.Add(this.txb_Username);
            this.groupBox2.Controls.Add(this.txb_Nickname);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(52, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(487, 223);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account";
            // 
            // txb_Password
            // 
            this.txb_Password.Location = new System.Drawing.Point(130, 166);
            this.txb_Password.Name = "txb_Password";
            this.txb_Password.Size = new System.Drawing.Size(327, 26);
            this.txb_Password.TabIndex = 5;
            // 
            // txb_Username
            // 
            this.txb_Username.Location = new System.Drawing.Point(130, 113);
            this.txb_Username.Name = "txb_Username";
            this.txb_Username.Size = new System.Drawing.Size(327, 26);
            this.txb_Username.TabIndex = 4;
            // 
            // txb_Nickname
            // 
            this.txb_Nickname.Location = new System.Drawing.Point(130, 56);
            this.txb_Nickname.Name = "txb_Nickname";
            this.txb_Nickname.ReadOnly = true;
            this.txb_Nickname.Size = new System.Drawing.Size(327, 26);
            this.txb_Nickname.TabIndex = 3;
            this.txb_Nickname.Text = "Việt";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nickname";
            // 
            // btn_TestConnection
            // 
            this.btn_TestConnection.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_TestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TestConnection.Location = new System.Drawing.Point(569, 406);
            this.btn_TestConnection.Name = "btn_TestConnection";
            this.btn_TestConnection.Size = new System.Drawing.Size(156, 32);
            this.btn_TestConnection.TabIndex = 25;
            this.btn_TestConnection.Text = "Test connection";
            this.btn_TestConnection.UseVisualStyleBackColor = false;
            this.btn_TestConnection.Click += new System.EventHandler(this.btn_TestConnection_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_SMTPPort);
            this.groupBox1.Controls.Add(this.cmb_IMAPPort);
            this.groupBox1.Controls.Add(this.cb_SSLSMTP);
            this.groupBox1.Controls.Add(this.cb_SSLIMAP);
            this.groupBox1.Controls.Add(this.txb_SMTP);
            this.groupBox1.Controls.Add(this.txb_IMAP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(52, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 206);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Email server configuration";
            // 
            // cmb_SMTPPort
            // 
            this.cmb_SMTPPort.FormattingEnabled = true;
            this.cmb_SMTPPort.Items.AddRange(new object[] {
            "465",
            "587"});
            this.cmb_SMTPPort.Location = new System.Drawing.Point(433, 109);
            this.cmb_SMTPPort.Name = "cmb_SMTPPort";
            this.cmb_SMTPPort.Size = new System.Drawing.Size(174, 28);
            this.cmb_SMTPPort.TabIndex = 9;
            // 
            // cmb_IMAPPort
            // 
            this.cmb_IMAPPort.FormattingEnabled = true;
            this.cmb_IMAPPort.Items.AddRange(new object[] {
            "993",
            "143"});
            this.cmb_IMAPPort.Location = new System.Drawing.Point(130, 109);
            this.cmb_IMAPPort.Name = "cmb_IMAPPort";
            this.cmb_IMAPPort.Size = new System.Drawing.Size(174, 28);
            this.cmb_IMAPPort.TabIndex = 8;
            // 
            // cb_SSLSMTP
            // 
            this.cb_SSLSMTP.AutoSize = true;
            this.cb_SSLSMTP.Location = new System.Drawing.Point(433, 159);
            this.cb_SSLSMTP.Name = "cb_SSLSMTP";
            this.cb_SSLSMTP.Size = new System.Drawing.Size(126, 24);
            this.cb_SSLSMTP.TabIndex = 7;
            this.cb_SSLSMTP.Text = "Require SSL";
            this.cb_SSLSMTP.UseVisualStyleBackColor = true;
            // 
            // cb_SSLIMAP
            // 
            this.cb_SSLIMAP.AutoSize = true;
            this.cb_SSLIMAP.Location = new System.Drawing.Point(130, 159);
            this.cb_SSLIMAP.Name = "cb_SSLIMAP";
            this.cb_SSLIMAP.Size = new System.Drawing.Size(126, 24);
            this.cb_SSLIMAP.TabIndex = 6;
            this.cb_SSLIMAP.Text = "Require SSL";
            this.cb_SSLIMAP.UseVisualStyleBackColor = true;
            // 
            // txb_SMTP
            // 
            this.txb_SMTP.Location = new System.Drawing.Point(433, 55);
            this.txb_SMTP.Name = "txb_SMTP";
            this.txb_SMTP.ReadOnly = true;
            this.txb_SMTP.Size = new System.Drawing.Size(174, 26);
            this.txb_SMTP.TabIndex = 5;
            this.txb_SMTP.Text = "smtp.gmail.com";
            // 
            // txb_IMAP
            // 
            this.txb_IMAP.Location = new System.Drawing.Point(130, 55);
            this.txb_IMAP.Name = "txb_IMAP";
            this.txb_IMAP.ReadOnly = true;
            this.txb_IMAP.Size = new System.Drawing.Size(174, 26);
            this.txb_IMAP.TabIndex = 4;
            this.txb_IMAP.Text = "imap.gmail.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "SMTP Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "SMTP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "IMAP Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "IMAP";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.IndianRed;
            this.label11.Location = new System.Drawing.Point(26, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(303, 57);
            this.label11.TabIndex = 27;
            this.label11.Text = "Email Config";
            // 
            // Email_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 564);
            this.Controls.Add(this.btn_SaveExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_TestConnection);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.Name = "Email_Setting";
            this.Text = "Email_Setting";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SaveExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txb_Password;
        private System.Windows.Forms.TextBox txb_Username;
        private System.Windows.Forms.TextBox txb_Nickname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_TestConnection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_SMTPPort;
        private System.Windows.Forms.ComboBox cmb_IMAPPort;
        private System.Windows.Forms.CheckBox cb_SSLSMTP;
        private System.Windows.Forms.CheckBox cb_SSLIMAP;
        private System.Windows.Forms.TextBox txb_SMTP;
        private System.Windows.Forms.TextBox txb_IMAP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
    }
}