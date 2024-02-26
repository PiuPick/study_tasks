namespace Palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a palindrome to check");
            string str = Console.ReadLine().ToLower();

            bool check(string str)
            {
                // если рекурсия "съела" всю строку без false
                // или строка состоит из нечетного количества
                // символов (т.е. дошли до центра строки)
                if (str.Length <= 1) { return true; } 

                // сравниваем концы
                if (str[0] == str.Last())
                {
                    str = str[1..^1];                   // отрезали концы
                    if (check(str)) { return true; }    // запустили рекурсию
                    else { return false; }
                }

                return false;
            }

            if (check(str)) { Console.WriteLine("Palindrome"); }
            else { Console.WriteLine("Not a palindrome"); }
        }
    }
}
