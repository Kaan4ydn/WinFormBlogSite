namespace WinFormBlogSite
{
    partial class MainForm
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
            label1 = new Label();
            txtTitle = new TextBox();
            pbPostPicture = new PictureBox();
            label2 = new Label();
            rtbContent = new RichTextBox();
            btnPost = new Button();
            lfpPosts = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pbPostPicture).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 0;
            label1.Text = "Title:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(58, 6);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(320, 23);
            txtTitle.TabIndex = 1;
            // 
            // pbPostPicture
            // 
            pbPostPicture.BackColor = SystemColors.ActiveCaption;
            pbPostPicture.Location = new Point(12, 46);
            pbPostPicture.Name = "pbPostPicture";
            pbPostPicture.Size = new Size(366, 242);
            pbPostPicture.TabIndex = 2;
            pbPostPicture.TabStop = false;
            pbPostPicture.Click += pbContent_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 309);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 3;
            label2.Text = "Content:";
            // 
            // rtbContent
            // 
            rtbContent.Location = new Point(71, 309);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(307, 230);
            rtbContent.TabIndex = 4;
            rtbContent.Text = "";
            // 
            // btnPost
            // 
            btnPost.Location = new Point(212, 560);
            btnPost.Name = "btnPost";
            btnPost.Size = new Size(166, 58);
            btnPost.TabIndex = 5;
            btnPost.Text = "ADD";
            btnPost.UseVisualStyleBackColor = true;
            btnPost.Click += btnPost_Click;
            // 
            // lfpPosts
            // 
            lfpPosts.Location = new Point(396, 6);
            lfpPosts.Name = "lfpPosts";
            lfpPosts.Size = new Size(820, 612);
            lfpPosts.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1228, 633);
            Controls.Add(lfpPosts);
            Controls.Add(btnPost);
            Controls.Add(rtbContent);
            Controls.Add(label2);
            Controls.Add(pbPostPicture);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)pbPostPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private PictureBox pbPostPicture;
        private Label label2;
        private RichTextBox rtbContent;
        private Button btnPost;
        private FlowLayoutPanel lfpPosts;
    }
}