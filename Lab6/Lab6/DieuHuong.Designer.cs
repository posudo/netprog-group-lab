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
            this.button1 = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ID = new System.Windows.Forms.TextBox();
            this.btnPasWord = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Client
            // 
            this.Client.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Client.Location = new System.Drawing.Point(58, 44);
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
            this.server.Location = new System.Drawing.Point(322, 44);
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
            this.Quay2.Location = new System.Drawing.Point(58, 114);
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
            this.Quay3.Location = new System.Drawing.Point(58, 181);
            this.Quay3.Margin = new System.Windows.Forms.Padding(2);
            this.Quay3.Name = "Quay3";
            this.Quay3.Size = new System.Drawing.Size(118, 34);
            this.Quay3.TabIndex = 3;
            this.Quay3.Text = "Quầy 3";
            this.Quay3.UseVisualStyleBackColor = true;
            this.Quay3.Click += new System.EventHandler(this.Quay3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(322, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "Đăng nhập superUser";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.Location = new System.Drawing.Point(262, 252);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(70, 19);
            this.ID.TabIndex = 5;
            this.ID.Text = "Nhập ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(253, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Password:";
            // 
            // btn_ID
            // 
            this.btn_ID.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ID.Location = new System.Drawing.Point(356, 252);
            this.btn_ID.Name = "btn_ID";
            this.btn_ID.Size = new System.Drawing.Size(100, 27);
            this.btn_ID.TabIndex = 7;
            // 
            // btnPasWord
            // 
            this.btnPasWord.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPasWord.Location = new System.Drawing.Point(356, 292);
            this.btnPasWord.Name = "btnPasWord";
            this.btnPasWord.Size = new System.Drawing.Size(100, 27);
            this.btnPasWord.TabIndex = 8;
            this.btnPasWord.UseSystemPasswordChar = true;
            // 
            // DieuHuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnPasWord);
            this.Controls.Add(this.btn_ID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox btn_ID;
        private System.Windows.Forms.TextBox btnPasWord;
    }
}