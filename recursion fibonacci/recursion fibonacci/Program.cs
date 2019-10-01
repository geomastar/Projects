using System;

namespace recursion_fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gib number\n");

            int n = 0;

            while (n != -1)
            {
                n = Convert.ToInt32(Console.ReadLine());

                if (n != -1)
                {
                    Console.WriteLine(RecursiveFib(n) + "\n");
                }
            }
        }

        public static int RecursiveFib(int n)
        {
            if (n==0)
            {
                return 0;
            }

            if (n==1)
            {
                return 1;
            }

            return RecursiveFib(n - 1) + RecursiveFib(n - 2);
        }
    }
}
