namespace MathematicalCalculationVersionOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter var a:");
            double a_var = Convert.ToDouble(Console.ReadLine());

            double x_var = Math.Round(Math.Sqrt((2 * a_var + Math.Sin(Math.Abs(3 * a_var))) / 3.56), 3);

            Console.WriteLine($"Result var x = {x_var}");
        }
    }
}
