using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02_02
{
    class CLGPhone :CSmartPhone
    {
       public CLGPhone()
       {

       }

       public override string GetMarket()
       {
           string parentMarket = base.GetMarket();//부모의 함수 가져오기
           return (parentMarket + ", U+ Market");
       }

       public int GetButtonCount()
       {
           return (2);
       }
    }


}

