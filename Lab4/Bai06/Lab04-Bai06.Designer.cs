namespace Bai06
{
    partial class Bai06
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
            this.btShow = new System.Windows.Forms.Button();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.tbToken = new System.Windows.Forms.TextBox();
            this.rtbShow = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btShow
            // 
            this.btShow.Location = new System.Drawing.Point(445, 15);
            this.btShow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btShow.Name = "btShow";
            this.btShow.Size = new System.Drawing.Size(88, 57);
            this.btShow.TabIndex = 0;
            this.btShow.Text = "SHOW";
            this.btShow.UseVisualStyleBackColor = true;
            this.btShow.Click += new System.EventHandler(this.btShow_Click);
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(131, 15);
            this.tbURL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(287, 22);
            this.tbURL.TabIndex = 1;
            this.tbURL.Text = "https://nt106.uitiot.vn/api/v1/user/me";
            // 
            // tbToken
            // 
            this.tbToken.Location = new System.Drawing.Point(131, 47);
            this.tbToken.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbToken.Name = "tbToken";
            this.tbToken.Size = new System.Drawing.Size(287, 22);
            this.tbToken.TabIndex = 2;
            // 
            // rtbShow
            // 
            this.rtbShow.Location = new System.Drawing.Point(16, 79);
            this.rtbShow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbShow.Name = "rtbShow";
            this.rtbShow.ReadOnly = true;
            this.rtbShow.Size = new System.Drawing.Size(516, 246);
            this.rtbShow.TabIndex = 3;
            this.rtbShow.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Token";
            // 
            // Bai06
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 340);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbShow);
            this.Controls.Add(this.tbToken);
            this.Controls.Add(this.tbURL);
            this.Controls.Add(this.btShow);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Bai06";
            this.Text = "Bai 6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btShow;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.TextBox tbToken;
        private System.Windows.Forms.RichTextBox rtbShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

