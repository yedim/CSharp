using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "Hello", "Program", "C#", "Collections", "Threading" };
            foreach(string iter in words)
            {
                if(iter.Length>5)//문자열의 길이가 5이상
                {
                    Console.WriteLine(iter);
                }
            }
            Console.WriteLine("=== Linq1 ===");
            IEnumerable<string> resWords1 = words.Where(x => x.Length > 5);//Func<String,Bool> 매개변수에 함수넣을 수 있음
            foreach(string iter in resWords1)
            {
                Console.WriteLine(iter);
            }
            Console.WriteLine("=== Linq2 ==="); 
            var resWords2 = from iter in words
                            where iter.Length > 5
                            select iter;
            foreach(string iter in resWords2)
            {
                Console.WriteLine(iter);
            }

            Console.WriteLine("=== Linq3 ==="); 
            var resWords3 = words.Where(x => x.Length > 5).Select(x => x.Substring(0, 5));//5글자 이상인 것만
            foreach(string iter in resWords3)
            {
                Console.WriteLine(iter);
            }

            Console.WriteLine("=== Linq4 ===");
            var resWords4 = from iter in words
                            where iter.Length > 5
                            select iter.Substring(0,5);
            foreach (string iter in resWords4)
            {
                Console.WriteLine(iter);
            }

            Console.WriteLine("=== Linq5 ===");
            var resWords5 = words.Where(x => x.Contains("o"));
            foreach (string iter in resWords5)
            {
                Console.WriteLine(iter);
            }

            Console.WriteLine("=== Linq6 ===");
            var resWords6 = from iter in words
                            where iter.Contains("o")
                            select iter;
            foreach (string iter in resWords6)
            {
                Console.WriteLine(iter);
            }

            Console.WriteLine("=== Linq7 ===");
            var resWords7 = words.Where(x => x.Contains("o"))
                .Select(x =>
                {
                    int tmpIdx = x.IndexOf("o");
                    return (x.Substring(0, tmpIdx + 1));//o가 포함된 곳까지 자름

                });
            foreach (string iter in resWords7)
            {
                Console.WriteLine(iter);
            }

            Console.WriteLine("=== Linq8 ===");
            var resWords8 = from iter in words
                            where iter.Contains("o")
                            select iter.Substring(0,iter.IndexOf("o")+1);
            foreach (string iter in resWords8)
            {
                Console.WriteLine(iter);
            }

            int[] numbers = { 35, 10, 27, 31, 23, 30, 40, 74, 81, 56, 45, 93 };

            var resNum1 = numbers.Where(x => x > 30);
            var resNum2 = from num in numbers
                          where num > 30
                          select num;
            PrintNumbers(1, resNum1);
            PrintNumbers(2, resNum2);

            var resNum3 = numbers.Where(num => 10 <num && num<30);
            var resNum4 = from num in numbers
                          where 10 < num && num < 30
                          select num;
            PrintNumbers(3, resNum3);
            PrintNumbers(4, resNum4);

            var resNum5 = numbers.Where((num,idx) => num>10 && idx < 5);
            var resNum6 = numbers.Where((num, idx) => (num > 10 && idx < 5) || (num>50 && idx>=5));
            PrintNumbers(5, resNum5);
            PrintNumbers(6, resNum6);

            var resNum7 = numbers.OrderBy(num => num);
            var resNum8 = from num in numbers
                          orderby num
                          select num;
            PrintNumbers(7, resNum7);
            PrintNumbers(8, resNum8);

            var resNum9 = numbers.OrderBy(num => num);
            var resNum10 = from num in numbers
                          orderby num descending
                          select num;
            PrintNumbers(9, resNum9);
            PrintNumbers(10, resNum10);

            Console.ReadKey();
        }
        public static void PrintNumbers(int aIndex, IEnumerable<int> aNums)
        {
            Console.WriteLine("== Linq Number{0} ===", aIndex);
            foreach(int iter in aNums)
            {
                Console.Write(iter + ". ");
            }
            Console.WriteLine();
        }
    }
}
