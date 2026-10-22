using System;
using System.Text;
using DZ_Module4_Namespaces.TicTacToe;
using DZ_Module4_Namespaces.Morse;

namespace DZ_Module4_Namespaces
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1 — крестики-нолики с компьютером");
                Console.WriteLine("2 — крестики-нолики с другим игроком");
                Console.WriteLine("3 — текст в азбуку Морзе");
                Console.WriteLine("4 — азбука Морзе в текст");
                Console.WriteLine("0 — выход");
                Console.Write("Выберите задание: ");
                switch (Console.ReadLine())
                {
                    case "1": new Game().PlayWithComputer(); break;
                    case "2": new Game().PlayWithPlayer(); break;
                    case "3": Translator.TextToMorse(); break;
                    case "4": Translator.MorseToText(); break;
                    case "0": return;
                    default: Console.WriteLine("Введите число от 0 до 4."); break;
                }
            }
        }
    }
}
