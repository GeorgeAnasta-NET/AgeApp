using AgeApp.Models;
using AgeApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AgeApp.Controllers
{
    public class BallotController : Controller
    {
        private ApplicationDbContext _context;

        public BallotController() {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        public ViewResult Index() {
            var ballots = _context.Ballots.Include(b => b.Genre).ToList();

            return View(ballots);
        }

        public ActionResult Details(long id) {
            var ballot = _context.Ballots.Include(b => b.Genre).SingleOrDefault(b => b.Id == id);

            if (ballot == null) return HttpNotFound();

            return View(ballot);
        }

        //// GET: Ballot/Random
        //public ActionResult Random()
        //{
        //    var ballot = new Ballot() { Name = "Shrek!" };
        //    var voters = new List<Voter> {
        //        new Voter{Name = "Voter1"},
        //        new Voter{Name = "Voter 2 "}
        //    };

        //    var viewModel = new RandomViewModel {
        //        Ballot = ballot,
        //        Voters = voters
        //    };


        //    return View(viewModel);
        //}

        public ActionResult Edit(long Id) {
            return Content("Id = " + Id);
        }

        //public ActionResult Index(int? pageIndex, string sortBy) {
        //    if (!pageIndex.HasValue) {
        //        pageIndex = 1;
        //    }

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(string.Format("pageIndex = {0} & sortBy = {1}", pageIndex, sortBy));
        //}

        //[Route("Ballot/released/{year}/{month:regerx(\\d{4}):range(1, 12}")]
        //public ActionResult ByReleaseDate(int year, int month) {
        //    return Content(year + "/" + month);
        //}
    }
}