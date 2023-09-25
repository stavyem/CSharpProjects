using static Ex02.Board;

namespace Ex02
{
    internal class Player
    {
        private string m_PlayerName;
        private eCellValue m_PlayerSymbol;
        private int m_Score = 0;

        internal Player(string i_PlayerName, eCellValue i_PlayerSymbol)
        {
            m_PlayerName = i_PlayerName;
            m_PlayerSymbol = i_PlayerSymbol;
        }

        public string PlayerName
        {
            get
            {
                return m_PlayerName;
            }

        }

        public eCellValue PlayerSymbol
        {
            get
            {
                return m_PlayerSymbol;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        internal void ChooseMove(Board i_Board, int i_Row, int i_Col)
        {
            i_Board.PlaceSymbol(i_Row, i_Col, m_PlayerSymbol);
        }
    }
}
