namespace MineSweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MineSweeper
    {
        private const int MaxFreeCells = 35;
        private const int TopPlayersNumber = 5;

        static void Main(string[] arguments)
        {
            string command = string.Empty;

            char[,] boardMap = CreateBoardMap();
            char[,] minesMap = PlaceMinesToBoardMap();

            int row = 0;
            int column = 0;

            int openedCells = 0;
            List<Player> players = new List<Player>(TopPlayersNumber + 1);

            bool startNewGame = true;
            bool mineIsExploded = false;
            bool success = false;

            do
            {
                if (startNewGame)
                {
                    Console.WriteLine("Let's play on “MineSweeper”. Try your chance to reveal all mines free cells.");
                    Console.WriteLine();
                    Console.WriteLine("Command 'top' prints rating list of players.");
                    Console.WriteLine("Command 'restart' starts new game.");
                    Console.WriteLine("Command 'exit' exits from game.");

                    PrintBoardMap(boardMap);

                    startNewGame = false;
                }

                Console.Write("Write row and column : ");

                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= boardMap.GetLength(0) && column <= boardMap.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintRatingList(players);
                        break;
                    case "restart":
                        boardMap = CreateBoardMap();
                        minesMap = PlaceMinesToBoardMap();
                        PrintBoardMap(boardMap);
                        mineIsExploded = false;
                        startNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, Bye!");
                        break;
                    case "turn":
                        if (minesMap[row, column] != '*')
                        {
                            if (minesMap[row, column] == '-')
                            {
                                FindNumberOfMinesNearCell(boardMap, minesMap, row, column);

                                openedCells++;
                            }

                            if (openedCells == MaxFreeCells)
                            {
                                success = true;
                            }
                            else
                            {
                                PrintBoardMap(boardMap);
                            }
                        }
                        else
                        {
                            mineIsExploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid Command.\n");
                        break;
                }

                if (mineIsExploded)
                {
                    PrintBoardMap(minesMap);

                    Console.Write("\nOMG! You are dead with {0} points. Write your nickname: ", openedCells);
                    string nickname = Console.ReadLine();

                    Player player = new Player(nickname, openedCells);

                    if (players.Count < TopPlayersNumber)
                    {
                        players.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Score < player.Score)
                            {
                                players.Insert(i, player);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((Player x, Player y) => y.Score.CompareTo(x.Score));
                    PrintRatingList(players);

                    boardMap = CreateBoardMap();
                    minesMap = PlaceMinesToBoardMap();

                    openedCells = 0;
                    mineIsExploded = false;
                    startNewGame = true;
                }

                if (success)
                {
                    Console.WriteLine("\nCongratulations! You opened all 35 cells without any mistakes.");

                    PrintBoardMap(minesMap);

                    Console.Write("Write your name: ");
                    string name = Console.ReadLine();

                    Player player = new Player(name, openedCells);
                    players.Insert(0, player);
                    players.RemoveAt(players.Count - 1);

                    PrintRatingList(players);

                    boardMap = CreateBoardMap();
                    minesMap = PlaceMinesToBoardMap();

                    openedCells = 0;
                    success = false;
                    startNewGame = true;
                }
            } 
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.WriteLine("HQC Team.");
            Console.Read();
        }

        private static void PrintRatingList(List<Player> players)
        {
            Console.WriteLine("\nRating list:");

            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", i + 1, players[i].Name, players[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Rating list is empty!\n");
            }
        }

        private static void FindNumberOfMinesNearCell(char[,] boardMap, char[,] minesMap, int row, int column)
        {
            char minesNearCell = GetNumberOfMinesNearCell(minesMap, row, column);

            boardMap[row, column] = minesNearCell;
            minesMap[row, column] = minesNearCell;
        }

        private static void PrintBoardMap(char[,] boardMap)
        {
            int rows = boardMap.GetLength(0);
            int columns = boardMap.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);

                for (int column = 0; column < columns; column++)
                {
                    Console.Write(string.Format("{0} ", boardMap[row, column]));
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateBoardMap()
        {
            const int BoardRows = 5;
            const int BoardColumns = 10;

            char[,] boardMap = new char[BoardRows, BoardColumns];

            for (int row = 0; row < BoardRows; row++)
            {
                for (int column = 0; column < BoardColumns; column++)
                {
                    boardMap[row, column] = '?';
                }
            }

            return boardMap;
        }

        private static char[,] PlaceMinesToBoardMap()
        {
            const int BoardRows = 5;
            const int BoardColumns = 10;
            const int NumberOfBoardCells = BoardRows * BoardColumns;

            char[,] minesMap = new char[BoardRows, BoardColumns];

            for (int row = 0; row < BoardRows; row++)
            {
                for (int column = 0; column < BoardColumns; column++)
                {
                    minesMap[row, column] = '-';
                }
            }

            List<int> uniqueRandomNumbers = new List<int>();

            while (uniqueRandomNumbers.Count < (NumberOfBoardCells - MaxFreeCells))
            {
                Random random = new Random();

                int randomNumber = random.Next(NumberOfBoardCells);

                if (!uniqueRandomNumbers.Contains(randomNumber))
                {
                    uniqueRandomNumbers.Add(randomNumber);
                }
            }

            foreach (int number in uniqueRandomNumbers)
            {
                int row = number / BoardColumns;
                int column = number % BoardColumns;

                minesMap[row, column] = '*';
            }

            return minesMap;
        }

        private static void SetMinesMap(char[,] minesMap)
        {
            int rows = minesMap.GetLength(0);
            int columns = minesMap.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (minesMap[row, column] != '*')
                    {
                        char minesNearCell = GetNumberOfMinesNearCell(minesMap, row, column);

                        minesMap[row, column] = minesNearCell;
                    }
                }
            }
        }

        private static char GetNumberOfMinesNearCell(char[,] minesMap, int row, int column)
        {
            int number = 0;

            int previousRow = row - 1;
            int nextRow = row + 1;

            int previousColumn = column - 1;
            int nextColumn = column + 1;

            int rows = minesMap.GetLength(0);
            int columns = minesMap.GetLength(1);

            if (previousRow >= 0)
            {
                if (minesMap[previousRow, column] == '*')
                {
                    number++;
                }
            }

            if (nextRow < rows)
            {
                if (minesMap[nextRow, column] == '*')
                {
                    number++;
                }
            }

            if (previousColumn >= 0)
            {
                if (minesMap[row, previousColumn] == '*')
                {
                    number++;
                }
            }

            if (nextColumn < columns)
            {
                if (minesMap[row, nextColumn] == '*')
                {
                    number++;
                }
            }

            if ((previousRow >= 0) && (previousColumn >= 0))
            {
                if (minesMap[previousRow, previousColumn] == '*')
                {
                    number++;
                }
            }

            if ((previousRow >= 0) && (nextColumn < columns))
            {
                if (minesMap[previousRow, nextColumn] == '*')
                {
                    number++;
                }
            }

            if ((nextRow < rows) && (previousColumn >= 0))
            {
                if (minesMap[nextRow, previousColumn] == '*')
                {
                    number++;
                }
            }

            if ((nextRow < rows) && (nextColumn < columns))
            {
                if (minesMap[nextRow, nextColumn] == '*')
                {
                    number++;
                }
            }

            return char.Parse(number.ToString());
        }

        public class Player
        {
            private string name;
            private int score;

            public Player() 
            { 
            }

            public Player(string name, int score)
            {
                this.name = name;
                this.score = score;
            }

            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }

            public int Score
            {
                get { return this.score; }
                set { this.score = value; }
            }
        }
    }
}
