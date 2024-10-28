namespace Lab3
{
    partial class Server_Bai3
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
            this.txtServerMessages = new System.Windows.Forms.RichTextBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtServerMessages
            // 
            this.txtServerMessages.Location = new System.Drawing.Point(62, 136);
            this.txtServerMessages.Name = "txtServerMessages";
            this.txtServerMessages.Size = new System.Drawing.Size(679, 254);
            this.txtServerMessages.TabIndex = 0;
            this.txtServerMessages.Text = "";
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(619, 48);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(111, 42);
            this.btnListen.TabIndex = 1;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // Server_Bai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.txtServerMessages);
            this.Name = "Server_Bai3";
            this.Text = "Server_Bai3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtServerMessages;
        private System.Windows.Forms.Button btnListen;
    }
}