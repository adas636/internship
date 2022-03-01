using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace jeszcze_nie_wiem_co_to_bedziesz
{
    class Game
    {
        Random rnd = new Random();
        string[] text = System.IO.File.ReadAllLines(@"C:\Users\Admin\source\repos\jeszcze nie wiem co to bedziesz\Words.txt");
        int chances;
        int rowCount;
        int colCount;
        string[,] matrix = new string[3, 5] { { "", "1", "2", "3", "4" }, { "A", "*", "*", "*", "*" }, { "B", "*", "*", "*", "*" } };
        string[] words;
        string[] shuffled;
        string[,] results = new string[3, 5] { { "", "1", "2", "3", "4" }, { "A", "*", "*", "*", "*" }, { "B", "*", "*", "*", "*" } }; 
        public void Difficulty_Level() //acquiring information of difficulty level of a game
        {
            Console.WriteLine("Choose dificulty level ( 1 - easy , 2 - hard )");
            if (Console.ReadKey().Key == ConsoleKey.D1)
            {
                chances = 10;
                Console.WriteLine("\nLevel:easy\nGuess chances:" + chances);               
            }
            else
            {
                chances = 8;
                Console.WriteLine("\nLevel:hard\nGuess chances:" + chances);
            }
            
        }
        public string[] Words() //generating words to game
        {
            string[] text1 = text;
            string[] words1 = new string[8];
            for (int i=0;i<=3; i++) //drawing a words and making sure that they don't double
            {
                words1[i] = text1[rnd.Next(0,text.Length)];
                int numIndex = Array.IndexOf(text1, words1[i]);
                List<string> tmp1 = new List<string>(text1);
                tmp1.RemoveAt(numIndex);
                text1 = tmp1.ToArray();
            }
            for(int i=4;i<8;i++)//doubles array
            {
                words1[i] = words1[i - 4];
            }
            int n = words1.Length;
            while ( n> 1)//shuffles
            {
                int k = rnd.Next(n--);
                string temp = words1[n];
                words1[n] = words1[k];
                words1[k] = temp;
            }

            return words=words1;
        }
        public void Board(string [,] matrix1)
        {
            rowCount = matrix1.GetLength(0);
            colCount = matrix1.GetLength(1);
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    Console.Write(matrix1[row, col] + "\t");
                }
                Console.WriteLine();
            }
        } // displays the board 
        public string Reaviling(string players_answer, bool hiding)
        {
            if(hiding == false)
            {
                string word = "mistake"; // had to difine somehow to make it working
                if (players_answer.Contains("A") || players_answer.Contains("a"))
                {
                    if (players_answer.Contains("1"))
                    {
                        matrix[1, 1] = words[0];
                        word = words[0];
                    }
                    if (players_answer.Contains("2"))
                    {
                        matrix[1, 2] = words[1];
                        word = words[1];
                    }
                    if (players_answer.Contains("3"))
                    {
                        matrix[1, 3] = words[2];
                        word = words[2];
                    }
                    if (players_answer.Contains("4"))
                    {
                        matrix[1, 4] = words[3];
                        word = words[3];
                    }
                    return word;
                }
                if (players_answer.Contains("B") || players_answer.Contains("b"))
                {
                    if (players_answer.Contains("1"))
                    {
                        matrix[2, 1] = words[4];
                        word = words[4];
                    }
                    if (players_answer.Contains("2"))
                    {
                        matrix[2, 2] = words[5];
                        word = words[5];
                    }
                    if (players_answer.Contains("3"))
                    {
                        matrix[2, 3] = words[6];
                        word = words[6];
                    }
                    if (players_answer.Contains("4"))
                    {
                        matrix[2, 4] = words[7];
                        word = words[7];
                    }
                    return word;
                }
                return word;
            }
            else
            {
                string word = "mistake"; // had to difine somehow to make it working
                if (players_answer.Contains("A") || players_answer.Contains("a"))
                {
                    if (players_answer.Contains("1"))
                    {
                        matrix[1, 1] = "*";
                        word = words[0];
                    }
                    if (players_answer.Contains("2"))
                    {
                        matrix[1, 2] = "*";
                        word = words[1];
                    }
                    if (players_answer.Contains("3"))
                    {
                        matrix[1, 3] = "*";
                        word = words[2];
                    }
                    if (players_answer.Contains("4"))
                    {
                        matrix[1, 4] = "*";
                        word = words[3];
                    }
                    return word;
                }
                if (players_answer.Contains("B") || players_answer.Contains("b"))
                {
                    if (players_answer.Contains("1"))
                    {
                        matrix[2, 1] = "*";
                        word = shuffled[0];
                    }
                    if (players_answer.Contains("2"))
                    {
                        matrix[2, 2] = "*";
                        word = shuffled[1];
                    }
                    if (players_answer.Contains("3"))
                    {
                        matrix[2, 3] = "*";
                        word = shuffled[2];
                    }
                    if (players_answer.Contains("4"))
                    {
                        matrix[2, 4] = "*";
                        word = shuffled[3];
                    }
                    return word;
                }
                return word;
            }
        }
        public void Restart()
        {
            Console.WriteLine("Do you wish to play again? If so press ENTER if not press three times ESC");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                The_Game();
            }
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Wrong key try again");
                Restart();
            }
        }
        public void The_Game()
        {
            int exsistance=0;
            Difficulty_Level();
            string word1;
            string word2;
            Words();
            shuffled = words;
            string players_answer1;
            string players_answer2;
            Board(matrix);
            for(int i=0;i<=chances;i++)
            {
                if(chances <= 0 )
                {
                    Restart();
                }
                else
                {
                    Console.WriteLine("Choose first position to reveal");
                    players_answer1 = Console.ReadLine();
                    word1 = Reaviling(players_answer1, false);
                    Board(matrix);
                    Console.WriteLine("Choose second position to reveal");
                    players_answer2 = Console.ReadLine();
                    word2 = Reaviling(players_answer2, false);
                    Board(matrix);
                    Thread.Sleep(1500);
                    Console.Clear();
                    chances--;
                    Console.WriteLine("Chances left: " + chances);
                    if (word1 == word2)
                    {
                        results = matrix;
                        Board(results);
                    }
                    else
                    {
                        Reaviling(players_answer1, true);
                        Reaviling(players_answer2, true);
                        Board(results);
                    }
                    for (int j = 0; j < rowCount; j++)
                    {
                        for (int k = 0; k < colCount; k++)
                        {
                            if (results[j, k] != "*")
                            {
                                exsistance++;
                            }
                        }
                    }
                    if (exsistance == 8)
                    {
                        Restart();
                    }
                }                  
            }
        }
    }

}
