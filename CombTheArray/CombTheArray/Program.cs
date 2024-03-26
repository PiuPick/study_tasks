namespace CombTheArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter arr size = ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[size];

            Console.WriteLine("Enter " + size + " numbers:");
            for (int i = 0; i < size; i++) arr[i] = Convert.ToInt32(Console.ReadLine());

            //int[] arr = { -6, -2, -3, 0, 6, 1, 3, 11, 11, 14 };
            //int[] arr = { 22, 20, 18, 14, 10 };

            int[] res = CombTheArray(arr);

            foreach (int i in res)
                Console.WriteLine(i);
        }

        static int[] CombTheArray(int[] arr)
        {
            int[] res = new int[arr.Length];
            int temp = res[0] = arr[0];
            int index = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] >= temp)
                    res[++index] = temp = arr[i];
            }

            res = res[0..++index];

            return res;
        }
    }
}
