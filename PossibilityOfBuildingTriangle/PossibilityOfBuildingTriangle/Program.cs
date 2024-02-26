namespace PossibilityOfBuildingTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a, b, c:");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());

            if (a + b > c && a + c > b && b + c > a)
            { Console.WriteLine("YES"); }
            else { Console.WriteLine("NO"); }
        }
    }
}
