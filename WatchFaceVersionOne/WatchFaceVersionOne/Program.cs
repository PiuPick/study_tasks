using System.Reflection.Metadata;

namespace WatchFaceVersionOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter h_angle:");
            double h_angle = Convert.ToDouble(Console.ReadLine());

            // каждые 30 градусов, пройденные часовой стрелкой,
            // равняются одному часу или пройденным 360 градусам минутной стрелки
            // поэтому 1 градус часовой стрелки равен 12 градусам минутной стрелки

            double minute_angle = Math.Round(h_angle * 12 % 360, 2);

            Console.WriteLine(minute_angle);
        }
    }
}
