namespace music
{
    partial class PlaylistEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaylistEditorForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addMusicButton = new System.Windows.Forms.Button();
            this.removeMusicButton = new System.Windows.Forms.Button();
            this.endButton = new System.Windows.Forms.Button();
            this.libraryCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.playlistCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.musicPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.PlaySelectedButton = new System.Windows.Forms.Button();
            this.totalLengthLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.musicPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Playlist Editor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Library";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(500, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Your Playlist";
            // 
            // addMusicButton
            // 
            this.addMusicButton.Location = new System.Drawing.Point(11, 260);
            this.addMusicButton.Name = "addMusicButton";
            this.addMusicButton.Size = new System.Drawing.Size(101, 50);
            this.addMusicButton.TabIndex = 10;
            this.addMusicButton.Text = "Add selected music to your playlist";
            this.addMusicButton.UseVisualStyleBackColor = true;
            this.addMusicButton.Click += new System.EventHandler(this.addMusicButton_Click);
            // 
            // removeMusicButton
            // 
            this.removeMusicButton.Location = new System.Drawing.Point(500, 260);
            this.removeMusicButton.Name = "removeMusicButton";
            this.removeMusicButton.Size = new System.Drawing.Size(101, 50);
            this.removeMusicButton.TabIndex = 11;
            this.removeMusicButton.Text = "Remove selected music from your playlist";
            this.removeMusicButton.UseVisualStyleBackColor = true;
            this.removeMusicButton.Click += new System.EventHandler(this.removeMusicButton_Click);
            // 
            // endButton
            // 
            this.endButton.Location = new System.Drawing.Point(871, 9);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(101, 50);
            this.endButton.TabIndex = 12;
            this.endButton.Text = "Save and Exit";
            this.endButton.UseVisualStyleBackColor = true;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // libraryCheckedListBox
            // 
            this.libraryCheckedListBox.FormattingEnabled = true;
            this.libraryCheckedListBox.Location = new System.Drawing.Point(11, 100);
            this.libraryCheckedListBox.MaximumSize = new System.Drawing.Size(400, 154);
            this.libraryCheckedListBox.MinimumSize = new System.Drawing.Size(400, 154);
            this.libraryCheckedListBox.Name = "libraryCheckedListBox";
            this.libraryCheckedListBox.Size = new System.Drawing.Size(400, 154);
            this.libraryCheckedListBox.TabIndex = 13;
            // 
            // playlistCheckedListBox
            // 
            this.playlistCheckedListBox.FormattingEnabled = true;
            this.playlistCheckedListBox.Location = new System.Drawing.Point(500, 100);
            this.playlistCheckedListBox.MaximumSize = new System.Drawing.Size(400, 154);
            this.playlistCheckedListBox.MinimumSize = new System.Drawing.Size(400, 154);
            this.playlistCheckedListBox.Name = "playlistCheckedListBox";
            this.playlistCheckedListBox.Size = new System.Drawing.Size(400, 154);
            this.playlistCheckedListBox.TabIndex = 14;
            // 
            // musicPlayer
            // 
            this.musicPlayer.Enabled = true;
            this.musicPlayer.Location = new System.Drawing.Point(500, 341);
            this.musicPlayer.MaximumSize = new System.Drawing.Size(400, 150);
            this.musicPlayer.MinimumSize = new System.Drawing.Size(400, 150);
            this.musicPlayer.Name = "musicPlayer";
            this.musicPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("musicPlayer.OcxState")));
            this.musicPlayer.Size = new System.Drawing.Size(400, 150);
            this.musicPlayer.TabIndex = 15;
            // 
            // PlaySelectedButton
            // 
            this.PlaySelectedButton.Location = new System.Drawing.Point(607, 260);
            this.PlaySelectedButton.Name = "PlaySelectedButton";
            this.PlaySelectedButton.Size = new System.Drawing.Size(101, 50);
            this.PlaySelectedButton.TabIndex = 16;
            this.PlaySelectedButton.Text = "Play Selected Music";
            this.PlaySelectedButton.UseVisualStyleBackColor = true;
            this.PlaySelectedButton.Click += new System.EventHandler(this.PlaySelectedButton_Click);
            // 
            // totalLengthLabel
            // 
            this.totalLengthLabel.AutoSize = true;
            this.totalLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLengthLabel.Location = new System.Drawing.Point(715, 261);
            this.totalLengthLabel.Name = "totalLengthLabel";
            this.totalLengthLabel.Size = new System.Drawing.Size(88, 16);
            this.totalLengthLabel.TabIndex = 17;
            this.totalLengthLabel.Text = "Total Length: ";
            // 
            // PlaylistEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 536);
            this.Controls.Add(this.totalLengthLabel);
            this.Controls.Add(this.PlaySelectedButton);
            this.Controls.Add(this.musicPlayer);
            this.Controls.Add(this.playlistCheckedListBox);
            this.Controls.Add(this.libraryCheckedListBox);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.removeMusicButton);
            this.Controls.Add(this.addMusicButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.MaximumSize = new System.Drawing.Size(1000, 575);
            this.MinimumSize = new System.Drawing.Size(1000, 575);
            this.Name = "PlaylistEditorForm";
            this.Text = "Playlist Creater: Playlist Editor";
            this.Load += new System.EventHandler(this.PlaylistEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.musicPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addMusicButton;
        private System.Windows.Forms.Button removeMusicButton;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.CheckedListBox libraryCheckedListBox;
        private System.Windows.Forms.CheckedListBox playlistCheckedListBox;
        private AxWMPLib.AxWindowsMediaPlayer musicPlayer;
        private System.Windows.Forms.Button PlaySelectedButton;
        private System.Windows.Forms.Label totalLengthLabel;
    }
}