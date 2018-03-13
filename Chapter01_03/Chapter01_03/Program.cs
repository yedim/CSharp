using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter01_03
{
    class Program
    {
        class CMyInt
        {
            public int theValue;
            //public override string ToString()
            //{
            //    Console.WriteLine("-");
            //    return (theValue.ToString());
            //}
        }
        static void Main(string[] args)
        {
            int a = 12345;
            int b = 1;
            Console.WriteLine("Before");
            Console.WriteLine("a : {0}", a);
            Console.WriteLine("b : {0}", b);

            a = 98765;
            Console.WriteLine("After");
            Console.WriteLine("a : {0}", a);
            Console.WriteLine("b : {0}", b);

            object c = 12345;//boxing, 참조타입
            object d = c;
            Console.WriteLine("Before");
            Console.WriteLine("c : {0}", c);
            Console.WriteLine("d : {0}", d);

            c = 98765;//boxing
            Console.WriteLine("After");
            Console.WriteLine("c : {0}", c);
            Console.WriteLine("d : {0}", d);

            CMyInt e = new CMyInt();//참조형이므로 값이 같이 바뀜.
            e.theValue = 12345;
            CMyInt f = e;
            Console.WriteLine("Before");
            Console.WriteLine("e : {0}", e);//ToString호출
            Console.WriteLine("f : {0}", f);

            e.theValue = 98765;//boxing
            Console.WriteLine("After");
            Console.WriteLine("e : {0}", e);
            Console.WriteLine("f : {0}", f);

            Console.ReadKey();
        }
    }
}
