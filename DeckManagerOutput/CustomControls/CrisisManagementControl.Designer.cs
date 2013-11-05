namespace DeckManagerOutput.CustomControls
{
    partial class CrisisManagementControl
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
            this.CrisisDisplayTextBox = new System.Windows.Forms.TextBox();
            this.selectionGroupBox = new System.Windows.Forms.GroupBox();
            this.drawToActiveRadioButton = new System.Windows.Forms.RadioButton();
            this.buryRadioButton = new System.Windows.Forms.RadioButton();
            this.replaceRadioButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.selectionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.CrisisDisplayTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.selectionGroupBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(380, 200);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // CrisisDisplayTextBox
            // 
            this.CrisisDisplayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrisisDisplayTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrisisDisplayTextBox.Location = new System.Drawing.Point(3, 3);
            this.CrisisDisplayTextBox.Multiline = true;
            this.CrisisDisplayTextBox.Name = "CrisisDisplayTextBox";
            this.CrisisDisplayTextBox.ReadOnly = true;
            this.CrisisDisplayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CrisisDisplayTextBox.Size = new System.Drawing.Size(224, 194);
            this.CrisisDisplayTextBox.TabIndex = 0;
            // 
            // selectionGroupBox
            // 
            this.selectionGroupBox.Controls.Add(this.drawToActiveRadioButton);
            this.selectionGroupBox.Controls.Add(this.buryRadioButton);
            this.selectionGroupBox.Controls.Add(this.replaceRadioButton);
            this.selectionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionGroupBox.Location = new System.Drawing.Point(233, 3);
            this.selectionGroupBox.Name = "selectionGroupBox";
            this.selectionGroupBox.Size = new System.Drawing.Size(144, 194);
            this.selectionGroupBox.TabIndex = 1;
            this.selectionGroupBox.TabStop = false;
            this.selectionGroupBox.Text = "Select Action:";
            // 
            // drawToActiveRadioButton
            // 
            this.drawToActiveRadioButton.AutoSize = true;
            this.drawToActiveRadioButton.Location = new System.Drawing.Point(7, 68);
            this.drawToActiveRadioButton.Name = "drawToActiveRadioButton";
            this.drawToActiveRadioButton.Size = new System.Drawing.Size(122, 17);
            this.drawToActiveRadioButton.TabIndex = 2;
            this.drawToActiveRadioButton.TabStop = true;
            this.drawToActiveRadioButton.Text = "Draw to Active Crisis";
            this.drawToActiveRadioButton.UseVisualStyleBackColor = true;
            // 
            // buryRadioButton
            // 
            this.buryRadioButton.AutoSize = true;
            this.buryRadioButton.Location = new System.Drawing.Point(7, 44);
            this.buryRadioButton.Name = "buryRadioButton";
            this.buryRadioButton.Size = new System.Drawing.Size(46, 17);
            this.buryRadioButton.TabIndex = 1;
            this.buryRadioButton.TabStop = true;
            this.buryRadioButton.Text = "Bury";
            this.buryRadioButton.UseVisualStyleBackColor = true;
            // 
            // replaceRadioButton
            // 
            this.replaceRadioButton.AutoSize = true;
            this.replaceRadioButton.Location = new System.Drawing.Point(7, 20);
            this.replaceRadioButton.Name = "replaceRadioButton";
            this.replaceRadioButton.Size = new System.Drawing.Size(106, 17);
            this.replaceRadioButton.TabIndex = 0;
            this.replaceRadioButton.TabStop = true;
            this.replaceRadioButton.Text = "Replace In Order";
            this.replaceRadioButton.UseVisualStyleBackColor = true;
            // 
            // CrisisManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CrisisManagementControl";
            this.Size = new System.Drawing.Size(380, 200);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.selectionGroupBox.ResumeLayout(false);
            this.selectionGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox CrisisDisplayTextBox;
        private System.Windows.Forms.GroupBox selectionGroupBox;
        private System.Windows.Forms.RadioButton drawToActiveRadioButton;
        private System.Windows.Forms.RadioButton buryRadioButton;
        private System.Windows.Forms.RadioButton replaceRadioButton;
    }
}
