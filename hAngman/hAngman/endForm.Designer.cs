namespace hAngman
{
    partial class endForm
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
            this.endButton = new System.Windows.Forms.Button();
            this.endLabel = new System.Windows.Forms.Label();
            this.replayButton = new System.Windows.Forms.Button();
            this.hangmanPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.hangmanPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // endButton
            // 
            this.endButton.Location = new System.Drawing.Point(97, 340);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(75, 23);
            this.endButton.TabIndex = 3;
            this.endButton.Text = "End";
            this.endButton.UseVisualStyleBackColor = true;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Location = new System.Drawing.Point(94, 191);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(43, 13);
            this.endLabel.TabIndex = 2;
            this.endLabel.Text = "Result: ";
            // 
            // replayButton
            // 
            this.replayButton.Location = new System.Drawing.Point(218, 340);
            this.replayButton.Name = "replayButton";
            this.replayButton.Size = new System.Drawing.Size(75, 23);
            this.replayButton.TabIndex = 4;
            this.replayButton.Text = "Play Again";
            this.replayButton.UseVisualStyleBackColor = true;
            this.replayButton.Click += new System.EventHandler(this.replayButton_Click);
            // 
            // hangmanPictureBox
            // 
            this.hangmanPictureBox.Location = new System.Drawing.Point(492, 35);
            this.hangmanPictureBox.Name = "hangmanPictureBox";
            this.hangmanPictureBox.Size = new System.Drawing.Size(500, 500);
            this.hangmanPictureBox.TabIndex = 36;
            this.hangmanPictureBox.TabStop = false;
            // 
            // endForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 557);
            this.Controls.Add(this.hangmanPictureBox);
            this.Controls.Add(this.replayButton);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.endLabel);
            this.Name = "endForm";
            this.Text = "endForm";
            this.Load += new System.EventHandler(this.endForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hangmanPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Button replayButton;
        private System.Windows.Forms.PictureBox hangmanPictureBox;
    }
}