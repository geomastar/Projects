namespace hAngman
{
    partial class errorForm
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
            this.errorLabel = new System.Windows.Forms.Label();
            this.errorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(155, 164);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(547, 13);
            this.errorLabel.TabIndex = 0;
            this.errorLabel.Text = "ERROR: Please make sure that the word you entered only contains letters. It must " +
    "also be between 3 and 9 letters.";
            // 
            // errorButton
            // 
            this.errorButton.Location = new System.Drawing.Point(318, 306);
            this.errorButton.Name = "errorButton";
            this.errorButton.Size = new System.Drawing.Size(75, 23);
            this.errorButton.TabIndex = 1;
            this.errorButton.Text = "OK";
            this.errorButton.UseVisualStyleBackColor = true;
            this.errorButton.Click += new System.EventHandler(this.errorButton_Click);
            // 
            // errorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.errorButton);
            this.Controls.Add(this.errorLabel);
            this.Name = "errorForm";
            this.Text = "errorForm";
            this.Load += new System.EventHandler(this.errorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button errorButton;
    }
}