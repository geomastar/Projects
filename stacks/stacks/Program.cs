using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            void pushToStack(string word)
            {
                int bottom = 0;
                int top = 0;
                string[] stack = new string[10];
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    stack[top] = word[i].ToString();
                    top++;
                }
                stack[top] = word.Length.ToString();

                foreach(string s in stack)
                {
                    Console.WriteLine(s);
                }
            }

            void pushToStackbutgey(string passString)
            {
                int stringPtr;
                int stackPtr;
                string[] stack = new string[10]; 
                int stringLen = passString.Length;
                if (stringLen == 0)
                {
                    stack[0] = "0";
                }
                else
                {
                    stackPtr = 0;
                    stringPtr = stringLen - 1;
                    for (int i = 1; i <= stringLen; i++)
                    {
                        stack[stackPtr] = passString[stringPtr].ToString();
                        stackPtr++;
                        stringPtr--;
                    }
                    stack[stackPtr] = stringLen.ToString();
                }

                foreach (string s in stack)
                {
                    Console.WriteLine(s);
                }
            }

            pushToStack("silver");
            Console.ReadLine();
            pushToStackbutgey("silver");
            Console.ReadLine();
        }
    }
}
