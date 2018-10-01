using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Chapter04_03
{
    class Program
    {
        static void Run()
        {
            int i;
            int tmpCount = theCount;
            for(i=0; i<10;i++)
            {
                Console.WriteLine("{0} : {1}", tmpCount,i);
                Thread.Sleep(100);
            }
        }

       
        static void Run2()
        {
            int i;
            Random tmpR = new Random();
            int tmpS = tmpR.Next(9) + 1;
            for(i=0; i<10;i++)
            {
                Console.WriteLine("{0} * {1} = {2}", tmpS, i, tmpS * i);
                Thread.Sleep(100);
            }
        }
        static int theCount;

        static int theValue1 = 0;

        static void Increase1()
        {
            int i;
            for (i = 0; i < 100000; i++)
            {
                theValue1++;
            }
        }

        static int theValue2 = 0;

        static object theObj = new object();

        static void Increase2()
        {
            int i;
            for(i=0; i<100000;i++)
            {
                lock("AAA")
                {
                    theValue2++; //lock은 쓰레드의 행위가 끝날 때까지 다른 쓰레드 접근 불가.1개의 쓰레드만 사용.
                }
            }
        }

        static int theValue3 = 0;

        static void Increase3()
        {
            int i;
            for(i=0; i<100000;i++)
            {
                Monitor.Enter(theObj); //이거는 lock과는 다르게 {}없이 원하는 곳에 코드삽입가능.
                theValue3++;
                Monitor.Exit(theObj);
            }
        }

        static void Main(string[] args)
        {
        //    Thread tmpT1 = new Thread(new ThreadStart((Run)));
        //    tmpT1.Start();

        //    tmpT1.Join();//join이용하면 실행순서 보장할 수 있다.
        //    theCount = 0;

        //    ConsoleKeyInfo tmpCKI;
        //    tmpCKI = Console.ReadKey();

        //    while(tmpCKI.KeyChar!='q')
        //    {
        //        //Thread tmpT2 = new Thread(new ThreadStart((Run)));
        //        Thread tmpT2;
        //        if(tmpCKI.KeyChar=='a')
        //        {
        //            tmpT2 = new Thread(new ThreadStart((Run)));
        //        }
        //        else
        //        {
        //            tmpT2 = new Thread(new ThreadStart((Run2)));
        //        }
        //        tmpT2.Start();
        //        theCount++;
        //        tmpCKI=Console.ReadKey();
        //    }
        //    Console.WriteLine("End");
        //    Console.ReadKey();
            
            int i;
            Thread[] testThread = new Thread[100];
            for (i = 0; i < 100; i++)
            {
                testThread[i] = new Thread(new ThreadStart((Increase1)));
                testThread[i].Start();
            }
            for (i = 0; i < 100; i++)
            {
                testThread[i].Join();//겹칠 수가 있다. 53,53 겹치면 54로만 증가,,
            }
            Console.WriteLine("Value1:{0}", theValue1);

            Thread[] lockThread = new Thread[100];
            for (i = 0; i < 100; i++)
            {
                lockThread[i] = new Thread(new ThreadStart((Increase2)));
                lockThread[i].Start();
            }
            for (i = 0; i < 100;i++)
            {
                lockThread[i].Join();
            }
            Console.WriteLine("Value2:{0}", theValue2);

            lockThread = new Thread[100];

            for (i = 0; i < 100;i++)
            {
                lockThread[i]=new Thread(new ThreadStart((Increase3)));
                lockThread[i].Start();
            }

            for (i = 0; i < 100; i++)
            {
                lockThread[i].Join();
            }
            Console.WriteLine("End");
            Console.ReadKey();
        }

           

    }
}
