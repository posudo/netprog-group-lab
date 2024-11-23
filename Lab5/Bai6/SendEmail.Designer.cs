namespace Bai6
{
    partial class SendEmail
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
            this.lbFrom = new System.Windows.Forms.Label();
            this.lbSubject = new System.Windows.Forms.Label();
            this.lbTo = new System.Windows.Forms.Label();
            this.lbBody = new System.Windows.Forms.Label();
            this.lbAttachment = new System.Windows.Forms.Label();
            this.btBrowse = new System.Windows.Forms.Button();
            this.btSend = new System.Windows.Forms.Button();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.tbTo = new System.Windows.Forms.TextBox();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.tbAttachment = new System.Windows.Forms.TextBox();
            this.cbHTML = new System.Windows.Forms.CheckBox();
            this.rtbBody = new System.Windows.Forms.RichTextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Location = new System.Drawing.Point(12, 19);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(30, 13);
            this.lbFrom.TabIndex = 0;
            this.lbFrom.Text = "From";
            // 
            // lbSubject
            // 
            this.lbSubject.AutoSize = true;
            this.lbSubject.Location = new System.Drawing.Point(12, 107);
            this.lbSubject.Name = "lbSubject";
            this.lbSubject.Size = new System.Drawing.Size(43, 13);
            this.lbSubject.TabIndex = 2;
            this.lbSubject.Text = "Subject";
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Location = new System.Drawing.Point(12, 81);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(20, 13);
            this.lbTo.TabIndex = 3;
            this.lbTo.Text = "To";
            // 
            // lbBody
            // 
            this.lbBody.AutoSize = true;
            this.lbBody.Location = new System.Drawing.Point(12, 133);
            this.lbBody.Name = "lbBody";
            this.lbBody.Size = new System.Drawing.Size(31, 13);
            this.lbBody.TabIndex = 4;
            this.lbBody.Text = "Body";
            // 
            // lbAttachment
            // 
            this.lbAttachment.AutoSize = true;
            this.lbAttachment.Location = new System.Drawing.Point(12, 499);
            this.lbAttachment.Name = "lbAttachment";
            this.lbAttachment.Size = new System.Drawing.Size(61, 13);
            this.lbAttachment.TabIndex = 5;
            this.lbAttachment.Text = "Attachment";
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(409, 493);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(75, 23);
            this.btBrowse.TabIndex = 6;
            this.btBrowse.Text = "Browse...";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(409, 533);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 7;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(83, 16);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.ReadOnly = true;
            this.tbFrom.Size = new System.Drawing.Size(401, 20);
            this.tbFrom.TabIndex = 8;
            // 
            // tbTo
            // 
            this.tbTo.Location = new System.Drawing.Point(83, 78);
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(401, 20);
            this.tbTo.TabIndex = 10;
            // 
            // tbSubject
            // 
            this.tbSubject.Location = new System.Drawing.Point(83, 104);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(401, 20);
            this.tbSubject.TabIndex = 11;
            // 
            // tbAttachment
            // 
            this.tbAttachment.Location = new System.Drawing.Point(83, 496);
            this.tbAttachment.Name = "tbAttachment";
            this.tbAttachment.ReadOnly = true;
            this.tbAttachment.Size = new System.Drawing.Size(320, 20);
            this.tbAttachment.TabIndex = 12;
            // 
            // cbHTML
            // 
            this.cbHTML.AutoSize = true;
            this.cbHTML.Location = new System.Drawing.Point(83, 133);
            this.cbHTML.Name = "cbHTML";
            this.cbHTML.Size = new System.Drawing.Size(56, 17);
            this.cbHTML.TabIndex = 13;
            this.cbHTML.Text = "HTML";
            this.cbHTML.UseVisualStyleBackColor = true;
            // 
            // rtbBody
            // 
            this.rtbBody.Location = new System.Drawing.Point(83, 156);
            this.rtbBody.Name = "rtbBody";
            this.rtbBody.Size = new System.Drawing.Size(401, 331);
            this.rtbBody.TabIndex = 14;
            this.rtbBody.Text = "";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(12, 45);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 15;
            this.lbName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(83, 42);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(401, 20);
            this.tbName.TabIndex = 16;
            // 
            // SendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 568);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.rtbBody);
            this.Controls.Add(this.cbHTML);
            this.Controls.Add(this.tbAttachment);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.tbTo);
            this.Controls.Add(this.tbFrom);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.lbAttachment);
            this.Controls.Add(this.lbBody);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.lbSubject);
            this.Controls.Add(this.lbFrom);
            this.Name = "SendEmail";
            this.Text = "SendEmail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Label lbSubject;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.Label lbBody;
        private System.Windows.Forms.Label lbAttachment;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.TextBox tbTo;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.TextBox tbAttachment;
        private System.Windows.Forms.CheckBox cbHTML;
        private System.Windows.Forms.RichTextBox rtbBody;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
    }
}