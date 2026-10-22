using System;

namespace DZ_Module4_Namespaces.Morse
{
    // Задание 3
    // Создайте приложение для перевода обычного текста в азбуку Морзе. Пользователь
    // вводит текст. Приложение отображает введенный текст азбукой Морзе.
    // Используйте механизмы пространств имён.
    //
    // Задание 4
    // Добавьте к предыдущему заданию механизм перевода текста из азбуки Морзе
    // в обычный текст.
    internal class Translator
    {
        private static char[] letters = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789".ToCharArray();
        private static string[] codes = { ".-", "-...", ".--", "--.", "-..", ".", "...-", "--..", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", ".-.", "...", "-", "..-", "..-.", "....", "-.-.", "---.", "----", "--.-", "--.--", "-.--", "-..-", "..-..", "..--", ".--.-", "----.", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----." };

        public static void TextToMorse()
        {
            Console.Write("Введите текст: ");
            string text = (Console.ReadLine() ?? "").ToUpper();
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ') { result += "/ "; continue; }
                int index = FindLetter(text[i]);
                if (index != -1) result += codes[index] + " ";
                else result += "? ";
            }
            Console.WriteLine("Азбука Морзе: " + result);
            Console.WriteLine("Символы отделяются пробелом, слова — знаком /.");
        }
        public static void MorseToText()
        {
            Console.Write("Введите азбуку Морзе: ");
            string[] parts = (Console.ReadLine() ?? "").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string result = "";
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "/") { result += " "; continue; }
                int index = FindCode(parts[i]);
                result += index == -1 ? "?" : letters[index].ToString();
            }
            Console.WriteLine("Обычный текст: " + result);
        }
        private static int FindLetter(char letter) { for (int i = 0; i < letters.Length; i++) if (letters[i] == letter) return i; return -1; }
        private static int FindCode(string code) { for (int i = 0; i < codes.Length; i++) if (codes[i] == code) return i; return -1; }
    }
}
