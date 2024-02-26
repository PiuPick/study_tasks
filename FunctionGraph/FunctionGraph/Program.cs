namespace FunctionGraph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double y;
            
            Console.WriteLine("Enter x:");
            double x = Math.Abs(Convert.ToDouble(Console.ReadLine()));

            // узнаем после какой вершины находится точка (четная/нечетная)
            if ((x - x % 1) % 2 == 0) 
            { 
                y = Math.Round(1 - x % 1, 1);
            }
            else 
            {
                y = Math.Round(x % 1, 1); 
            }

            y *= -1;

            // проверяем на целые значения x
            if (x % 1 == 0) 
            {
                if (x % 2 == 0) { y = -1; }
                else { y = 0; }
            }

            Console.WriteLine($"y = {y}");
        }
    }
}
