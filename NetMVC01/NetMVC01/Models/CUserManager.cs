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

            TUser3513 tmpUser = new TUser3513();
            tmpUser.theID = aUser.theID;
            tmpUser.thePW = aUser.thePW;
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

        public int CheckUser(string aID, string aPW)
        {
            //foreach(CUser iter in theUsers)
            //{
            //    if(iter.theName.Equals(aID)==true && iter.thePW.Equals(aPW) == true)
            //    {
            //        return (1);
            //    }
            //}
            return (0);
        }
    }
}