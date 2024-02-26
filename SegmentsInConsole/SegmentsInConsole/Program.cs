namespace SegmentsInConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter args - width, a, b, c");

            // вытягиваем числа из строки
            int[] arr_i = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            int sum_args_first = arr_i[1] + arr_i[2] + arr_i[3];

            double[] arr_d = new double[4];

            for (int i = 1; i < arr_i.Length; i++) 
            {
                // находим цену одного символа будущей строки с вычетом двух символов вертикальных палочек
                arr_d[i] = (arr_i[0] - 2) * (double) arr_i[i] / sum_args_first;
                // проверяем что хотя б одна палочка будет соответствовать введенному числу
                // + 0,6 предусматривает под собой ширину вертикальной палочки на каждый отрезок (то есть 2/3)
                if (arr_d[i] + 0.6 < 1)
                {
                    Console.WriteLine("Error!");
                    return;
                }

                arr_i[i] = (int) Math.Round(arr_d[i]);
            }

            int sum_args_second = arr_i[1] + arr_i[2] + arr_i[3];

            // если не добрали или перебрали количество символов в строке
            if (arr_i[0] != sum_args_second + 2)
            {
                if (arr_i[0] - sum_args_second > 0)
                {
                    int i = 2, index = 2;
                    double max = arr_d[1];
                    while (i <= 3) 
                    {
                        if (arr_d[i] % 1 > max % 1)
                        {
                            max = arr_d[i];
                            index = i++;
                        }
                    }
                    arr_i[index]++;
                }
                else
                {
                    int i = 2, index = 2;
                    double min = arr_d[1];
                    while (i <= 3)
                    {
                        if (arr_d[i] % 1 > min % 1)
                        {
                            min = arr_d[i];
                            index = i++;
                        }
                    }
                    arr_i[index]--;
                }
            }

            Console.WriteLine(
                string.Join("", Enumerable.Repeat("-", arr_i[1])) + "|" +
                string.Join("", Enumerable.Repeat("-", arr_i[2])) + "|" +
                string.Join("", Enumerable.Repeat("-", arr_i[3])));
        }
    }
}
