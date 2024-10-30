namespace Lab4
{
    partial class Form1
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
            this.Load = new System.Windows.Forms.Button();
            this.URL = new System.Windows.Forms.TextBox();
            this.Reload = new System.Windows.Forms.Button();
            this.Down_File = new System.Windows.Forms.Button();
            this.Down_Resources = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // Load
            // 
            this.Load.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Load.Location = new System.Drawing.Point(26, 30);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(83, 31);
            this.Load.TabIndex = 0;
            this.Load.Text = "Load";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // URL
            // 
            this.URL.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.URL.Location = new System.Drawing.Point(139, 30);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(460, 27);
            this.URL.TabIndex = 1;
            // 
            // Reload
            // 
            this.Reload.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reload.Location = new System.Drawing.Point(628, 30);
            this.Reload.Name = "Reload";
            this.Reload.Size = new System.Drawing.Size(83, 31);
            this.Reload.TabIndex = 2;
            this.Reload.Text = "Reload";
            this.Reload.UseVisualStyleBackColor = true;
            this.Reload.Click += new System.EventHandler(this.Reload_Click);
            // 
            // Down_File
            // 
            this.Down_File.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Down_File.Location = new System.Drawing.Point(484, 67);
            this.Down_File.Name = "Down_File";
            this.Down_File.Size = new System.Drawing.Size(115, 31);
            this.Down_File.TabIndex = 3;
            this.Down_File.Text = "Down File";
            this.Down_File.UseVisualStyleBackColor = true;
            this.Down_File.Click += new System.EventHandler(this.Down_File_Click);
            // 
            // Down_Resources
            // 
            this.Down_Resources.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Down_Resources.Location = new System.Drawing.Point(628, 67);
            this.Down_Resources.Name = "Down_Resources";
            this.Down_Resources.Size = new System.Drawing.Size(140, 31);
            this.Down_Resources.TabIndex = 4;
            this.Down_Resources.Text = "Down Resources";
            this.Down_Resources.UseVisualStyleBackColor = true;
            this.Down_Resources.Click += new System.EventHandler(this.Down_Resources_Click);
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(26, 121);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(742, 317);
            this.webView21.TabIndex = 5;
            this.webView21.ZoomFactor = 1D;
            this.webView21.Click += new System.EventHandler(this.webView21_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.Down_Resources);
            this.Controls.Add(this.Down_File);
            this.Controls.Add(this.Reload);
            this.Controls.Add(this.URL);
            this.Controls.Add(this.Load);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.TextBox URL;
        private System.Windows.Forms.Button Reload;
        private System.Windows.Forms.Button Down_File;
        private System.Windows.Forms.Button Down_Resources;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}

