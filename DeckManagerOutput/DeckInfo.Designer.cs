namespace DeckManagerOutput
{
    partial class DeckInfo
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
            this.cardsInDeckListBox = new System.Windows.Forms.ListBox();
            this.cardsInDiscardListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.deckInfoSubmitButton = new System.Windows.Forms.Button();
            this.deckInfoCancelButton = new System.Windows.Forms.Button();
            this.deckInfoDeckComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.discardButton = new System.Windows.Forms.Button();
            this.buryButton = new System.Windows.Forms.Button();
            this.reshuffleButton = new System.Windows.Forms.Button();
            this.addToDestinyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cardsInDeckListBox
            // 
            this.cardsInDeckListBox.FormattingEnabled = true;
            this.cardsInDeckListBox.Location = new System.Drawing.Point(12, 52);
            this.cardsInDeckListBox.Name = "cardsInDeckListBox";
            this.cardsInDeckListBox.Size = new System.Drawing.Size(158, 238);
            this.cardsInDeckListBox.TabIndex = 0;
            // 
            // cardsInDiscardListBox
            // 
            this.cardsInDiscardListBox.FormattingEnabled = true;
            this.cardsInDiscardListBox.Location = new System.Drawing.Point(190, 52);
            this.cardsInDiscardListBox.Name = "cardsInDiscardListBox";
            this.cardsInDiscardListBox.Size = new System.Drawing.Size(158, 238);
            this.cardsInDiscardListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cards in Deck:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cards in Discard:";
            // 
            // deckInfoSubmitButton
            // 
            this.deckInfoSubmitButton.Location = new System.Drawing.Point(273, 354);
            this.deckInfoSubmitButton.Name = "deckInfoSubmitButton";
            this.deckInfoSubmitButton.Size = new System.Drawing.Size(75, 23);
            this.deckInfoSubmitButton.TabIndex = 4;
            this.deckInfoSubmitButton.Text = "Submit";
            this.deckInfoSubmitButton.UseVisualStyleBackColor = true;
            this.deckInfoSubmitButton.Click += new System.EventHandler(this.deckInfoSubmitButton_Click);
            // 
            // deckInfoCancelButton
            // 
            this.deckInfoCancelButton.Location = new System.Drawing.Point(13, 354);
            this.deckInfoCancelButton.Name = "deckInfoCancelButton";
            this.deckInfoCancelButton.Size = new System.Drawing.Size(75, 23);
            this.deckInfoCancelButton.TabIndex = 5;
            this.deckInfoCancelButton.Text = "Cancel";
            this.deckInfoCancelButton.UseVisualStyleBackColor = true;
            this.deckInfoCancelButton.Click += new System.EventHandler(this.deckInfoCancelButton_Click);
            // 
            // deckInfoDeckComboBox
            // 
            this.deckInfoDeckComboBox.FormattingEnabled = true;
            this.deckInfoDeckComboBox.Location = new System.Drawing.Point(49, 9);
            this.deckInfoDeckComboBox.Name = "deckInfoDeckComboBox";
            this.deckInfoDeckComboBox.Size = new System.Drawing.Size(121, 21);
            this.deckInfoDeckComboBox.TabIndex = 6;
            this.deckInfoDeckComboBox.SelectedIndexChanged += new System.EventHandler(this.deckInfoDeckComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Deck:";
            // 
            // discardButton
            // 
            this.discardButton.Location = new System.Drawing.Point(12, 296);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(75, 23);
            this.discardButton.TabIndex = 8;
            this.discardButton.Text = "Discard Selected";
            this.discardButton.UseVisualStyleBackColor = true;
            this.discardButton.Click += new System.EventHandler(this.discardButton_Click);
            // 
            // buryButton
            // 
            this.buryButton.Location = new System.Drawing.Point(95, 296);
            this.buryButton.Name = "buryButton";
            this.buryButton.Size = new System.Drawing.Size(75, 23);
            this.buryButton.TabIndex = 9;
            this.buryButton.Text = "Bury";
            this.buryButton.UseVisualStyleBackColor = true;
            this.buryButton.Click += new System.EventHandler(this.buryButton_Click);
            // 
            // reshuffleButton
            // 
            this.reshuffleButton.Location = new System.Drawing.Point(272, 295);
            this.reshuffleButton.Name = "reshuffleButton";
            this.reshuffleButton.Size = new System.Drawing.Size(75, 23);
            this.reshuffleButton.TabIndex = 10;
            this.reshuffleButton.Text = "Reshuffle";
            this.reshuffleButton.UseVisualStyleBackColor = true;
            this.reshuffleButton.Click += new System.EventHandler(this.reshuffleButton_Click);
            // 
            // addToDestinyButton
            // 
            this.addToDestinyButton.Location = new System.Drawing.Point(72, 326);
            this.addToDestinyButton.Name = "addToDestinyButton";
            this.addToDestinyButton.Size = new System.Drawing.Size(98, 23);
            this.addToDestinyButton.TabIndex = 11;
            this.addToDestinyButton.Text = "Add To Destiny";
            this.addToDestinyButton.UseVisualStyleBackColor = true;
            this.addToDestinyButton.Visible = false;
            this.addToDestinyButton.Click += new System.EventHandler(this.addToDestinyButton_Click);
            // 
            // DeckInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 389);
            this.Controls.Add(this.addToDestinyButton);
            this.Controls.Add(this.reshuffleButton);
            this.Controls.Add(this.buryButton);
            this.Controls.Add(this.discardButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deckInfoDeckComboBox);
            this.Controls.Add(this.deckInfoCancelButton);
            this.Controls.Add(this.deckInfoSubmitButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cardsInDiscardListBox);
            this.Controls.Add(this.cardsInDeckListBox);
            this.Name = "DeckInfo";
            this.Text = "DeckInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox cardsInDeckListBox;
        private System.Windows.Forms.ListBox cardsInDiscardListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button deckInfoSubmitButton;
        private System.Windows.Forms.Button deckInfoCancelButton;
        private System.Windows.Forms.ComboBox deckInfoDeckComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button discardButton;
        private System.Windows.Forms.Button buryButton;
        private System.Windows.Forms.Button reshuffleButton;
        private System.Windows.Forms.Button addToDestinyButton;
    }
}