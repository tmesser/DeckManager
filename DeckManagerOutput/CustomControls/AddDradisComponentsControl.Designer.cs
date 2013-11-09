namespace DeckManagerOutput.CustomControls
{
    partial class AddDradisComponentsControl
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
            this.ComponentNameLabel = new System.Windows.Forms.Label();
            this.requestedNumberComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.ComponentNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.requestedNumberComboBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(171, 28);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ComponentNameLabel
            // 
            this.ComponentNameLabel.AutoSize = true;
            this.ComponentNameLabel.Location = new System.Drawing.Point(3, 0);
            this.ComponentNameLabel.Name = "ComponentNameLabel";
            this.ComponentNameLabel.Size = new System.Drawing.Size(121, 13);
            this.ComponentNameLabel.TabIndex = 0;
            this.ComponentNameLabel.Text = "[ComponentNameLabel]";
            // 
            // requestedNumberComboBox
            // 
            this.requestedNumberComboBox.FormattingEnabled = true;
            this.requestedNumberComboBox.Items.AddRange(new object[] {
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
            this.requestedNumberComboBox.Location = new System.Drawing.Point(139, 3);
            this.requestedNumberComboBox.Name = "requestedNumberComboBox";
            this.requestedNumberComboBox.Size = new System.Drawing.Size(29, 21);
            this.requestedNumberComboBox.TabIndex = 1;
            // 
            // AddDradisComponentsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddDradisComponentsControl";
            this.Size = new System.Drawing.Size(171, 28);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label ComponentNameLabel;
        private System.Windows.Forms.ComboBox requestedNumberComboBox;
    }
}
