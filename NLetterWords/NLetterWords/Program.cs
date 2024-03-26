namespace NLetterWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter the length of the word N\nN = ");
            //int N_num= Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Enter the length of the alphabet used for the word M\nM = ");
            //int M_num = Convert.ToInt32(Console.ReadLine());

            NLetterWords(4, 3);

            Console.WriteLine();

            //NLetterWords_recursion(N_num, M_num);
        }

        const string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        static void NLetterWords(int N_num, int M_num)
        {
            string mini_alphabet = alphabet[..M_num]; // записали алфавит из M_num букв русского алфавита
            int count_placements = (int)Math.Pow(M_num, N_num); // число размещений с повторениями

            int[,] result = new int[count_placements, N_num];

            int temp = 0;

            for (int i = 1; i < count_placements; i++) // проходимся по каждому слову
            {
                result[i - 1, 0] = temp++;

                for (int j = 1; j < N_num; j++) // проходимся по каждому символу (начиная со 2 по счету)
                {
                    result[i, j] = result[i - 1, j]; // копируем предыдущее слово
                }

                if (temp == M_num)
                {
                    temp = 0;
                    int help = 1;

                    while (help + 1 < N_num)
                    {
                        if (++result[i, help] == M_num)
                        {
                            result[i, help] = 0;
                            ++result[i, ++help];
                        }
                        else break;
                    }
                }
            }


            for (int i = 0; i < count_placements; i++)
            {
                for (int j = 0; j < N_num; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Console.WriteLine(result);
        }
        static void NLetterWords_recursion(int N_num, int M_num)
        {

        }
    }
}
