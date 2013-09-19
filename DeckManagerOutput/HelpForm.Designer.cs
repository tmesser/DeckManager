namespace DeckManagerOutput
{
    sealed partial class HelpForm
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
            this.MessageRichTextBox = new System.Windows.Forms.RichTextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.MessageRichTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.OkButton, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(392, 55);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MessageRichTextBox
            // 
            this.MessageRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.MessageRichTextBox, 2);
            this.MessageRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageRichTextBox.Location = new System.Drawing.Point(3, 3);
            this.MessageRichTextBox.Name = "MessageRichTextBox";
            this.MessageRichTextBox.ReadOnly = true;
            this.MessageRichTextBox.Size = new System.Drawing.Size(386, 19);
            this.MessageRichTextBox.TabIndex = 0;
            this.MessageRichTextBox.Text = "";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(345, 28);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(44, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 55);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HelpForm";
            this.Text = "HelpForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox MessageRichTextBox;
        private System.Windows.Forms.Button OkButton;
    }
}