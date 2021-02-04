using System;
namespace methods
{
    public class Game
    {
        public int moves;
        public string[] fieldStates;

        public Game()
        {
            moves = 9;
            fieldStates = new string[9];
            for (int i = 0; i < 9; i++)
            {
                fieldStates[i] = " ";
            }
            Console.WriteLine("Welcome to tic-tac-toe!");
            playNewGame();

        }

        private void play(string player, int move)
        {
            this.fieldStates[move] = player;
        }

        public void display()
        {
            Console.WriteLine();
            Console.WriteLine($" {this.fieldStates[0]} | {this.fieldStates[1]} | {this.fieldStates[2]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {this.fieldStates[3]} | {this.fieldStates[4]} | {this.fieldStates[5]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {this.fieldStates[6]} | {this.fieldStates[7]} | {this.fieldStates[8]}");
        }

        private string winner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (this.fieldStates[i * 3] == this.fieldStates[(i * 3) + 1] && this.fieldStates[i * 3] == this.fieldStates[(i * 3) + 2] && this.fieldStates[i * 3] != " ")
                    return this.fieldStates[i * 3];
                if (this.fieldStates[i] == this.fieldStates[i + 3] && this.fieldStates[i] == this.fieldStates[i + 6] && this.fieldStates[i] != " ")
                    return this.fieldStates[i];
            }

            if (this.fieldStates[0] == this.fieldStates[4] && this.fieldStates[0] == this.fieldStates[8] && this.fieldStates[0] != " ")
                return this.fieldStates[0];

            if (this.fieldStates[2] == this.fieldStates[4] && this.fieldStates[2] == this.fieldStates[6] && this.fieldStates[2] != " ")
                return this.fieldStates[2];

            return " ";
        }

        private bool isFull()
        {
            for (int i = 0; i < 9; i++)
            {
                if (this.fieldStates[i] != " ")
                    return false;
            }

            return true;
        }

        public void playNewGame()
        {
            int mymove;
            this.display();
            while (moves > 0)
            {
                if (moves % 2 == 1)
                {
                    Console.Write("X's move >");
                }
                else
                {
                    Console.Write("O's move >");
                }

                mymove = Convert.ToInt32(Console.ReadLine());
                while ((mymove < 0 || mymove > 8) || this.fieldStates[mymove] != " ")
                {
                    Console.WriteLine("Illegal move! Try again.");


                    if (moves % 2 == 1)
                    {
                        Console.Write("X's move >");
                    }
                    else
                    {
                        Console.Write("O's move >");
                    }

                    mymove = Convert.ToInt32(Console.ReadLine());
                }

                if (moves % 2 == 1)
                {
                    this.play("X", mymove);
                }
                else
                {
                    this.play("O", mymove);
                }


                this.display();

                moves -= 1;
                if (this.winner() == "X" || this.winner() == "O")
                {
                    Console.WriteLine("The winner is: " + this.winner());

                    break;
                }
                else if (this.isFull())
                {
                    break;
                }

            }
            Console.WriteLine("Game Over!");



        }


    }

    class Menu
    {
        public Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1) New Game");
                Console.WriteLine("2) About the author");
                Console.WriteLine("3) Exit");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Clear();
                    Game game = new Game();
                    Console.WriteLine("Press Enter to return to main menu...");
                    input = Console.ReadLine();
                    continue;

                }
                else if (input == "2")
                {
                    Console.Clear();
                    Console.WriteLine("The author of this game is Ege Aktas.");
                    Console.WriteLine("Press Enter to return to main menu...");
                    input = Console.ReadLine();
                    continue;
                }
                else if (input == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Are you sure you want to quit? [y/n]");
                    input = Console.ReadLine();
                    if (input == "y" || input == "Y")
                    {
                        Environment.Exit(0);

                    }
                    else
                    {
                        Console.Clear();
                        continue;
                    }

                }

            }


        }



    }


}