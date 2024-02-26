using System;

namespace VowelConsonantLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter char:");
            char sym = Char.ToLower(Convert.ToChar(Console.ReadLine())); // записали и сразу перевели символ в нижний регистр

            // строки гласных и согласных соответственно
            string vowelLetters = "ауоыиэяюёе";
            string consonantLetters = "бвгджзйклмнпрстфхцчшщ";

            // функция проверяющая содержание символа в строке
            bool charInString (char sym, string str)
            {
                int length = str.Length;
                while (length > 0)
                {
                    --length;
                    if (str[length] == sym)
                    {
                        return true;
                    }
                }
                return false;
            }

            if (charInString(sym, vowelLetters)) { Console.WriteLine("гласная"); return; }
            if (charInString(sym, consonantLetters)) { Console.WriteLine("согласная"); return; }

            Console.WriteLine("Error");
        }
    }
}
