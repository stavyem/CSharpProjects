using System;
using static Ex02.Board;
//using Ex02.ConsoleUtils;
using static Ex02.GameLogic;

namespace Ex02
{
    internal class ConsoleInterface
    {
        private GameLogic m_GameLogic;
        private eGameState m_GameState;

        private static void chooseMatrixSize(out int o_MatrixSize)
        {
            Console.WriteLine("Welcome to Reversed X - Mix - Drix!\nPlease define your Matrix size: choose a number between 3 and 9.\n");
            string matrixSize = Console.ReadLine();

            while (!isMatrixSizeValid(matrixSize))
            {
                Console.WriteLine("Input is not valid,\nplease make sure it is a number between 3 and 9 (including).\n");
                matrixSize = Console.ReadLine();
            }

            o_MatrixSize = int.Parse(matrixSize);
        }

        private static void chooseNumberOfPlayers(out int o_PlayersNumber)
        {
            Console.WriteLine("Please choose number of players.\nIt could be 1 (you against the computer) or 2 (you against another person).\n");
            string playersNumber = Console.ReadLine();

            while (!isPlayersNumberValid(playersNumber))
            {
                Console.WriteLine("Input is not valid, please make sure it is a number. It could be 1 or 2.");
                playersNumber = Console.ReadLine();
            }

            o_PlayersNumber = int.Parse(playersNumber);
        }
        
        private static bool isMatrixSizeValid(string i_MatrixSize)
        {
            bool isValid = false;
            bool isItInt = int.TryParse(i_MatrixSize, out int o_ResultNumber);
            const int k_MinimumMatrixSize = 3, k_MaximumMatrixSize = 9;

            if (isItInt && o_ResultNumber >= k_MinimumMatrixSize && o_ResultNumber <= k_MaximumMatrixSize)
            {
                isValid = true;
            }

            return isValid;
        }

        private static bool isPlayersNumberValid(string i_PlayersNumber)
        {
            bool isValid = false;
            bool isItInt = int.TryParse(i_PlayersNumber, out int o_ResultNumber);
            const int k_MinimumNumberOfPlayers = 1, k_MaximumNumberOfPlayers = 2;

            if (isItInt && (o_ResultNumber == k_MinimumNumberOfPlayers || o_ResultNumber == k_MaximumNumberOfPlayers))
            {
                isValid = true;
            }

            return isValid;
        }

        private int[] getSymbolPlaceFromUser(out bool o_PlayerQuit)
        {
            string announcementOfPlaceSymbol = string.Format("Please choose where you want to place your symbol\n" +
                                                             "please write it in the format: rowcol. for example 12 (first row, second column).\n" +
                                                             "\nYou can exit the game by pressing Q (capital letter only)\n" +
                                                             "\n{0} PLAYS NOW WITH {1}",
            m_GameLogic.Players[m_GameLogic.CurrentPlayerIndex].PlayerName,
            m_GameLogic.Players[m_GameLogic.CurrentPlayerIndex].PlayerSymbol);

            Console.WriteLine(announcementOfPlaceSymbol);
            string placeInput = Console.ReadLine();
            
            while (!isPlaceSymbolValid(placeInput))
            {
                Console.WriteLine("Input is not valid, please make sure it is two adjacent digits only,\nand that the chosen cell is not taken.\n"
                                  + "\nYou can also press Q if you want to exit.\n");
                placeInput = Console.ReadLine();
            }

            int[] place = new int[2] {0, 0};

            if (placeInput == "Q")
            {
                o_PlayerQuit = true;
            }
            else
            {
                o_PlayerQuit = false;
                int row = Int32.Parse(placeInput[0].ToString());
                int col = Int32.Parse(placeInput[1].ToString());
                place = new int[2] {row - 1, col - 1};
            }

            return place;
        }

        private bool isPlaceSymbolValid(string i_PlaceSymbol)
        {
            bool isValid = false;
            bool isDigitAndInRange = true;

            if (i_PlaceSymbol.Length == 2)
            {
                for (int i = 0; i < i_PlaceSymbol.Length; i++)
                {
                    char c = i_PlaceSymbol[i]; 

                    if (!char.IsDigit(c) || int.Parse(c.ToString()) > m_GameLogic.CurrentBoard.Size || int.Parse(c.ToString()) == 0)
                    {
                        isDigitAndInRange = false;
                    }
                }
                
                if (isDigitAndInRange)
                {
                    int firstDigit = int.Parse(i_PlaceSymbol[0].ToString());
                    int secondDigit = int.Parse(i_PlaceSymbol[1].ToString());

                    if (m_GameLogic.CurrentBoard.IsEmpty(firstDigit - 1, secondDigit - 1))
                    {
                        isValid = true;
                    }
                }
            }
            else if (i_PlaceSymbol == "Q")
            {
                isValid = true;
            }

            return isValid;
        }

        private void displayBoard() 
        {
            int boardSize = m_GameLogic.CurrentBoard.Size;

            Console.WriteLine("This is the current state of the board:\n");
            Console.Write("  ");
            for (int i = 0; i < boardSize; i++)
            {
                string stringNum = string.Format(" {0}  ", i + 1);
                Console.Write(stringNum);
            }

            Console.WriteLine();
            for (int i = 0; i < boardSize; i++)
            {
                string verticalLine = string.Format("{0}|", i + 1);
                Console.Write(verticalLine);

                for (int j = 0; j < boardSize; j++)
                {
                    if (m_GameLogic.CurrentBoard.CurrentMatrix[i, j] == eCellValue.Empty)
                    {
                        string placeEmptyValue = string.Format("  {0} ", convertCellValueToString(m_GameLogic.CurrentBoard.CurrentMatrix[i, j]));
                        Console.Write(placeEmptyValue);
                    }
                    else
                    {
                        string placeValue = string.Format(" {0} ", convertCellValueToString(m_GameLogic.CurrentBoard.CurrentMatrix[i, j]));
                        Console.Write(placeValue);
                    }

                    if (j < boardSize)
                    {
                        Console.Write("|");
                    }
                }

                Console.WriteLine();

                if (i < boardSize - 1)
                {
                    Console.WriteLine(" " + new string('=', boardSize * 4 + 1));
                }
            }

            Console.WriteLine(" " + new string('=', boardSize * 4 + 1));
            System.Threading.Thread.Sleep(1500);
        }

        private static string convertCellValueToString(eCellValue i_Value)
        {
            string cellValue = i_Value == eCellValue.Empty ? "" : i_Value.ToString();
            
            return cellValue;
        }

        private static bool userWantAnotherRound()
        {
            bool anotherRound = false;

            Console.WriteLine("Hey there mate. Are you interested in another round? (Yes/No).\n");
            string anotherRoundInput = Console.ReadLine();

            while(!isAnotherRoundValid(anotherRoundInput))
            {
                Console.WriteLine("Sorry mate. Please enter 'Yes' or 'No' only.\n");
                anotherRoundInput = Console.ReadLine();
            }

            if(anotherRoundInput == "Yes")
            {
                anotherRound = true;
            }

            return anotherRound;
        }

        private static bool isAnotherRoundValid(string i_AnotherRoundInput)
        {
            return i_AnotherRoundInput == "Yes" || i_AnotherRoundInput == "No";
        }

        private void displaysWhosTurnMessage()
        {
            string whoseTurn = string.Format("{0} played with {1}:\n", m_GameLogic.GetCurrentPlayerName(), m_GameLogic.GetCurrentPlayerSymbol());

            Console.WriteLine(whoseTurn);
        }

        private void endGame()
        {
            m_GameLogic.ResetNumFullCells();
            if (m_GameState == eGameState.Lose)
            {
                string announcementOfWinner = String.Format(
                    "And the winner is: {0} !!!\n",
                    m_GameLogic.Players[m_GameLogic.CurrentPlayerIndex].PlayerName);
                Console.WriteLine(announcementOfWinner);
            }
            else if(m_GameState == eGameState.Tie)
            {
                Console.WriteLine("We had a Tie.\n");
            }

            string messageToUser = String.Format(
                @"The Game is Over.

This is the score board:

    {0,-10}    |    {1,-10}     
-------------------------------
    {2,-10}    |    {3,-10}     
",
                m_GameLogic.Players[0].PlayerName,
                m_GameLogic.Players[1].PlayerName,
                m_GameLogic.Players[0].Score,
                m_GameLogic.Players[1].Score);
            Console.WriteLine(messageToUser);
        }

        internal void Run()
        {
            chooseMatrixSize(out int matrixSize);
            chooseNumberOfPlayers(out int playersNumber);
            m_GameLogic = new GameLogic(matrixSize, playersNumber);
            bool doAnotherRound = true;

            while (doAnotherRound)
            {
                //Screen.Clear();
                m_GameLogic.StartGame();
                displayBoard();
                
                while ((m_GameState = m_GameLogic.GetGameState()) == eGameState.NotOverYet)
                {
                    bool playerQuit = false;
                    int[] symbolPlace = m_GameLogic.GetCurrentPlayerName() == "Computer" ? m_GameLogic.GetSymbolPlaceFromComputer() : 
                                            getSymbolPlaceFromUser(out playerQuit);
                    if(playerQuit)
                    {
                        break;
                    }

                    m_GameLogic.NextTurn(symbolPlace[0], symbolPlace[1]);
                    //Screen.Clear();
                    displaysWhosTurnMessage();
                    displayBoard();
                }
                endGame();
                if (!userWantAnotherRound())
                {
                    doAnotherRound = false;
                }
            }
        }
    }
}
