namespace Lab6
{
    partial class DieuHuong
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
            this.Client = new System.Windows.Forms.Button();
            this.server = new System.Windows.Forms.Button();
            this.Quay2 = new System.Windows.Forms.Button();
            this.Quay3 = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Client
            // 
            this.Client.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Client.Location = new System.Drawing.Point(58, 62);
            this.Client.Margin = new System.Windows.Forms.Padding(2);
            this.Client.Name = "Client";
            this.Client.Size = new System.Drawing.Size(118, 34);
            this.Client.TabIndex = 0;
            this.Client.Text = "Quầy 1";
            this.Client.UseVisualStyleBackColor = true;
            this.Client.Click += new System.EventHandler(this.Client_Click);
            // 
            // server
            // 
            this.server.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server.Location = new System.Drawing.Point(343, 149);
            this.server.Margin = new System.Windows.Forms.Padding(2);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(118, 34);
            this.server.TabIndex = 1;
            this.server.Text = "Server";
            this.server.UseVisualStyleBackColor = true;
            this.server.Click += new System.EventHandler(this.server_Click);
            // 
            // Quay2
            // 
            this.Quay2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quay2.Location = new System.Drawing.Point(58, 149);
            this.Quay2.Margin = new System.Windows.Forms.Padding(2);
            this.Quay2.Name = "Quay2";
            this.Quay2.Size = new System.Drawing.Size(118, 34);
            this.Quay2.TabIndex = 2;
            this.Quay2.Text = "Quầy 2";
            this.Quay2.UseVisualStyleBackColor = true;
            this.Quay2.Click += new System.EventHandler(this.Quay2_Click);
            // 
            // Quay3
            // 
            this.Quay3.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quay3.Location = new System.Drawing.Point(58, 240);
            this.Quay3.Margin = new System.Windows.Forms.Padding(2);
            this.Quay3.Name = "Quay3";
            this.Quay3.Size = new System.Drawing.Size(118, 34);
            this.Quay3.TabIndex = 3;
            this.Quay3.Text = "Quầy 3";
            this.Quay3.UseVisualStyleBackColor = true;
            this.Quay3.Click += new System.EventHandler(this.Quay3_Click);
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(323, 240);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(155, 19);
            this.Login.TabIndex = 4;
            this.Login.TabStop = true;
            this.Login.Text = "Đăng nhập SuperUser";
            this.Login.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Login_LinkClicked);
            // 
            // DieuHuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Quay3);
            this.Controls.Add(this.Quay2);
            this.Controls.Add(this.server);
            this.Controls.Add(this.Client);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DieuHuong";
            this.Text = "DieuHuong_Bai4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Client;
        private System.Windows.Forms.Button server;
        private System.Windows.Forms.Button Quay2;
        private System.Windows.Forms.Button Quay3;
        private System.Windows.Forms.LinkLabel Login;
    }
}