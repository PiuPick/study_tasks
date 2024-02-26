namespace TextRecordNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number [1, 99] = ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num >= 1 && num <= 99)
            {
                string[] one_to_nineteen = {"один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь",
                                            "девять", "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать",
                                            "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };

                string[] dozens = { "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };

                switch (num)
                {
                    case <= 19:
                        Console.WriteLine(one_to_nineteen[num - 1]);
                        break;

                    default:
                        Console.Write(dozens[num / 10 - 2] + " ");
                        if (num % 10 != 0) Console.WriteLine(one_to_nineteen[num % 10 - 1]);
                        break;
                }
                return;
            }
            Console.WriteLine("Error value");
        }
    }
}
