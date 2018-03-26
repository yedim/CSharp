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

            Console.ReadKey();
        }
    }
}
