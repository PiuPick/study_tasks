using System;

namespace NLetterWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the length of the word N\nN = ");
            int N_num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the length of the alphabet used for the word M\nM = ");
            int M_num = Convert.ToInt32(Console.ReadLine());

            //NLetterWords(3, 3);
            //NLetterWords_recursive(3, 3);
        }

        const string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        static void NLetterWords_recursive(int N_num, int M_num, string word = "")
        {
            if (word.Length == N_num) // если слово сформировалось, то выводим
            {
                Console.WriteLine(word);
                return;
            }

            // с конца будут изменяться значения (ААА, ААБ, ААВ и тд)
            for (int i = 0; i < M_num; i++) NLetterWords_recursive(N_num, M_num, word + alphabet[i]);
        }

        static void NLetterWords(int N_num, int M_num)
        {
            string mini_alphabet = alphabet[..M_num];               // записали мини алфавит из M_num букв русского алфавита

            int count_placements = (int)Math.Pow(M_num, N_num);     // нашли число размещений с повторениями (количество слов)
            int[,] words_in_num = new int[count_placements, N_num]; // создаем таблицу слов, которая будет содержать числа ячеек мини алфавита

            for (int k = 1; k < count_placements; k++)              // проходимся по каждому слову
            {
                for (int n = 0; n < N_num; n++)                     // проходимся по каждому предыдущему символу слова, чтобы его скопировать в новое
                    words_in_num[k, n] = words_in_num[k - 1, n];

                if (words_in_num[k, 0] + 1 < M_num) ++words_in_num[k, 0]; // увеличиваем значение первой ячейки
                else // если она равна M_num, тогда обнуляем её и прибавляем единицу следующему элементу слова
                {
                    words_in_num[k, 0] = 0;

                    for (int t = 1; t < N_num; t++) // проходимся по оставшимся элементам слова
                    {
                        // если предыдущий элемент равен нулю и текущий при увелечении равен M_num, то обнуляем элемент и повторяем снова
                        if (words_in_num[k, t - 1] == 0 && ++words_in_num[k, t] == M_num) words_in_num[k, t] = 0; 
                        else break; // в противном случае заканчиваем с увеличениями
                    }
                }
            }

            // выводим
            for (int i = 0; i < count_placements; i++)
            {
                for (int j = 0; j < N_num; j++)
                {
                    Console.Write(mini_alphabet[words_in_num[i, j]]);
                }
                Console.WriteLine();
            }
        }
    }
}
