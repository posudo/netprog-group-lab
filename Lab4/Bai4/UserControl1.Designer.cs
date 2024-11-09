namespace Bai4
{
    partial class MovieItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Poster = new System.Windows.Forms.PictureBox();
            this.MovieTitle = new System.Windows.Forms.Label();
            this.MovieURI = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Poster)).BeginInit();
            this.SuspendLayout();
            // 
            // Poster
            // 
            this.Poster.Location = new System.Drawing.Point(0, 0);
            this.Poster.Name = "Poster";
            this.Poster.Size = new System.Drawing.Size(137, 126);
            this.Poster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Poster.TabIndex = 0;
            this.Poster.TabStop = false;
            // 
            // MovieTitle
            // 
            this.MovieTitle.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovieTitle.ForeColor = System.Drawing.Color.Tomato;
            this.MovieTitle.Location = new System.Drawing.Point(143, 15);
            this.MovieTitle.Name = "MovieTitle";
            this.MovieTitle.Size = new System.Drawing.Size(450, 23);
            this.MovieTitle.TabIndex = 1;
            this.MovieTitle.Text = "Movie Title";
            this.MovieTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MovieURI
            // 
            this.MovieURI.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovieURI.Location = new System.Drawing.Point(143, 73);
            this.MovieURI.Name = "MovieURI";
            this.MovieURI.Size = new System.Drawing.Size(450, 23);
            this.MovieURI.TabIndex = 2;
            this.MovieURI.Text = "URI";
            this.MovieURI.Click += new System.EventHandler(this.MovieURI_Click);
            // 
            // MovieItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MovieURI);
            this.Controls.Add(this.MovieTitle);
            this.Controls.Add(this.Poster);
            this.Name = "MovieItemControl";
            this.Size = new System.Drawing.Size(700, 127);
            this.Load += new System.EventHandler(this.MovieItemControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Poster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Poster;
        private System.Windows.Forms.Label MovieTitle;
        private System.Windows.Forms.Label MovieURI;
    }
}
