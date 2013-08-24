namespace DeckManagerOutput
{
    partial class NewPlayerForm
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
            this.OKButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.playerNameTextBox = new System.Windows.Forms.TextBox();
            this.characterListBox = new System.Windows.Forms.ListBox();
            this.initialDrawGroupBox = new System.Windows.Forms.GroupBox();
            this.initialDrawComboBox1 = new System.Windows.Forms.ComboBox();
            this.initialDrawComboBox2 = new System.Windows.Forms.ComboBox();
            this.initialDrawComboBox3 = new System.Windows.Forms.ComboBox();
            this.characterAbilitiesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.initialDrawGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(493, 124);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "Done";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Character:";
            // 
            // playerNameTextBox
            // 
            this.playerNameTextBox.Location = new System.Drawing.Point(89, 10);
            this.playerNameTextBox.Name = "playerNameTextBox";
            this.playerNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.playerNameTextBox.TabIndex = 3;
            this.playerNameTextBox.Leave += new System.EventHandler(playerNameTextBox_Leave);
            // 
            // characterListBox
            // 
            this.characterListBox.FormattingEnabled = true;
            this.characterListBox.Location = new System.Drawing.Point(89, 36);
            this.characterListBox.Name = "characterListBox";
            this.characterListBox.Size = new System.Drawing.Size(100, 82);
            this.characterListBox.TabIndex = 4;
            this.characterListBox.SelectedIndexChanged += new System.EventHandler(this.characterListBox_SelectedIndexChanged);
            // 
            // initialDrawGroupBox
            // 
            this.initialDrawGroupBox.Controls.Add(this.initialDrawComboBox3);
            this.initialDrawGroupBox.Controls.Add(this.initialDrawComboBox2);
            this.initialDrawGroupBox.Controls.Add(this.initialDrawComboBox1);
            this.initialDrawGroupBox.Location = new System.Drawing.Point(196, 10);
            this.initialDrawGroupBox.Name = "initialDrawGroupBox";
            this.initialDrawGroupBox.Size = new System.Drawing.Size(135, 108);
            this.initialDrawGroupBox.TabIndex = 5;
            this.initialDrawGroupBox.TabStop = false;
            this.initialDrawGroupBox.Text = "Initial Draw";
            // 
            // initialDrawComboBox1
            // 
            this.initialDrawComboBox1.FormattingEnabled = true;
            this.initialDrawComboBox1.Location = new System.Drawing.Point(7, 20);
            this.initialDrawComboBox1.Name = "initialDrawComboBox1";
            this.initialDrawComboBox1.Size = new System.Drawing.Size(121, 21);
            this.initialDrawComboBox1.TabIndex = 0;
            // 
            // initialDrawComboBox2
            // 
            this.initialDrawComboBox2.FormattingEnabled = true;
            this.initialDrawComboBox2.Location = new System.Drawing.Point(7, 47);
            this.initialDrawComboBox2.Name = "initialDrawComboBox2";
            this.initialDrawComboBox2.Size = new System.Drawing.Size(121, 21);
            this.initialDrawComboBox2.TabIndex = 1;
            // 
            // initialDrawComboBox3
            // 
            this.initialDrawComboBox3.FormattingEnabled = true;
            this.initialDrawComboBox3.Location = new System.Drawing.Point(7, 74);
            this.initialDrawComboBox3.Name = "initialDrawComboBox3";
            this.initialDrawComboBox3.Size = new System.Drawing.Size(121, 21);
            this.initialDrawComboBox3.TabIndex = 2;
            // 
            // characterAbilitiesRichTextBox
            // 
            this.characterAbilitiesRichTextBox.Enabled = false;
            this.characterAbilitiesRichTextBox.Location = new System.Drawing.Point(338, 13);
            this.characterAbilitiesRichTextBox.Name = "characterAbilitiesRichTextBox";
            this.characterAbilitiesRichTextBox.Size = new System.Drawing.Size(230, 105);
            this.characterAbilitiesRichTextBox.TabIndex = 6;
            this.characterAbilitiesRichTextBox.Text = "";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(412, 123);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // NewPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 158);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.characterAbilitiesRichTextBox);
            this.Controls.Add(this.initialDrawGroupBox);
            this.Controls.Add(this.characterListBox);
            this.Controls.Add(this.playerNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OKButton);
            this.Name = "NewPlayerForm";
            this.Text = "NewPlayerForm";
            this.initialDrawGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox playerNameTextBox;
        private System.Windows.Forms.ListBox characterListBox;
        private System.Windows.Forms.GroupBox initialDrawGroupBox;
        private System.Windows.Forms.ComboBox initialDrawComboBox3;
        private System.Windows.Forms.ComboBox initialDrawComboBox2;
        private System.Windows.Forms.ComboBox initialDrawComboBox1;
        private System.Windows.Forms.RichTextBox characterAbilitiesRichTextBox;
        private System.Windows.Forms.Button cancelButton;
    }
}