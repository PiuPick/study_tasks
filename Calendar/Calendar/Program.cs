using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Calendar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter date (d.m.y) = ");
            string date = Console.ReadLine();
            Console.Write("\n");

            Calendar(date);         // основная функция (для оценивания)
            Console.Write("\n");
            Calendar_color(date);   // дополнительная функция (для наглядности и красоты)
        }

        static void Calendar(string date)
        {
            // находим вхождения чисел с помощью регулярного выражения
            MatchCollection matches = Regex.Matches(date, @"\d+");

            // берем первые три вхождения
            int day = Convert.ToInt32(matches[0].Value);
            int month = Convert.ToInt32(matches[1].Value);
            int year = Convert.ToInt32(matches[2].Value);

            DateTime dateTime = new DateTime(year, month, day);

            dateTime = dateTime.AddDays(1 - day); // узнаем начало месяца

            int day_week; // день недели первого дня месяца
            switch (dateTime.DayOfWeek.ToString()) 
            {
                case "Monday":    day_week = 0; break;
                case "Tuesday":   day_week = 1; break;
                case "Wednesday": day_week = 2; break;
                case "Thursday":  day_week = 3; break;
                case "Friday":    day_week = 4; break;
                case "Saturday":  day_week = 5; break;
                default:          day_week = 6; break;
            }

            // узнаем количество дней в месяце
            int days_in_month = DateTime.DaysInMonth(year, month);

            // делаем шапку календаря
            string result = "ПН  ВТ  СР  ЧТ  ПТ  СБ  ВС\n" + 
                            new String(' ', day_week * 4); // добавлем необходимые пробелы для дня недели

            for (int i = 1; i <= days_in_month; i++)
            {
                // форматируем для ровного вывода календаря
                result += string.Format("{0,2}  ", i); 

                // инкрементируем / сбрасываем счетчик дней недели
                if (day_week++ == 6)
                {
                    day_week = 0;
                    result += "\n";
                }
            }

            Console.WriteLine(result);
        }
        static void Calendar_color(string date)
        {
            // находим вхождения чисел с помощью регулярного выражения
            MatchCollection matches = Regex.Matches(date, @"\d+");

            // берем первые три вхождения
            int day = Convert.ToInt32(matches[0].Value);
            int month = Convert.ToInt32(matches[1].Value);
            int year = Convert.ToInt32(matches[2].Value);

            DateTime dateTime = new DateTime(year, month, day);

            dateTime = dateTime.AddDays(1 - day); // узнаем начало месяца

            int day_week; // день недели первого дня месяца
            switch (dateTime.DayOfWeek.ToString())
            {
                case "Monday": day_week = 0; break;
                case "Tuesday": day_week = 1; break;
                case "Wednesday": day_week = 2; break;
                case "Thursday": day_week = 3; break;
                case "Friday": day_week = 4; break;
                case "Saturday": day_week = 5; break;
                default: day_week = 6; break;
            }

            // узнаем количество дней в месяце
            int days_in_month = DateTime.DaysInMonth(year, month);

            // делаем шапку календаря
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("ПН  ВТ  СР  ЧТ  ПТ  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("СБ  ВС\n");
            Console.ResetColor();

            Console.Write(new String(' ', day_week * 4)); // добавлем необходимые пробелы для дня недели

            for (int i = 1; i <= days_in_month; i++)
            {
                // отрисовываем изначальный день
                if (i == day)
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(string.Format("{0,2}  ", i));
                    Console.ResetColor();
                }
                // отрисовываем будни
                else if (day_week < 5)
                {
                    Console.Write(string.Format("{0,2}  ", i));
                }
                // отрисовываем выходные
                else
                { 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(string.Format("{0,2}  ", i));
                    Console.ResetColor();
                }

                // инкрементируем / сбрасываем счетчик дней недели
                if (++day_week == 7)
                {
                    day_week = 0;
                    Console.Write("\n");
                }
            }
            Console.WriteLine("\n");
        }
    }
}
