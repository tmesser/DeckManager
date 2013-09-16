namespace DeckManagerOutput
{
    partial class PlayerRosterForm
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
            this.doneButton = new System.Windows.Forms.Button();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.characterListBoxLabel = new System.Windows.Forms.Label();
            this.playerNameTextBox = new System.Windows.Forms.TextBox();
            this.characterListBox = new System.Windows.Forms.ListBox();
            this.initialDrawGroupBox = new System.Windows.Forms.GroupBox();
            this.initialDrawComboBox3 = new System.Windows.Forms.ComboBox();
            this.initialDrawComboBox2 = new System.Windows.Forms.ComboBox();
            this.initialDrawComboBox1 = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addPlayerButton = new System.Windows.Forms.Button();
            this.characterDetailButton = new System.Windows.Forms.Button();
            this.playerRosterListBox = new System.Windows.Forms.ListBox();
            this.initialDrawGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // doneButton
            // 
            this.doneButton.Enabled = false;
            this.doneButton.Location = new System.Drawing.Point(255, 335);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 0;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.AutoSize = true;
            this.playerNameLabel.Location = new System.Drawing.Point(13, 13);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(70, 13);
            this.playerNameLabel.TabIndex = 1;
            this.playerNameLabel.Text = "Player Name:";
            // 
            // characterListBoxLabel
            // 
            this.characterListBoxLabel.AutoSize = true;
            this.characterListBoxLabel.Location = new System.Drawing.Point(12, 36);
            this.characterListBoxLabel.Name = "characterListBoxLabel";
            this.characterListBoxLabel.Size = new System.Drawing.Size(56, 13);
            this.characterListBoxLabel.TabIndex = 2;
            this.characterListBoxLabel.Text = "Character:";
            // 
            // playerNameTextBox
            // 
            this.playerNameTextBox.Location = new System.Drawing.Point(89, 10);
            this.playerNameTextBox.Name = "playerNameTextBox";
            this.playerNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.playerNameTextBox.TabIndex = 3;
            // 
            // characterListBox
            // 
            this.characterListBox.FormattingEnabled = true;
            this.characterListBox.Location = new System.Drawing.Point(12, 52);
            this.characterListBox.Name = "characterListBox";
            this.characterListBox.Size = new System.Drawing.Size(177, 82);
            this.characterListBox.TabIndex = 4;
            this.characterListBox.SelectedIndexChanged += new System.EventHandler(this.CharacterListBoxSelectedIndexChanged);
            // 
            // initialDrawGroupBox
            // 
            this.initialDrawGroupBox.Controls.Add(this.initialDrawComboBox3);
            this.initialDrawGroupBox.Controls.Add(this.initialDrawComboBox2);
            this.initialDrawGroupBox.Controls.Add(this.initialDrawComboBox1);
            this.initialDrawGroupBox.Location = new System.Drawing.Point(195, 37);
            this.initialDrawGroupBox.Name = "initialDrawGroupBox";
            this.initialDrawGroupBox.Size = new System.Drawing.Size(135, 97);
            this.initialDrawGroupBox.TabIndex = 5;
            this.initialDrawGroupBox.TabStop = false;
            this.initialDrawGroupBox.Text = "Initial Draw";
            // 
            // initialDrawComboBox3
            // 
            this.initialDrawComboBox3.FormattingEnabled = true;
            this.initialDrawComboBox3.Location = new System.Drawing.Point(7, 74);
            this.initialDrawComboBox3.Name = "initialDrawComboBox3";
            this.initialDrawComboBox3.Size = new System.Drawing.Size(121, 21);
            this.initialDrawComboBox3.TabIndex = 2;
            // 
            // initialDrawComboBox2
            // 
            this.initialDrawComboBox2.FormattingEnabled = true;
            this.initialDrawComboBox2.Location = new System.Drawing.Point(7, 47);
            this.initialDrawComboBox2.Name = "initialDrawComboBox2";
            this.initialDrawComboBox2.Size = new System.Drawing.Size(121, 21);
            this.initialDrawComboBox2.TabIndex = 1;
            // 
            // initialDrawComboBox1
            // 
            this.initialDrawComboBox1.FormattingEnabled = true;
            this.initialDrawComboBox1.Location = new System.Drawing.Point(7, 20);
            this.initialDrawComboBox1.Name = "initialDrawComboBox1";
            this.initialDrawComboBox1.Size = new System.Drawing.Size(121, 21);
            this.initialDrawComboBox1.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 335);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // addPlayerButton
            // 
            this.addPlayerButton.Enabled = false;
            this.addPlayerButton.Location = new System.Drawing.Point(255, 138);
            this.addPlayerButton.Name = "addPlayerButton";
            this.addPlayerButton.Size = new System.Drawing.Size(75, 23);
            this.addPlayerButton.TabIndex = 8;
            this.addPlayerButton.Text = "Add Player";
            this.addPlayerButton.UseVisualStyleBackColor = true;
            this.addPlayerButton.Click += new System.EventHandler(this.AddPlayerButtonClick);
            // 
            // characterDetailButton
            // 
            this.characterDetailButton.Enabled = false;
            this.characterDetailButton.Location = new System.Drawing.Point(12, 140);
            this.characterDetailButton.Name = "characterDetailButton";
            this.characterDetailButton.Size = new System.Drawing.Size(108, 23);
            this.characterDetailButton.TabIndex = 9;
            this.characterDetailButton.Text = "Character Details";
            this.characterDetailButton.UseVisualStyleBackColor = true;
            this.characterDetailButton.Click += new System.EventHandler(this.CharacterDetailButtonClick);
            // 
            // playerRosterListBox
            // 
            this.playerRosterListBox.FormattingEnabled = true;
            this.playerRosterListBox.Location = new System.Drawing.Point(12, 169);
            this.playerRosterListBox.Name = "playerRosterListBox";
            this.playerRosterListBox.Size = new System.Drawing.Size(318, 160);
            this.playerRosterListBox.TabIndex = 10;
            // 
            // PlayerRosterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 370);
            this.Controls.Add(this.playerRosterListBox);
            this.Controls.Add(this.characterDetailButton);
            this.Controls.Add(this.addPlayerButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.initialDrawGroupBox);
            this.Controls.Add(this.characterListBox);
            this.Controls.Add(this.playerNameTextBox);
            this.Controls.Add(this.characterListBoxLabel);
            this.Controls.Add(this.playerNameLabel);
            this.Controls.Add(this.doneButton);
            this.Name = "PlayerRosterForm";
            this.Text = "Player Roster";
            this.initialDrawGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void initialDrawComboBox3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        void initialDrawComboBox2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        void initialDrawComboBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        #endregion

        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.Label characterListBoxLabel;
        private System.Windows.Forms.TextBox playerNameTextBox;
        private System.Windows.Forms.ListBox characterListBox;
        private System.Windows.Forms.GroupBox initialDrawGroupBox;
        private System.Windows.Forms.ComboBox initialDrawComboBox3;
        private System.Windows.Forms.ComboBox initialDrawComboBox2;
        private System.Windows.Forms.ComboBox initialDrawComboBox1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addPlayerButton;
        private System.Windows.Forms.Button characterDetailButton;
        private System.Windows.Forms.ListBox playerRosterListBox;
    }
}