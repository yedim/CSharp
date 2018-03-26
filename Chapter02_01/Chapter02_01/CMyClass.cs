using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02_01
{
    class CMyClass
    {
        public int theStudentCount;
        public string theName;
        public int theGrade;

        public CMyClass()
        {
            theStudentCount = 20;
            theName = "NoName";
            theGrade = 0;
        }
        public CMyClass(int aGrade)
        {
            theStudentCount = 20;
            theName = "NoName";
            theGrade = aGrade;
        }
        public CMyClass(int aGrade, string aName) : this()
        {
            theName = aName;
            theGrade = aGrade;
        }
        public string GetName()
        {
            string res = string.Format("{0}학년 {1}, {2}명", theGrade, theName, theStudentCount);
            return (res);
        }
        public void Increase(int aValue)
        {
            aValue++;
        }
        public void Increase(ref int aValue)
        {
            aValue++;
        }
        public void MakeValue(out int aValue)
        {
            aValue = 19; //매개변수 할당하지 않으면 에러
        }
    }
}
