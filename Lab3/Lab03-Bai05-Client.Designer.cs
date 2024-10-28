namespace Lab3
{
    partial class Lab03_Bai05_Client
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
            this.listBox_participants = new System.Windows.Forms.ListBox();
            this.textBox_send_chat = new System.Windows.Forms.TextBox();
            this.label_participants = new System.Windows.Forms.Label();
            this.button_send = new System.Windows.Forms.Button();
            this.button_send_files = new System.Windows.Forms.Button();
            this.button_private_chat = new System.Windows.Forms.Button();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.label_username = new System.Windows.Forms.Label();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.richTextBox_chat = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // listBox_participants
            // 
            this.listBox_participants.FormattingEnabled = true;
            this.listBox_participants.Location = new System.Drawing.Point(497, 25);
            this.listBox_participants.Name = "listBox_participants";
            this.listBox_participants.Size = new System.Drawing.Size(139, 394);
            this.listBox_participants.TabIndex = 1;
            // 
            // textBox_send_chat
            // 
            this.textBox_send_chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_send_chat.Location = new System.Drawing.Point(12, 519);
            this.textBox_send_chat.Multiline = true;
            this.textBox_send_chat.Name = "textBox_send_chat";
            this.textBox_send_chat.ReadOnly = true;
            this.textBox_send_chat.Size = new System.Drawing.Size(467, 42);
            this.textBox_send_chat.TabIndex = 2;
            // 
            // label_participants
            // 
            this.label_participants.AutoSize = true;
            this.label_participants.Location = new System.Drawing.Point(494, 9);
            this.label_participants.Name = "label_participants";
            this.label_participants.Size = new System.Drawing.Size(62, 13);
            this.label_participants.TabIndex = 3;
            this.label_participants.Text = "Participants";
            // 
            // button_send
            // 
            this.button_send.Enabled = false;
            this.button_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_send.Location = new System.Drawing.Point(497, 519);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(139, 42);
            this.button_send.TabIndex = 4;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_send_files
            // 
            this.button_send_files.Enabled = false;
            this.button_send_files.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_send_files.Location = new System.Drawing.Point(497, 471);
            this.button_send_files.Name = "button_send_files";
            this.button_send_files.Size = new System.Drawing.Size(139, 42);
            this.button_send_files.TabIndex = 5;
            this.button_send_files.Text = "Send files";
            this.button_send_files.UseVisualStyleBackColor = true;
            this.button_send_files.Click += new System.EventHandler(this.button_send_files_Click);
            // 
            // button_private_chat
            // 
            this.button_private_chat.Enabled = false;
            this.button_private_chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_private_chat.Location = new System.Drawing.Point(497, 425);
            this.button_private_chat.Name = "button_private_chat";
            this.button_private_chat.Size = new System.Drawing.Size(139, 42);
            this.button_private_chat.TabIndex = 6;
            this.button_private_chat.Text = "Private chat";
            this.button_private_chat.UseVisualStyleBackColor = true;
            this.button_private_chat.Click += new System.EventHandler(this.button_private_chat_Click);
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(70, 483);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(130, 20);
            this.textBox_username.TabIndex = 7;
            this.textBox_username.Text = "Unknown";
            // 
            // button_connect
            // 
            this.button_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_connect.ForeColor = System.Drawing.Color.Red;
            this.button_connect.Location = new System.Drawing.Point(265, 477);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(104, 30);
            this.button_connect.TabIndex = 8;
            this.button_connect.Text = "CONNECT!";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Location = new System.Drawing.Point(9, 486);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(55, 13);
            this.label_username.TabIndex = 9;
            this.label_username.Text = "Username";
            // 
            // button_disconnect
            // 
            this.button_disconnect.Enabled = false;
            this.button_disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_disconnect.ForeColor = System.Drawing.Color.Red;
            this.button_disconnect.Location = new System.Drawing.Point(375, 477);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(104, 30);
            this.button_disconnect.TabIndex = 10;
            this.button_disconnect.Text = "DISCONNECT!";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // richTextBox_chat
            // 
            this.richTextBox_chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_chat.Location = new System.Drawing.Point(12, 12);
            this.richTextBox_chat.Name = "richTextBox_chat";
            this.richTextBox_chat.ReadOnly = true;
            this.richTextBox_chat.Size = new System.Drawing.Size(467, 459);
            this.richTextBox_chat.TabIndex = 0;
            this.richTextBox_chat.Text = "";
            // 
            // Lab03_Bai05_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 582);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.button_private_chat);
            this.Controls.Add(this.button_send_files);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.label_participants);
            this.Controls.Add(this.textBox_send_chat);
            this.Controls.Add(this.listBox_participants);
            this.Controls.Add(this.richTextBox_chat);
            this.Name = "Lab03_Bai05_Client";
            this.Text = "Lab03_Bai05_Client";
            this.Load += new System.EventHandler(this.Lab03_Bai05_Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox_participants;
        private System.Windows.Forms.TextBox textBox_send_chat;
        private System.Windows.Forms.Label label_participants;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_send_files;
        private System.Windows.Forms.Button button_private_chat;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.RichTextBox richTextBox_chat;
    }
}