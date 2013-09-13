using DeckManager;
using DeckManager.Cards.Enums;

namespace DeckManagerOutput
{
    partial class DeckCreator
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.DeckTypeComboBox = new System.Windows.Forms.ComboBox();
            this.CardFieldsPanel = new System.Windows.Forms.Panel();
            this.DeckListBox = new System.Windows.Forms.ListBox();
            this.AddToDeckButton = new System.Windows.Forms.Button();
            this.ClearFieldsButton = new System.Windows.Forms.Button();
            this.RemoveFromDeckButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(405, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDeckToolStripMenuItem,
            this.loadDeckToolStripMenuItem,
            this.saveDeckToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newDeckToolStripMenuItem
            // 
            this.newDeckToolStripMenuItem.Name = "newDeckToolStripMenuItem";
            this.newDeckToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.newDeckToolStripMenuItem.Text = "New Deck";
            this.newDeckToolStripMenuItem.Click += new System.EventHandler(this.newDeckToolStripMenuItem_Click);
            // 
            // loadDeckToolStripMenuItem
            // 
            this.loadDeckToolStripMenuItem.Name = "loadDeckToolStripMenuItem";
            this.loadDeckToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.loadDeckToolStripMenuItem.Text = "Load Deck";
            this.loadDeckToolStripMenuItem.Click += new System.EventHandler(this.loadDeckToolStripMenuItem_Click);
            // 
            // saveDeckToolStripMenuItem
            // 
            this.saveDeckToolStripMenuItem.Name = "saveDeckToolStripMenuItem";
            this.saveDeckToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.saveDeckToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.saveDeckToolStripMenuItem.Text = "Save Deck";
            this.saveDeckToolStripMenuItem.Click += new System.EventHandler(this.saveDeckToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Deck Type:";
            // 
            // DeckTypeComboBox
            // 
            this.DeckTypeComboBox.FormattingEnabled = true;
            this.DeckTypeComboBox.Items.AddRange(new object[] {
            DeckManager.Cards.Enums.CardType.Crisis,
            DeckManager.Cards.Enums.CardType.Destination,
            DeckManager.Cards.Enums.CardType.Loyalty,
            DeckManager.Cards.Enums.CardType.Mission,
            DeckManager.Cards.Enums.CardType.Quorum,
            DeckManager.Cards.Enums.CardType.Skill,
            DeckManager.Cards.Enums.CardType.SuperCrisis});
            this.DeckTypeComboBox.Location = new System.Drawing.Point(82, 25);
            this.DeckTypeComboBox.Name = "DeckTypeComboBox";
            this.DeckTypeComboBox.Size = new System.Drawing.Size(91, 21);
            this.DeckTypeComboBox.TabIndex = 2;
            // 
            // CardFieldsPanel
            // 
            this.CardFieldsPanel.Location = new System.Drawing.Point(16, 52);
            this.CardFieldsPanel.Name = "CardFieldsPanel";
            this.CardFieldsPanel.Size = new System.Drawing.Size(200, 172);
            this.CardFieldsPanel.TabIndex = 3;
            // 
            // DeckListBox
            // 
            this.DeckListBox.FormattingEnabled = true;
            this.DeckListBox.Location = new System.Drawing.Point(273, 27);
            this.DeckListBox.Name = "DeckListBox";
            this.DeckListBox.Size = new System.Drawing.Size(120, 199);
            this.DeckListBox.TabIndex = 4;
            this.DeckListBox.SelectedIndexChanged += new System.EventHandler(this.DeckListBox_SelectedIndexChanged);
            this.DeckListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DeckListBox_MouseDoubleClick);
            // 
            // AddToDeckButton
            // 
            this.AddToDeckButton.Location = new System.Drawing.Point(222, 52);
            this.AddToDeckButton.Name = "AddToDeckButton";
            this.AddToDeckButton.Size = new System.Drawing.Size(45, 23);
            this.AddToDeckButton.TabIndex = 5;
            this.AddToDeckButton.Text = "→";
            this.AddToDeckButton.UseVisualStyleBackColor = true;
            this.AddToDeckButton.Click += new System.EventHandler(this.AddToDeckButton_Click);
            // 
            // ClearFieldsButton
            // 
            this.ClearFieldsButton.Location = new System.Drawing.Point(222, 201);
            this.ClearFieldsButton.Name = "ClearFieldsButton";
            this.ClearFieldsButton.Size = new System.Drawing.Size(45, 23);
            this.ClearFieldsButton.TabIndex = 6;
            this.ClearFieldsButton.Text = "Clear";
            this.ClearFieldsButton.UseVisualStyleBackColor = true;
            this.ClearFieldsButton.Click += new System.EventHandler(this.ClearFieldsButton_Click);
            // 
            // RemoveFromDeckButton
            // 
            this.RemoveFromDeckButton.Location = new System.Drawing.Point(222, 81);
            this.RemoveFromDeckButton.Name = "RemoveFromDeckButton";
            this.RemoveFromDeckButton.Size = new System.Drawing.Size(45, 23);
            this.RemoveFromDeckButton.TabIndex = 7;
            this.RemoveFromDeckButton.Text = "X";
            this.RemoveFromDeckButton.UseVisualStyleBackColor = true;
            this.RemoveFromDeckButton.Click += new System.EventHandler(this.RemoveFromDeckButton_Click);
            // 
            // DeckCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 239);
            this.Controls.Add(this.RemoveFromDeckButton);
            this.Controls.Add(this.ClearFieldsButton);
            this.Controls.Add(this.AddToDeckButton);
            this.Controls.Add(this.DeckListBox);
            this.Controls.Add(this.CardFieldsPanel);
            this.Controls.Add(this.DeckTypeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DeckCreator";
            this.Text = "Deck Creator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
            //
            // SkillCardPanel
            // 
            this.SkillCardPanel = new System.Windows.Forms.Panel();
            this.SkillCardPanel.Location = new System.Drawing.Point(16, 52);
            this.SkillCardPanel.Name = "SkillCardPanel";
            this.SkillCardPanel.Size = new System.Drawing.Size(200, 172);
            this.SkillCardPanel.TabIndex = 3;
            

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDeckToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DeckTypeComboBox;
        private System.Windows.Forms.Panel CardFieldsPanel;
        private System.Windows.Forms.ListBox DeckListBox;
        private System.Windows.Forms.Button AddToDeckButton;
        private System.Windows.Forms.Button ClearFieldsButton;
        private System.Windows.Forms.Button RemoveFromDeckButton;
        private System.Windows.Forms.Panel SkillCardPanel;
        private System.Windows.Forms.Panel QuorumCardPanel;
    }
}