using DeckManagerOutput.Properties;

namespace DeckManagerOutput
{
    partial class GameWindow
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
            this.components = new System.ComponentModel.Container();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.gameStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGameStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PlayerRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowHandMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayerReadonlyListBox = new DeckManagerOutput.CustomControls.ReadOnlyListBox();
            this.MainMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.PlayerRightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(721, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // gameStripMenuItem
            // 
            this.gameStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameStripMenuItem,
            this.loadGameStripMenuItem,
            this.saveGameStripMenuItem});
            this.gameStripMenuItem.Name = "gameStripMenuItem";
            this.gameStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.gameStripMenuItem.Text = global::DeckManagerOutput.Properties.Resources.GameWindowForm_MainMenu_Game;
            // 
            // newGameStripMenuItem
            // 
            this.newGameStripMenuItem.Name = "newGameStripMenuItem";
            this.newGameStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.newGameStripMenuItem.Text = global::DeckManagerOutput.Properties.Resources.GameWindowForm_MainMenu_Game_New;
            this.newGameStripMenuItem.Click += new System.EventHandler(this.NewGameStripMenuItemClick);
            // 
            // loadGameStripMenuItem
            // 
            this.loadGameStripMenuItem.Name = "loadGameStripMenuItem";
            this.loadGameStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.loadGameStripMenuItem.Text = global::DeckManagerOutput.Properties.Resources.GameWindowForm_MainMenu_Game_Load;
            // 
            // saveGameStripMenuItem
            // 
            this.saveGameStripMenuItem.Name = "saveGameStripMenuItem";
            this.saveGameStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.saveGameStripMenuItem.Text = global::DeckManagerOutput.Properties.Resources.GameWindowForm_MainMenu_Game_Save;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Controls.Add(this.PlayerReadonlyListBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(721, 439);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // PlayerRightClickMenu
            // 
            this.PlayerRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowHandMenuItem});
            this.PlayerRightClickMenu.Name = "PlayerRightClickMenu";
            this.PlayerRightClickMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // ShowHandMenuItem
            // 
            this.ShowHandMenuItem.Name = "ShowHandMenuItem";
            this.ShowHandMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ShowHandMenuItem.Text = "Show Hand...";
            this.ShowHandMenuItem.Click += new System.EventHandler(this.ShowHandMenuItemClick);
            // 
            // PlayerReadonlyListBox
            // 
            this.PlayerReadonlyListBox.BackColor = System.Drawing.SystemColors.Menu;
            this.PlayerReadonlyListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlayerReadonlyListBox.ContextMenuStrip = this.PlayerRightClickMenu;
            this.PlayerReadonlyListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerReadonlyListBox.FormattingEnabled = true;
            this.PlayerReadonlyListBox.Location = new System.Drawing.Point(3, 3);
            this.PlayerReadonlyListBox.Name = "PlayerReadonlyListBox";
            this.PlayerReadonlyListBox.ReadOnly = true;
            this.PlayerReadonlyListBox.Size = new System.Drawing.Size(294, 163);
            this.PlayerReadonlyListBox.TabIndex = 0;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 463);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.MainMenuStrip);
            this.Name = "GameWindow";
            this.Text = "GameWindow";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.PlayerRightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private new System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem gameStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGameStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControls.ReadOnlyListBox PlayerReadonlyListBox;
        private System.Windows.Forms.ContextMenuStrip PlayerRightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem ShowHandMenuItem;
    }
}