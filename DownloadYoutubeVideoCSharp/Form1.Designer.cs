namespace DownloadYoutubeVideoCSharp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_download_YT = new Button();
            textbox_link = new TextBox();
            label_yt_link = new Label();
            checkBox_NeedLowQualityWithSound = new CheckBox();
            checkBox_NeedHighQuality = new CheckBox();
            SuspendLayout();
            // 
            // button_download_YT
            // 
            button_download_YT.Font = new Font("Microsoft JhengHei UI", 12F);
            button_download_YT.Location = new Point(493, 50);
            button_download_YT.Name = "button_download_YT";
            button_download_YT.Size = new Size(99, 31);
            button_download_YT.TabIndex = 0;
            button_download_YT.Text = "Download";
            button_download_YT.UseVisualStyleBackColor = true;
            button_download_YT.Click += button_download_YT_Click;
            // 
            // textbox_link
            // 
            textbox_link.Font = new Font("Microsoft JhengHei UI", 12F);
            textbox_link.ForeColor = Color.Gray;
            textbox_link.Location = new Point(134, 16);
            textbox_link.Name = "textbox_link";
            textbox_link.Size = new Size(458, 28);
            textbox_link.TabIndex = 2;
            textbox_link.Text = "Enter youtube URL here...";
            textbox_link.MouseClick += textbox_link_MouseClick;
            textbox_link.TextChanged += textbox_link_TextChanged;
            textbox_link.Enter += textbox_link_Enter;
            textbox_link.Leave += textbox_link_Leave;
            // 
            // label_yt_link
            // 
            label_yt_link.AutoSize = true;
            label_yt_link.BackColor = SystemColors.Control;
            label_yt_link.Font = new Font("Microsoft JhengHei UI", 12F);
            label_yt_link.ForeColor = SystemColors.ControlText;
            label_yt_link.Location = new Point(12, 19);
            label_yt_link.Name = "label_yt_link";
            label_yt_link.Size = new Size(116, 20);
            label_yt_link.TabIndex = 2;
            label_yt_link.Text = "YouTube Link:";
            // 
            // checkBox_NeedLowQualityWithSound
            // 
            checkBox_NeedLowQualityWithSound.AutoSize = true;
            checkBox_NeedLowQualityWithSound.Checked = true;
            checkBox_NeedLowQualityWithSound.CheckState = CheckState.Checked;
            checkBox_NeedLowQualityWithSound.Location = new Point(17, 56);
            checkBox_NeedLowQualityWithSound.Name = "checkBox_NeedLowQualityWithSound";
            checkBox_NeedLowQualityWithSound.Size = new Size(162, 22);
            checkBox_NeedLowQualityWithSound.TabIndex = 3;
            checkBox_NeedLowQualityWithSound.Text = "Low Quality (Sound)";
            checkBox_NeedLowQualityWithSound.UseVisualStyleBackColor = true;
            // 
            // checkBox_NeedHighQuality
            // 
            checkBox_NeedHighQuality.AutoSize = true;
            checkBox_NeedHighQuality.Checked = true;
            checkBox_NeedHighQuality.CheckState = CheckState.Checked;
            checkBox_NeedHighQuality.Location = new Point(185, 56);
            checkBox_NeedHighQuality.Name = "checkBox_NeedHighQuality";
            checkBox_NeedHighQuality.Size = new Size(190, 22);
            checkBox_NeedHighQuality.TabIndex = 4;
            checkBox_NeedHighQuality.Text = "High Quality (no Sound)";
            checkBox_NeedHighQuality.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 91);
            Controls.Add(checkBox_NeedHighQuality);
            Controls.Add(checkBox_NeedLowQualityWithSound);
            Controls.Add(label_yt_link);
            Controls.Add(textbox_link);
            Controls.Add(button_download_YT);
            Font = new Font("Microsoft JhengHei UI", 10F);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_download_YT;
        private TextBox textbox_link;
        private Label label_yt_link;
        private CheckBox checkBox_NeedLowQualityWithSound;
        private CheckBox checkBox_NeedHighQuality;
    }
}
