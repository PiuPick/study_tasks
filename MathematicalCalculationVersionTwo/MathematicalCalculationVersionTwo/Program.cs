namespace MathematicalCalculationVersionTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter var a:");
            double a_var = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter var b:");
            double b_var = Convert.ToDouble(Console.ReadLine());

            double x_var = Math.Round((2 / (Math.Pow(a_var, 2) + 25) + b_var) / (Math.Sqrt(b_var) + (a_var + b_var) / 2), 3);

            Console.WriteLine($"Result var x = {x_var}");
        }
    }
}
