using System;

namespace DZ_Module4_Namespaces.TicTacToe
{
    // Задание 1
    // Создайте приложение «Крестики-Нолики». Пользователь играет с компьютером.
    // При старте игры случайным образом выбирается, кто ходит первым. Игроки ходят
    // по очереди. Игра может закончиться победой одного из игроков или ничьей.
    // Используйте механизмы пространств имён.
    //
    // Задание 2
    // Добавьте к первому заданию возможность игры с другим пользователем.
    internal class Game
    {
        private char[,] board;
        private Random random;

        public Game()
        {
            board = new char[3, 3];
            random = new Random();
            ClearBoard();
        }

        public void PlayWithComputer()
        {
            ClearBoard();
            char current = random.Next(2) == 0 ? 'X' : 'O';
            Console.WriteLine(current == 'X' ? "Первым ходит игрок (X)." : "Первым ходит компьютер (O). ");
            while (true)
            {
                PrintBoard();
                if (current == 'X') PlayerMove("Игрок, ваш ход (X)", 'X');
                else ComputerMove();
                if (FinishGame(current)) return;
                current = current == 'X' ? 'O' : 'X';
            }
        }

        public void PlayWithPlayer()
        {
            ClearBoard();
            char current = random.Next(2) == 0 ? 'X' : 'O';
            Console.WriteLine("Первым ходит игрок " + (current == 'X' ? "1 (X)." : "2 (O)."));
            while (true)
            {
                PrintBoard();
                PlayerMove(current == 'X' ? "Ход игрока 1 (X)" : "Ход игрока 2 (O)", current);
                if (FinishGame(current)) return;
                current = current == 'X' ? 'O' : 'X';
            }
        }

        private void ClearBoard()
        {
            for (int row = 0; row < 3; row++)
                for (int column = 0; column < 3; column++) board[row, column] = ' ';
        }
        private void PrintBoard()
        {
            Console.WriteLine("  1   2   3");
            for (int row = 0; row < 3; row++)
            {
                Console.WriteLine((row + 1) + " " + board[row, 0] + " | " + board[row, 1] + " | " + board[row, 2]);
                if (row < 2) Console.WriteLine(" ---+---+---");
            }
        }
        private void PlayerMove(string message, char symbol)
        {
            int row; int column;
            while (true)
            {
                try
                {
                    Console.Write(message + ". Введите строку (1-3): "); row = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Введите столбец (1-3): "); column = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (row >= 0 && row < 3 && column >= 0 && column < 3 && board[row, column] == ' ') break;
                    Console.WriteLine("Эта клетка недоступна.");
                }
                catch { Console.WriteLine("Введите числа от 1 до 3."); }
            }
            board[row, column] = symbol;
        }
        private void ComputerMove()
        {
            int row; int column;
            do { row = random.Next(3); column = random.Next(3); } while (board[row, column] != ' ');
            board[row, column] = 'O';
            Console.WriteLine("Компьютер выбрал: " + (row + 1) + ", " + (column + 1));
        }
        private bool FinishGame(char player)
        {
            if (HasWon(player)) { PrintBoard(); Console.WriteLine("Победили " + player + "!"); return true; }
            if (IsBoardFull()) { PrintBoard(); Console.WriteLine("Ничья!"); return true; }
            return false;
        }
        private bool HasWon(char player)
        {
            for (int i = 0; i < 3; i++)
                if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) || (board[0, i] == player && board[1, i] == player && board[2, i] == player)) return true;
            return (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) || (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player);
        }
        private bool IsBoardFull() { foreach (char cell in board) if (cell == ' ') return false; return true; }
    }
}
