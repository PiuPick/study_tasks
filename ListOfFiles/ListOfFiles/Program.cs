namespace ListOfFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Программа выводит список подпапок и файлов в заданной папке.\r\nВведите имя папки: ");
            string folder = Console.ReadLine();

            // если ничего не написали, то завершаем работу
            if (folder == string.Empty) return;

            // находим полный путь до папки назначения
            string full_path_folder = Directory.GetCurrentDirectory() + @"\" + folder;

            void path(string path_folder, int nesting_level = 0)
            {
                ++nesting_level; // уровень вложенности

                // получаем все папки внутри директории
                IEnumerable<string> dirnames = Directory.EnumerateDirectories(path_folder);
                if (nesting_level == 0) { dirnames = dirnames.Prepend(full_path_folder); --nesting_level; }

                // пересматриваем папки и их содержимое
                foreach (var dirname in dirnames)
                {
                    // выводим папку голубого цвета
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(string.Join("", Enumerable.Repeat("   ", nesting_level)) + "+ " +
                        Path.GetFileName(dirname.TrimEnd(Path.DirectorySeparatorChar)));

                    // получаем все файлы внутри директории
                    IEnumerable<string> files = Directory.EnumerateFiles(dirname);

                    // перечисляем файлы
                    foreach (var file in files)
                    {
                        Console.ResetColor();
                        Console.WriteLine(string.Join("", Enumerable.Repeat("   ", nesting_level + 1)) + "└─ " +
                        Path.GetFileName(file));
                    }

                    // изначальный путь и проверка на пустоту папки, затем рекурсия
                    if (dirname == full_path_folder) { ++nesting_level; }
                    else if (Directory.EnumerateFileSystemEntries(dirname).Any()) { path(dirname, nesting_level); }
                }
            }

            path(full_path_folder);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nНажмите Enter для завершения работы программы...");
            Console.Read();
        }
    }
}
