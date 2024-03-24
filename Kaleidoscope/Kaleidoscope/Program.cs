namespace Kaleidoscope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the size of the kaleidoscope (half square)\nsize = ");
            int size = Convert.ToInt32(Console.ReadLine());

            if (size < 3 || size > 20) { Console.WriteLine("Error: your 3 < size > 20"); return; }

            Kaleidoscope(size);
        }

        private static int[] colors = { 0, 8, 7, 15, 14, 6, 12, 4, 5, 13, 11, 3, 9, 1, 2, 10 };

        static void Kaleidoscope(int size)
        {
            // создаем квадрат общей картины, который включает в себя 4 четвертинки
            int[,] color_square = new int[size * 2, size * 2];

            int temp = size * 2 - 1; // вспомогательная переменная для заполнения массива 
            Random rnd = new Random();

            // заполнение и проверка массива рандомными значениями из диапазона цветов ConsoleColor
            for (int i = 0; i < size; i++)
            {
                for (int j = i; j < size; j++)
                {
                    // задаем цвет одному пикселю
                    color_square[i, j] = colors[rnd.Next(16)];

                    // проверка на совпадение левого и верхнего пикселя от текущего
                    while ((i > 0 && (color_square[i, j] == color_square[i - 1, j])) ||
                           (j > 0 && (color_square[i, j] == color_square[i, j - 1])) )
                    {
                        color_square[i, j] = colors[rnd.Next(16)];
                    }

                    // симметричная отрисовка четвертинки относительно её диагонали:
                    color_square[j, i] =                                                    // верхней левой
                    color_square[i, temp - j] = color_square[j, temp - i] =                 // верхней правой
                    color_square[temp - i, j] = color_square[temp - j, i] =                 // нижней левой
                    color_square[temp - i, temp - j] = color_square[temp - j, temp - i] =   // нижней правой
                        color_square[i, j]; // присвоили к одному проверенному цвету все остальные
                }
            }

            // отрисовываем калейдоскоп
            ++temp; // увеличиваем значение до полного размера калейдоскопа
            for (int i = 0; i < temp; i++)
            {
                for (int j = 0; j < temp; j++)
                {
                    Console.BackgroundColor = (ConsoleColor)color_square[i, j];
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}