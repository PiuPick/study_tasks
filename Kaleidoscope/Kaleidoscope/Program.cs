namespace Kaleidoscope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the kaleidoscope (half square)\nsize = ");
            int size = Convert.ToInt32(Console.ReadLine());

            if (size < 3 || size > 20) { Console.WriteLine("Error: size >20 or <3"); return; }

            Kaleidoscope(size);
        }

        static int[] colors = { 0, 8, 7, 15, 14, 6, 12, 4, 5, 13, 11, 3, 9, 1, 2, 10 };
        static void Kaleidoscope(int size)
        {
            // создаем четверть всей картинки (пусть это будет левый верхний квадрат)
            int[,] color_square = new int[size, size];
            Random rnd = new Random();

            // запоняем массив рандомными значениями из диапазона цветов ConsoleColor
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    // главная диагональ
                    if (i == j) { color_square[i, i] = colors[rnd.Next(3, 20)]; continue; }

                    // симметрия по диагонали
                    color_square[i, j] = colors[rnd.Next(3, 20)];
                    color_square[j, i] = color_square[i, j];

                    // проверка на соседние повторяющиеся цвета
                    if ((i > 0 && color_square[i, j] == color_square[i - 1, j]) ||
                        (j > 0 && color_square[i, j] == color_square[i, j - 1]))
                    {
                        while (color_square[i, j] == color_square[i - 1, j] ||
                              color_square[i, j] == color_square[i, j - 1])
                            color_square[i, j] = colors[rnd.Next(3, 20)];
                    }
                }
            }

            // отзеркалить матрицу
            // 1) по вертикали
            // 2) по горизонтали
            // 3) 1. по горизонтали

            // соединить все 4 кусочка матрицы в одну

            // вывести на экран
        }
    }
}