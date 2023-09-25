using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedXMixDrix
{
    internal class Board
    {
        private eCellValue[,] m_CurrentMatrix;
        private int m_Size;
        private int m_NumFullCells = 0;


        internal Board(int i_Size)
        {
            m_CurrentMatrix = new eCellValue[i_Size, i_Size];
            m_Size = i_Size;
        }

        public eCellValue[,] CurrentMatrix
        {
            get
            {
                return m_CurrentMatrix;
            }
        }

        public int Size
        {
            get
            {
                return m_Size;
            }
        }

        public int NumFullCells
        {
            get
            {
                return m_NumFullCells;
            }

            set
            {
                m_NumFullCells = value;
            }
        }

        internal enum eCellValue
        {
            X,
            O,
            Empty
        }

        internal void InitializeBoard()
        {
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    m_CurrentMatrix[i, j] = eCellValue.Empty;
                }
            }
        }

        internal bool IsEmpty(int i_Row, int i_Col)
        {
            return m_CurrentMatrix[i_Row, i_Col] == eCellValue.Empty;
        }

        internal void PlaceSymbol(int i_Row, int i_Col, eCellValue i_Symbol)
        {
            m_CurrentMatrix[i_Row, i_Col] = i_Symbol;
        }

        internal bool CheckRowLose(eCellValue i_Symbol, int i_Row)
        {
            bool didPlayerLose = true;
            int col = 0;

            while (col < m_Size && m_CurrentMatrix[i_Row, col] == i_Symbol)
            {
                col++;
            }

            if (col < m_Size)
            {
                didPlayerLose = false;
            }

            return didPlayerLose;
        }

        internal bool CheckColumnLose(eCellValue i_Symbol, int i_Col)
        {
            bool didPlayerLose = true;
            int row = 0;

            while (row < m_Size && m_CurrentMatrix[row, i_Col] == i_Symbol)
            {
                row++;
            }

            if (row < m_Size)
            {
                didPlayerLose = false;
            }

            return didPlayerLose;
        }

        internal bool CheckDiagonalLose(eCellValue i_Symbol, bool i_IsMainDiagonal)
        {
            bool didPlayerLose = true;

            for (int row = 0; row < m_Size; row++)
            {
                int col = i_IsMainDiagonal ? row : m_Size - 1 - row;
                while (m_CurrentMatrix[row, col] != i_Symbol)
                {
                    didPlayerLose = false;
                    break;
                }

                if (!didPlayerLose)
                {
                    break;
                }
            }

            return didPlayerLose;
        }

        internal bool IsFull()
        {
            return m_NumFullCells == (m_Size * m_Size);
        }
    }
}
