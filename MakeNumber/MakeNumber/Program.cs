using System.Data;
using System.IO;

namespace MakeNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter vars:\nnum = ");
            uint num = Convert.ToUInt32(Console.ReadLine());

            Console.Write("a = ");
            uint a = Convert.ToUInt32(Console.ReadLine());

            Console.Write("b = ");
            uint b = Convert.ToUInt32(Console.ReadLine());

            // для решения задачи используем принцип бинарного дерева
            bool finding_the_path_binary_tree(uint number, uint a_add, uint b_mult, ref bool flag, string history = "")
            {
                // правая ветка дерева
                if (number % b_mult == 0 && !flag)
                {
                    finding_the_path_binary_tree(number/b_mult, a_add, b_mult, ref flag, "*" + Convert.ToString(b_mult) + " " + history);
                }

                // левая ветка дерева
                if (number - a_add >= 1 && number > number - a_add && !flag) // дополнительное условие, так как у нас uint
                {
                    finding_the_path_binary_tree(number - a_add, a_add, b_mult, ref flag, "+" + Convert.ToString(a_add) + " " + history);
                }

                // выход из рекурсии
                if (number == 1) // Convert.ToInt32(new DataTable().Compute(history, "")
                {
                    Console.WriteLine(history);
                    flag = true;
                }
                return flag; // возвращение флага
            }

            bool result = false; // флаг обозначающий успех/фиаско в вычислениях

            if (!finding_the_path_binary_tree(num, a, b, ref result))
            {
                Console.WriteLine("Error: the number cannot be obtained by these two terms");
            }
        }
    }
}
