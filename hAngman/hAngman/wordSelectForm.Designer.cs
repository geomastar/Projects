namespace hAngman
{
    partial class wordSelectForm
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
            this.wordSelectTextBox = new System.Windows.Forms.TextBox();
            this.playButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.enterWordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // wordSelectTextBox
            // 
            this.wordSelectTextBox.Location = new System.Drawing.Point(393, 181);
            this.wordSelectTextBox.Name = "wordSelectTextBox";
            this.wordSelectTextBox.Size = new System.Drawing.Size(100, 20);
            this.wordSelectTextBox.TabIndex = 1;
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(307, 321);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 2;
            this.playButton.Text = "Play!";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(315, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hang Man";
            // 
            // enterWordLabel
            // 
            this.enterWordLabel.AutoSize = true;
            this.enterWordLabel.Location = new System.Drawing.Point(208, 181);
            this.enterWordLabel.Name = "enterWordLabel";
            this.enterWordLabel.Size = new System.Drawing.Size(66, 13);
            this.enterWordLabel.TabIndex = 4;
            this.enterWordLabel.Text = "Type a word";
            // 
            // wordSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.enterWordLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.wordSelectTextBox);
            this.Name = "wordSelectForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.wordSelectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox wordSelectTextBox;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label enterWordLabel;
    }
}

