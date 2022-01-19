namespace Namespace
{

    using System.Collections.Generic;

    using System;

    using System.Linq;

    class Module
    {

        static void Main(string[] args)
        {
            var player = "x";
            var board = create_board();
            while (!(has_winner(board) || is_a_draw(board)))
            {
                display_board(board);
                make_move(player, board);
                player = next_player(player);
            }
            display_board(board);
            Console.WriteLine("Good game. Thanks for playing!");
        }

        public static List<string> create_board()
        {
            var board = new List<string>();
            foreach (var square in Enumerable.Range(0, 9))
            {
                board.Add(Convert.ToString(square + 1));
            }
            return board;
        }

        public static void display_board(List<string> board)
        {
            Console.WriteLine();
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
            Console.WriteLine();
        }

        public static bool is_a_draw(List<string> board)
        {
            foreach (var square in Enumerable.Range(0, 9))
            {
                if (board[square] != "x" && board[square] != "o")
                {
                    return false;
                }
            }
            return true;
        }

        public static bool has_winner(List<string> board)
        {
            return (board[0] == board[1] && board[1] == board[2]) ||
                    (board[3] == board[4] && board[4] == board[5]) ||
                    (board[6] == board[7] && board[7] == board[8]) ||
                    (board[0] == board[3] && board[3] == board[6]) ||
                    (board[1] == board[4] && board[4] == board[7]) ||
                    (board[2] == board[5] && board[5] == board[8]) ||
                    (board[0] == board[4] && board[4] == board[8]) ||
                    (board[2] == board[4] && board[4] == board[6]);
        }

        public static void make_move(string player, List<string> board)
        {
            Console.Write($"{player}'s turn to choose a square (1-9): ");
            var answer = Convert.ToInt32(Console.ReadLine());
            // object player = new Player();
            // Console.WriteLine(player.ToString());
            board[answer - 1] = player;
        }

        public static string next_player(string player)
        {
            if (player == "o")
            {
                return "x";
            }
            else
            {
                return "o";
            }
        }

    }
}