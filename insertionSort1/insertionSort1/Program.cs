using System;

namespace insertionSort1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] arr = new int[10];

            for(int i = 0; i < arr.Length; i ++)
            {
                arr[i] = rnd.Next(1, 50);
            }

            for (int i = 1; i < arr.Length; i++)
            {
                int nextItem = arr[i];
                int j = i - 1;

                while (j >= 0 && nextItem < arr[j])
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                arr[j + 1] = nextItem;
            }

            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
