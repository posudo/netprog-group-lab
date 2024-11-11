namespace Bai7
{
    partial class HeThong
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
            this.btnThemmon = new System.Windows.Forms.Button();
            this.btnXoamon = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRandomDish = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tôiĐóngGópToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabellogout = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThemmon
            // 
            this.btnThemmon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnThemmon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemmon.Location = new System.Drawing.Point(417, 43);
            this.btnThemmon.Name = "btnThemmon";
            this.btnThemmon.Size = new System.Drawing.Size(154, 50);
            this.btnThemmon.TabIndex = 28;
            this.btnThemmon.Text = "Thêm món ăn";
            this.btnThemmon.UseVisualStyleBackColor = false;
            this.btnThemmon.Click += new System.EventHandler(this.btnThemmon_Click);
            // 
            // btnXoamon
            // 
            this.btnXoamon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnXoamon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoamon.Location = new System.Drawing.Point(613, 43);
            this.btnXoamon.Name = "btnXoamon";
            this.btnXoamon.Size = new System.Drawing.Size(125, 50);
            this.btnXoamon.TabIndex = 27;
            this.btnXoamon.Text = "Xoá món ăn";
            this.btnXoamon.UseVisualStyleBackColor = false;
            this.btnXoamon.Click += new System.EventHandler(this.btnXoamon_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(642, 595);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(61, 28);
            this.comboBox1.TabIndex = 26;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(573, 595);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "Page ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(108, 127);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(595, 437);
            this.tableLayoutPanel1.TabIndex = 24;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // btnRandomDish
            // 
            this.btnRandomDish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnRandomDish.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomDish.Location = new System.Drawing.Point(264, 43);
            this.btnRandomDish.Name = "btnRandomDish";
            this.btnRandomDish.Size = new System.Drawing.Size(125, 50);
            this.btnRandomDish.TabIndex = 23;
            this.btnRandomDish.Text = "Ăn gì giờ";
            this.btnRandomDish.UseVisualStyleBackColor = false;
            this.btnRandomDish.Click += new System.EventHandler(this.btnRandomDish_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.IndianRed;
            this.label11.Location = new System.Drawing.Point(15, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(212, 33);
            this.label11.TabIndex = 21;
            this.label11.Text = "HÔM NAY ĂN GÌ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.tôiĐóngGópToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(780, 33);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(48, 29);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // tôiĐóngGópToolStripMenuItem
            // 
            this.tôiĐóngGópToolStripMenuItem.Name = "tôiĐóngGópToolStripMenuItem";
            this.tôiĐóngGópToolStripMenuItem.Size = new System.Drawing.Size(136, 29);
            this.tôiĐóngGópToolStripMenuItem.Text = "Tôi đóng góp";
            this.tôiĐóngGópToolStripMenuItem.Click += new System.EventHandler(this.tôiĐóngGópToolStripMenuItem_Click);
            // 
            // linkLabellogout
            // 
            this.linkLabellogout.AutoSize = true;
            this.linkLabellogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabellogout.Location = new System.Drawing.Point(16, 594);
            this.linkLabellogout.Name = "linkLabellogout";
            this.linkLabellogout.Size = new System.Drawing.Size(72, 25);
            this.linkLabellogout.TabIndex = 29;
            this.linkLabellogout.TabStop = true;
            this.linkLabellogout.Text = "Logout";
            this.linkLabellogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabellogout_LinkClicked);
            // 
            // HeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 637);
            this.Controls.Add(this.linkLabellogout);
            this.Controls.Add(this.btnThemmon);
            this.Controls.Add(this.btnXoamon);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnRandomDish);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.menuStrip1);
            this.Name = "HeThong";
            this.Text = "Hôm nay ăn gì";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThemmon;
        private System.Windows.Forms.Button btnXoamon;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnRandomDish;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tôiĐóngGópToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabellogout;
    }
}