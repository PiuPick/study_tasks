namespace WatchFaceVersionTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter hours:");
            int hours = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter minutes:");
            int minutes = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter seconds:");
            int seconds = Convert.ToInt32(Console.ReadLine());

            // 1 час это 30 градусов, следовательно
            // 2 минуты это изменение часовой стрелки на 1 градус
            // 120 секунд это изменение часовой стрелки на 1 градус

            double angle = Math.Round((double)hours * 30 + (double)minutes / 2 + (double)seconds / 120, 3);

            Console.WriteLine($"Angle hours = {angle}");
        }
    }
}
