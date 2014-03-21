namespace DeckManagerOutput.CustomControls
{
    partial class DrawSpecialComboControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DrawCardsCheckBox = new System.Windows.Forms.CheckBox();
            this.DrawAmountComboBox = new System.Windows.Forms.ComboBox();
            this.DrawTypeComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.Controls.Add(this.DrawCardsCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DrawAmountComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.DrawTypeComboBox, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(150, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DrawCardsCheckBox
            // 
            this.DrawCardsCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.DrawCardsCheckBox, 3);
            this.DrawCardsCheckBox.Location = new System.Drawing.Point(3, 3);
            this.DrawCardsCheckBox.Name = "DrawCardsCheckBox";
            this.DrawCardsCheckBox.Size = new System.Drawing.Size(84, 17);
            this.DrawCardsCheckBox.TabIndex = 0;
            this.DrawCardsCheckBox.Text = "Draw Cards:";
            this.DrawCardsCheckBox.UseVisualStyleBackColor = true;
            this.DrawCardsCheckBox.CheckedChanged += new System.EventHandler(this.DrawCardsCheckBoxCheckedChanged);
            // 
            // DrawAmountComboBox
            // 
            this.DrawAmountComboBox.FormattingEnabled = true;
            this.DrawAmountComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.DrawAmountComboBox.Location = new System.Drawing.Point(13, 28);
            this.DrawAmountComboBox.Name = "DrawAmountComboBox";
            this.DrawAmountComboBox.Size = new System.Drawing.Size(45, 21);
            this.DrawAmountComboBox.TabIndex = 1;
            // 
            // DrawTypeComboBox
            // 
            this.DrawTypeComboBox.FormattingEnabled = true;
            this.DrawTypeComboBox.Items.AddRange(new object[] {
            "SuperCrisis",
            "Quorum",
            "Loyalty"});
            this.DrawTypeComboBox.Location = new System.Drawing.Point(64, 28);
            this.DrawTypeComboBox.Name = "DrawTypeComboBox";
            this.DrawTypeComboBox.Size = new System.Drawing.Size(76, 21);
            this.DrawTypeComboBox.TabIndex = 2;
            // 
            // DrawSpecialComboControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DrawSpecialComboControl";
            this.Size = new System.Drawing.Size(150, 50);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox DrawCardsCheckBox;
        private System.Windows.Forms.ComboBox DrawAmountComboBox;
        private System.Windows.Forms.ComboBox DrawTypeComboBox;
    }
}
