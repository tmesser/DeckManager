namespace DeckManagerOutput.CustomControls
{
    partial class CardActionControl
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
            this.actionCheckbox = new System.Windows.Forms.CheckBox();
            this.cardActionComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.actionCheckbox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cardActionComboBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(150, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // actionCheckbox
            // 
            this.actionCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.actionCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.actionCheckbox.Location = new System.Drawing.Point(3, 3);
            this.actionCheckbox.Name = "actionCheckbox";
            this.actionCheckbox.Size = new System.Drawing.Size(14, 17);
            this.actionCheckbox.TabIndex = 0;
            this.actionCheckbox.UseVisualStyleBackColor = true;
            // 
            // cardActionComboBox
            // 
            this.cardActionComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardActionComboBox.Location = new System.Drawing.Point(23, 3);
            this.cardActionComboBox.Name = "cardActionComboBox";
            this.cardActionComboBox.Size = new System.Drawing.Size(124, 21);
            this.cardActionComboBox.TabIndex = 0;
            // 
            // CardActionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CardActionControl";
            this.Size = new System.Drawing.Size(150, 29);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox actionCheckbox;
        private System.Windows.Forms.ComboBox cardActionComboBox;

    }
}
