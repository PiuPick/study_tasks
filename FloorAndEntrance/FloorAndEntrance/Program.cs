using System.Runtime.ConstrainedExecution;

namespace FloorAndEntrance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // номер квартиры
            Console.WriteLine("Enter apartNum:");
            int apartNum = Convert.ToInt32(Console.ReadLine());

            // количество этажей
            Console.WriteLine("Enter countFloors:");
            int countFloors = Convert.ToInt32(Console.ReadLine());

            // количество квартир на этаже
            Console.WriteLine("Enter countApartOnFloor:");
            int countApartOnFloor = Convert.ToInt32(Console.ReadLine());

            // номер поъезда
            int entranceNum = (int)Math.Ceiling((double)apartNum / (countFloors * countApartOnFloor));

            // номер этажа
            int floorNum = (int)Math.Ceiling(((double)apartNum - countFloors * countApartOnFloor * (entranceNum - 1)) / countApartOnFloor);

            Console.WriteLine(entranceNum);
            Console.WriteLine(floorNum);
        }
    }
}
