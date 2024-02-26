namespace FillingTheArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k, j, m, n;

            n = 20;
            m = 19;

            k = 1;

            int[,] mas = new int[n, m];

            while (k < n) // в условии <=, но компилятор ругается
            {
                mas[k, 1] = k;
                j = 2;

                while (j < m) // в условии <=, но компилятор ругается
                {
                    mas[k, j] = k * j - mas[k, j - 1];
                    j++;
                }   
                k++;
            }

            // Console.WriteLine("k = " + k);

            // выводим всё что есть и считаем количество четных элементов
            int count = 0;
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int p = 0; p < mas.GetLength(1); p++)
                {
                    Console.Write(mas[i, p] + " ");
                    if (mas[i, p] % 2 == 0 /*&& mas[i, p] != 0*/) { count++; }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nCount = " + count); // count = 280 четных чисел (если ещё считать ноль)
        }
    }
}
