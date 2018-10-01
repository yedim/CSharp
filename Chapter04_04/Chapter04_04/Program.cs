using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
namespace Chapter04_04
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Input File Name : ");
            String fileName = Console.ReadLine(); //scanf처럼

            Console.WriteLine("Load : {0}", fileName);

 /*
           FileStream tmpFS = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter tmpSW = new StreamWriter(tmpFS); //Console 쓰듯이 txt 처럼 쓴다.

            tmpSW.Write((long)65);
            tmpSW.WriteLine("ABCDEF");
            tmpSW.WriteLine("Text Writer");
            tmpSW.WriteLine("Hello C#");

            tmpSW.Close();
            tmpFS.Close();

            Console.Write("Load File Name : ");
            String loadName = Console.ReadLine();
            Console.WriteLine("Load : {0}", loadName);

            StreamReader tmpSR = new StreamReader(new FileStream(loadName, FileMode.Open));

            while(tmpSR.EndOfStream == false)
            {
                Console.WriteLine(tmpSR.ReadLine());
            }
            tmpSR.Close();
*/


 /*         FileStream tmpFS = new FileStream(fileName, FileMode.OpenOrCreate);

            BinaryWriter tmpBW = new BinaryWriter(tmpFS);

            tmpBW.Write((long)65);
            tmpBW.Write("ABCDEF");

            tmpBW.Close();
            tmpFS.Close();

            Console.Write("Load File Name : ");
            String loadName = Console.ReadLine();
            Console.WriteLine("Load : {0}", loadName);

            BinaryReader tmpBR = new BinaryReader(new FileStream(loadName, FileMode.Open));

            //쓴 순서 그대로 읽어와야대 (2줄이면 편하게 코딩! 그러나 C#만 사용가능,,)
            long numL = tmpBR.ReadInt64();
            string strL = tmpBR.ReadString();

            tmpBR.Close();

            Console.WriteLine("N : {0}", numL);
            Console.WriteLine("S : {0}", strL);
*/


/*            long tmpL = 65;

            String tmpSL = "ABC";
            long strSize = Encoding.UTF8.GetByteCount(tmpSL);
            Console.WriteLine(strSize);
            byte[] strBytes = Encoding.UTF8.GetBytes(tmpSL);
            byte[] sizeBytes = BitConverter.GetBytes(strSize);//6

            FileStream tmpFS = new FileStream(fileName, FileMode.OpenOrCreate);

            byte[] byteL = BitConverter.GetBytes(tmpL);
            tmpFS.Write(byteL, 0, sizeof(long));//0-8

            tmpFS.Write(sizeBytes, 0, sizeof(long));
            tmpFS.Write(strBytes, 0, (int)strSize);
            tmpFS.Close();
*/

            FileStream tmpFS = new FileStream(fileName, FileMode.OpenOrCreate);
           
            //A읽어오기
            byte[] byteR = new byte[sizeof(long)];
            tmpFS.Read(byteR, 0, sizeof(long));
            long tmpR = BitConverter.ToInt64(byteR, 0);

            //6읽어오기
            byte[] byteS = new byte[sizeof(long)];
            tmpFS.Read(byteS, 0, sizeof(long));
            long tmpSize = BitConverter.ToInt64(byteS, 0);//size 6

            //ABCDEF읽어오기
            byte[] byteStr = new byte[tmpSize];
            tmpFS.Read(byteStr, 0, (int)tmpSize);
            String tmpStr = Encoding.UTF8.GetString(byteStr);

            tmpFS.Close();

            Console.WriteLine("N : {0}", tmpR);//A
            Console.WriteLine("S : {0}", tmpStr);//ABCDEF

            Console.ReadKey();
        }
    }
}
