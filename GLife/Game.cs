//////////////////////////////////////////////////////////////////////////////////////
//Date         Developer            Description
//2021-02-6   Isaac K         --Creation of file for program
//2021-02-6   Isaac K         --Completion of program
//2022-07-24  Isaac K         --Added a stop to the program at the end so user can evaluate the end board
//                              without the program ending automatically 

using System;

namespace GLife
{
    internal class Game
    {

        //storage for the field of the game
        private char[,] gameBoard;
        private char[,] resultsBoard;


        //constants for the game
        public const int ROW_SIZE = 50;
        public const int COL_SIZE = 80;
        public const char LIVE = 'O';
        public const char DEAD = '-';
        public const string SPACE = " "; //used string so I could add 2 if I wanted to and not change much

        public Game()
        {
            gameBoard = new char[ROW_SIZE, COL_SIZE];
            resultsBoard = new char[ROW_SIZE, COL_SIZE];

            InitializeGameBoard();
            InsertsStartupPattern();
        }

        private void InitializeGameBoard()
        {

            for (int r = 0; r < ROW_SIZE; r++)
            {
                for (int c = 0; c < COL_SIZE; c++)
                {
                    gameBoard[r, c] = DEAD;
                    resultsBoard[r, c] = DEAD;
                }
            }
            
        }

        public void PlayTheGame()
        {
            Console.WriteLine("Enter the number of generations to display: ");
            int numGenerations = int.Parse(Console.ReadLine());

            //iterate  for a given number of generations (get info from user)
            for (int generation = 1; generation <= numGenerations; generation++)
            {
                //display the current game board
                DisplayGameBoard(generation);

                //process the game board
                ProcessGameBoard();

                //swap the two boards
                SwapTheBoards();
            }

            Console.WriteLine("Press any key to continue: ");
            Console.ReadKey();
            //display the game board

            //process gameboard and store results in the buffer board

            //swap the two boards to prepare for the next generation/oteration

        }

        private void SwapTheBoards()
        {
            char[,] tmp = gameBoard;
            gameBoard = resultsBoard;
            resultsBoard = tmp;
        }

        private void ProcessGameBoard()
        {
            //iterate through entire 2 dimmensional array
            for (int r = 0; r < ROW_SIZE; r++)
            {
                for (int c = 0; c < COL_SIZE; c++)
                {
                    //consider the current cell [r, c] - determine if the current cell
                    //will be live or dead in the next generation (which state do we store in the results board?)
                    resultsBoard[r, c] = DetermineDeadOrAlive(r, c);
                }
            }
        }

        private char DetermineDeadOrAlive(int r, int c)
        {
            // 1 - count number of neighbors that have live cells
            int count = GetNeighborCount(r, c);

            // 2 - apply rules for dead or alive

            //LIVE cell with 2 or 3 LIVE neighbors remains LIVE
            //DEAD cell with 3 LIVE neighbors becomes LIVE
            //All other counts - LIVE becomes DEAD, DEAD stays DEAD

            if (count == 2) return gameBoard[r, c];
            else if (count == 3) return LIVE;
            else return DEAD;

            return DEAD; //fix later
        }

        private int GetNeighborCount(int r, int c)
        {
            int neighbors = 0;
            if (r == 0 && c == 0)
            {
                //top left corner
                if (gameBoard[r, c + 1] == LIVE) neighbors++;
                if (gameBoard[r + 1, c] == LIVE) neighbors++;
                if (gameBoard[r + 1, c + 1] == LIVE) neighbors++;
            } 
            else if(r == 0 && c == COL_SIZE-1) {
                //top right corner
                if (gameBoard[r, c - 1] == LIVE) neighbors++;
                if (gameBoard[r + 1, c - 1] == LIVE) neighbors++;
                if (gameBoard[r + 1, c] == LIVE) neighbors++;            
            } 
            else if(r == ROW_SIZE-1 && c== 0)
            {
                //bottom left corner
                if (gameBoard[r - 1, c] == LIVE) neighbors++;
                if (gameBoard[r - 1, c + 1] == LIVE) neighbors++;
                if (gameBoard[r, c + 1] == LIVE) neighbors++;
            }
            else if(r == ROW_SIZE - 1 && c == COL_SIZE - 1)
            {
                //bottom right corner
                if (gameBoard[r - 1, c - 1] == LIVE) neighbors++;
                if (gameBoard[r - 1, c] == LIVE) neighbors++;
                if (gameBoard[r, c - 1] == LIVE) neighbors++;
            }
            else if(r == 0)
            {
                //top edge - not corner
                if (gameBoard[r, c - 1] == LIVE) neighbors++;
                if (gameBoard[r, c + 1] == LIVE) neighbors++;
                if (gameBoard[r + 1, c - 1] == LIVE) neighbors++;
                if (gameBoard[r + 1, c] == LIVE) neighbors++;
                if (gameBoard[r + 1, c + 1] == LIVE) neighbors++;
            } 
            else if(c == 0)
            {
                //left edge
                if (gameBoard[r - 1, c] == LIVE) neighbors++;
                if (gameBoard[r - 1, c + 1] == LIVE) neighbors++;
                if (gameBoard[r, c + 1] == LIVE) neighbors++;
                if (gameBoard[r + 1, c] == LIVE) neighbors++;
                if (gameBoard[r + 1, c + 1] == LIVE) neighbors++;

            }
            else if(c == COL_SIZE - 1)
            {
                //right edge
                if (gameBoard[r - 1, c - 1] == LIVE) neighbors++;
                if (gameBoard[r - 1, c] == LIVE) neighbors++;
                if (gameBoard[r, c - 1] == LIVE) neighbors++;
                if (gameBoard[r + 1, c - 1] == LIVE) neighbors++;
                if (gameBoard[r + 1, c] == LIVE) neighbors++;
            }
            else if(r == ROW_SIZE - 1)
            {
                //bottom edge
                if (gameBoard[r - 1, c - 1] == LIVE) neighbors++;
                if (gameBoard[r - 1, c] == LIVE) neighbors++;
                if (gameBoard[r - 1, c + 1] == LIVE) neighbors++;
                if (gameBoard[r, c - 1] == LIVE) neighbors++;
                if (gameBoard[r, c + 1] == LIVE) neighbors++;
            }
            else
            {
                
                //nominal case - not an edge or a neighbor
                if (gameBoard[r - 1, c - 1] == LIVE) neighbors++;
                if (gameBoard[r - 1, c] == LIVE) neighbors++;
                if (gameBoard[r - 1, c + 1] == LIVE) neighbors++;
                if (gameBoard[r, c - 1] == LIVE) neighbors++;
                if (gameBoard[r, c + 1] == LIVE) neighbors++;
                if (gameBoard[r + 1, c - 1] == LIVE) neighbors++;
                if (gameBoard[r + 1, c] == LIVE) neighbors++;
                if (gameBoard[r + 1, c + 1] == LIVE) neighbors++;
            }

            return neighbors;
        }

        private void InsertsStartupPattern()
        {
            Console.WriteLine("*** Starting Patterns Available ***");
            Console.WriteLine("[1] - Linear arrangement of cells - longer period before repeat.");
            Console.WriteLine("[2] - Glider arrangement of cells - that moves off the bioard.");
            Console.WriteLine("[3] - Puffer/gun arrangement of cells - produces an output stream of cells.");

            Console.WriteLine("Enter the starting pattern choice: ");
            int startPattern = int.Parse(Console.ReadLine());

            switch (startPattern)
            {
                case 1:
                    InsertPattern1(10, 10);
                    InsertPattern1(30, 20);
                    break;
                case 2:
                case 3:
                default:
                    InsertPattern1(30, 20);
                    break;
            }
        }

        private void InsertPattern1(int r, int c)
        {
            //insert 8 live cells for first segnment
            gameBoard[r, c + 1] = LIVE;
            gameBoard[r, c + 2] = LIVE;
            gameBoard[r, c + 3] = LIVE;
            gameBoard[r, c + 4] = LIVE;
            gameBoard[r, c + 5] = LIVE;
            gameBoard[r, c + 6] = LIVE;
            gameBoard[r, c + 7] = LIVE;
            gameBoard[r, c + 8] = LIVE;
            //1 dead
            //5 alive
            gameBoard[r, c +  10] = LIVE;
            gameBoard[r, c +  11] = LIVE;
            gameBoard[r, c +  12] = LIVE;
            gameBoard[r, c +  13] = LIVE;
            gameBoard[r, c +  14] = LIVE;
            //3 dead - 15
            //3 dead - 16
            //3 dead - 17
            //3 alive
            gameBoard[r, c + 18] = LIVE;
            gameBoard[r, c + 19] = LIVE;
            gameBoard[r, c + 20] = LIVE;
            //6 dead - 21
            //6 dead - 22
            //6 dead - 23
            //6 dead - 24
            //6 dead - 25
            //6 dead - 26
            //7 live
            gameBoard[r, c + 27] = LIVE;
            gameBoard[r, c + 28] = LIVE;
            gameBoard[r, c + 29] = LIVE;
            gameBoard[r, c + 30] = LIVE;
            gameBoard[r, c + 31] = LIVE;
            gameBoard[r, c + 32] = LIVE;
            gameBoard[r, c + 33] = LIVE;
            //1 dead - 34
            //5 live
            gameBoard[r, c + 35] = LIVE;
            gameBoard[r, c + 36] = LIVE;
            gameBoard[r, c + 37] = LIVE;
            gameBoard[r, c + 38] = LIVE;
            gameBoard[r, c + 39] = LIVE;


        }

        private void DisplayGameBoard(int gen)
        {
            Console.WriteLine($"Generation number: {gen}");
            for (int r = 0; r < ROW_SIZE; r++)
            {
                for (int c = 0; c < COL_SIZE; c++)
                {
                    Console.Write($"{SPACE}{gameBoard[r, c]}");
                }
                Console.WriteLine();
            }

        }

    }
}