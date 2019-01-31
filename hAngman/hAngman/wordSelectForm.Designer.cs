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
            this.rndWordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wordSelectTextBox
            // 
            this.wordSelectTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordSelectTextBox.Location = new System.Drawing.Point(110, 100);
            this.wordSelectTextBox.Name = "wordSelectTextBox";
            this.wordSelectTextBox.Size = new System.Drawing.Size(140, 26);
            this.wordSelectTextBox.TabIndex = 1;
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(10, 150);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hang Man";
            // 
            // enterWordLabel
            // 
            this.enterWordLabel.AutoSize = true;
            this.enterWordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterWordLabel.Location = new System.Drawing.Point(10, 100);
            this.enterWordLabel.Name = "enterWordLabel";
            this.enterWordLabel.Size = new System.Drawing.Size(94, 20);
            this.enterWordLabel.TabIndex = 4;
            this.enterWordLabel.Text = "Type a word";
            // 
            // rndWordButton
            // 
            this.rndWordButton.Location = new System.Drawing.Point(100, 150);
            this.rndWordButton.Name = "rndWordButton";
            this.rndWordButton.Size = new System.Drawing.Size(150, 23);
            this.rndWordButton.TabIndex = 5;
            this.rndWordButton.Text = "Generate Random Word!";
            this.rndWordButton.UseVisualStyleBackColor = true;
            this.rndWordButton.Click += new System.EventHandler(this.rndWordButton_Click);
            // 
            // wordSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 211);
            this.Controls.Add(this.rndWordButton);
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
        private System.Windows.Forms.Button rndWordButton;
    }
}

