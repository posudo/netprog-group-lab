namespace web_server
{
    partial class Lab04_Bai03_ViewSource
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
            this.rtbShow = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbShow
            // 
            this.rtbShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbShow.Location = new System.Drawing.Point(0, 0);
            this.rtbShow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtbShow.Name = "rtbShow";
            this.rtbShow.Size = new System.Drawing.Size(600, 366);
            this.rtbShow.TabIndex = 0;
            this.rtbShow.Text = "";
            // 
            // Lab04_Bai03_ViewSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.rtbShow);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Lab04_Bai03_ViewSource";
            this.Text = "Lab04_Bai03_ViewSource";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbShow;
    }
}