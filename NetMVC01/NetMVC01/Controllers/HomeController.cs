using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetMVC01.Models;

namespace NetMVC01.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            ViewBag.theUsers = CInstance.theUserManager.GetUser();
            ViewBag.bFail = 0;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string aID, string aPW)
        {
            ViewBag.theUsers = CInstance.theUserManager.GetUser();

            CUser resUser;
            int tmpBool = CInstance.theUserManager.CheckUser(aID, aPW, out resUser);
            if(tmpBool==1)
            {
                //로그인 성공
                Session["id"] = aID;
                Session["user"] = resUser;
                return (RedirectToAction("Main"));
            }
            else
            {
                ViewBag.bFail = 1;
            }
            return (View());
        }

        public ActionResult Main()
        {
            if(Session["id"] == null)//로그인안하면 홈화면(index)로
            {
                return (RedirectToAction("Index"));
            }
            CUser tmpUser = (CUser)Session["user"];

            ViewBag.theID = tmpUser.theID;
            ViewBag.theDate = tmpUser.theDate.ToString("yyyy.MM.dd");
            return (View());
        }

        public ActionResult Join()
        {
            ViewBag.bFail = 0;//처음 시작하면 아직 실패가 아니죠
            return (View());
        }

        [HttpPost]
        public ActionResult Join(CUser aUser)
        {
            if(!ModelState.IsValid)
            {
                return (View(aUser));
            }

            int tmpBool;
            tmpBool = CInstance.theUserManager.AddUser(ref aUser);
            if(tmpBool==1)
            {
                return (RedirectToAction("JoinOK", aUser));
            }

            ViewBag.bFail = 1;//성공하면 joinok로 가는데 여기까지 온건 실패
            return (View(aUser));
        }

        public ActionResult JoinOK(CUser aUser)
        {
            ViewBag.theName = aUser.theName;
            ViewBag.theDate = aUser.theDate.ToString("yyyy.MM.dd");
            return View(aUser);
        }
	}
}