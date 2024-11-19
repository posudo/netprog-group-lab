namespace web_server
{
    partial class Form3
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
            this.button_reload = new System.Windows.Forms.Button();
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.button_files = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.button_resources = new System.Windows.Forms.Button();
            this.webShow = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.button_view = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.webShow)).BeginInit();
            this.SuspendLayout();
            // 
            // button_reload
            // 
            this.button_reload.Location = new System.Drawing.Point(278, 10);
            this.button_reload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_reload.Name = "button_reload";
            this.button_reload.Size = new System.Drawing.Size(56, 19);
            this.button_reload.TabIndex = 8;
            this.button_reload.Text = "Reload";
            this.button_reload.UseVisualStyleBackColor = true;
            this.button_reload.Click += new System.EventHandler(this.button_reload_Click);
            // 
            // textBox_url
            // 
            this.textBox_url.Location = new System.Drawing.Point(70, 10);
            this.textBox_url.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_url.Name = "textBox_url";
            this.textBox_url.Size = new System.Drawing.Size(205, 20);
            this.textBox_url.TabIndex = 7;
            // 
            // button_files
            // 
            this.button_files.Location = new System.Drawing.Point(339, 10);
            this.button_files.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_files.Name = "button_files";
            this.button_files.Size = new System.Drawing.Size(85, 19);
            this.button_files.TabIndex = 11;
            this.button_files.Text = "Down files";
            this.button_files.UseVisualStyleBackColor = true;
            this.button_files.Click += new System.EventHandler(this.button_files_Click);
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(9, 10);
            this.button_load.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(56, 19);
            this.button_load.TabIndex = 12;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_resources
            // 
            this.button_resources.Location = new System.Drawing.Point(428, 10);
            this.button_resources.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_resources.Name = "button_resources";
            this.button_resources.Size = new System.Drawing.Size(95, 19);
            this.button_resources.TabIndex = 13;
            this.button_resources.Text = "Down resources";
            this.button_resources.UseVisualStyleBackColor = true;
            this.button_resources.Click += new System.EventHandler(this.button_resources_Click);
            // 
            // webShow
            // 
            this.webShow.AllowExternalDrop = true;
            this.webShow.CreationProperties = null;
            this.webShow.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webShow.Location = new System.Drawing.Point(0, 33);
            this.webShow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.webShow.Name = "webShow";
            this.webShow.Size = new System.Drawing.Size(712, 474);
            this.webShow.TabIndex = 14;
            this.webShow.ZoomFactor = 1D;
            // 
            // button_view
            // 
            this.button_view.Location = new System.Drawing.Point(526, 10);
            this.button_view.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_view.Name = "button_view";
            this.button_view.Size = new System.Drawing.Size(74, 19);
            this.button_view.TabIndex = 15;
            this.button_view.Text = "View source";
            this.button_view.UseVisualStyleBackColor = true;
            this.button_view.Click += new System.EventHandler(this.button_view_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(606, 10);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(94, 18);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 16;
            this.progressBar1.Visible = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 508);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_view);
            this.Controls.Add(this.webShow);
            this.Controls.Add(this.button_resources);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.button_files);
            this.Controls.Add(this.button_reload);
            this.Controls.Add(this.textBox_url);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_reload;
        private System.Windows.Forms.TextBox textBox_url;
        private System.Windows.Forms.Button button_files;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_resources;
        private Microsoft.Web.WebView2.WinForms.WebView2 webShow;
        private System.Windows.Forms.Button button_view;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}