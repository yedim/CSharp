using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;

namespace NetMVC01.Models
{
    public class CUserManager
    {
//        private List<CUser> theUsers;

        LUserDataContext theUserContext;

        public CUserManager()
        {
//            theUsers = new List<CUser>();
            theUserContext = new LUserDataContext();
        }

        public int AddUser(ref CUser aUser)
        {
 /*           CUser tmpUser=new CUser();
            tmpUser.theUniqueID=0;
            tmpUser.theID=aUser.theID;
            tmpUser.thePW = aUser.thePW;
            tmpUser.theName = aUser.theName;
            tmpUser.theEMail = aUser.theEMail;
            tmpUser.theDate = DateTime.Now;
            theUsers.Add(tmpUser);
*/
            string tmpID = aUser.theID;
            int tmpCount = theUserContext.TUser3513.Where(x => x.theID == tmpID).Count();
            if(tmpCount>0)
            {
                return (0);
            }

            TUser3513 tmpUser = new TUser3513();
            tmpUser.theID = aUser.theID;
            tmpUser.thePW = aUser.thePW;
            tmpUser.theName = aUser.theName;
            tmpUser.theEMail = aUser.theEMail;
            tmpUser.bSubscription = aUser.bSubscription ? 1 : 0;
            tmpUser.theDate = DateTime.Now;

            theUserContext.TUser3513.InsertOnSubmit(tmpUser);//데이터 추가
            theUserContext.SubmitChanges();//동적으로 쿼리 생성

            aUser.theDate = DateTime.Now;
            return (1);
        }

        public List<CUser> GetUser()
        {
            IQueryable<TUser3513> tmpR = theUserContext.TUser3513.OrderByDescending(x => x.theID);//id순서대로 오름차순 정렬해서 가져옴

            List<TUser3513> tmpL = tmpR.ToList<TUser3513>();//가변배열
            List<CUser> resUsers = new List<CUser>();

            foreach(TUser3513 iter in tmpL)//모든 값을 가져와서
            {
                CUser tmpUser = new CUser();//대입
                tmpUser.theUniqueID = iter.theUniqueID;
                tmpUser.theID = iter.theID;
                tmpUser.thePW = iter.thePW;
                tmpUser.theName = iter.theName;
                tmpUser.theEMail = iter.theEMail;
                tmpUser.bSubscription = iter.bSubscription == 1 ? true : false;
                tmpUser.theDate = iter.theDate;
                resUsers.Add(tmpUser);
            }
            return (resUsers);
        }

        public int CheckUser(string aID, string aPW, out CUser aUser)
        {
            //foreach(CUser iter in theUsers)
            //{
            //    if(iter.theName.Equals(aID)==true && iter.thePW.Equals(aPW) == true)
            //    {
            //        return (1);
            //    }
            //}

            Table<TUser3513> users = theUserContext.GetTable<TUser3513>();
            IQueryable<TUser3513> tmpQ = from iter in users
                                         where iter.theID == aID && iter.thePW == aPW
                                         select iter;

            if(tmpQ.Count()>0)
            {
                List<TUser3513> tmpUser = tmpQ.Take(1).ToList();//take는 데이터 하나 가져옴. 그래서 0만 유효함
                aUser = new CUser();
                aUser.theID = tmpUser[0].theID;
                aUser.thePW = tmpUser[0].thePW;
                aUser.theName = tmpUser[0].theName;
                aUser.theEMail = tmpUser[0].theEMail;
                aUser.bSubscription = tmpUser[0].bSubscription == 1 ? true : false;
                aUser.theDate = tmpUser[0].theDate;
                return (1);
            }
            aUser = new CUser();
            return (0);
        }
    }
}