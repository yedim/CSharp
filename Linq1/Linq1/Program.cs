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

            var resNum11 = numbers.OrderBy(num => (num % 10) * 10 + num / 10);
            var resNum12 = from num in numbers
                           orderby (num%10)*10+num/10
                           select num;

            var resNum13 = numbers.OrderBy(num => num / 10);
            var resNum14 = from num in numbers
                           orderby num / 10
                           select num;

            PrintNumbers(13, resNum13);
            PrintNumbers(14, resNum14);

            List<CBook> books = new List<CBook>();
            books.Add(new CBook() { Title = "Java", Author = "Choi", Publisher = "Mirim", Price = 10000 });
            books.Add(new CBook() { Title = "PHP", Author = "Ham", Publisher = "Mirim", Price = 10000 });
            books.Add(new CBook() { Title = "Android", Author = "Ham", Publisher = "Mirim", Price = 10000 });
            books.Add(new CBook() { Title = "swift", Author = "Jung", Publisher = "Mirim", Price = 10000 });
            books.Add(new CBook() { Title = "C#", Author = "Jung", Publisher = "Mirim", Price = 10000 });

            var resBooks1 = books.OrderBy(x => x.Price);
            var resBooks2 = from book in books
                            orderby book.Price
                            select book;
            Console.WriteLine("======");
            Console.WriteLine("resBook1");
            foreach(CBook iter in resBooks1)
            {
                Console.WriteLine("{0} : {1} : {2}", iter.Title, iter.Author, iter.Price);
            }
            Console.WriteLine("resBook2");
            foreach(CBook iter in resBooks2)
            {
                Console.WriteLine("{0} : {1} : {2}", iter.Title, iter.Author, iter.Price);
            }


            var resBooks3 = books.OrderBy(x => x.Price);
            var resBooks4 = from book in books
                            orderby book.Price
                            select book;
            Console.WriteLine("resBooks3");
            foreach (CBook iter in resBooks3)
            {
                Console.WriteLine("{0,8} : {1,5} : {2,6}", iter.Title, iter.Author, iter.Price);
            }
            Console.WriteLine("resBooks4");
            foreach (CBook iter in resBooks4)
            {
                Console.WriteLine("{0,8} : {1,5} : {2,6}", iter.Title, iter.Author, iter.Price);
            }

            var resBooks5 = books.Where(x => x.Price<23000).Select(x=>new {Title=x.Title,Price = x.Price});
            var resBooks6 = from book in books
                            orderby book.Price<23000
                            select book;
            Console.WriteLine("resBooks5");
            foreach (var iter in resBooks5)
            {
                Console.WriteLine("{0,8} : {1,6}", iter.Title, iter.Price);
            }
            Console.WriteLine("resBooks6");
            foreach (var iter in resBooks6)
            {
                Console.WriteLine("{0,8} : {1,6}", iter.Title, iter.Price);
            }

            var resBooks7 = books.Where(x => x.Price < 23000).Select(x => new { Title = x.Title, Price = x.Price });
            var resBooks8 = from book in books
                            orderby book.Price < 20000
                            select book;
            Console.WriteLine("resBooks7");
            foreach (var iter in resBooks7)
            {
                Console.WriteLine("{0,8} : {1,6}", iter.Title, iter.Price);
            }
            Console.WriteLine("resBooks8");
            foreach (var iter in resBooks8)
            {
                Console.WriteLine("{0,8} : {1,6}", iter.Title, iter.Price);
            }

            var resBooks9 = books
                .Where(x=> x.Author.StartsWith("H"))
                .OrderBy(x => x.Price)
                .Select(x => x.Title);

            var resBooks10 = from book in books
                             where book.Author.StartsWith("H")
                             orderby book.Price
                             select book.Title;

            Console.WriteLine("resBooks9");
            foreach(var iter in resBooks9)
            {
                Console.WriteLine("{0,8}", iter);
            }

            Console.WriteLine("resBooks10");
            foreach (var iter in resBooks10)
            {
                Console.WriteLine("{0,8}", iter);
            }

            var resBooks11 = books
                .Where(x => x.Publisher == "Mirim" && x.Author.Contains("J"))
                .Select(x => new { x.Title, x.Price });

            var resBooks12 = from book in books
                             where book.Publisher == "Mirim" && book.Author.Contains("J")
                             select new { book.Title, book.Price };

            Console.WriteLine("resBooks11");
            foreach(var iter in resBooks11)
            {
                Console.WriteLine("{0,8} : {1,6}", iter.Title, iter.Price);
            }
            Console.WriteLine("{0,8} : {1,6}", iter.Title, iter.Price);

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
