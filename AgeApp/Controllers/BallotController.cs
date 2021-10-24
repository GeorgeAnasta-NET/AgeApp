using AgeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgeApp.Controllers
{
    public class BallotController : Controller
    {
        // GET: Ballot/Random
        public ActionResult Random()
        {
            var ballot = new Ballot() { Name = "Shrek!" };

            return View(ballot);
        }
    }
}