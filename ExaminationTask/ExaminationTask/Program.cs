using System.IO;

namespace ExaminationTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь до папки = ");
            string folder = Console.ReadLine();

            Console.WriteLine(folder_nesting_depth(folder));
        }
        static ushort folder_nesting_depth(string path, ushort nesting_level = 1)
        {
            // проверка пути папки - начального значения (полный или относительный путь)
            if (nesting_level == 1 && path.Contains(':') == false)
                path = Directory.GetCurrentDirectory() + @"\" + path; // прописываем полный путь

            // получаем папки внутри текущей директории
            string[] list_folders = Directory.GetDirectories(path);

            // массив для оценки самого длинного пути
            ushort[] list_levels = new ushort[list_folders.Length];
            if (list_folders.Length == 0) return nesting_level; // выход из рекурсии

            ushort count = 0; // счетчик для массива list_levels
            ++nesting_level;

            // пробегаем по каталогам в директории
            foreach (string dir in list_folders)
                list_levels[count++] = folder_nesting_depth(dir, nesting_level);

            return list_levels.Max(); // возвращаем самое большое значение глубины
        }

        static ulong folder_nesting_depth_update(string path) 
        {
            if (path.Contains(':') == false)                            // проверка пути (полный или относительный)
                path = Directory.GetCurrentDirectory() + @"\" + path;   // прописываем полный путь

            // получаем папки внутри текущей директории
            string[] list_folders = Directory.GetDirectories(path);

            if (list_folders.Length == 0) return 1; // выход из рекурсии

            ulong level = 1;

            // пробегаем по каталогам в директории
            foreach (string dir in list_folders)
                if (level < folder_nesting_depth_update(dir)) 
                    level = folder_nesting_depth_update(dir);

            return level;
        }
    }
}
