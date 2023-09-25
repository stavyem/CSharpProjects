using System;
using System.Windows.Forms;

namespace ReversedXMixDrix
{
    internal partial class GameSettingsForm : Form
    {
        internal GameSettingsForm()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            this.startButton.DialogResult = DialogResult.OK;
            this.Hide();
            int sizeBoard = (int)nUDCols.Value;
            int numOfPlayers = player2CB.Checked ? 2 : 1;
            GameBoardForm gameBoardForm = new GameBoardForm(sizeBoard, numOfPlayers, textBoxPlayer1.Text, textBoxPlayer2.Text);
            gameBoardForm.ShowDialog();
        }

        private void player2CB_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPlayer2.Enabled = player2CB.Checked;
            textBoxPlayer2.Text = player2CB.Checked ? String.Empty : "[Computer]";
            if (textBoxPlayer1.Text.Length > 0 && !player2CB.Checked)
            {
                startButton.Enabled = true;
            }
            else
            {
                startButton.Enabled = false;
            }
        }

        private void nUDCols_ValueChanged(object sender, EventArgs e)
        {
            this.nUDRows.Value = this.nUDCols.Value;
        }

        private void nUDRows_ValueChanged(object sender, EventArgs e)
        {
            this.nUDCols.Value = this.nUDRows.Value;
        }

        private void textBoxPlayer1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPlayer1.Text.Length > 0)
            {
                if (player2CB.Checked)
                {
                    startButton.Enabled = textBoxPlayer2.Text.Length > 0;
                }
                else
                {
                    startButton.Enabled = true;
                }
            }
            else
            {
                startButton.Enabled = false;
            }
        }

        private void textBoxPlayer2_TextChanged(object sender, EventArgs e)
        {
            if (player2CB.Checked && textBoxPlayer2.Text.Length > 0 && textBoxPlayer1.Text.Length > 0)
            {
                startButton.Enabled = true;
            }
            else
            {
                startButton.Enabled = false;
            }
        }
    }
}
