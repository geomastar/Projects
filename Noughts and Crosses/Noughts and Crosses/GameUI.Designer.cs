namespace Noughts_and_Crosses
{
    partial class GameUI
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
            this.square1Button = new System.Windows.Forms.Button();
            this.square2Button = new System.Windows.Forms.Button();
            this.square3Button = new System.Windows.Forms.Button();
            this.square4Button = new System.Windows.Forms.Button();
            this.square5Button = new System.Windows.Forms.Button();
            this.square6Button = new System.Windows.Forms.Button();
            this.square7Button = new System.Windows.Forms.Button();
            this.square8Button = new System.Windows.Forms.Button();
            this.square9Button = new System.Windows.Forms.Button();
            this.theCurrentPlayerIsLabel = new System.Windows.Forms.Label();
            this.currentPlayerLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // square1Button
            // 
            this.square1Button.Location = new System.Drawing.Point(100, 100);
            this.square1Button.Name = "square1Button";
            this.square1Button.Size = new System.Drawing.Size(100, 100);
            this.square1Button.TabIndex = 0;
            this.square1Button.UseVisualStyleBackColor = true;
            this.square1Button.Click += new System.EventHandler(this.square1Button_Click);
            // 
            // square2Button
            // 
            this.square2Button.Location = new System.Drawing.Point(250, 100);
            this.square2Button.Name = "square2Button";
            this.square2Button.Size = new System.Drawing.Size(100, 100);
            this.square2Button.TabIndex = 1;
            this.square2Button.UseVisualStyleBackColor = true;
            this.square2Button.Click += new System.EventHandler(this.square2Button_Click);
            // 
            // square3Button
            // 
            this.square3Button.Location = new System.Drawing.Point(400, 100);
            this.square3Button.Name = "square3Button";
            this.square3Button.Size = new System.Drawing.Size(100, 100);
            this.square3Button.TabIndex = 2;
            this.square3Button.UseVisualStyleBackColor = true;
            this.square3Button.Click += new System.EventHandler(this.square3Button_Click);
            // 
            // square4Button
            // 
            this.square4Button.Location = new System.Drawing.Point(100, 250);
            this.square4Button.Name = "square4Button";
            this.square4Button.Size = new System.Drawing.Size(100, 100);
            this.square4Button.TabIndex = 3;
            this.square4Button.UseVisualStyleBackColor = true;
            this.square4Button.Click += new System.EventHandler(this.square4Button_Click);
            // 
            // square5Button
            // 
            this.square5Button.Location = new System.Drawing.Point(250, 250);
            this.square5Button.Name = "square5Button";
            this.square5Button.Size = new System.Drawing.Size(100, 100);
            this.square5Button.TabIndex = 4;
            this.square5Button.UseVisualStyleBackColor = true;
            this.square5Button.Click += new System.EventHandler(this.square5Button_Click);
            // 
            // square6Button
            // 
            this.square6Button.Location = new System.Drawing.Point(400, 250);
            this.square6Button.Name = "square6Button";
            this.square6Button.Size = new System.Drawing.Size(100, 100);
            this.square6Button.TabIndex = 5;
            this.square6Button.UseVisualStyleBackColor = true;
            this.square6Button.Click += new System.EventHandler(this.square6Button_Click);
            // 
            // square7Button
            // 
            this.square7Button.Location = new System.Drawing.Point(100, 400);
            this.square7Button.Name = "square7Button";
            this.square7Button.Size = new System.Drawing.Size(100, 100);
            this.square7Button.TabIndex = 6;
            this.square7Button.UseVisualStyleBackColor = true;
            this.square7Button.Click += new System.EventHandler(this.square7Button_Click);
            // 
            // square8Button
            // 
            this.square8Button.Location = new System.Drawing.Point(250, 400);
            this.square8Button.Name = "square8Button";
            this.square8Button.Size = new System.Drawing.Size(100, 100);
            this.square8Button.TabIndex = 7;
            this.square8Button.UseVisualStyleBackColor = true;
            this.square8Button.Click += new System.EventHandler(this.square8Button_Click);
            // 
            // square9Button
            // 
            this.square9Button.Location = new System.Drawing.Point(400, 400);
            this.square9Button.Name = "square9Button";
            this.square9Button.Size = new System.Drawing.Size(100, 100);
            this.square9Button.TabIndex = 8;
            this.square9Button.UseVisualStyleBackColor = true;
            this.square9Button.Click += new System.EventHandler(this.square9Button_Click);
            // 
            // theCurrentPlayerIsLabel
            // 
            this.theCurrentPlayerIsLabel.AutoSize = true;
            this.theCurrentPlayerIsLabel.Location = new System.Drawing.Point(555, 13);
            this.theCurrentPlayerIsLabel.Name = "theCurrentPlayerIsLabel";
            this.theCurrentPlayerIsLabel.Size = new System.Drawing.Size(103, 13);
            this.theCurrentPlayerIsLabel.TabIndex = 9;
            this.theCurrentPlayerIsLabel.Text = "The current player is";
            // 
            // currentPlayerLabel
            // 
            this.currentPlayerLabel.AutoSize = true;
            this.currentPlayerLabel.Location = new System.Drawing.Point(684, 13);
            this.currentPlayerLabel.Name = "currentPlayerLabel";
            this.currentPlayerLabel.Size = new System.Drawing.Size(0, 13);
            this.currentPlayerLabel.TabIndex = 10;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(305, 13);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(108, 13);
            this.titleLabel.TabIndex = 12;
            this.titleLabel.Text = "Noughts and Crosses";
            // 
            // GameUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 533);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.currentPlayerLabel);
            this.Controls.Add(this.theCurrentPlayerIsLabel);
            this.Controls.Add(this.square9Button);
            this.Controls.Add(this.square8Button);
            this.Controls.Add(this.square7Button);
            this.Controls.Add(this.square6Button);
            this.Controls.Add(this.square5Button);
            this.Controls.Add(this.square4Button);
            this.Controls.Add(this.square3Button);
            this.Controls.Add(this.square2Button);
            this.Controls.Add(this.square1Button);
            this.Name = "GameUI";
            this.Text = "GameUI";
            this.Load += new System.EventHandler(this.GameUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button square1Button;
        private System.Windows.Forms.Button square2Button;
        private System.Windows.Forms.Button square3Button;
        private System.Windows.Forms.Button square4Button;
        private System.Windows.Forms.Button square5Button;
        private System.Windows.Forms.Button square6Button;
        private System.Windows.Forms.Button square7Button;
        private System.Windows.Forms.Button square8Button;
        private System.Windows.Forms.Button square9Button;
        private System.Windows.Forms.Label theCurrentPlayerIsLabel;
        private System.Windows.Forms.Label currentPlayerLabel;
        private System.Windows.Forms.Label titleLabel;
    }
}