using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace Chapter03_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[2];
            numbers[0] = 10;
            numbers[1] = 15;
            Console.WriteLine(numbers[0]);
            Console.WriteLine(numbers[1]);

            int[] nums = new int[] { 2, 3, 5, 8, 13 };
            Console.WriteLine(nums[0]);
            Console.WriteLine(nums[3]);

            int i;
            Console.WriteLine();
            Console.Write("Nums : ");
            for (i = 0; i < nums.Length; i++)
            {
                Console.Write("{0}, ", nums[i]);//배열은 index쓸 수 있으므로 자료의 범위 확장 
            }

            int[] num2s = { 3, 1, 4, 1, 5, 9, 2 };
            Console.WriteLine();
            Console.Write("num2s : ");
            for (i = 0; i < num2s.Length;i++ )
            {
                Console.Write("{0}, ", num2s[i]);
            }
            Console.WriteLine();
            Console.Write("num2s : ");
            foreach(int iter in num2s)
            {
                Console.Write("{0}, ", iter);
            }

            String[] tmpStrs = { "C++", "C#", "Java", "Swift" };
            Console.WriteLine();
            Console.Write("tmpStrs : ");
            foreach(String iter in tmpStrs)
            {
                Console.Write("{0}, ", iter);
            }

            String[,] tmpStrLists = { { "Apple", "Banana", "Lemon" }, { "Pizza", "Pasta", "Risoto" } };
            Console.WriteLine();
            Console.WriteLine(tmpStrLists[0, 1]);
            Console.WriteLine(tmpStrLists[1, 2]);

            int j;
            
            for (i = 0; i < tmpStrLists.GetLength(0);i++ )
            {
                for(j=0; j<tmpStrLists.GetLength(1); j++)
                {
                    Console.WriteLine("{0}, ", tmpStrLists[i, j]);
                }
                Console.WriteLine();
            }

            foreach(String iter in tmpStrLists)
            {
                Console.WriteLine("{0}, ", iter);
            }

            ArrayList tmpAL = new ArrayList();
            tmpAL.Add(10);
            tmpAL.Add("AAA");
            tmpAL.Add(20);
            tmpAL.Add("BBB");
            tmpAL.Add(30);
            Console.WriteLine(tmpAL[0]);
            Console.WriteLine(tmpAL[3]);

            Console.WriteLine();
            for (i = 0; i < tmpAL.Count; i++ )
            {
                Console.Write("{0}, ", tmpAL[i]);
            }
            Console.WriteLine();
            foreach(Object iter in tmpAL)
            {
                Console.Write("{0}, ", iter);
            }

            int sum = 0;
            foreach(Object iter in tmpAL)
            {
                if(iter is int)
                {
                    int tmpValue = (int)iter;
                    sum += tmpValue;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Sum : {0}", sum);
            Console.ReadKey();
        }
    }
}
