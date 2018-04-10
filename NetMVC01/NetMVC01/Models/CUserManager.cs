using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetMVC01.Models
{
    public class CUserManager
    {
        private List<CUser> theUsers;

        public CUserManager()
        {
            theUsers = new List<CUser>();
        }

        public int AddUser(ref CUser aUser)
        {
            CUser tmpUser=new CUser();
            tmpUser.theUniqueID=0;
            tmpUser.theID=aUser.theID;
            tmpUser.thePW = aUser.thePW;
            tmpUser.theName = aUser.theName;
            tmpUser.theEMail = aUser.theEMail;
            tmpUser.theDate = DateTime.Now;
            theUsers.Add(tmpUser);

            aUser.theDate = DateTime.Now;
            return (1);
        }

        public List<CUser> GetUser()
        {
            return (theUsers);
        }

        public int CheckUser(string aID, string aPW)
        {
            foreach(CUser iter in theUsers)
            {
                if(iter.theName.Equals(aID)==true && iter.thePW.Equals(aPW) == true)
                {
                    return (1);
                }
            }
            return (0);
        }
    }
}