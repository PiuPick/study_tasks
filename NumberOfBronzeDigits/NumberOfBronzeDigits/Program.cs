namespace NumberOfBronzeDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            Console.WriteLine("Enter countApartments:");
            int countApartments = Convert.ToInt32(Console.ReadLine());

            // 1 цифра в номере
            if (countApartments >= 0 && countApartments <= 9)
            {
                num += countApartments;
            }

            // 2 цифры в номере
            if (countApartments >= 10 && countApartments <= 99)
            {
                num += 9; // 1 цифра
                num += (countApartments - 9) * 2; 
            }

            // 3 цифры в номере
            if (countApartments >= 100 && countApartments <= 999)
            {
                num += 9; // 1 цифра
                num += 180; // 2 цифры
                num += (countApartments - 99) * 3;
            }

            Console.WriteLine(num);
        }
    }
}
