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
            this.CharacterNameLabel = new System.Windows.Forms.Label();
            this.PlayerNameLabel = new System.Windows.Forms.Label();
            this.PlayerCardListBox = new System.Windows.Forms.ListBox();
            this.DiscardSelectedCheckBox = new System.Windows.Forms.CheckBox();
            this.drawCardComboControl1 = new DeckManagerOutput.CustomControls.DrawCardComboControl();
            this.LocationMarkerLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.0274F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.9726F));
            this.tableLayoutPanel1.Controls.Add(this.CharacterNameLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.PlayerNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PlayerCardListBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DiscardSelectedCheckBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.drawCardComboControl1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LocationMarkerLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.530806F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.45283F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.0566F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(292, 273);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.PlayerCardListBox.Location = new System.Drawing.Point(3, 21);
            this.PlayerCardListBox.Name = "PlayerCardListBox";
            this.tableLayoutPanel1.SetRowSpan(this.PlayerCardListBox, 2);
            this.PlayerCardListBox.Size = new System.Drawing.Size(143, 188);
            this.PlayerCardListBox.TabIndex = 2;
            // 
            // DiscardSelectedCheckBox
            // 
            this.DiscardSelectedCheckBox.AutoSize = true;
            this.DiscardSelectedCheckBox.Location = new System.Drawing.Point(152, 21);
            this.DiscardSelectedCheckBox.Name = "DiscardSelectedCheckBox";
            this.DiscardSelectedCheckBox.Size = new System.Drawing.Size(107, 17);
            this.DiscardSelectedCheckBox.TabIndex = 3;
            this.DiscardSelectedCheckBox.Text = "Discard Selected";
            this.DiscardSelectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // drawCardComboControl1
            // 
            this.drawCardComboControl1.Location = new System.Drawing.Point(152, 58);
            this.drawCardComboControl1.Name = "drawCardComboControl1";
            this.drawCardComboControl1.Size = new System.Drawing.Size(137, 50);
            this.drawCardComboControl1.TabIndex = 4;
            // 
            // LocationMarkerLabel
            // 
            this.LocationMarkerLabel.AutoSize = true;
            this.LocationMarkerLabel.Location = new System.Drawing.Point(3, 212);
            this.LocationMarkerLabel.Name = "LocationMarkerLabel";
            this.LocationMarkerLabel.Size = new System.Drawing.Size(91, 13);
            this.LocationMarkerLabel.TabIndex = 5;
            this.LocationMarkerLabel.Text = "Currrent Location:";
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(152, 215);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(137, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // PlayerManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
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
        private CustomControls.DrawCardComboControl drawCardComboControl1;
        private System.Windows.Forms.Label LocationMarkerLabel;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}