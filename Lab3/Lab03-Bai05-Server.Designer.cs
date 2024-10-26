namespace Lab3
{
    partial class Lab03_Bai05_Server
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
            this.richTextBox_chat = new System.Windows.Forms.RichTextBox();
            this.listBox_participants = new System.Windows.Forms.ListBox();
            this.textBox_send_chat = new System.Windows.Forms.TextBox();
            this.label_participants = new System.Windows.Forms.Label();
            this.button_send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox_chat
            // 
            this.richTextBox_chat.Location = new System.Drawing.Point(12, 12);
            this.richTextBox_chat.Name = "richTextBox_chat";
            this.richTextBox_chat.Size = new System.Drawing.Size(467, 501);
            this.richTextBox_chat.TabIndex = 0;
            this.richTextBox_chat.Text = "";
            // 
            // listBox_participants
            // 
            this.listBox_participants.FormattingEnabled = true;
            this.listBox_participants.Location = new System.Drawing.Point(497, 28);
            this.listBox_participants.Name = "listBox_participants";
            this.listBox_participants.Size = new System.Drawing.Size(139, 485);
            this.listBox_participants.TabIndex = 1;
            this.listBox_participants.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // textBox_send_chat
            // 
            this.textBox_send_chat.Location = new System.Drawing.Point(12, 519);
            this.textBox_send_chat.Multiline = true;
            this.textBox_send_chat.Name = "textBox_send_chat";
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
            this.button_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_send.Location = new System.Drawing.Point(497, 519);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(139, 42);
            this.button_send.TabIndex = 4;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            // 
            // Lab03_Bai05_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 582);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.label_participants);
            this.Controls.Add(this.textBox_send_chat);
            this.Controls.Add(this.listBox_participants);
            this.Controls.Add(this.richTextBox_chat);
            this.Name = "Lab03_Bai05_Server";
            this.Text = "Lab03_Bai05_Server";
            this.Load += new System.EventHandler(this.Lab03_Bai05_Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_chat;
        private System.Windows.Forms.ListBox listBox_participants;
        private System.Windows.Forms.TextBox textBox_send_chat;
        private System.Windows.Forms.Label label_participants;
        private System.Windows.Forms.Button button_send;
    }
}