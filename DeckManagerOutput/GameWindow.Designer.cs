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
            this.CharlieDradisListBox = new System.Windows.Forms.ListBox();
            this.BravoDradisListBox = new System.Windows.Forms.ListBox();
            this.BravoToCharlieButton = new System.Windows.Forms.Button();
            this.CharlieToBravoButton = new System.Windows.Forms.Button();
            this.ColonialOneListBox = new System.Windows.Forms.ListBox();
            this.AlphaDradisListBox = new System.Windows.Forms.ListBox();
            this.DeltaDradisListBox = new System.Windows.Forms.ListBox();
            this.AlphaToBravoButton = new System.Windows.Forms.Button();
            this.BravoToAlphaButton = new System.Windows.Forms.Button();
            this.DeltaToCharlieButton = new System.Windows.Forms.Button();
            this.CharlieToDeltaButton = new System.Windows.Forms.Button();
            this.EchoToDeltaButton = new System.Windows.Forms.Button();
            this.DeltaToEchoButton = new System.Windows.Forms.Button();
            this.AlphaToFoxtrotButton = new System.Windows.Forms.Button();
            this.FoxtrotToAlphaButton = new System.Windows.Forms.Button();
            this.GalacticaBoardListBox = new System.Windows.Forms.ListBox();
            this.FoxtrotDradisListBox = new System.Windows.Forms.ListBox();
            this.EchoDradisListBox = new System.Windows.Forms.ListBox();
            this.FoxtrotToEchoButton = new System.Windows.Forms.Button();
            this.EchoToFoxtrotButton = new System.Windows.Forms.Button();
            this.CylonBoardListBox = new System.Windows.Forms.ListBox();
            this.PlayerRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowHandMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JumpPrepGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Red1RadioButton = new System.Windows.Forms.RadioButton();
            this.Red2RadioButton = new System.Windows.Forms.RadioButton();
            this.Red3RadioButton = new System.Windows.Forms.RadioButton();
            this.Risk3RadioButton = new System.Windows.Forms.RadioButton();
            this.Risk1RadioButton = new System.Windows.Forms.RadioButton();
            this.JumpNowRadioButton = new System.Windows.Forms.RadioButton();
            this.CentBoardingGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.CentBoardingTextBox1 = new System.Windows.Forms.TextBox();
            this.CentBoardingTextBox2 = new System.Windows.Forms.TextBox();
            this.CentBoardingTextBox3 = new System.Windows.Forms.TextBox();
            this.CentBoardingTextBox4 = new System.Windows.Forms.TextBox();
            this.CentBoardingTextBox5 = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.FuelLabel = new System.Windows.Forms.Label();
            this.FoodLabel = new System.Windows.Forms.Label();
            this.MoraleLabel = new System.Windows.Forms.Label();
            this.PopulationLabel = new System.Windows.Forms.Label();
            this.CrisisLabel = new System.Windows.Forms.Label();
            this.PlayerReadonlyListBox = new DeckManagerOutput.CustomControls.ReadOnlyListBox();
            this.MainMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.PlayerRightClickMenu.SuspendLayout();
            this.JumpPrepGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.CentBoardingGroupBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(792, 24);
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
            this.tableLayoutPanel1.ColumnCount = 16;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.Controls.Add(this.CharlieDradisListBox, 9, 4);
            this.tableLayoutPanel1.Controls.Add(this.BravoDradisListBox, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.BravoToCharlieButton, 7, 4);
            this.tableLayoutPanel1.Controls.Add(this.CharlieToBravoButton, 7, 5);
            this.tableLayoutPanel1.Controls.Add(this.ColonialOneListBox, 8, 6);
            this.tableLayoutPanel1.Controls.Add(this.AlphaDradisListBox, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.DeltaDradisListBox, 11, 7);
            this.tableLayoutPanel1.Controls.Add(this.AlphaToBravoButton, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.BravoToAlphaButton, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.DeltaToCharlieButton, 11, 5);
            this.tableLayoutPanel1.Controls.Add(this.CharlieToDeltaButton, 12, 5);
            this.tableLayoutPanel1.Controls.Add(this.EchoToDeltaButton, 11, 9);
            this.tableLayoutPanel1.Controls.Add(this.DeltaToEchoButton, 12, 9);
            this.tableLayoutPanel1.Controls.Add(this.AlphaToFoxtrotButton, 4, 9);
            this.tableLayoutPanel1.Controls.Add(this.FoxtrotToAlphaButton, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.GalacticaBoardListBox, 5, 7);
            this.tableLayoutPanel1.Controls.Add(this.FoxtrotDradisListBox, 5, 11);
            this.tableLayoutPanel1.Controls.Add(this.EchoDradisListBox, 9, 11);
            this.tableLayoutPanel1.Controls.Add(this.FoxtrotToEchoButton, 7, 11);
            this.tableLayoutPanel1.Controls.Add(this.EchoToFoxtrotButton, 7, 12);
            this.tableLayoutPanel1.Controls.Add(this.CylonBoardListBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.PlayerReadonlyListBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.JumpPrepGroupBox, 3, 13);
            this.tableLayoutPanel1.Controls.Add(this.CentBoardingGroupBox, 10, 13);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown1, 6, 14);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown2, 7, 14);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown3, 8, 14);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown4, 9, 14);
            this.tableLayoutPanel1.Controls.Add(this.FuelLabel, 6, 13);
            this.tableLayoutPanel1.Controls.Add(this.FoodLabel, 7, 13);
            this.tableLayoutPanel1.Controls.Add(this.MoraleLabel, 8, 13);
            this.tableLayoutPanel1.Controls.Add(this.PopulationLabel, 9, 13);
            this.tableLayoutPanel1.Controls.Add(this.CrisisLabel, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 16;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 549);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // CharlieDradisListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.CharlieDradisListBox, 2);
            this.CharlieDradisListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharlieDradisListBox.FormattingEnabled = true;
            this.CharlieDradisListBox.Location = new System.Drawing.Point(476, 145);
            this.CharlieDradisListBox.Name = "CharlieDradisListBox";
            this.tableLayoutPanel1.SetRowSpan(this.CharlieDradisListBox, 2);
            this.CharlieDradisListBox.Size = new System.Drawing.Size(82, 68);
            this.CharlieDradisListBox.TabIndex = 3;
            // 
            // BravoDradisListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.BravoDradisListBox, 2);
            this.BravoDradisListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BravoDradisListBox.FormattingEnabled = true;
            this.BravoDradisListBox.Location = new System.Drawing.Point(300, 145);
            this.BravoDradisListBox.Name = "BravoDradisListBox";
            this.tableLayoutPanel1.SetRowSpan(this.BravoDradisListBox, 2);
            this.BravoDradisListBox.Size = new System.Drawing.Size(82, 68);
            this.BravoDradisListBox.TabIndex = 2;
            // 
            // BravoToCharlieButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.BravoToCharlieButton, 2);
            this.BravoToCharlieButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BravoToCharlieButton.Location = new System.Drawing.Point(388, 145);
            this.BravoToCharlieButton.Name = "BravoToCharlieButton";
            this.BravoToCharlieButton.Size = new System.Drawing.Size(82, 31);
            this.BravoToCharlieButton.TabIndex = 7;
            this.BravoToCharlieButton.Text = "→";
            this.BravoToCharlieButton.UseVisualStyleBackColor = true;
            // 
            // CharlieToBravoButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.CharlieToBravoButton, 2);
            this.CharlieToBravoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharlieToBravoButton.Location = new System.Drawing.Point(388, 182);
            this.CharlieToBravoButton.Name = "CharlieToBravoButton";
            this.CharlieToBravoButton.Size = new System.Drawing.Size(82, 31);
            this.CharlieToBravoButton.TabIndex = 8;
            this.CharlieToBravoButton.Text = "←";
            this.CharlieToBravoButton.UseVisualStyleBackColor = true;
            // 
            // ColonialOneListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ColonialOneListBox, 3);
            this.ColonialOneListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColonialOneListBox.FormattingEnabled = true;
            this.ColonialOneListBox.Location = new System.Drawing.Point(432, 219);
            this.ColonialOneListBox.Name = "ColonialOneListBox";
            this.tableLayoutPanel1.SetRowSpan(this.ColonialOneListBox, 3);
            this.ColonialOneListBox.Size = new System.Drawing.Size(126, 105);
            this.ColonialOneListBox.TabIndex = 20;
            // 
            // AlphaDradisListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.AlphaDradisListBox, 2);
            this.AlphaDradisListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlphaDradisListBox.FormattingEnabled = true;
            this.AlphaDradisListBox.Location = new System.Drawing.Point(212, 256);
            this.AlphaDradisListBox.Name = "AlphaDradisListBox";
            this.tableLayoutPanel1.SetRowSpan(this.AlphaDradisListBox, 2);
            this.AlphaDradisListBox.Size = new System.Drawing.Size(82, 68);
            this.AlphaDradisListBox.TabIndex = 1;
            // 
            // DeltaDradisListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.DeltaDradisListBox, 2);
            this.DeltaDradisListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeltaDradisListBox.FormattingEnabled = true;
            this.DeltaDradisListBox.Location = new System.Drawing.Point(564, 256);
            this.DeltaDradisListBox.Name = "DeltaDradisListBox";
            this.tableLayoutPanel1.SetRowSpan(this.DeltaDradisListBox, 2);
            this.DeltaDradisListBox.Size = new System.Drawing.Size(82, 68);
            this.DeltaDradisListBox.TabIndex = 4;
            // 
            // AlphaToBravoButton
            // 
            this.AlphaToBravoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlphaToBravoButton.Location = new System.Drawing.Point(212, 182);
            this.AlphaToBravoButton.Name = "AlphaToBravoButton";
            this.tableLayoutPanel1.SetRowSpan(this.AlphaToBravoButton, 2);
            this.AlphaToBravoButton.Size = new System.Drawing.Size(38, 68);
            this.AlphaToBravoButton.TabIndex = 9;
            this.AlphaToBravoButton.Text = "↑";
            this.AlphaToBravoButton.UseVisualStyleBackColor = true;
            // 
            // BravoToAlphaButton
            // 
            this.BravoToAlphaButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BravoToAlphaButton.Location = new System.Drawing.Point(256, 182);
            this.BravoToAlphaButton.Name = "BravoToAlphaButton";
            this.tableLayoutPanel1.SetRowSpan(this.BravoToAlphaButton, 2);
            this.BravoToAlphaButton.Size = new System.Drawing.Size(38, 68);
            this.BravoToAlphaButton.TabIndex = 10;
            this.BravoToAlphaButton.Text = "↓";
            this.BravoToAlphaButton.UseVisualStyleBackColor = true;
            // 
            // DeltaToCharlieButton
            // 
            this.DeltaToCharlieButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeltaToCharlieButton.Location = new System.Drawing.Point(564, 182);
            this.DeltaToCharlieButton.Name = "DeltaToCharlieButton";
            this.tableLayoutPanel1.SetRowSpan(this.DeltaToCharlieButton, 2);
            this.DeltaToCharlieButton.Size = new System.Drawing.Size(38, 68);
            this.DeltaToCharlieButton.TabIndex = 13;
            this.DeltaToCharlieButton.Text = "↑";
            this.DeltaToCharlieButton.UseVisualStyleBackColor = true;
            // 
            // CharlieToDeltaButton
            // 
            this.CharlieToDeltaButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharlieToDeltaButton.Location = new System.Drawing.Point(608, 182);
            this.CharlieToDeltaButton.Name = "CharlieToDeltaButton";
            this.tableLayoutPanel1.SetRowSpan(this.CharlieToDeltaButton, 2);
            this.CharlieToDeltaButton.Size = new System.Drawing.Size(38, 68);
            this.CharlieToDeltaButton.TabIndex = 14;
            this.CharlieToDeltaButton.Text = "↓";
            this.CharlieToDeltaButton.UseVisualStyleBackColor = true;
            // 
            // EchoToDeltaButton
            // 
            this.EchoToDeltaButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EchoToDeltaButton.Location = new System.Drawing.Point(564, 330);
            this.EchoToDeltaButton.Name = "EchoToDeltaButton";
            this.tableLayoutPanel1.SetRowSpan(this.EchoToDeltaButton, 2);
            this.EchoToDeltaButton.Size = new System.Drawing.Size(38, 68);
            this.EchoToDeltaButton.TabIndex = 18;
            this.EchoToDeltaButton.Text = "↑";
            this.EchoToDeltaButton.UseVisualStyleBackColor = true;
            // 
            // DeltaToEchoButton
            // 
            this.DeltaToEchoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeltaToEchoButton.Location = new System.Drawing.Point(608, 330);
            this.DeltaToEchoButton.Name = "DeltaToEchoButton";
            this.tableLayoutPanel1.SetRowSpan(this.DeltaToEchoButton, 2);
            this.DeltaToEchoButton.Size = new System.Drawing.Size(38, 68);
            this.DeltaToEchoButton.TabIndex = 15;
            this.DeltaToEchoButton.Text = "↓";
            this.DeltaToEchoButton.UseVisualStyleBackColor = true;
            // 
            // AlphaToFoxtrotButton
            // 
            this.AlphaToFoxtrotButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlphaToFoxtrotButton.Location = new System.Drawing.Point(256, 330);
            this.AlphaToFoxtrotButton.Name = "AlphaToFoxtrotButton";
            this.tableLayoutPanel1.SetRowSpan(this.AlphaToFoxtrotButton, 2);
            this.AlphaToFoxtrotButton.Size = new System.Drawing.Size(38, 68);
            this.AlphaToFoxtrotButton.TabIndex = 16;
            this.AlphaToFoxtrotButton.Text = "↓";
            this.AlphaToFoxtrotButton.UseVisualStyleBackColor = true;
            // 
            // FoxtrotToAlphaButton
            // 
            this.FoxtrotToAlphaButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FoxtrotToAlphaButton.Location = new System.Drawing.Point(212, 330);
            this.FoxtrotToAlphaButton.Name = "FoxtrotToAlphaButton";
            this.tableLayoutPanel1.SetRowSpan(this.FoxtrotToAlphaButton, 2);
            this.FoxtrotToAlphaButton.Size = new System.Drawing.Size(38, 68);
            this.FoxtrotToAlphaButton.TabIndex = 17;
            this.FoxtrotToAlphaButton.Text = "↑";
            this.FoxtrotToAlphaButton.UseVisualStyleBackColor = true;
            // 
            // GalacticaBoardListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.GalacticaBoardListBox, 3);
            this.GalacticaBoardListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GalacticaBoardListBox.FormattingEnabled = true;
            this.GalacticaBoardListBox.Location = new System.Drawing.Point(300, 256);
            this.GalacticaBoardListBox.Name = "GalacticaBoardListBox";
            this.tableLayoutPanel1.SetRowSpan(this.GalacticaBoardListBox, 4);
            this.GalacticaBoardListBox.Size = new System.Drawing.Size(126, 142);
            this.GalacticaBoardListBox.TabIndex = 19;
            // 
            // FoxtrotDradisListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.FoxtrotDradisListBox, 2);
            this.FoxtrotDradisListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FoxtrotDradisListBox.FormattingEnabled = true;
            this.FoxtrotDradisListBox.Location = new System.Drawing.Point(300, 404);
            this.FoxtrotDradisListBox.Name = "FoxtrotDradisListBox";
            this.tableLayoutPanel1.SetRowSpan(this.FoxtrotDradisListBox, 2);
            this.FoxtrotDradisListBox.Size = new System.Drawing.Size(82, 68);
            this.FoxtrotDradisListBox.TabIndex = 6;
            // 
            // EchoDradisListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.EchoDradisListBox, 2);
            this.EchoDradisListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EchoDradisListBox.FormattingEnabled = true;
            this.EchoDradisListBox.Location = new System.Drawing.Point(476, 404);
            this.EchoDradisListBox.Name = "EchoDradisListBox";
            this.tableLayoutPanel1.SetRowSpan(this.EchoDradisListBox, 2);
            this.EchoDradisListBox.Size = new System.Drawing.Size(82, 68);
            this.EchoDradisListBox.TabIndex = 5;
            // 
            // FoxtrotToEchoButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.FoxtrotToEchoButton, 2);
            this.FoxtrotToEchoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FoxtrotToEchoButton.Location = new System.Drawing.Point(388, 404);
            this.FoxtrotToEchoButton.Name = "FoxtrotToEchoButton";
            this.FoxtrotToEchoButton.Size = new System.Drawing.Size(82, 31);
            this.FoxtrotToEchoButton.TabIndex = 12;
            this.FoxtrotToEchoButton.Text = "→";
            this.FoxtrotToEchoButton.UseVisualStyleBackColor = true;
            // 
            // EchoToFoxtrotButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.EchoToFoxtrotButton, 2);
            this.EchoToFoxtrotButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EchoToFoxtrotButton.Location = new System.Drawing.Point(388, 441);
            this.EchoToFoxtrotButton.Name = "EchoToFoxtrotButton";
            this.EchoToFoxtrotButton.Size = new System.Drawing.Size(82, 31);
            this.EchoToFoxtrotButton.TabIndex = 11;
            this.EchoToFoxtrotButton.Text = "←";
            this.EchoToFoxtrotButton.UseVisualStyleBackColor = true;
            // 
            // CylonBoardListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.CylonBoardListBox, 2);
            this.CylonBoardListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CylonBoardListBox.FormattingEnabled = true;
            this.CylonBoardListBox.Location = new System.Drawing.Point(168, 58);
            this.CylonBoardListBox.Name = "CylonBoardListBox";
            this.tableLayoutPanel1.SetRowSpan(this.CylonBoardListBox, 3);
            this.CylonBoardListBox.Size = new System.Drawing.Size(82, 81);
            this.CylonBoardListBox.TabIndex = 21;
            // 
            // PlayerRightClickMenu
            // 
            this.PlayerRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowHandMenuItem});
            this.PlayerRightClickMenu.Name = "PlayerRightClickMenu";
            this.PlayerRightClickMenu.Size = new System.Drawing.Size(141, 26);
            // 
            // ShowHandMenuItem
            // 
            this.ShowHandMenuItem.Name = "ShowHandMenuItem";
            this.ShowHandMenuItem.Size = new System.Drawing.Size(140, 22);
            this.ShowHandMenuItem.Text = "Show Hand...";
            this.ShowHandMenuItem.Click += new System.EventHandler(this.ShowHandMenuItemClick);
            // 
            // JumpPrepGroupBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.JumpPrepGroupBox, 3);
            this.JumpPrepGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.JumpPrepGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.JumpPrepGroupBox.Location = new System.Drawing.Point(212, 478);
            this.JumpPrepGroupBox.Name = "JumpPrepGroupBox";
            this.tableLayoutPanel1.SetRowSpan(this.JumpPrepGroupBox, 2);
            this.JumpPrepGroupBox.Size = new System.Drawing.Size(126, 59);
            this.JumpPrepGroupBox.TabIndex = 25;
            this.JumpPrepGroupBox.TabStop = false;
            this.JumpPrepGroupBox.Text = "JumpPrepGroupBox";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.Red1RadioButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Red2RadioButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Red3RadioButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.Risk3RadioButton, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.Risk1RadioButton, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.JumpNowRadioButton, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(120, 40);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // Red1RadioButton
            // 
            this.Red1RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Red1RadioButton.AutoSize = true;
            this.Red1RadioButton.Checked = true;
            this.Red1RadioButton.Location = new System.Drawing.Point(3, 11);
            this.Red1RadioButton.Name = "Red1RadioButton";
            this.Red1RadioButton.Size = new System.Drawing.Size(14, 17);
            this.Red1RadioButton.TabIndex = 0;
            this.Red1RadioButton.TabStop = true;
            this.Red1RadioButton.Text = "radioButton1";
            this.Red1RadioButton.UseVisualStyleBackColor = true;
            // 
            // Red2RadioButton
            // 
            this.Red2RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Red2RadioButton.AutoSize = true;
            this.Red2RadioButton.Location = new System.Drawing.Point(23, 11);
            this.Red2RadioButton.Name = "Red2RadioButton";
            this.Red2RadioButton.Size = new System.Drawing.Size(14, 17);
            this.Red2RadioButton.TabIndex = 1;
            this.Red2RadioButton.Text = "radioButton2";
            this.Red2RadioButton.UseVisualStyleBackColor = true;
            // 
            // Red3RadioButton
            // 
            this.Red3RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Red3RadioButton.AutoSize = true;
            this.Red3RadioButton.Location = new System.Drawing.Point(43, 11);
            this.Red3RadioButton.Name = "Red3RadioButton";
            this.Red3RadioButton.Size = new System.Drawing.Size(14, 17);
            this.Red3RadioButton.TabIndex = 2;
            this.Red3RadioButton.Text = "radioButton3";
            this.Red3RadioButton.UseVisualStyleBackColor = true;
            // 
            // Risk3RadioButton
            // 
            this.Risk3RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Risk3RadioButton.AutoSize = true;
            this.Risk3RadioButton.Location = new System.Drawing.Point(63, 11);
            this.Risk3RadioButton.Name = "Risk3RadioButton";
            this.Risk3RadioButton.Size = new System.Drawing.Size(14, 17);
            this.Risk3RadioButton.TabIndex = 3;
            this.Risk3RadioButton.Text = "radioButton4";
            this.Risk3RadioButton.UseVisualStyleBackColor = true;
            // 
            // Risk1RadioButton
            // 
            this.Risk1RadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Risk1RadioButton.AutoSize = true;
            this.Risk1RadioButton.Location = new System.Drawing.Point(83, 11);
            this.Risk1RadioButton.Name = "Risk1RadioButton";
            this.Risk1RadioButton.Size = new System.Drawing.Size(14, 17);
            this.Risk1RadioButton.TabIndex = 4;
            this.Risk1RadioButton.Text = "radioButton5";
            this.Risk1RadioButton.UseVisualStyleBackColor = true;
            // 
            // JumpNowRadioButton
            // 
            this.JumpNowRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.JumpNowRadioButton.AutoSize = true;
            this.JumpNowRadioButton.Location = new System.Drawing.Point(103, 11);
            this.JumpNowRadioButton.Name = "JumpNowRadioButton";
            this.JumpNowRadioButton.Size = new System.Drawing.Size(14, 17);
            this.JumpNowRadioButton.TabIndex = 5;
            this.JumpNowRadioButton.Text = "radioButton6";
            this.JumpNowRadioButton.UseVisualStyleBackColor = true;
            // 
            // CentBoardingGroupBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.CentBoardingGroupBox, 3);
            this.CentBoardingGroupBox.Controls.Add(this.tableLayoutPanel3);
            this.CentBoardingGroupBox.Location = new System.Drawing.Point(520, 478);
            this.CentBoardingGroupBox.Name = "CentBoardingGroupBox";
            this.tableLayoutPanel1.SetRowSpan(this.CentBoardingGroupBox, 2);
            this.CentBoardingGroupBox.Size = new System.Drawing.Size(126, 59);
            this.CentBoardingGroupBox.TabIndex = 26;
            this.CentBoardingGroupBox.TabStop = false;
            this.CentBoardingGroupBox.Text = "Centurion Boarding";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.CentBoardingTextBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.CentBoardingTextBox2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.CentBoardingTextBox3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.CentBoardingTextBox4, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.CentBoardingTextBox5, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(120, 40);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // CentBoardingTextBox1
            // 
            this.CentBoardingTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CentBoardingTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CentBoardingTextBox1.ForeColor = System.Drawing.SystemColors.Menu;
            this.CentBoardingTextBox1.Location = new System.Drawing.Point(3, 10);
            this.CentBoardingTextBox1.Name = "CentBoardingTextBox1";
            this.CentBoardingTextBox1.ReadOnly = true;
            this.CentBoardingTextBox1.Size = new System.Drawing.Size(18, 13);
            this.CentBoardingTextBox1.TabIndex = 0;
            this.CentBoardingTextBox1.Text = "0";
            // 
            // CentBoardingTextBox2
            // 
            this.CentBoardingTextBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CentBoardingTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CentBoardingTextBox2.ForeColor = System.Drawing.SystemColors.Menu;
            this.CentBoardingTextBox2.Location = new System.Drawing.Point(27, 10);
            this.CentBoardingTextBox2.Name = "CentBoardingTextBox2";
            this.CentBoardingTextBox2.ReadOnly = true;
            this.CentBoardingTextBox2.Size = new System.Drawing.Size(18, 13);
            this.CentBoardingTextBox2.TabIndex = 1;
            this.CentBoardingTextBox2.Text = "0";
            // 
            // CentBoardingTextBox3
            // 
            this.CentBoardingTextBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CentBoardingTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CentBoardingTextBox3.ForeColor = System.Drawing.SystemColors.Menu;
            this.CentBoardingTextBox3.Location = new System.Drawing.Point(51, 10);
            this.CentBoardingTextBox3.Name = "CentBoardingTextBox3";
            this.CentBoardingTextBox3.ReadOnly = true;
            this.CentBoardingTextBox3.Size = new System.Drawing.Size(18, 13);
            this.CentBoardingTextBox3.TabIndex = 2;
            this.CentBoardingTextBox3.Text = "0";
            // 
            // CentBoardingTextBox4
            // 
            this.CentBoardingTextBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CentBoardingTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CentBoardingTextBox4.ForeColor = System.Drawing.SystemColors.Menu;
            this.CentBoardingTextBox4.Location = new System.Drawing.Point(75, 10);
            this.CentBoardingTextBox4.Name = "CentBoardingTextBox4";
            this.CentBoardingTextBox4.ReadOnly = true;
            this.CentBoardingTextBox4.Size = new System.Drawing.Size(18, 13);
            this.CentBoardingTextBox4.TabIndex = 3;
            this.CentBoardingTextBox4.Text = "0";
            // 
            // CentBoardingTextBox5
            // 
            this.CentBoardingTextBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CentBoardingTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CentBoardingTextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CentBoardingTextBox5.ForeColor = System.Drawing.Color.Red;
            this.CentBoardingTextBox5.Location = new System.Drawing.Point(99, 10);
            this.CentBoardingTextBox5.Name = "CentBoardingTextBox5";
            this.CentBoardingTextBox5.ReadOnly = true;
            this.CentBoardingTextBox5.Size = new System.Drawing.Size(18, 13);
            this.CentBoardingTextBox5.TabIndex = 4;
            this.CentBoardingTextBox5.Text = "0";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(344, 515);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown1.TabIndex = 27;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(388, 515);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown2.TabIndex = 28;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(432, 515);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown3.TabIndex = 29;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(476, 515);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown4.TabIndex = 30;
            // 
            // FuelLabel
            // 
            this.FuelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FuelLabel.AutoSize = true;
            this.FuelLabel.Location = new System.Drawing.Point(344, 499);
            this.FuelLabel.Name = "FuelLabel";
            this.FuelLabel.Size = new System.Drawing.Size(27, 13);
            this.FuelLabel.TabIndex = 31;
            this.FuelLabel.Text = "Fuel";
            // 
            // FoodLabel
            // 
            this.FoodLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FoodLabel.AutoSize = true;
            this.FoodLabel.Location = new System.Drawing.Point(388, 499);
            this.FoodLabel.Name = "FoodLabel";
            this.FoodLabel.Size = new System.Drawing.Size(31, 13);
            this.FoodLabel.TabIndex = 32;
            this.FoodLabel.Text = "Food";
            // 
            // MoraleLabel
            // 
            this.MoraleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MoraleLabel.AutoSize = true;
            this.MoraleLabel.Location = new System.Drawing.Point(432, 486);
            this.MoraleLabel.Name = "MoraleLabel";
            this.MoraleLabel.Size = new System.Drawing.Size(33, 26);
            this.MoraleLabel.TabIndex = 33;
            this.MoraleLabel.Text = "Morale";
            // 
            // PopulationLabel
            // 
            this.PopulationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PopulationLabel.AutoSize = true;
            this.PopulationLabel.Location = new System.Drawing.Point(476, 499);
            this.PopulationLabel.Name = "PopulationLabel";
            this.PopulationLabel.Size = new System.Drawing.Size(26, 13);
            this.PopulationLabel.TabIndex = 34;
            this.PopulationLabel.Text = "Pop";
            // 
            // CrisisLabel
            // 
            this.CrisisLabel.AutoSize = true;
            this.CrisisLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrisisLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrisisLabel.Location = new System.Drawing.Point(3, 105);
            this.CrisisLabel.Name = "CrisisLabel";
            this.tableLayoutPanel1.SetRowSpan(this.CrisisLabel, 4);
            this.CrisisLabel.Size = new System.Drawing.Size(158, 148);
            this.CrisisLabel.TabIndex = 35;
            this.CrisisLabel.Text = "CrisisLabel";
            // 
            // PlayerReadonlyListBox
            // 
            this.PlayerReadonlyListBox.BackColor = System.Drawing.SystemColors.Menu;
            this.PlayerReadonlyListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayerReadonlyListBox.ContextMenuStrip = this.PlayerRightClickMenu;
            this.PlayerReadonlyListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerReadonlyListBox.FormattingEnabled = true;
            this.PlayerReadonlyListBox.HorizontalScrollbar = true;
            this.PlayerReadonlyListBox.Location = new System.Drawing.Point(3, 3);
            this.PlayerReadonlyListBox.Name = "PlayerReadonlyListBox";
            this.PlayerReadonlyListBox.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.PlayerReadonlyListBox, 3);
            this.PlayerReadonlyListBox.Size = new System.Drawing.Size(158, 99);
            this.PlayerReadonlyListBox.TabIndex = 24;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.MainMenuStrip);
            this.Name = "GameWindow";
            this.Text = "GameWindow";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.PlayerRightClickMenu.ResumeLayout(false);
            this.JumpPrepGroupBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.CentBoardingGroupBox.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
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
        private System.Windows.Forms.ContextMenuStrip PlayerRightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem ShowHandMenuItem;
        private System.Windows.Forms.ListBox EchoDradisListBox;
        private System.Windows.Forms.ListBox FoxtrotDradisListBox;
        private System.Windows.Forms.ListBox DeltaDradisListBox;
        private System.Windows.Forms.ListBox BravoDradisListBox;
        private System.Windows.Forms.ListBox CharlieDradisListBox;
        private System.Windows.Forms.ListBox AlphaDradisListBox;
        private System.Windows.Forms.Button BravoToCharlieButton;
        private System.Windows.Forms.Button CharlieToBravoButton;
        private System.Windows.Forms.Button EchoToFoxtrotButton;
        private System.Windows.Forms.Button FoxtrotToEchoButton;
        private System.Windows.Forms.ListBox GalacticaBoardListBox;
        private System.Windows.Forms.ListBox ColonialOneListBox;
        private System.Windows.Forms.ListBox CylonBoardListBox;
        private System.Windows.Forms.Button AlphaToBravoButton;
        private System.Windows.Forms.Button BravoToAlphaButton;
        private System.Windows.Forms.Button DeltaToCharlieButton;
        private System.Windows.Forms.Button CharlieToDeltaButton;
        private System.Windows.Forms.Button EchoToDeltaButton;
        private System.Windows.Forms.Button DeltaToEchoButton;
        private System.Windows.Forms.Button AlphaToFoxtrotButton;
        private System.Windows.Forms.Button FoxtrotToAlphaButton;
        private CustomControls.ReadOnlyListBox PlayerReadonlyListBox;
        private System.Windows.Forms.GroupBox JumpPrepGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton Red1RadioButton;
        private System.Windows.Forms.RadioButton Red2RadioButton;
        private System.Windows.Forms.RadioButton Red3RadioButton;
        private System.Windows.Forms.RadioButton Risk3RadioButton;
        private System.Windows.Forms.RadioButton Risk1RadioButton;
        private System.Windows.Forms.RadioButton JumpNowRadioButton;
        private System.Windows.Forms.GroupBox CentBoardingGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox CentBoardingTextBox1;
        private System.Windows.Forms.TextBox CentBoardingTextBox2;
        private System.Windows.Forms.TextBox CentBoardingTextBox3;
        private System.Windows.Forms.TextBox CentBoardingTextBox4;
        private System.Windows.Forms.TextBox CentBoardingTextBox5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label FuelLabel;
        private System.Windows.Forms.Label FoodLabel;
        private System.Windows.Forms.Label MoraleLabel;
        private System.Windows.Forms.Label PopulationLabel;
        private System.Windows.Forms.Label CrisisLabel;
    }
}