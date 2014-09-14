namespace DeckManagerOutput
{
    partial class OptionalRulesForm
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
            this.UsingSympathizerHelpLabel = new System.Windows.Forms.Label();
            this.SympathizerLabel = new System.Windows.Forms.Label();
            this.ExtraLoyaltyCardsLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ExtraLoyaltyCardsHelpLabel = new System.Windows.Forms.Label();
            this.ExtraLoyaltyCardsComboBox = new System.Windows.Forms.ComboBox();
            this.SympathizerCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.UsingSympathizerHelpLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.SympathizerLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ExtraLoyaltyCardsLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.OkButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.CancelButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ExtraLoyaltyCardsHelpLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ExtraLoyaltyCardsComboBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.SympathizerCheckBox, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(354, 80);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // UsingSympathizerHelpLabel
            // 
            this.UsingSympathizerHelpLabel.AutoSize = true;
            this.UsingSympathizerHelpLabel.ForeColor = System.Drawing.Color.Blue;
            this.UsingSympathizerHelpLabel.Location = new System.Drawing.Point(153, 25);
            this.UsingSympathizerHelpLabel.Name = "UsingSympathizerHelpLabel";
            this.UsingSympathizerHelpLabel.Size = new System.Drawing.Size(19, 13);
            this.UsingSympathizerHelpLabel.TabIndex = 7;
            this.UsingSympathizerHelpLabel.Text = "(?)";
            this.UsingSympathizerHelpLabel.Click += new System.EventHandler(this.UsingSympathizerHelpLabelClick);
            this.UsingSympathizerHelpLabel.MouseLeave += new System.EventHandler(this.HelpLabelMouseLeave);
            this.UsingSympathizerHelpLabel.MouseHover += new System.EventHandler(this.HelpLabelMouseHover);
            // 
            // SympathizerLabel
            // 
            this.SympathizerLabel.AutoSize = true;
            this.SympathizerLabel.Location = new System.Drawing.Point(3, 25);
            this.SympathizerLabel.Name = "SympathizerLabel";
            this.SympathizerLabel.Size = new System.Drawing.Size(67, 13);
            this.SympathizerLabel.TabIndex = 6;
            this.SympathizerLabel.Text = "Sympathizer:";
            // 
            // ExtraLoyaltyCardsLabel
            // 
            this.ExtraLoyaltyCardsLabel.AutoSize = true;
            this.ExtraLoyaltyCardsLabel.Location = new System.Drawing.Point(3, 0);
            this.ExtraLoyaltyCardsLabel.Name = "ExtraLoyaltyCardsLabel";
            this.ExtraLoyaltyCardsLabel.Size = new System.Drawing.Size(139, 13);
            this.ExtraLoyaltyCardsLabel.TabIndex = 0;
            this.ExtraLoyaltyCardsLabel.Text = "Extra Loyalty Cards needed:";
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(276, 54);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(3, 54);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // ExtraLoyaltyCardsHelpLabel
            // 
            this.ExtraLoyaltyCardsHelpLabel.AutoSize = true;
            this.ExtraLoyaltyCardsHelpLabel.ForeColor = System.Drawing.Color.Blue;
            this.ExtraLoyaltyCardsHelpLabel.Location = new System.Drawing.Point(153, 0);
            this.ExtraLoyaltyCardsHelpLabel.Name = "ExtraLoyaltyCardsHelpLabel";
            this.ExtraLoyaltyCardsHelpLabel.Size = new System.Drawing.Size(19, 13);
            this.ExtraLoyaltyCardsHelpLabel.TabIndex = 4;
            this.ExtraLoyaltyCardsHelpLabel.Text = "(?)";
            this.ExtraLoyaltyCardsHelpLabel.Click += new System.EventHandler(this.ExtraLoyaltyCardsHelpLabelClick);
            this.ExtraLoyaltyCardsHelpLabel.MouseLeave += new System.EventHandler(this.HelpLabelMouseLeave);
            this.ExtraLoyaltyCardsHelpLabel.MouseHover += new System.EventHandler(this.HelpLabelMouseHover);
            // 
            // ExtraLoyaltyCardsComboBox
            // 
            this.ExtraLoyaltyCardsComboBox.FormattingEnabled = true;
            this.ExtraLoyaltyCardsComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.ExtraLoyaltyCardsComboBox.Location = new System.Drawing.Point(178, 3);
            this.ExtraLoyaltyCardsComboBox.Name = "ExtraLoyaltyCardsComboBox";
            this.ExtraLoyaltyCardsComboBox.Size = new System.Drawing.Size(121, 21);
            this.ExtraLoyaltyCardsComboBox.TabIndex = 5;
            // 
            // SympathizerCheckBox
            // 
            this.SympathizerCheckBox.AutoSize = true;
            this.SympathizerCheckBox.Location = new System.Drawing.Point(178, 28);
            this.SympathizerCheckBox.Name = "SympathizerCheckBox";
            this.SympathizerCheckBox.Size = new System.Drawing.Size(133, 17);
            this.SympathizerCheckBox.TabIndex = 8;
            this.SympathizerCheckBox.Text = "Not Using Sympathizer";
            this.SympathizerCheckBox.UseVisualStyleBackColor = true;
            this.SympathizerCheckBox.CheckedChanged += new System.EventHandler(this.SympathizerCheckBoxCheckedChanged);
            // 
            // OptionalRulesForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(354, 80);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OptionalRulesForm";
            this.Text = "OptionalRulesForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label ExtraLoyaltyCardsLabel;
        private System.Windows.Forms.Button OkButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label ExtraLoyaltyCardsHelpLabel;
        private System.Windows.Forms.ComboBox ExtraLoyaltyCardsComboBox;
        private System.Windows.Forms.Label UsingSympathizerHelpLabel;
        private System.Windows.Forms.Label SympathizerLabel;
        private System.Windows.Forms.CheckBox SympathizerCheckBox;
    }
}