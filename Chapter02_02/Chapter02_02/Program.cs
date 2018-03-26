using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02_02
{
    class Program
    {
        public int SumAll(params int[] aNumbers)//가변길이 매개변수
        {
            int i;
            int tmp = 0;
            for(i=0; i<aNumbers.Length;i++)
            {
                tmp += aNumbers[i];
            }
            return (tmp);
        }

        public int SumAll2(int[] aNumbers) 
        {
            int i;
            int tmp = 0;
            for(i=0; i<aNumbers.Length; i++)
            {
                tmp += aNumbers[i];
            }
            return (tmp);
        }

        public void SelectCard(int aNumber, string aShape)
        {
            Console.WriteLine("Shape : {0}, Number : {1}", aShape, aNumber % 13 + 1);
        }

        public void MakeCard(int aNumber,string aShape="Diamond")
        {
            Console.WriteLine("Shape : {0}, Number : {1}", aShape, aNumber % 13 + 1);
        }
        static void Main(string[] args)
        {
            Program tmpC = new Program();
            int total1 = tmpC.SumAll(1,2);//배열 자동생성
            int total2 = tmpC.SumAll(1,2,3,4,5);
            int total3 = tmpC.SumAll(1,2,3,4,5,6,7,8,9,10);

            Console.WriteLine(total1);
            Console.WriteLine(total2);
            Console.WriteLine(total3);

            int[] param4 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int total4 = tmpC.SumAll2(param4);//배열을 넣어야 함.
            Console.WriteLine(total4);

            tmpC.SelectCard(10, "Diamond");
            tmpC.SelectCard(aNumber: 12, aShape: "Diamond");
            tmpC.SelectCard(aShape: "Heart", aNumber: 12);

            tmpC.MakeCard(7);
            tmpC.MakeCard(10, "Heart");

            Console.ReadKey();
        }
    }
}
