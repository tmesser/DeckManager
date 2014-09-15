namespace DeckManagerOutput
{
    partial class PlayerManagementForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DiscardSpecialTextBox = new System.Windows.Forms.CheckBox();
            this.SpecialCardListBox = new System.Windows.Forms.ListBox();
            this.CharacterNameLabel = new System.Windows.Forms.Label();
            this.PlayerNameLabel = new System.Windows.Forms.Label();
            this.PlayerCardListBox = new System.Windows.Forms.ListBox();
            this.DiscardSelectedCheckBox = new System.Windows.Forms.CheckBox();
            this.DrawCardComboControl = new DeckManagerOutput.CustomControls.DrawCardComboControl();
            this.LocationMarkerLabel = new System.Windows.Forms.Label();
            this.LocationComboBox = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.DrawSpecialComboControl = new DeckManagerOutput.CustomControls.DrawSpecialComboControl();
            this.OpgCheckbox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.0274F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.9726F));
            this.tableLayoutPanel1.Controls.Add(this.DiscardSpecialTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.SpecialCardListBox, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.CharacterNameLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.PlayerNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PlayerCardListBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DiscardSelectedCheckBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.DrawCardComboControl, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LocationMarkerLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.LocationComboBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.CancelButton, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.SubmitButton, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.DrawSpecialComboControl, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.OpgCheckbox, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(292, 452);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DiscardSpecialTextBox
            // 
            this.DiscardSpecialTextBox.AutoSize = true;
            this.DiscardSpecialTextBox.Location = new System.Drawing.Point(152, 246);
            this.DiscardSpecialTextBox.Name = "DiscardSpecialTextBox";
            this.DiscardSpecialTextBox.Size = new System.Drawing.Size(107, 17);
            this.DiscardSpecialTextBox.TabIndex = 8;
            this.DiscardSpecialTextBox.Text = "Discard Selected";
            this.DiscardSpecialTextBox.UseVisualStyleBackColor = true;
            // 
            // SpecialCardListBox
            // 
            this.SpecialCardListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SpecialCardListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpecialCardListBox.FormattingEnabled = true;
            this.SpecialCardListBox.Location = new System.Drawing.Point(3, 246);
            this.SpecialCardListBox.Name = "SpecialCardListBox";
            this.tableLayoutPanel1.SetRowSpan(this.SpecialCardListBox, 2);
            this.SpecialCardListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.SpecialCardListBox.Size = new System.Drawing.Size(143, 167);
            this.SpecialCardListBox.TabIndex = 7;
            // 
            // CharacterNameLabel
            // 
            this.CharacterNameLabel.AutoSize = true;
            this.CharacterNameLabel.Location = new System.Drawing.Point(152, 0);
            this.CharacterNameLabel.Name = "CharacterNameLabel";
            this.CharacterNameLabel.Size = new System.Drawing.Size(90, 13);
            this.CharacterNameLabel.TabIndex = 1;
            this.CharacterNameLabel.Text = "(Character Name)";
            // 
            // PlayerNameLabel
            // 
            this.PlayerNameLabel.AutoSize = true;
            this.PlayerNameLabel.Location = new System.Drawing.Point(3, 0);
            this.PlayerNameLabel.Name = "PlayerNameLabel";
            this.PlayerNameLabel.Size = new System.Drawing.Size(73, 13);
            this.PlayerNameLabel.TabIndex = 0;
            this.PlayerNameLabel.Text = "(Player Name)";
            // 
            // PlayerCardListBox
            // 
            this.PlayerCardListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayerCardListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerCardListBox.FormattingEnabled = true;
            this.PlayerCardListBox.Location = new System.Drawing.Point(3, 38);
            this.PlayerCardListBox.Name = "PlayerCardListBox";
            this.tableLayoutPanel1.SetRowSpan(this.PlayerCardListBox, 3);
            this.PlayerCardListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.PlayerCardListBox.Size = new System.Drawing.Size(143, 167);
            this.PlayerCardListBox.TabIndex = 2;
            // 
            // DiscardSelectedCheckBox
            // 
            this.DiscardSelectedCheckBox.AutoSize = true;
            this.DiscardSelectedCheckBox.Location = new System.Drawing.Point(152, 38);
            this.DiscardSelectedCheckBox.Name = "DiscardSelectedCheckBox";
            this.DiscardSelectedCheckBox.Size = new System.Drawing.Size(107, 17);
            this.DiscardSelectedCheckBox.TabIndex = 3;
            this.DiscardSelectedCheckBox.Text = "Discard Selected";
            this.DiscardSelectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // DrawCardComboControl
            // 
            this.DrawCardComboControl.Location = new System.Drawing.Point(152, 90);
            this.DrawCardComboControl.Name = "DrawCardComboControl";
            this.DrawCardComboControl.Size = new System.Drawing.Size(137, 50);
            this.DrawCardComboControl.TabIndex = 4;
            // 
            // LocationMarkerLabel
            // 
            this.LocationMarkerLabel.AutoSize = true;
            this.LocationMarkerLabel.Location = new System.Drawing.Point(3, 208);
            this.LocationMarkerLabel.Name = "LocationMarkerLabel";
            this.LocationMarkerLabel.Size = new System.Drawing.Size(91, 13);
            this.LocationMarkerLabel.TabIndex = 5;
            this.LocationMarkerLabel.Text = "Currrent Location:";
            // 
            // LocationComboBox
            // 
            this.LocationComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocationComboBox.FormattingEnabled = true;
            this.LocationComboBox.Location = new System.Drawing.Point(152, 211);
            this.LocationComboBox.Name = "LocationComboBox";
            this.LocationComboBox.Size = new System.Drawing.Size(137, 21);
            this.LocationComboBox.TabIndex = 6;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(3, 419);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitButton.Location = new System.Drawing.Point(214, 419);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 11;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButtonClick);
            // 
            // DrawSpecialComboControl
            // 
            this.DrawSpecialComboControl.Location = new System.Drawing.Point(152, 298);
            this.DrawSpecialComboControl.Name = "DrawSpecialComboControl";
            this.DrawSpecialComboControl.Size = new System.Drawing.Size(137, 50);
            this.DrawSpecialComboControl.TabIndex = 12;
            // 
            // OpgCheckbox
            // 
            this.OpgCheckbox.AutoSize = true;
            this.OpgCheckbox.Location = new System.Drawing.Point(152, 159);
            this.OpgCheckbox.Name = "OpgCheckbox";
            this.OpgCheckbox.Size = new System.Drawing.Size(103, 17);
            this.OpgCheckbox.TabIndex = 13;
            this.OpgCheckbox.Text = "Player Has OPG";
            this.OpgCheckbox.UseVisualStyleBackColor = true;
            // 
            // PlayerManagementForm
            // 
            this.AcceptButton = this.SubmitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 452);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PlayerManagementForm";
            this.Text = "PlayerManagementForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label CharacterNameLabel;
        private System.Windows.Forms.Label PlayerNameLabel;
        private System.Windows.Forms.ListBox PlayerCardListBox;
        private System.Windows.Forms.CheckBox DiscardSelectedCheckBox;
        private CustomControls.DrawCardComboControl DrawCardComboControl;
        private System.Windows.Forms.Label LocationMarkerLabel;
        private System.Windows.Forms.ComboBox LocationComboBox;
        private System.Windows.Forms.CheckBox DiscardSpecialTextBox;
        private System.Windows.Forms.ListBox SpecialCardListBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SubmitButton;
        private CustomControls.DrawSpecialComboControl DrawSpecialComboControl;
        private System.Windows.Forms.CheckBox OpgCheckbox;
    }
}