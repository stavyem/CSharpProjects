using System;
using static ReversedXMixDrix.Board;

namespace ReversedXMixDrix
{
    internal class GameLogic
    {
        private Board m_Board;
        private Player[] m_Players;
        private int m_CurrentPlayerIndex;

        internal GameLogic(int i_BoardSize, int i_NumberOfPlayers)
        {
            m_Board = new Board(i_BoardSize);
            m_Players = new Player[2];

            if (i_NumberOfPlayers == 1)
            {
                m_Players[0] = new Player("Player 1", eCellValue.X);
                m_Players[1] = new Player("Computer", eCellValue.O);
            }
            else
            {
                m_Players[0] = new Player("Player 1", eCellValue.X);
                m_Players[1] = new Player("Player 2", eCellValue.O);
            }
        }

        public Board CurrentBoard
        {
            get
            {
                return m_Board;
            }
        }

        public Player[] Players
        {
            get
            {
                return m_Players;
            }
        }

        public int CurrentPlayerIndex
        {
            get
            {
                return m_CurrentPlayerIndex;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_Players[m_CurrentPlayerIndex];
            }
        }

        internal void ResetNumFullCells()
        {
            m_Board.NumFullCells = 0;
        }

        internal void StartGame()
        {
            m_CurrentPlayerIndex = 0;
            m_Board.InitializeBoard();
        }

        internal string GetCurrentPlayerName()
        {
            Player currentPlayer = m_Players[m_CurrentPlayerIndex];
            return currentPlayer.PlayerName;
        }

        internal eCellValue GetCurrentPlayerSymbol()
        {
            Player currentPlayer = m_Players[m_CurrentPlayerIndex];
            return currentPlayer.PlayerSymbol;
        }

        internal int[] GetSymbolPlaceFromComputer()
        {
            Random random = new Random();
            int row = random.Next() % m_Board.Size;
            int col = random.Next() % m_Board.Size;

            while (eCellValue.Empty != m_Board.CurrentMatrix[row, col])
            {
                row = random.Next() % m_Board.Size;
                col = random.Next() % m_Board.Size;
            }

            return new[] { row, col };
        }

        internal void NextTurn(int i_Row, int i_Col)
        {
            Player currentPlayer = m_Players[m_CurrentPlayerIndex];

            currentPlayer.ChooseMove(m_Board, i_Row, i_Col);
            m_Board.NumFullCells += 1;
        }

        internal bool IsLose(eCellValue i_Symbol)
        {
            bool didPlayerLose = false;

            for (int i = 0; i < m_Board.Size; i++)
            {
                if (m_Board.CheckRowLose(i_Symbol, i) || m_Board.CheckColumnLose(i_Symbol, i))
                {
                    didPlayerLose = true;
                }
            }

            if (m_Board.CheckDiagonalLose(i_Symbol, true) || m_Board.CheckDiagonalLose(i_Symbol, false))
            {
                didPlayerLose = true;
            }

            return didPlayerLose;
        }

        internal enum eGameState
        {
            Lose,
            Tie,
            NotOverYet
        }

        internal eGameState GetGameState()
        {
            Player currentPlayer = m_Players[m_CurrentPlayerIndex];
            eGameState gameState = eGameState.NotOverYet;

            if (IsLose(currentPlayer.PlayerSymbol))
            {
                m_CurrentPlayerIndex = m_CurrentPlayerIndex == 1 ? 0 : 1;
                currentPlayer = m_Players[m_CurrentPlayerIndex];
                currentPlayer.Score++;
                gameState = eGameState.Lose;

                return gameState;
            }

            if (m_Board.IsFull())
            {
                gameState = eGameState.Tie;
            }

            m_CurrentPlayerIndex = m_CurrentPlayerIndex == 1 ? 0 : 1;

            return gameState;
        }

        internal static string ConvertCellValueToString(eCellValue i_Value)
        {
            string cellValue = i_Value == eCellValue.Empty ? "" : i_Value.ToString();

            return cellValue;
        }
    }
}
