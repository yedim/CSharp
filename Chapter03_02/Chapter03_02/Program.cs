using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter03_02
{
    class Program
    {
        static void Main(string[] args)
        {
            CPoint4i tmpP = new CPoint4i();//배열아님 tmp[0]  this[int aIndex] 인덱서
            tmpP.theX = 3;
            Console.WriteLine("x : {0}", tmpP.theX);
            Console.WriteLine("[0] : {0}", tmpP[0]);

            tmpP[1] = 8;
            Console.WriteLine("Y : {0}", tmpP.theY);
            Console.WriteLine("[1] : {0}", tmpP[1]);

            tmpP["Z"] = 36;
            Console.WriteLine("Z : {0}", tmpP.theZ);
            Console.WriteLine("[2] : {0}", tmpP[2]);
            Console.WriteLine("\"Z\" : {0}", tmpP["Z"]);

            Console.WriteLine();
            string[] tmpStrs = { "X", "Y", "Z", "W" };
            foreach(string iter in tmpStrs)
            {
                Console.WriteLine("{0}:{1}", iter,tmpP[iter]);
            }

            List<int> tmpList = new List<int>();

            tmpList.Add(35);
            tmpList.Add(27);
            tmpList.Add(10);

            Console.WriteLine(tmpList[0]);
            Console.WriteLine(tmpList[1]);

            foreach(int iter in tmpList)
            {
                Console.WriteLine(iter);
            }
            tmpList.Sort();

            foreach(int iter in tmpList)
            {
                Console.WriteLine(iter);
            }

            List<string> strList = new List<string>();//가변배열. Java ArrayList =>C# List
            strList.Add("VIPS");
            strList.Add("Ashley");
            strList.Add("Outback");

            strList.Sort();
            foreach(string iter in strList)
            {
                Console.WriteLine(iter);
            }
            if(strList.Contains("VIPS")==true)
            {
                Console.WriteLine("Find!");
            }

            List<List<string>> itemList = new List<List<string>>();//List<string>이 타입
            List<string> itemAttack = new List<string>();
            itemAttack.Add("Sword");
            itemAttack.Add("Axe");
            itemAttack.Add("Spear");
            itemList.Add(itemAttack);

            List<string> itemDefend = new List<string>();
            itemDefend.Add("Shield");
            itemDefend.Add("Armor");
            itemList.Add(itemDefend);

            List<string> itemProtion = new List<string>();
            itemProtion.Add("Healing");
            itemProtion.Add("Flyihng");
            itemProtion.Add("Fog");
            itemProtion.Add("Fast");
            itemList.Add(itemProtion);

            foreach(List<string> iterList in itemList)
            {
                foreach (string iterStr in iterList)
                {
                    Console.Write(iterStr);
                    Console.Write("     ");

                }
                Console.WriteLine();
            }

            Console.WriteLine(itemList[0][1]);
            Console.WriteLine(itemList[1][0]);
            Console.WriteLine(itemList[2][2]);

            SortedList<string, int> tmpSL = new SortedList<string, int>();//sortedlist의 key는 PrimaryKey와 특성이 동일. 자동으로 정렬됨.
            tmpSL.Add("Hong", 89);
            tmpSL.Add("Lee", 85);
            tmpSL.Add("Choi", 75);
            tmpSL.Add("Kim", 92);

            foreach(KeyValuePair<string,int> iter in tmpSL)
            {
                Console.WriteLine("{0} : {1}", iter.Key, iter.Value);
            }
            foreach(string key in tmpSL.Keys)
            {
                Console.WriteLine("{0} : {1}", key, tmpSL[key]);
            }

            tmpSL["Jung"] = 89;//Add
            tmpSL["Hong"] = 95;//Modify

            foreach(string key in tmpSL.Keys)
            {
                Console.WriteLine("{0} : {1}", key, tmpSL[key]);
            }
            tmpSL["Choi"] = 92;//Modify

            Console.WriteLine("===Score List===");

            SortedList<int, List<string>> tmpScores = new SortedList<int, List<string>>();//점수는 int, 이름은 list<string>.각 점수에 대한 가변배열을 만든다.
            foreach(KeyValuePair<string,int> iter in tmpSL)
            {
                string tmpName = iter.Key;
                int tmpScore = iter.Value;

                if (tmpScores.ContainsKey(tmpScore) == true)
                {
                    tmpScores[tmpScore].Add(tmpName);//중복되는 값이 있다면 tmpScores[tmpScore]가 list여서 add하면 바로 list에 추가됨.
                }
                else
                {
                    List<string> tmpArrs = new List<string>();//중복되는 값이 없다면 새로 list생성한다.
                    tmpArrs.Add(tmpName);
                    tmpScores.Add(tmpScore, tmpArrs);
                }
            }

            foreach(int iterScore in tmpScores.Keys.Reverse())
            {
                Console.Write("{0} :", iterScore);
                foreach(string iterName in tmpScores[iterScore])
                {
                    Console.Write("{0} , ", iterName);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
