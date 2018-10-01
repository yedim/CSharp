using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04_02
{
    class Program
    {
        public delegate int calculate(int a, int b); //calculate는 타입처럼 간주.

        public static int Plus(int a, int b) // 함수에 주소값이 있는듯
        {
            Console.WriteLine("{0}+{1}={2}", a, b, a + b);
            return (a + b);
        }

        public static int Minus(int a, int b)
        {
            Console.WriteLine("{0}-{1}={2}", a, b, a - b);
            return (a - b);
        }

        public static int Mutiply(int a, int b)
        {
            Console.WriteLine("{0}*{1}={2}", a, b, a * b);
            return (a * b);
        }

        public static int Divide(int a, int b)
        {
            Console.WriteLine("{0}/{1}={2}", a, b, a / b);
            return (a / b);
        }

        public calculate DelegateOper;
        public event calculate EventOper;

        static void Main(string[] args)
        {
            calculate cal1;
            cal1 = new calculate(Plus);
            int res1 = cal1(3, 5);
            Console.WriteLine("return : {0}", res1);

            calculate cal2;
            cal2 = new calculate(Mutiply);
            int res2 = cal2(4, 5);
            Console.WriteLine("return : {0}", res2);

            cal1 = new calculate(Divide);
            int res3 = cal1(10, 5);//다형성
            Console.WriteLine("return : {0}", res3);

            calculate tmpOperation;
            tmpOperation = new calculate(Plus);
            tmpOperation += new calculate(Minus);

            tmpOperation(8, 9);

            tmpOperation += new calculate(Mutiply);
            tmpOperation += new calculate(Divide);

            tmpOperation(3, 2);

            Console.WriteLine("Remove");
            tmpOperation -= new calculate(Minus);
            tmpOperation(7, 3);

            tmpOperation += delegate(int a, int b)
            {
                Console.WriteLine("{0}%{1}={2}", a, b, a % b);
                return (a % b);
            };
            tmpOperation(4, 3);

            Program tmpPrg = new Program();

            tmpPrg.DelegateOper = new calculate(Plus);
            tmpPrg.DelegateOper += new calculate(Mutiply);
            tmpPrg.DelegateOper(2, 3);

            tmpPrg.EventOper = new calculate(Minus);
            tmpPrg.EventOper += new calculate(Divide);
            tmpPrg.EventOper(4, 5);


            List<string> tmpStrs = new List<string>();
            tmpStrs.Add("flower");
            tmpStrs.Add("leaf");
            tmpStrs.Add("tree");

            tmpStrs.Sort(delegate(string a, string b) //익명함수
            {
                return (b.CompareTo(a));
            });
            Console.WriteLine("DES"); //내림차순
            foreach(string iter in tmpStrs)
            {
                Console.WriteLine(iter);
            }

            List<int> tmpInts = new List<int>();
            tmpInts.Add(51);
            tmpInts.Add(15);
            tmpInts.Add(27);
            tmpInts.Add(41);
            tmpInts.Add(32);

            Console.WriteLine("ASC");
            tmpInts.Sort(delegate(int a, int b)
            {
                return (a.CompareTo(b));
            });

            foreach (int iter in tmpInts)
            {
                Console.WriteLine(iter);
            }

            tmpInts.Sort((int a, int b) => b.CompareTo(a));//람다식

            Console.WriteLine("DES");
            foreach (int iter in tmpInts)
            {
                Console.WriteLine(iter);
            }

            calculate AddFunc = (a, b) => a + b;
            calculate MinusFunc = (a, b) => a - b;

            Console.WriteLine("{0}+{1}={2}", 5, 3, AddFunc(5, 3));
            Console.WriteLine("{0}-{1}={2}", 5, 3, MinusFunc(5, 3));
          
            Func<int,int,int> MulFunc = (a, b) => a * b;
            Func<string,string,string> Concat= (a, b) => a + b;

            Console.WriteLine("{0}+{1}={2}", 5, 3, AddFunc(5, 3));
            Console.WriteLine("{0}-{1}={2}", 5, 3, Concat("5", "3"));

            int resInt = 0;
            String resStr = "0";
            Action<int, int> CallAdd = (a, b) => resInt = a + b;
            Action<string,string> CallStr = (a, b) => resStr = a + b;
            CallAdd(7, 8);
            CallStr("7", "8");

            Console.ReadKey();
        }

    }
}
