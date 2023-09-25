namespace ReversedXMixDrix
{
    partial class GameSettingsForm
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
            this.startButton = new System.Windows.Forms.Button();
            this.players = new System.Windows.Forms.Label();
            this.player1Label = new System.Windows.Forms.Label();
            this.player2CB = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.boardSize = new System.Windows.Forms.Label();
            this.rows = new System.Windows.Forms.Label();
            this.nUDRows = new System.Windows.Forms.NumericUpDown();
            this.nUDCols = new System.Windows.Forms.NumericUpDown();
            this.cols = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.startButton.Location = new System.Drawing.Point(59, 265);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(266, 40);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.start_Click);
            // 
            // players
            // 
            this.players.AutoSize = true;
            this.players.Location = new System.Drawing.Point(33, 27);
            this.players.Name = "players";
            this.players.Size = new System.Drawing.Size(64, 18);
            this.players.TabIndex = 1;
            this.players.Text = "Players:";
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Location = new System.Drawing.Point(56, 75);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(69, 18);
            this.player1Label.TabIndex = 3;
            this.player1Label.Text = "Player 1:";
            // 
            // player2CB
            // 
            this.player2CB.AutoSize = true;
            this.player2CB.Location = new System.Drawing.Point(59, 109);
            this.player2CB.Name = "player2CB";
            this.player2CB.Size = new System.Drawing.Size(95, 22);
            this.player2CB.TabIndex = 4;
            this.player2CB.Text = "Player 2:";
            this.player2CB.UseVisualStyleBackColor = true;
            this.player2CB.CheckedChanged += new System.EventHandler(this.player2CB_CheckedChanged);
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(161, 75);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(130, 26);
            this.textBoxPlayer1.TabIndex = 5;
            this.textBoxPlayer1.TextChanged += new System.EventHandler(this.textBoxPlayer1_TextChanged);
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.Location = new System.Drawing.Point(161, 107);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(130, 26);
            this.textBoxPlayer2.TabIndex = 6;
            this.textBoxPlayer2.Text = "[Computer]";
            this.textBoxPlayer2.TextChanged += new System.EventHandler(this.textBoxPlayer2_TextChanged);
            // 
            // boardSize
            // 
            this.boardSize.AutoSize = true;
            this.boardSize.Location = new System.Drawing.Point(33, 169);
            this.boardSize.Name = "boardSize";
            this.boardSize.Size = new System.Drawing.Size(90, 18);
            this.boardSize.TabIndex = 7;
            this.boardSize.Text = "Board Size:";
            // 
            // rows
            // 
            this.rows.AutoSize = true;
            this.rows.Location = new System.Drawing.Point(56, 213);
            this.rows.Name = "rows";
            this.rows.Size = new System.Drawing.Size(51, 18);
            this.rows.TabIndex = 8;
            this.rows.Text = "Rows:";
            // 
            // nUDRows
            // 
            this.nUDRows.Location = new System.Drawing.Point(113, 211);
            this.nUDRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDRows.Name = "nUDRows";
            this.nUDRows.Size = new System.Drawing.Size(47, 26);
            this.nUDRows.TabIndex = 9;
            this.nUDRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDRows.ValueChanged += new System.EventHandler(this.nUDRows_ValueChanged);
            // 
            // nUDCols
            // 
            this.nUDCols.Location = new System.Drawing.Point(269, 211);
            this.nUDCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDCols.Name = "nUDCols";
            this.nUDCols.Size = new System.Drawing.Size(47, 26);
            this.nUDCols.TabIndex = 11;
            this.nUDCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDCols.ValueChanged += new System.EventHandler(this.nUDCols_ValueChanged);
            // 
            // cols
            // 
            this.cols.AutoSize = true;
            this.cols.Location = new System.Drawing.Point(212, 213);
            this.cols.Name = "cols";
            this.cols.Size = new System.Drawing.Size(44, 18);
            this.cols.TabIndex = 10;
            this.cols.Text = "Cols:";
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(379, 317);
            this.Controls.Add(this.nUDCols);
            this.Controls.Add(this.cols);
            this.Controls.Add(this.nUDRows);
            this.Controls.Add(this.rows);
            this.Controls.Add(this.boardSize);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.player2CB);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.players);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GameSettingsForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label players;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.CheckBox player2CB;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.Label boardSize;
        private System.Windows.Forms.Label rows;
        private System.Windows.Forms.NumericUpDown nUDRows;
        private System.Windows.Forms.NumericUpDown nUDCols;
        private System.Windows.Forms.Label cols;
    }
}

