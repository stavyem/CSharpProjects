using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static ReversedXMixDrix.GameLogic;


namespace ReversedXMixDrix
{
    internal partial class GameBoardForm : Form
    {
        private readonly GameLogic r_GameLogic;
        private readonly Font r_CurrentPlayerFont;
        private readonly Font r_WaitingPlayerFont;
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private readonly string r_Player1Name;
        private readonly string r_Player2Name;
        private eGameState m_GameState;

        internal GameBoardForm(int i_BoardSize, int i_NumberOfPlayers, string i_Player1Name, string i_Player2Name)
        {
            r_GameLogic = new GameLogic(i_BoardSize, i_NumberOfPlayers);

            InitializeComponent();
            labelPlayer1.Text = $"{i_Player1Name}:";
            r_Player1Name = i_Player1Name;
            if (i_NumberOfPlayers == 2)
            {
                labelPlayer2.Text = $"{i_Player2Name}:";
                r_Player2Name = i_Player2Name;
            }
            else
            {
                r_Player2Name = "Computer";
            }

            r_CurrentPlayerFont = new Font(labelPlayer1.Font, FontStyle.Bold);
            r_WaitingPlayerFont = new Font(labelPlayer2.Font, FontStyle.Regular);
            r_Player1 = r_GameLogic.Players[0];
            r_Player2 = r_GameLogic.Players[1];
            r_GameLogic.StartGame();
            initializeCells(i_BoardSize);
        }

        private void initializeCells(int i_BoardSize)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = i_BoardSize;
            tableLayoutPanel1.ColumnCount = i_BoardSize;
            int buttonWidth = (tableLayoutPanel1.ClientSize.Width - 6 * i_BoardSize) / i_BoardSize;
            int buttonHeight = (tableLayoutPanel1.ClientSize.Height - 6 * i_BoardSize) / i_BoardSize;
            for (int row = 0; row < i_BoardSize; row++)
            {
                for (int col = 0; col < i_BoardSize; col++)
                {
                    Button cellButton = new Button();
                    cellButton.Width = buttonWidth;
                    cellButton.Height = buttonHeight;
                    cellButton.BackColor = Color.LightGray;
                    cellButton.Click += cellButton_Click;
                    cellButton.Tag = new Point(row, col);
                    tableLayoutPanel1.Controls.Add(cellButton, col, row);
                }
            }
        }

        private void cellButton_Click(object sender, EventArgs e)
        {
            performMoveOnBoard(sender);
            if (r_GameLogic.GetCurrentPlayerName() == "Computer")
            {
                int[] symbolPlace = r_GameLogic.GetSymbolPlaceFromComputer();
                Button computerButton = tableLayoutPanel1.GetControlFromPosition(symbolPlace[1], symbolPlace[0]) as Button;
                performMoveOnBoard(computerButton);
            }
        }

        private void performMoveOnBoard(object sender)
        {
            Button senderButton = sender as Button;
            senderButton.Enabled = false;
            int row = ((Point)senderButton.Tag).X;
            int col = ((Point)senderButton.Tag).Y;

            r_GameLogic.NextTurn(row, col);
            updateBoard(out Label currentPlayerLabel, out Label waitingPlayerLabel, senderButton);
            updateGameState(currentPlayerLabel, waitingPlayerLabel);
        }

        private void updateGameState(Label i_CurrentPlayerLabel, Label i_WaitingPlayerLabel)
        {
            m_GameState = r_GameLogic.GetGameState();

            if (m_GameState == eGameState.NotOverYet)
            {
                i_CurrentPlayerLabel.Font = r_CurrentPlayerFont;
                i_WaitingPlayerLabel.Font = r_WaitingPlayerFont;
            }
            else if(m_GameState == eGameState.Lose)
            {
                DialogResult result = showResultDialog(true);
                handleUserRequest(result);
            }
            else if(m_GameState == eGameState.Tie)
            {
                DialogResult result = showResultDialog(false);
                handleUserRequest(result);
            }
        }

        private void updateBoard(out Label o_CurrentPlayerLabel, out Label o_WaitingPlayerLabel, Button i_SenderButton)
        {
            Board.eCellValue symbol = r_GameLogic.GetCurrentPlayerSymbol();
            i_SenderButton.Text = GameLogic.ConvertCellValueToString(symbol);
            
            if(r_GameLogic.CurrentPlayer == r_Player1)
            {
                i_SenderButton.BackColor = Color.DarkGray;
                o_CurrentPlayerLabel = labelPlayer2;
                o_WaitingPlayerLabel = labelPlayer1;
            }
            else
            {
                if(r_GameLogic.GetCurrentPlayerName() == "Computer")
                {
                    Thread.Sleep(300);
                }

                i_SenderButton.BackColor = Color.FromArgb(242, 242, 242);
                o_CurrentPlayerLabel = labelPlayer1;
                o_WaitingPlayerLabel = labelPlayer2;
            }

            o_CurrentPlayerLabel.Font = r_CurrentPlayerFont;
            o_WaitingPlayerLabel.Font = r_WaitingPlayerFont;
            updateScore();
            Refresh();
        }

        private DialogResult showResultDialog(bool i_DidLose)
        {
            string title = i_DidLose ? "A Win!" : "A Tie!";
            string caption = i_DidLose ? string.Format("The winner is {0}!", r_GameLogic.CurrentPlayer == r_Player1 ? r_Player1Name : r_Player2Name) : "Tie!";
            string intireCaption = $@"
{caption}
Would you like to play another round?";
            DialogResult result = MessageBox.Show(intireCaption, title, MessageBoxButtons.YesNo);

            Refresh();

            return result;
        }

        private void handleUserRequest(DialogResult i_Result)
        {
            if (i_Result == DialogResult.Yes)
            {
                resetButtons();
                r_GameLogic.StartGame();
                r_GameLogic.ResetNumFullCells();
                updateScore();
                labelPlayer1.Font = r_CurrentPlayerFont;
                labelPlayer2.Font = r_WaitingPlayerFont;
            }
            else
            {
                Close();
            }
        }

        private void resetButtons()
        {
            foreach (Button button in tableLayoutPanel1.Controls)
            {
                button.BackColor = Color.LightGray;
                button.Enabled = true;
                button.Text = string.Empty;
            }
        }

        private void updateScore()
        {
            labelScorePlayer1.Text = r_Player1.Score.ToString();
            labelScorePlayer2.Text = r_Player2.Score.ToString();
        }
    }
}
