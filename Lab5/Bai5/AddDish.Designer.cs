namespace Bai5
{
    partial class AddDish
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txbMota = new System.Windows.Forms.RichTextBox();
            this.txbHinhanh = new System.Windows.Forms.TextBox();
            this.txbDiachi = new System.Windows.Forms.TextBox();
            this.txbGia = new System.Windows.Forms.TextBox();
            this.txbMonan = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(524, 266);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(101, 83);
            this.btnClear.TabIndex = 44;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(524, 143);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(101, 77);
            this.btnThem.TabIndex = 43;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txbMota
            // 
            this.txbMota.Location = new System.Drawing.Point(185, 323);
            this.txbMota.Name = "txbMota";
            this.txbMota.Size = new System.Drawing.Size(282, 96);
            this.txbMota.TabIndex = 42;
            this.txbMota.Text = "";
            // 
            // txbHinhanh
            // 
            this.txbHinhanh.Location = new System.Drawing.Point(185, 266);
            this.txbHinhanh.Name = "txbHinhanh";
            this.txbHinhanh.Size = new System.Drawing.Size(282, 26);
            this.txbHinhanh.TabIndex = 41;
            // 
            // txbDiachi
            // 
            this.txbDiachi.Location = new System.Drawing.Point(185, 223);
            this.txbDiachi.Name = "txbDiachi";
            this.txbDiachi.Size = new System.Drawing.Size(282, 26);
            this.txbDiachi.TabIndex = 40;
            // 
            // txbGia
            // 
            this.txbGia.Location = new System.Drawing.Point(185, 171);
            this.txbGia.Name = "txbGia";
            this.txbGia.Size = new System.Drawing.Size(282, 26);
            this.txbGia.TabIndex = 39;
            // 
            // txbMonan
            // 
            this.txbMonan.Location = new System.Drawing.Point(185, 126);
            this.txbMonan.Name = "txbMonan";
            this.txbMonan.Size = new System.Drawing.Size(282, 26);
            this.txbMonan.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cambria", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.IndianRed;
            this.label11.Location = new System.Drawing.Point(177, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(276, 47);
            this.label11.TabIndex = 37;
            this.label11.Text = "Thêm Món Ăn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Mô tả";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Địa chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Hình ảnh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Gía";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Món ăn";
            // 
            // AddDish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txbMota);
            this.Controls.Add(this.txbHinhanh);
            this.Controls.Add(this.txbDiachi);
            this.Controls.Add(this.txbGia);
            this.Controls.Add(this.txbMonan);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddDish";
            this.Text = "AddDish";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.RichTextBox txbMota;
        private System.Windows.Forms.TextBox txbHinhanh;
        private System.Windows.Forms.TextBox txbDiachi;
        private System.Windows.Forms.TextBox txbGia;
        private System.Windows.Forms.TextBox txbMonan;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}