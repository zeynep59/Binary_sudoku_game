/*Binary Sudoku is a sudoku like game that is played on a 9*9 board, where there are randomly generated pieces whose elements are either 0’s or 1’s.
The goal of the game is to place randomly generated pieces on the board to fill rows, columns or blocks to get a 9 digit binary number.
This number is then converted to its decimal equivalent and added to the score.*/



using System;

namespace prooje2new
{
    class Program
    {
        static void Main()
        {
            string restart;
            do
            {
                Console.Clear();
                //total score
                int score = 0;

                //first positions of the cursor
                int cursorx = 5, cursory = 2;

                //sudoku array holds the all elements of board .
                //the size of sudoku array is 10 to avoid the possible "Out of range" errors
                int[,] sudoku = new int[10, 10];

                //IsGameOver variable returns "true" if there is no place that can put the piece
                bool IsGameOver;

                //npiece variable holds the number of total piece that is put
                int npiece = 0; //number of piece

                //**********************************************************************
                //printing the board with nested loops
                for (int i = 1; i < 10; i++)
                {
                    Console.SetCursorPosition((i * 4) + 1, 0);
                    Console.Write(i);

                    Console.SetCursorPosition(2, i * 2);
                    Console.Write(i);

                    for (int j = 4; j < 40; j++)
                    {
                        if (6 * i < 30)
                        {
                            Console.SetCursorPosition(j, (6 * i) - 5);
                            Console.Write("-");
                        }
                    }
                }
                for (int i = 2; i < 20; i++)
                {
                    for (int j = 3; j < 50; j += 12)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write("|");
                    }
                }
                //print the constant words on the board 
                Console.SetCursorPosition(50, 2);
                Console.WriteLine("New Piece:");
                Console.SetCursorPosition(80, 2);
                Console.WriteLine("Score:");
                Console.SetCursorPosition(80, 5);
                Console.WriteLine("Piece:");
                //********************************************************************************************

                //firstly all elements must be except 1 and 0, so assign 9 to all elements of sudoku array
                for (int i = 0; i < sudoku.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < sudoku.GetLength(1) - 1; j++)
                    {
                        sudoku[i, j] = 9;
                    }
                }

                //this is main loop of the game. You can play again and again the game under favour of this "do-while" loop.
                do
                {
                    //piece array holds the random piece
                    //size of this array is 3-3 because there can be max 3 elements per column and row
                    int[,] piece = new int[3, 3] { { 9, 9, 9 }, { 9, 9, 9 }, { 9, 9, 9 } };

                    //print the all sudoku elements     
                    for (int i = 0; i < sudoku.GetLength(0) - 1; i++)
                    {
                        Console.SetCursorPosition(5, 2 + 2 * i);
                        for (int j = 0; j < sudoku.GetLength(1) - 1; j++)
                        {
                            //be used "if-else" statements to arrange the position of elements on the board  
                            if (j + 1 % 3 == 0)
                            {
                                if (sudoku[i, j] == 9)
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write((char)(sudoku[i, j] + 37) + "");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write(sudoku[i, j] + "");
                                }
                            }
                            else
                            {
                                if (sudoku[i, j] == 9)
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write((char)(sudoku[i, j] + 37) + "   ");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write(sudoku[i, j] + "   ");
                                }
                            }
                        }
                    }

                    Console.ResetColor();

                    //reset the piece on the console
                    Console.SetCursorPosition(50, 4);
                    Console.WriteLine("     ");
                    Console.SetCursorPosition(50, 6);
                    Console.WriteLine("     ");
                    Console.SetCursorPosition(50, 8);
                    Console.WriteLine("     ");

                    //generate random numbers to create random pieces
                    Random rand = new Random();
                    int number = rand.Next(1, 11);

                    IsGameOver = true;

                    switch (number)
                    {
                        // Generating this piece -->  x x
                        //                              x
                        case 1:
                            // This nested loop decides if the game is over or not.
                            for (int i = 0; i < sudoku.GetLength(0) - 2; i++)
                            {
                                for (int j = 0; j < sudoku.GetLength(1) - 2; j++)
                                {
                                    if (sudoku[i, j] == 9 && sudoku[i, j + 1] == 9 && sudoku[i + 1, j + 1] == 9)
                                    {
                                        IsGameOver = false;
                                        break;
                                    }
                                }
                                if (IsGameOver == false)
                                {
                                    break;
                                }
                            }

                            //generate elements of piece and print under  the   "piece" section
                            int n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 4);
                            Console.Write(n);
                            piece[0, 0] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(52, 4);
                            Console.Write(n);
                            piece[0, 1] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(52, 6);
                            Console.WriteLine(n);
                            piece[1, 1] = n;

                            break;

                        // Generating this piece -->  x
                        //                            x x
                        case 2:
                            // This nested loop decides if the game is over or not.
                            for (int i = 0; i < sudoku.GetLength(0) - 2; i++)
                            {
                                for (int j = 0; j < sudoku.GetLength(1) - 2; j++)
                                {
                                    if (sudoku[i, j] == 9 && sudoku[i + 1, j] == 9 && sudoku[i + 1, j + 1] == 9)
                                    {
                                        IsGameOver = false;
                                        break;
                                    }
                                }
                                if (IsGameOver == false)
                                {
                                    break;
                                }
                            }

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 4);
                            Console.Write(n);
                            piece[0, 0] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 6);
                            Console.Write(n);
                            piece[1, 0] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(52, 6);
                            Console.Write(n);
                            piece[1, 1] = n;

                            break;

                        // Generating this piece -->   x
                        //                           x x
                        case 3:
                            // This nested loop decides if the game is over or not.
                            for (int i = 0; i < sudoku.GetLength(0) - 2; i++)
                            {
                                for (int j = 1; j < sudoku.GetLength(1) - 1; j++)
                                {
                                    if (sudoku[i, j] == 9 && sudoku[i + 1, j] == 9 && sudoku[i + 1, j - 1] == 9)
                                    {
                                        IsGameOver = false;
                                        break;
                                    }
                                }
                                if (IsGameOver == false)
                                {
                                    break;
                                }
                            }

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(52, 6);
                            Console.Write(n);
                            piece[1, 1] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 6);
                            Console.Write(n);
                            piece[1, 0] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(52, 4);
                            Console.Write(n);
                            piece[0, 1] = n;

                            break;

                        // Generating this piece --> x x
                        //                           x
                        case 4:
                            // This nested loop decides if the game is over or not.
                            for (int i = 0; i < sudoku.GetLength(0) - 2; i++)
                            {
                                for (int j = 0; j < sudoku.GetLength(1) - 2; j++)
                                {
                                    if (sudoku[i, j] == 9 && sudoku[i, j + 1] == 9 && sudoku[i + 1, j] == 9)
                                    {
                                        IsGameOver = false;
                                        break;
                                    }
                                }
                                if (IsGameOver == false)
                                {
                                    break;
                                }
                            }

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(52, 4);
                            Console.Write(n);
                            piece[1, 0] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 6);
                            Console.Write(n);
                            piece[0, 1] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 4);
                            Console.Write(n);
                            piece[0, 0] = n;

                            break;

                        // Generating this piece --> x x
                        //                           x x
                        case 5:
                            // This nested loop decides if the game is over or not.
                            for (int i = 0; i < sudoku.GetLength(0) - 2; i++)
                            {
                                for (int j = 0; j < sudoku.GetLength(1) - 2; j++)
                                {
                                    if (sudoku[i, j] == 9 && sudoku[i + 1, j] == 9 && sudoku[i + 1, j + 1] == 9 && sudoku[i, j + 1] == 9)
                                    {
                                        IsGameOver = false;
                                        break;
                                    }
                                }
                                if (IsGameOver == false)
                                {
                                    break;
                                }
                            }

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 4);
                            Console.Write(n);
                            piece[0, 0] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 6);
                            Console.Write(n);
                            piece[1, 0] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(52, 4);
                            Console.Write(n);
                            piece[0, 1] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(52, 6);
                            Console.Write(n);
                            piece[1, 1] = n;

                            break;

                        // Generating this piece --> x x
                        case 6:
                            // This nested loop decides if the game is over or not.
                            for (int i = 0; i < sudoku.GetLength(0) - 1; i++)
                            {
                                for (int j = 0; j < sudoku.GetLength(1) - 2; j++)
                                {
                                    if (sudoku[i, j] == 9 && sudoku[i, j + 1] == 9)
                                    {
                                        IsGameOver = false;
                                        break;
                                    }
                                }
                                if (IsGameOver == false)
                                {
                                    break;
                                }
                            };

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 4);
                            Console.Write(n);
                            piece[0, 0] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(52, 4);
                            Console.Write(n);
                            piece[0, 1] = n;

                            break;

                        // Generating this piece --> x
                        //                           x
                        case 7:
                            // This nested loop decides if the game is over or not.
                            for (int i = 0; i < sudoku.GetLength(0) - 2; i++)
                            {
                                for (int j = 0; j < sudoku.GetLength(1) - 1; j++)
                                {
                                    if (sudoku[i, j] == 9 && sudoku[i + 1, j] == 9)
                                    {
                                        IsGameOver = false;
                                        break;
                                    }
                                }
                                if (IsGameOver == false)
                                {
                                    break;
                                }
                            }

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 4);
                            Console.Write(n);
                            piece[0, 0] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 6);
                            Console.Write(n);
                            piece[1, 0] = n;

                            break;

                        // Generating this piece --> x
                        case 8:
                            //There is no need to control if the game ends 
                            //or not with this piece, because it's not possible.
                            IsGameOver = false;
                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 4);
                            Console.Write(n);
                            piece[0, 0] = n;

                            break;

                        // Generating this piece --> x x x 
                        case 9:
                            // This nested loop decides if the game is over or not.
                            for (int i = 0; i < sudoku.GetLength(0) - 1; i++)
                            {
                                for (int j = 0; j < sudoku.GetLength(1) - 3; j++)
                                {
                                    if (sudoku[i, j] == 9 && sudoku[i, j + 1] == 9 && sudoku[i, j + 2] == 9)
                                    {
                                        IsGameOver = false;
                                        break;
                                    }
                                }
                                if (IsGameOver == false)
                                {
                                    break;
                                }
                            }

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 4);
                            Console.Write(n);
                            piece[0, 0] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(52, 4);
                            Console.Write(n);
                            piece[0, 1] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(54, 4);
                            Console.Write(n);
                            piece[0, 2] = n;

                            break;

                        // Generating this piece --> x
                        //                           x
                        //                           x
                        case 10:
                            // This nested loop decides if the game is over or not.
                            for (int i = 0; i < sudoku.GetLength(0) - 3; i++)
                            {
                                for (int j = 0; j < sudoku.GetLength(1) - 1; j++)
                                {
                                    if (sudoku[i, j] == 9 && sudoku[i + 1, j] == 9 && sudoku[i + 2, j] == 9)
                                    {
                                        IsGameOver = false;
                                        break;
                                    }
                                }
                                if (IsGameOver == false)
                                {
                                    break;
                                }
                            }

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 4);
                            Console.Write(n);
                            piece[0, 0] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 6);
                            Console.Write(n);
                            piece[1, 0] = n;

                            n = rand.Next(0, 2);
                            Console.SetCursorPosition(50, 8);
                            Console.Write(n);
                            piece[2, 0] = n;

                            break;
                    }
                    //increase the number of piece
                    npiece++;

                    //if the game is over exit the game loop
                    if (IsGameOver == true)
                        break;

                    //x is the row number and y is the column number of the sudoku matrix 
                    int x, y;

                    Console.SetCursorPosition(cursorx, cursory);

                    //moving the cursor to determine the location of piece
                    ConsoleKeyInfo cki;
                    while (true)
                    {
                        if (Console.KeyAvailable)
                        {
                            // true: there is a key in keyboard buffer
                            cki = Console.ReadKey(true);

                            // key and boundary control
                            if (cki.Key == ConsoleKey.RightArrow)
                            {
                                if (cursorx != 37)
                                {
                                    cursorx += 4;
                                }
                                else
                                {
                                    cursorx = 5;
                                }
                            }
                            else if (cki.Key == ConsoleKey.LeftArrow)
                            {
                                if (cursorx != 5)
                                {
                                    cursorx -= 4;
                                }
                                else
                                {
                                    cursorx = 37;
                                }
                            }
                            else if (cki.Key == ConsoleKey.UpArrow)
                            {
                                if (cursory != 2)
                                {
                                    cursory -= 2;
                                }
                                else
                                {
                                    cursory = 18;
                                }
                            }
                            else if (cki.Key == ConsoleKey.DownArrow)
                            {
                                if (cursory != 18)
                                {
                                    cursory += 2;
                                }
                                else
                                {
                                    cursory = 2;
                                }
                            }

                            Console.SetCursorPosition(cursorx, cursory);
                            //writing the index of array from the type of position variables.
                            x = (cursory - 2) / 2;
                            y = (cursorx - 5) / 4;

                            if (cki.Key == ConsoleKey.Enter)
                            {
                                //checking the place that chosed is available
                                if ((number == 1 && (sudoku[x, y] != 9 || sudoku[x, y + 1] != 9 || sudoku[x + 1, y + 1] != 9)) ||
                                   (number == 2 && (sudoku[x, y] != 9 || sudoku[x + 1, y] != 9 || sudoku[x + 1, y + 1] != 9)) ||
                                   (number == 3 && (y < 1 || (sudoku[x + 1, y - 1] != 9 || sudoku[x, y] != 9 || sudoku[x + 1, y] != 9))) ||
                                   (number == 4 && (sudoku[x, y] != 9 || sudoku[x, y + 1] != 9 || sudoku[x + 1, y] != 9)) ||
                                   (number == 5 && (sudoku[x, y] != 9 || sudoku[x, y + 1] != 9 || sudoku[x + 1, y + 1] != 9 || sudoku[x + 1, y] != 9)) ||
                                   (number == 6 && (sudoku[x, y] != 9 || sudoku[x, y + 1] != 9)) ||
                                   (number == 7 && (sudoku[x, y] != 9 || sudoku[x + 1, y] != 9)) ||
                                   (number == 8 && (sudoku[x, y] != 9)) ||
                                   (number == 9 && (sudoku[x, y] != 9 || sudoku[x, y + 1] != 9 || sudoku[x, y + 2] != 9)) ||
                                   (number == 10 && (sudoku[x, y] != 9 || sudoku[x + 1, y] != 9 || sudoku[x + 2, y] != 9)))

                                {
                                    //if place is not available printing the warning message on the console
                                    Console.SetCursorPosition(5, 20);
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("This piece cannot be placed here.");
                                    Console.ResetColor();
                                    Console.SetCursorPosition(cursorx, cursory);
                                }
                                else break;
                            }
                        }
                    }
                    //deleting the warning messages
                    Console.SetCursorPosition(5, 20);
                    Console.Write("                                 ");

                    //assigning the piece array to sudoku array according to piece
                    if (number == 1)
                    {
                        sudoku[x, y] = piece[0, 0];
                        sudoku[x, y + 1] = piece[0, 1];
                        sudoku[x + 1, y + 1] = piece[1, 1];
                    }
                    else if (number == 2)
                    {
                        sudoku[x, y] = piece[0, 0];
                        sudoku[x + 1, y] = piece[1, 0];
                        sudoku[x + 1, y + 1] = piece[1, 1];
                    }
                    else if (number == 3)
                    {
                        sudoku[x + 1, y - 1] = piece[1, 0];
                        sudoku[x, y] = piece[0, 1];
                        sudoku[x + 1, y] = piece[1, 1];
                    }
                    else if (number == 4)
                    {
                        sudoku[x, y] = piece[0, 0];
                        sudoku[x, y + 1] = piece[0, 1];
                        sudoku[x + 1, y] = piece[1, 0];
                    }
                    else if (number == 5)
                    {
                        sudoku[x, y] = piece[0, 0];
                        sudoku[x, y + 1] = piece[0, 1];
                        sudoku[x + 1, y + 1] = piece[1, 1];
                        sudoku[x + 1, y] = piece[1, 0];
                    }
                    else if (number == 6)
                    {
                        sudoku[x, y] = piece[0, 0];
                        sudoku[x, y + 1] = piece[0, 1];
                    }
                    else if (number == 7)
                    {
                        sudoku[x, y] = piece[0, 0];
                        sudoku[x + 1, y] = piece[1, 0];
                    }
                    else if (number == 8)
                    {
                        sudoku[x, y] = piece[0, 0];
                    }
                    else if (number == 9)
                    {
                        sudoku[x, y] = piece[0, 0];
                        sudoku[x, y + 1] = piece[0, 1];
                        sudoku[x, y + 2] = piece[0, 2];
                    }
                    else if (number == 10)
                    {
                        sudoku[x, y] = piece[0, 0];
                        sudoku[x + 1, y] = piece[1, 0];
                        sudoku[x + 2, y] = piece[2, 0];
                    }

                    //convert bınary to decimal and calculate the score 
                    //decimal number in every filled column/row/block and it is temporary  variable
                    int dec;

                    //row score    column score   block score
                    int scorer = 0, scorec = 0, scoreb = 0;

                    //amount of the filled row-column-block
                    int countr = 0, countc = 0, countb = 0;

                    //the score of each time
                    int subscoreTot;

                    //count total is the summation of filled rows, columns and blocks
                    int countTotal;

                    //it holds the filled row's number
                    //firstly all elements equal 10 because 10th row and column dont effect anything.
                    int[] filled_row = new int[] { 10, 10, 10 };

                    //it holds the filled column's number
                    int[] filled__column = new int[] { 10, 10, 10 };

                    // it holds the filled block's number
                    int[,] filled_block = new int[,] { { 10, 10 }, { 10, 10 }, { 10, 10 }, { 10, 10 } };

                    //it holds the all scores 
                    int[] print_calculations = new int[8]; //the size of array is 8 because maximum 8 block/row/column can be filled

                    //deleting the calculations part
                    for (int i = 0; i <= 15; i++)
                    {
                        Console.SetCursorPosition(50, 9 + i);
                        Console.WriteLine("                          ");
                    }

                    //calculating score of rows
                    for (int i = 0; i < sudoku.GetLength(0) - 1; i++)
                    {
                        dec = 0;
                        for (int j = 0; j < sudoku.GetLength(1) - 1; j++)
                        {
                            //checking that row has a empty element or not 
                            if (sudoku[i, j] == 9)
                                break;

                            if (j == sudoku.GetLength(1) - 2)
                            {
                                for (int k = 0; k < sudoku.GetLength(0) - 1; k++)
                                {
                                    //printing binary part of filled rows
                                    Console.SetCursorPosition(50 + k, 11 + countr);
                                    Console.Write(sudoku[i, k]);
                                    //converting binary to decimal
                                    dec += (int)Math.Pow(2, sudoku.GetLength(1) - 2 - k) * sudoku[i, k];
                                }
                                scorer += dec;
                                countr++;
                                //printing the binary- decimal equalities
                                Console.WriteLine("(2) = " + dec + "(10)");

                                if (countr > 0)
                                {
                                    print_calculations[countr - 1] = dec;
                                    filled_row[countr - 1] = i;
                                }
                            }
                        }
                    }

                    //calculating score of columns
                    for (int i = 0; i < sudoku.GetLength(0) - 1; i++)
                    {
                        dec = 0;
                        for (int j = 0; j < sudoku.GetLength(1) - 1; j++)
                        {
                            if (sudoku[j, i] == 9)
                                break;

                            if (j == sudoku.GetLength(0) - 2)
                            {
                                for (int k = 0; k < sudoku.GetLength(0) - 1; k++)
                                {
                                    //printing column as a binary number
                                    Console.SetCursorPosition(50 + k, 11 + countr + countc);
                                    Console.Write(sudoku[k, i]);
                                    //converting binary to decimal
                                    dec += (int)Math.Pow(2, sudoku.GetLength(1) - 2 - k) * sudoku[k, i];
                                }
                                scorec += dec;
                                countc++;
                                Console.WriteLine("(2) = " + dec + "(10)");
                                if (countc > 0)
                                {
                                    print_calculations[countr + countc - 1] = dec;
                                    filled__column[countc - 1] = i;
                                }
                            }
                        }
                    }

                    //calculating score of blocks
                    //every block is like a element so there are 3 rows and columns
                    //row
                    for (int i = 0; i < 3; i++)
                    {
                        //column
                        for (int j = 0; j < 3; j++)
                        {
                            bool flagb = true;
                            //for inside of blocks
                            //row
                            for (int k = 0; k < 3; k++)
                            {
                                //column
                                for (int l = 0; l < 3; l++)
                                {
                                    if (sudoku[k + (3 * i), l + (3 * j)] == 9)
                                    {
                                        flagb = false;
                                        break;
                                    }
                                }
                            }
                            if (flagb == true)
                            {
                                //converting binary to decimal
                                dec = sudoku[3 * i, 3 * j];
                                dec = (dec * 2) + sudoku[3 * i, (3 * j) + 1];
                                dec = (dec * 2) + sudoku[3 * i, (3 * j) + 2];

                                for (int k = 1; k < 3; k++)
                                {
                                    for (int l = 0; l < 3; l++)
                                    {
                                        dec = (dec * 2) + sudoku[(3 * i) + k, (3 * j) + l];
                                    }
                                }
                                //printing binary number in blocks
                                for (int k = 0; k < 3; k++)
                                {
                                    for (int l = 0; l < 3; l++)
                                    {
                                        Console.SetCursorPosition(50 + l + (3 * k), 11 + countr + countc + countb);
                                        Console.Write(sudoku[(3 * i) + k, (3 * j) + l]);
                                    }
                                }
                                scoreb += dec;
                                countb++;
                                Console.WriteLine("(2) = " + dec + "(10)");
                                if (countb > 0)
                                {
                                    print_calculations[countc + countr + countb - 1] = dec;
                                    filled_block[countb - 1, 0] = i;
                                    filled_block[countb - 1, 1] = j;
                                }
                            }
                        }
                    }

                    countTotal = countr + countc + countb;
                    subscoreTot = scoreb + scorec + scorer;

                    //printing calculation operations
                    if (countr + countc + countb > 1)
                    {
                        for (int i = 0; i < print_calculations.Length; i++)
                        {
                            Console.SetCursorPosition(50 + 6 * i, 12 + countTotal);
                            if (print_calculations[i] != 0)
                            {
                                if (i == countTotal - 1)
                                    Console.Write(print_calculations[i] + " = " + subscoreTot);

                                else
                                    Console.Write(print_calculations[i] + " + ");
                            }
                        }
                        Console.SetCursorPosition(50, 13 + countTotal);
                        Console.WriteLine(subscoreTot + " * " + countTotal + " = " + subscoreTot * countTotal);
                    }

                    subscoreTot *= countTotal;
                    score += subscoreTot;

                    //empty the filled columns and rows
                    for (int i = 0; i < filled__column.Length; i++)
                    {
                        for (int j = 0; j < sudoku.GetLength(0); j++)
                        {
                            if (filled_row[i] != 10)
                                sudoku[filled_row[i], j] = 9;
                            if (filled__column[i] != 10)
                                sudoku[j, filled__column[i]] = 9;
                        }
                    }
                    //empty the filled blocks
                    for (int i = 0; i < filled_block.GetLength(0); i++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            for (int l = 0; l < 3; l++)
                            {
                                if (filled_block[i, 0] != 10)
                                    sudoku[filled_block[i, 0] * 3 + k, filled_block[i, 1] * 3 + l] = 9;
                            }
                        }
                    }

                    if (subscoreTot > 0)
                    {
                        Console.SetCursorPosition(50, 9);
                        Console.WriteLine("Calculations:");
                    }

                    //printing amount of piece and the total score
                    Console.SetCursorPosition(87, 5);
                    Console.WriteLine(npiece);

                    Console.SetCursorPosition(87, 2);
                    Console.WriteLine(score);


                } while (IsGameOver == false); // if the game is not over, the loop executes again and again

                //printing prompting messages when the game is over
                Console.SetCursorPosition(31, 22);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("There are no places left to place this piece. Game over.");
                Console.ResetColor();

                //asking the user if he/she wants to play again
                do
                {
                    Console.SetCursorPosition(0, 24);
                    Console.WriteLine("Would you like to play again? (Y/N): ");
                    restart = Console.ReadLine().ToUpper();

                    //taking the answer again when the user enters invalid answer
                    if (restart != "Y" && restart != "N")
                    {
                        Console.SetCursorPosition(44, 24);
                        Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                    }

                } while (restart != "Y" && restart != "N");

            } while (restart == "Y");
        }
    }
}
