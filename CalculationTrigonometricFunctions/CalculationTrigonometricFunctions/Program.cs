using System.Numerics;

namespace CalculationTrigonometricFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            double result = 1;

            Console.WriteLine("Enter x:");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter e:");
            double e = Convert.ToDouble(Console.ReadLine());

            // функция разложения ряда
            double DecompositionTrigonometrySeries(double x, int i)
            {
                double factorial = 1;
                for (int j = 2; j <= i * 2; ++j) { factorial *= j; }

                return Math.Pow(-1, i) * Math.Pow(x, i * 2) / factorial;
            }

            // гарантированные 3 итерации
            while (i < 3)
            {
                result += DecompositionTrigonometrySeries(x, i);
                ++i;
            }

            // вычисляем до определенной точности, если предыдущего условия было недостаточно
            while (e < Math.Abs(DecompositionTrigonometrySeries(x, i)))
            {
                result += DecompositionTrigonometrySeries(x, i);
                ++i;
            }

            // нахождение количества цифр после запятой заданного
            // числа точности для последующего округления результата
            int countNum = 0;
            while (e * Math.Pow(10, 1 + countNum) % 10 != 0) { countNum++; }
            result = Math.Round(result, countNum);

            Console.WriteLine($"cos({x}) = {result}");
        }
    }
}
