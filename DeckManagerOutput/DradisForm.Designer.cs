namespace DeckManagerOutput
{
    partial class DradisForm
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

        protected override void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
        {
            //base.OnFormClosing(e);

            //if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown) return;
            e.Cancel = true;
            this.Hide();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.bravoListBox = new System.Windows.Forms.ListBox();
            this.alphaListBox = new System.Windows.Forms.ListBox();
            this.foxtrotListBox = new System.Windows.Forms.ListBox();
            this.echoListBox = new System.Windows.Forms.ListBox();
            this.deltaListBox = new System.Windows.Forms.ListBox();
            this.charlieListBox = new System.Windows.Forms.ListBox();
            this.AtoBButton = new System.Windows.Forms.Button();
            this.AtoFButton = new System.Windows.Forms.Button();
            this.FtoAButton = new System.Windows.Forms.Button();
            this.BtoAButton = new System.Windows.Forms.Button();
            this.BtoCButton = new System.Windows.Forms.Button();
            this.CtoBButton = new System.Windows.Forms.Button();
            this.FtoEButton = new System.Windows.Forms.Button();
            this.EtoFButton = new System.Windows.Forms.Button();
            this.EtoDButton = new System.Windows.Forms.Button();
            this.DtoEButton = new System.Windows.Forms.Button();
            this.CtoDButton = new System.Windows.Forms.Button();
            this.DtoCButton = new System.Windows.Forms.Button();
            this.RecallVipersButton = new System.Windows.Forms.Button();
            this.BoardingTrackPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.LaunchLocationComboBox = new System.Windows.Forms.ComboBox();
            this.DamageGalacticaButton = new System.Windows.Forms.Button();
            this.LaunchComponentComboBox = new System.Windows.Forms.ComboBox();
            this.DrawnDamageTokensListBox = new System.Windows.Forms.ListBox();
            this.DrawDamageTokenButton = new System.Windows.Forms.Button();
            this.DiscardDamageTokenButton = new System.Windows.Forms.Button();
            this.DestroyComponentsButton = new System.Windows.Forms.Button();
            this.RecallComponentsButton = new System.Windows.Forms.Button();
            this.DestroyComponentsTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.RecallComponentsTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.DamageVipersButton = new System.Windows.Forms.Button();
            this.DamageVipersTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.RecallVipersTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.DiscardDamageTokenTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.DamageGalacticaTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.BoardingTrackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Galactica";
            // 
            // bravoListBox
            // 
            this.bravoListBox.FormattingEnabled = true;
            this.bravoListBox.Location = new System.Drawing.Point(104, 12);
            this.bravoListBox.Name = "bravoListBox";
            this.bravoListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.bravoListBox.Size = new System.Drawing.Size(120, 95);
            this.bravoListBox.TabIndex = 1;
            // 
            // alphaListBox
            // 
            this.alphaListBox.FormattingEnabled = true;
            this.alphaListBox.Location = new System.Drawing.Point(12, 169);
            this.alphaListBox.Name = "alphaListBox";
            this.alphaListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.alphaListBox.Size = new System.Drawing.Size(120, 95);
            this.alphaListBox.TabIndex = 2;
            // 
            // foxtrotListBox
            // 
            this.foxtrotListBox.FormattingEnabled = true;
            this.foxtrotListBox.Location = new System.Drawing.Point(104, 323);
            this.foxtrotListBox.Name = "foxtrotListBox";
            this.foxtrotListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.foxtrotListBox.Size = new System.Drawing.Size(120, 95);
            this.foxtrotListBox.TabIndex = 3;
            // 
            // echoListBox
            // 
            this.echoListBox.FormattingEnabled = true;
            this.echoListBox.Location = new System.Drawing.Point(351, 323);
            this.echoListBox.Name = "echoListBox";
            this.echoListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.echoListBox.Size = new System.Drawing.Size(120, 95);
            this.echoListBox.TabIndex = 4;
            // 
            // deltaListBox
            // 
            this.deltaListBox.FormattingEnabled = true;
            this.deltaListBox.Location = new System.Drawing.Point(455, 169);
            this.deltaListBox.Name = "deltaListBox";
            this.deltaListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.deltaListBox.Size = new System.Drawing.Size(120, 95);
            this.deltaListBox.TabIndex = 5;
            // 
            // charlieListBox
            // 
            this.charlieListBox.FormattingEnabled = true;
            this.charlieListBox.Location = new System.Drawing.Point(351, 12);
            this.charlieListBox.Name = "charlieListBox";
            this.charlieListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.charlieListBox.Size = new System.Drawing.Size(120, 95);
            this.charlieListBox.TabIndex = 6;
            // 
            // AtoBButton
            // 
            this.AtoBButton.Location = new System.Drawing.Point(104, 140);
            this.AtoBButton.Name = "AtoBButton";
            this.AtoBButton.Size = new System.Drawing.Size(75, 23);
            this.AtoBButton.TabIndex = 7;
            this.AtoBButton.Text = "↑";
            this.AtoBButton.UseVisualStyleBackColor = true;
            this.AtoBButton.Click += new System.EventHandler(this.AtoBButton_Click);
            // 
            // AtoFButton
            // 
            this.AtoFButton.Location = new System.Drawing.Point(104, 270);
            this.AtoFButton.Name = "AtoFButton";
            this.AtoFButton.Size = new System.Drawing.Size(75, 23);
            this.AtoFButton.TabIndex = 8;
            this.AtoFButton.Text = "↓";
            this.AtoFButton.UseVisualStyleBackColor = true;
            // 
            // FtoAButton
            // 
            this.FtoAButton.Location = new System.Drawing.Point(104, 294);
            this.FtoAButton.Name = "FtoAButton";
            this.FtoAButton.Size = new System.Drawing.Size(75, 23);
            this.FtoAButton.TabIndex = 9;
            this.FtoAButton.Text = "↑";
            this.FtoAButton.UseVisualStyleBackColor = true;
            this.FtoAButton.Click += new System.EventHandler(this.FtoAButton_Click);
            // 
            // BtoAButton
            // 
            this.BtoAButton.Location = new System.Drawing.Point(104, 111);
            this.BtoAButton.Name = "BtoAButton";
            this.BtoAButton.Size = new System.Drawing.Size(75, 23);
            this.BtoAButton.TabIndex = 10;
            this.BtoAButton.Text = "↓";
            this.BtoAButton.UseVisualStyleBackColor = true;
            this.BtoAButton.Click += new System.EventHandler(this.BtoAButton_Click);
            // 
            // BtoCButton
            // 
            this.BtoCButton.Location = new System.Drawing.Point(231, 83);
            this.BtoCButton.Name = "BtoCButton";
            this.BtoCButton.Size = new System.Drawing.Size(75, 23);
            this.BtoCButton.TabIndex = 11;
            this.BtoCButton.Text = "→";
            this.BtoCButton.UseVisualStyleBackColor = true;
            this.BtoCButton.Click += new System.EventHandler(this.BtoCButton_Click);
            // 
            // CtoBButton
            // 
            this.CtoBButton.Location = new System.Drawing.Point(270, 12);
            this.CtoBButton.Name = "CtoBButton";
            this.CtoBButton.Size = new System.Drawing.Size(75, 23);
            this.CtoBButton.TabIndex = 12;
            this.CtoBButton.Text = "←";
            this.CtoBButton.UseVisualStyleBackColor = true;
            this.CtoBButton.Click += new System.EventHandler(this.CtoBButton_Click);
            // 
            // FtoEButton
            // 
            this.FtoEButton.Location = new System.Drawing.Point(230, 323);
            this.FtoEButton.Name = "FtoEButton";
            this.FtoEButton.Size = new System.Drawing.Size(75, 23);
            this.FtoEButton.TabIndex = 13;
            this.FtoEButton.Text = "→";
            this.FtoEButton.UseVisualStyleBackColor = true;
            this.FtoEButton.Click += new System.EventHandler(this.FtoEButton_Click);
            // 
            // EtoFButton
            // 
            this.EtoFButton.Location = new System.Drawing.Point(269, 394);
            this.EtoFButton.Name = "EtoFButton";
            this.EtoFButton.Size = new System.Drawing.Size(75, 23);
            this.EtoFButton.TabIndex = 14;
            this.EtoFButton.Text = "←";
            this.EtoFButton.UseVisualStyleBackColor = true;
            this.EtoFButton.Click += new System.EventHandler(this.EtoFButton_Click);
            // 
            // EtoDButton
            // 
            this.EtoDButton.Location = new System.Drawing.Point(395, 294);
            this.EtoDButton.Name = "EtoDButton";
            this.EtoDButton.Size = new System.Drawing.Size(75, 23);
            this.EtoDButton.TabIndex = 15;
            this.EtoDButton.Text = "↑";
            this.EtoDButton.UseVisualStyleBackColor = true;
            this.EtoDButton.Click += new System.EventHandler(this.EtoDButton_Click);
            // 
            // DtoEButton
            // 
            this.DtoEButton.Location = new System.Drawing.Point(395, 270);
            this.DtoEButton.Name = "DtoEButton";
            this.DtoEButton.Size = new System.Drawing.Size(75, 23);
            this.DtoEButton.TabIndex = 16;
            this.DtoEButton.Text = "↓";
            this.DtoEButton.UseVisualStyleBackColor = true;
            this.DtoEButton.Click += new System.EventHandler(this.DtoEButton_Click);
            // 
            // CtoDButton
            // 
            this.CtoDButton.Location = new System.Drawing.Point(455, 111);
            this.CtoDButton.Name = "CtoDButton";
            this.CtoDButton.Size = new System.Drawing.Size(75, 23);
            this.CtoDButton.TabIndex = 17;
            this.CtoDButton.Text = "↓";
            this.CtoDButton.UseVisualStyleBackColor = true;
            this.CtoDButton.Click += new System.EventHandler(this.CtoDButton_Click);
            // 
            // DtoCButton
            // 
            this.DtoCButton.Location = new System.Drawing.Point(455, 140);
            this.DtoCButton.Name = "DtoCButton";
            this.DtoCButton.Size = new System.Drawing.Size(75, 23);
            this.DtoCButton.TabIndex = 18;
            this.DtoCButton.Text = "↑";
            this.DtoCButton.UseVisualStyleBackColor = true;
            this.DtoCButton.Click += new System.EventHandler(this.DtoCButton_Click);
            // 
            // RecallVipersButton
            // 
            this.RecallVipersButton.Location = new System.Drawing.Point(672, 224);
            this.RecallVipersButton.Name = "RecallVipersButton";
            this.RecallVipersButton.Size = new System.Drawing.Size(75, 37);
            this.RecallVipersButton.TabIndex = 20;
            this.RecallVipersButton.Text = "Recall Vipers";
            this.RecallVipersTooltip.SetToolTip(this.RecallVipersButton, "Recalls all selected Vipers to the Reserves.\r\nIf no Vipers are selected, ALL Vipe" +
        "rs will be returned to reserves.");
            this.RecallVipersButton.UseVisualStyleBackColor = true;
            // 
            // BoardingTrackPanel
            // 
            this.BoardingTrackPanel.Controls.Add(this.textBox1);
            this.BoardingTrackPanel.Controls.Add(this.numericUpDown4);
            this.BoardingTrackPanel.Controls.Add(this.numericUpDown3);
            this.BoardingTrackPanel.Controls.Add(this.numericUpDown2);
            this.BoardingTrackPanel.Controls.Add(this.numericUpDown1);
            this.BoardingTrackPanel.Controls.Add(this.label2);
            this.BoardingTrackPanel.Location = new System.Drawing.Point(515, 12);
            this.BoardingTrackPanel.Name = "BoardingTrackPanel";
            this.BoardingTrackPanel.Size = new System.Drawing.Size(232, 62);
            this.BoardingTrackPanel.TabIndex = 21;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(158, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Game Over";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(120, 29);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(32, 20);
            this.numericUpDown4.TabIndex = 4;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(82, 29);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(32, 20);
            this.numericUpDown3.TabIndex = 3;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(45, 29);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(32, 20);
            this.numericUpDown2.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(7, 29);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(32, 20);
            this.numericUpDown1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Boarding Track";
            // 
            // LaunchLocationComboBox
            // 
            this.LaunchLocationComboBox.FormattingEnabled = true;
            this.LaunchLocationComboBox.Location = new System.Drawing.Point(626, 80);
            this.LaunchLocationComboBox.Name = "LaunchLocationComboBox";
            this.LaunchLocationComboBox.Size = new System.Drawing.Size(121, 21);
            this.LaunchLocationComboBox.TabIndex = 23;
            this.LaunchLocationComboBox.Text = "in...";
            this.LaunchLocationComboBox.SelectedIndexChanged += new System.EventHandler(this.LaunchLocationComboBox_SelectedIndexChanged);
            // 
            // DamageGalacticaButton
            // 
            this.DamageGalacticaButton.Location = new System.Drawing.Point(672, 380);
            this.DamageGalacticaButton.Name = "DamageGalacticaButton";
            this.DamageGalacticaButton.Size = new System.Drawing.Size(75, 36);
            this.DamageGalacticaButton.TabIndex = 24;
            this.DamageGalacticaButton.Text = "Damage Galactica";
            this.DamageGalacticaTooltip.SetToolTip(this.DamageGalacticaButton, "Applies all currently selected Galactica Damage tokens, then marks them as resolv" +
        "ed.");
            this.DamageGalacticaButton.UseVisualStyleBackColor = true;
            this.DamageGalacticaButton.Click += new System.EventHandler(this.DamageGalacticaButton_Click);
            // 
            // LaunchComponentComboBox
            // 
            this.LaunchComponentComboBox.FormattingEnabled = true;
            this.LaunchComponentComboBox.Location = new System.Drawing.Point(515, 79);
            this.LaunchComponentComboBox.Name = "LaunchComponentComboBox";
            this.LaunchComponentComboBox.Size = new System.Drawing.Size(105, 21);
            this.LaunchComponentComboBox.TabIndex = 25;
            this.LaunchComponentComboBox.Text = "Launch...";
            this.LaunchComponentComboBox.SelectedIndexChanged += new System.EventHandler(this.LaunchComponentComboBox_SelectedIndexChanged);
            // 
            // DrawnDamageTokensListBox
            // 
            this.DrawnDamageTokensListBox.FormattingEnabled = true;
            this.DrawnDamageTokensListBox.Location = new System.Drawing.Point(547, 335);
            this.DrawnDamageTokensListBox.Name = "DrawnDamageTokensListBox";
            this.DrawnDamageTokensListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.DrawnDamageTokensListBox.Size = new System.Drawing.Size(120, 82);
            this.DrawnDamageTokensListBox.TabIndex = 26;
            // 
            // DrawDamageTokenButton
            // 
            this.DrawDamageTokenButton.Location = new System.Drawing.Point(479, 335);
            this.DrawDamageTokenButton.Name = "DrawDamageTokenButton";
            this.DrawDamageTokenButton.Size = new System.Drawing.Size(63, 52);
            this.DrawDamageTokenButton.TabIndex = 27;
            this.DrawDamageTokenButton.Text = "Draw Damage Token";
            this.DrawDamageTokenButton.UseVisualStyleBackColor = true;
            this.DrawDamageTokenButton.Click += new System.EventHandler(this.DrawDamageTokenButton_Click);
            // 
            // DiscardDamageTokenButton
            // 
            this.DiscardDamageTokenButton.Location = new System.Drawing.Point(480, 393);
            this.DiscardDamageTokenButton.Name = "DiscardDamageTokenButton";
            this.DiscardDamageTokenButton.Size = new System.Drawing.Size(62, 23);
            this.DiscardDamageTokenButton.TabIndex = 28;
            this.DiscardDamageTokenButton.Text = "Discard";
            this.DiscardDamageTokenTooltip.SetToolTip(this.DiscardDamageTokenButton, "Places the selected Damage tokens back into the pile of unresolved Damage tokens." +
        "\r\nTokens discarded in this way may be drawn again in the future.");
            this.DiscardDamageTokenButton.UseVisualStyleBackColor = true;
            this.DiscardDamageTokenButton.Click += new System.EventHandler(this.DiscardDamageTokenButton_Click);
            // 
            // DestroyComponentsButton
            // 
            this.DestroyComponentsButton.Location = new System.Drawing.Point(672, 111);
            this.DestroyComponentsButton.Name = "DestroyComponentsButton";
            this.DestroyComponentsButton.Size = new System.Drawing.Size(75, 52);
            this.DestroyComponentsButton.TabIndex = 29;
            this.DestroyComponentsButton.Text = "Destroy Selected Components";
            this.DestroyComponentsTooltip.SetToolTip(this.DestroyComponentsButton, "Destroys all selected components in all sectors. This will place Cylon ships\r\nbac" +
        "k in the box and remove Civilian ships from the game, as examples.");
            this.DestroyComponentsButton.UseVisualStyleBackColor = true;
            this.DestroyComponentsButton.Click += new System.EventHandler(this.DestroyComponentsButton_Click);
            // 
            // RecallComponentsButton
            // 
            this.RecallComponentsButton.Location = new System.Drawing.Point(672, 169);
            this.RecallComponentsButton.Name = "RecallComponentsButton";
            this.RecallComponentsButton.Size = new System.Drawing.Size(75, 49);
            this.RecallComponentsButton.TabIndex = 30;
            this.RecallComponentsButton.Text = "Recall Selected Components";
            this.RecallComponentsTooltip.SetToolTip(this.RecallComponentsButton, "Removes all selected components in all sectors\r\nfrom the board and places them ba" +
        "ck in the box.");
            this.RecallComponentsButton.UseVisualStyleBackColor = true;
            this.RecallComponentsButton.Click += new System.EventHandler(this.RecallComponentsButton_Click);
            // 
            // DamageVipersButton
            // 
            this.DamageVipersButton.Location = new System.Drawing.Point(671, 268);
            this.DamageVipersButton.Name = "DamageVipersButton";
            this.DamageVipersButton.Size = new System.Drawing.Size(75, 38);
            this.DamageVipersButton.TabIndex = 31;
            this.DamageVipersButton.Text = "Damage Vipers";
            this.DamageVipersTooltip.SetToolTip(this.DamageVipersButton, "Removes all selected Vipers from the board and sets their condition to Damaged.");
            this.DamageVipersButton.UseVisualStyleBackColor = true;
            // 
            // DradisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 437);
            this.Controls.Add(this.DamageVipersButton);
            this.Controls.Add(this.RecallComponentsButton);
            this.Controls.Add(this.DestroyComponentsButton);
            this.Controls.Add(this.DiscardDamageTokenButton);
            this.Controls.Add(this.DrawDamageTokenButton);
            this.Controls.Add(this.DrawnDamageTokensListBox);
            this.Controls.Add(this.LaunchComponentComboBox);
            this.Controls.Add(this.DamageGalacticaButton);
            this.Controls.Add(this.LaunchLocationComboBox);
            this.Controls.Add(this.BoardingTrackPanel);
            this.Controls.Add(this.RecallVipersButton);
            this.Controls.Add(this.DtoCButton);
            this.Controls.Add(this.CtoDButton);
            this.Controls.Add(this.DtoEButton);
            this.Controls.Add(this.EtoDButton);
            this.Controls.Add(this.EtoFButton);
            this.Controls.Add(this.FtoEButton);
            this.Controls.Add(this.CtoBButton);
            this.Controls.Add(this.BtoCButton);
            this.Controls.Add(this.BtoAButton);
            this.Controls.Add(this.FtoAButton);
            this.Controls.Add(this.AtoFButton);
            this.Controls.Add(this.AtoBButton);
            this.Controls.Add(this.charlieListBox);
            this.Controls.Add(this.deltaListBox);
            this.Controls.Add(this.echoListBox);
            this.Controls.Add(this.foxtrotListBox);
            this.Controls.Add(this.alphaListBox);
            this.Controls.Add(this.bravoListBox);
            this.Controls.Add(this.label1);
            this.Name = "DradisForm";
            this.Text = "DradisForm";
            this.BoardingTrackPanel.ResumeLayout(false);
            this.BoardingTrackPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void LaunchLocationComboBox_LostFocus(object sender, System.EventArgs e)
        {
            
            // if both component and location have option selected, place component and reset combo boxes

            // if only location has selection, do nothing until component box gets selection
        }

        // don't let the users shit up these boxes with nonsense 
        void LaunchLocationComboBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            { 
                case 'a':
                case 'A':
                    LaunchLocationComboBox.SelectedIndex = 0;
                    break;
                case 'b':
                case 'B':
                    LaunchLocationComboBox.SelectedIndex = 1;
                    break;
                case 'c':
                case 'C':
                    LaunchLocationComboBox.SelectedIndex = 2;
                    break;
                case 'd':
                case 'D':
                    LaunchLocationComboBox.SelectedIndex = 3;
                    break;
                case 'e':
                case 'E':
                    LaunchLocationComboBox.SelectedIndex = 4;
                    break;
                case 'f':
                case 'F':
                    LaunchLocationComboBox.SelectedIndex = 5;  
                    break;
                     
            }


            e.Handled = true;
        }
        void LaunchComponentComboBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox bravoListBox;
        private System.Windows.Forms.ListBox alphaListBox;
        private System.Windows.Forms.ListBox foxtrotListBox;
        private System.Windows.Forms.ListBox echoListBox;
        private System.Windows.Forms.ListBox deltaListBox;
        private System.Windows.Forms.ListBox charlieListBox;
        private System.Windows.Forms.Button AtoBButton;
        private System.Windows.Forms.Button AtoFButton;
        private System.Windows.Forms.Button FtoAButton;
        private System.Windows.Forms.Button BtoAButton;
        private System.Windows.Forms.Button BtoCButton;
        private System.Windows.Forms.Button CtoBButton;
        private System.Windows.Forms.Button FtoEButton;
        private System.Windows.Forms.Button EtoFButton;
        private System.Windows.Forms.Button EtoDButton;
        private System.Windows.Forms.Button DtoEButton;
        private System.Windows.Forms.Button CtoDButton;
        private System.Windows.Forms.Button DtoCButton;
        private System.Windows.Forms.Button RecallVipersButton;
        private System.Windows.Forms.Panel BoardingTrackPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox LaunchLocationComboBox;
        private System.Windows.Forms.Button DamageGalacticaButton;
        private System.Windows.Forms.ComboBox LaunchComponentComboBox;
        private System.Windows.Forms.ListBox DrawnDamageTokensListBox;
        private System.Windows.Forms.Button DrawDamageTokenButton;
        private System.Windows.Forms.Button DiscardDamageTokenButton;
        private System.Windows.Forms.Button DestroyComponentsButton;
        private System.Windows.Forms.Button RecallComponentsButton;
        private System.Windows.Forms.ToolTip DestroyComponentsTooltip;
        private System.Windows.Forms.ToolTip RecallComponentsTooltip;
        private System.Windows.Forms.Button DamageVipersButton;
        private System.Windows.Forms.ToolTip DamageVipersTooltip;
        private System.Windows.Forms.ToolTip RecallVipersTooltip;
        private System.Windows.Forms.ToolTip DiscardDamageTokenTooltip;
        private System.Windows.Forms.ToolTip DamageGalacticaTooltip;
    }
}