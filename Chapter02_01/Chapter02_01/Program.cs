using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02_01
{
    class Program
    {
        static void Main(string[] args)
        {
            CMyClass tmpMC1 = new CMyClass();
            Console.WriteLine(tmpMC1.GetName());

            Console.WriteLine(new CMyClass(1).GetName());
            Console.WriteLine(new CMyClass(3, "AAA").GetName());

            int a = 5;
            int b = 5;//ref는 초기화 해야됨.
            tmpMC1.Increase(a);
            tmpMC1.Increase(ref b);

            Console.WriteLine(a);
            Console.WriteLine(b);

            int c;//out은 초기화 안해도 됨
            tmpMC1.MakeValue(out c);
            Console.WriteLine(c);

            Console.ReadKey();
        }
    }
}
