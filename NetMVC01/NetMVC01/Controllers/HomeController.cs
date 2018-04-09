﻿using System;
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
            return View();
        }

        public ActionResult Join()
        {
            return (View());
        }

        [HttpPost]
        public ActionResult Join(CUser aUser)
        {
            return (View(aUser));
        }
	}
}