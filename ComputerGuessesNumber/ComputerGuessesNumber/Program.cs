namespace ComputerGuessesNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter numbers\nM = ");
            int m_num = Convert.ToInt32(Console.ReadLine());

            Console.Write("count = ");
            int count = Convert.ToInt32(Console.ReadLine());

            Guess_number(m_num, count);
        }
        static void Guess_number(int number, int count)
        {
            if (count == 0) { // выход из рекурсии
                if (number % 2 != 0)
                    Console.Write(number + " ");
            }
            else if (number % 2 == 0) { // если четное число
                Guess_number(number - 3, count - 1);
                Guess_number(number * 2, count - 1);
            }
            else if (number % 2 == 1) // если нечетное число
                Guess_number(number * 2, count - 1);
        }
    }
}
