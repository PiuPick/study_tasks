using System.Transactions;

namespace Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter vars a1, b1, c1:");
            double[] first_vars = new double[3];
            first_vars[0] = Convert.ToDouble(Console.ReadLine());
            first_vars[1] = Convert.ToDouble(Console.ReadLine());
            first_vars[2] = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter vars a2, b2, c2:");
            double[] second_vars = new double[3];
            second_vars[0] = Convert.ToDouble(Console.ReadLine());
            second_vars[1] = Convert.ToDouble(Console.ReadLine());
            second_vars[2] = Convert.ToDouble(Console.ReadLine());

            Array.Sort(first_vars);
            Array.Sort(second_vars);

            if (first_vars[0] <= second_vars[0] && 
                first_vars[1] <= second_vars[1] && 
                first_vars[2] <= second_vars[2])
            {
                Console.WriteLine("yes");
            }
            else { Console.WriteLine("no"); }
        }
    }
}
