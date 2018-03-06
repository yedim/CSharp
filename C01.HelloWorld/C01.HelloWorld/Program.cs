using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World");
           // Console.ReadKey();

            int tmpX;
            int tmpY;
            tmpX = 7;
            tmpY = 8;

            Console.WriteLine("%d + %d = %d", tmpX, tmpY, tmpX + tmpY);
            Console.WriteLine("{0} + {1} + = {2}", tmpX, tmpY, tmpX + tmpY);//{0},{1},{2} 객체
            Console.WriteLine("{0} + {1} + = {2} ({0}, {1})", tmpX, tmpY, tmpX + tmpY);
            Console.WriteLine("{0} + {1} + = {2}", tmpX.ToString(), tmpY.ToString(), tmpX.ToString() + tmpY.ToString());
            Console.WriteLine("{0} + {1} + = {2}", tmpX.ToString(), tmpY.ToString(), (tmpX+ tmpY).ToString());

            string tmpName = "Class"; //string과 String은 동일.  C#의 string, System.String. 
            String tmpLang = "C#";

            Console.WriteLine("{0} : {1}", tmpName, tmpLang); 

            Console.Write("{0}", tmpName + " : " + tmpLang); 

            Console.ReadKey();

        }
    }
}

//C#은 Integer없고 int만 있다. 컴파일러가 int를 값타입과 참조타입 유연하게 두개 다 사용.
