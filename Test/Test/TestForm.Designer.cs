namespace Test
{
    partial class TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.executionTextBox = new System.Windows.Forms.RichTextBox();
            this.startTestButton = new System.Windows.Forms.Button();
            this.executionLabel = new System.Windows.Forms.Label();
            this.deckBox1 = new System.Windows.Forms.RichTextBox();
            this.deckBox2 = new System.Windows.Forms.RichTextBox();
            this.deckBox3 = new System.Windows.Forms.RichTextBox();
            this.tenthCardLabel = new System.Windows.Forms.Label();
            this.penultimateCardLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.penCardPictureBox = new System.Windows.Forms.PictureBox();
            this.tenthCardPictureBox = new System.Windows.Forms.PictureBox();
            this.startGameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.penCardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenthCardPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // executionTextBox
            // 
            resources.ApplyResources(this.executionTextBox, "executionTextBox");
            this.executionTextBox.Name = "executionTextBox";
            this.executionTextBox.ReadOnly = true;
            // 
            // startTestButton
            // 
            this.startTestButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.startTestButton, "startTestButton");
            this.startTestButton.Name = "startTestButton";
            this.startTestButton.UseVisualStyleBackColor = false;
            this.startTestButton.Click += new System.EventHandler(this.startTestButton_Click);
            // 
            // executionLabel
            // 
            resources.ApplyResources(this.executionLabel, "executionLabel");
            this.executionLabel.Name = "executionLabel";
            // 
            // deckBox1
            // 
            resources.ApplyResources(this.deckBox1, "deckBox1");
            this.deckBox1.Name = "deckBox1";
            this.deckBox1.ReadOnly = true;
            // 
            // deckBox2
            // 
            resources.ApplyResources(this.deckBox2, "deckBox2");
            this.deckBox2.Name = "deckBox2";
            this.deckBox2.ReadOnly = true;
            // 
            // deckBox3
            // 
            resources.ApplyResources(this.deckBox3, "deckBox3");
            this.deckBox3.Name = "deckBox3";
            this.deckBox3.ReadOnly = true;
            // 
            // tenthCardLabel
            // 
            resources.ApplyResources(this.tenthCardLabel, "tenthCardLabel");
            this.tenthCardLabel.Name = "tenthCardLabel";
            // 
            // penultimateCardLabel
            // 
            resources.ApplyResources(this.penultimateCardLabel, "penultimateCardLabel");
            this.penultimateCardLabel.Name = "penultimateCardLabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // penCardPictureBox
            // 
            resources.ApplyResources(this.penCardPictureBox, "penCardPictureBox");
            this.penCardPictureBox.Name = "penCardPictureBox";
            this.penCardPictureBox.TabStop = false;
            // 
            // tenthCardPictureBox
            // 
            resources.ApplyResources(this.tenthCardPictureBox, "tenthCardPictureBox");
            this.tenthCardPictureBox.Name = "tenthCardPictureBox";
            this.tenthCardPictureBox.TabStop = false;
            // 
            // startGameButton
            // 
            this.startGameButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.startGameButton, "startGameButton");
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.UseVisualStyleBackColor = false;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // Test
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.penCardPictureBox);
            this.Controls.Add(this.tenthCardPictureBox);
            this.Controls.Add(this.penultimateCardLabel);
            this.Controls.Add(this.tenthCardLabel);
            this.Controls.Add(this.deckBox3);
            this.Controls.Add(this.deckBox2);
            this.Controls.Add(this.deckBox1);
            this.Controls.Add(this.executionLabel);
            this.Controls.Add(this.startTestButton);
            this.Controls.Add(this.executionTextBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Test";
            ((System.ComponentModel.ISupportInitialize)(this.penCardPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenthCardPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox executionTextBox;
        private System.Windows.Forms.Button startTestButton;
        private System.Windows.Forms.Label executionLabel;
        private System.Windows.Forms.RichTextBox deckBox1;
        private System.Windows.Forms.RichTextBox deckBox2;
        private System.Windows.Forms.RichTextBox deckBox3;
        private System.Windows.Forms.Label tenthCardLabel;
        private System.Windows.Forms.Label penultimateCardLabel;
        private System.Windows.Forms.PictureBox tenthCardPictureBox;
        private System.Windows.Forms.PictureBox penCardPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button startGameButton;
    }
}

