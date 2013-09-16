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
            this.initialDrawGroupBox = new System.Windows.Forms.GroupBox();
            this.initialDrawComboBox3 = new System.Windows.Forms.ComboBox();
            this.initialDrawComboBox2 = new System.Windows.Forms.ComboBox();
            this.initialDrawComboBox1 = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.playerRosterListBox = new System.Windows.Forms.ListBox();
            this.Layout = new System.Windows.Forms.TableLayoutPanel();
            this.characterDetailButton = new System.Windows.Forms.Button();
            this.characterListBox = new System.Windows.Forms.ListBox();
            this.addPlayerButton = new System.Windows.Forms.Button();
            this.initialDrawGroupBox.SuspendLayout();
            this.Layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // doneButton
            // 
            this.doneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doneButton.Enabled = false;
            this.doneButton.Location = new System.Drawing.Point(231, 287);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 0;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.playerNameLabel.AutoSize = true;
            this.playerNameLabel.Location = new System.Drawing.Point(86, 6);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(70, 13);
            this.playerNameLabel.TabIndex = 1;
            this.playerNameLabel.Text = "Player Name:";
            // 
            // characterListBoxLabel
            // 
            this.characterListBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.characterListBoxLabel.AutoSize = true;
            this.characterListBoxLabel.Location = new System.Drawing.Point(3, 37);
            this.characterListBoxLabel.Name = "characterListBoxLabel";
            this.characterListBoxLabel.Size = new System.Drawing.Size(56, 13);
            this.characterListBoxLabel.TabIndex = 2;
            this.characterListBoxLabel.Text = "Character:";
            // 
            // playerNameTextBox
            // 
            this.playerNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.playerNameTextBox.Location = new System.Drawing.Point(162, 3);
            this.playerNameTextBox.Name = "playerNameTextBox";
            this.playerNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.playerNameTextBox.TabIndex = 3;
            // 
            // initialDrawGroupBox
            // 
            this.initialDrawGroupBox.Controls.Add(this.initialDrawComboBox3);
            this.initialDrawGroupBox.Controls.Add(this.initialDrawComboBox2);
            this.initialDrawGroupBox.Controls.Add(this.initialDrawComboBox1);
            this.initialDrawGroupBox.Location = new System.Drawing.Point(162, 53);
            this.initialDrawGroupBox.Name = "initialDrawGroupBox";
            this.initialDrawGroupBox.Size = new System.Drawing.Size(135, 104);
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
            this.cancelButton.Location = new System.Drawing.Point(3, 287);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // playerRosterListBox
            // 
            this.Layout.SetColumnSpan(this.playerRosterListBox, 2);
            this.playerRosterListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerRosterListBox.FormattingEnabled = true;
            this.playerRosterListBox.Location = new System.Drawing.Point(3, 246);
            this.playerRosterListBox.Name = "playerRosterListBox";
            this.playerRosterListBox.Size = new System.Drawing.Size(303, 35);
            this.playerRosterListBox.TabIndex = 10;
            // 
            // Layout
            // 
            this.Layout.ColumnCount = 2;
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.Layout.Controls.Add(this.playerNameLabel, 0, 0);
            this.Layout.Controls.Add(this.doneButton, 1, 5);
            this.Layout.Controls.Add(this.cancelButton, 0, 5);
            this.Layout.Controls.Add(this.playerRosterListBox, 0, 4);
            this.Layout.Controls.Add(this.playerNameTextBox, 1, 0);
            this.Layout.Controls.Add(this.characterDetailButton, 0, 3);
            this.Layout.Controls.Add(this.characterListBox, 0, 2);
            this.Layout.Controls.Add(this.addPlayerButton, 1, 3);
            this.Layout.Controls.Add(this.characterListBoxLabel, 0, 1);
            this.Layout.Controls.Add(this.initialDrawGroupBox, 1, 2);
            this.Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Layout.Location = new System.Drawing.Point(0, 0);
            this.Layout.Name = "Layout";
            this.Layout.RowCount = 6;
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.Layout.Size = new System.Drawing.Size(309, 315);
            this.Layout.TabIndex = 11;
            // 
            // characterDetailButton
            // 
            this.characterDetailButton.Enabled = false;
            this.characterDetailButton.Location = new System.Drawing.Point(3, 217);
            this.characterDetailButton.Name = "characterDetailButton";
            this.characterDetailButton.Size = new System.Drawing.Size(108, 23);
            this.characterDetailButton.TabIndex = 9;
            this.characterDetailButton.Text = "Character Details";
            this.characterDetailButton.UseVisualStyleBackColor = true;
            this.characterDetailButton.Click += new System.EventHandler(this.CharacterDetailButtonClick);
            // 
            // characterListBox
            // 
            this.characterListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.characterListBox.FormattingEnabled = true;
            this.characterListBox.Location = new System.Drawing.Point(3, 53);
            this.characterListBox.Name = "characterListBox";
            this.characterListBox.Size = new System.Drawing.Size(153, 158);
            this.characterListBox.TabIndex = 5;
            this.characterListBox.SelectedIndexChanged += new System.EventHandler(this.CharacterListBoxSelectedIndexChanged);
            // 
            // addPlayerButton
            // 
            this.addPlayerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addPlayerButton.Enabled = false;
            this.addPlayerButton.Location = new System.Drawing.Point(231, 217);
            this.addPlayerButton.Name = "addPlayerButton";
            this.addPlayerButton.Size = new System.Drawing.Size(75, 23);
            this.addPlayerButton.TabIndex = 8;
            this.addPlayerButton.Text = "Add Player";
            this.addPlayerButton.UseVisualStyleBackColor = true;
            this.addPlayerButton.Click += new System.EventHandler(this.AddPlayerButtonClick);
            // 
            // PlayerRosterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 315);
            this.Controls.Add(this.Layout);
            this.Name = "PlayerRosterForm";
            this.Text = "Player Roster";
            this.initialDrawGroupBox.ResumeLayout(false);
            this.Layout.ResumeLayout(false);
            this.Layout.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox initialDrawGroupBox;
        private System.Windows.Forms.ComboBox initialDrawComboBox3;
        private System.Windows.Forms.ComboBox initialDrawComboBox2;
        private System.Windows.Forms.ComboBox initialDrawComboBox1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListBox playerRosterListBox;
        private System.Windows.Forms.TableLayoutPanel Layout;
        private System.Windows.Forms.Button characterDetailButton;
        private System.Windows.Forms.ListBox characterListBox;
        private System.Windows.Forms.Button addPlayerButton;
    }
}