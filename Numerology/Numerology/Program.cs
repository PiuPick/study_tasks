namespace Numerology
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number");
            int number = Convert.ToInt32(Console.ReadLine());
            int sum_8num = 0, sum_2num = 0, sum = 0;

            // поступает число из 8 цифр (полная дата)
            for (int i = 0; i < 8; i++)
            {
                sum_8num += number % 10;
                number /= 10;
            }
            // опытным путем понимаем что если все 8 цифр
            // будут равны 9,то сумма будет небольше двузначного числа (72)
            for (int i = 0; i < 2; i++)
            {
                sum_2num += sum_8num % 10;
                sum_8num /= 10;
            }
            // максимальная сумма предыдущего цикла будет небольше 72
            // а значит максимальная сумма двух цифр будет у числа 69
            // то есть максимальная сумма двух цифр будет небольше 15
            for (int i = 0; i < 2; i++)
            {
                sum += sum_2num % 10;
                sum_2num /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}
