using System.Collections.Generic;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AgeApp.Models;
using AgeApp.ViewModel;

namespace Vidly.Controllers {
    public class BallotController : Controller {
        private ApplicationDbContext _context;
        public BallotController() {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }
        public ViewResult Index() {

            if (User.IsInRole(RoleName.CanMangeBallots))
                return View("List");
            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanMangeBallots)]
        public ViewResult New() {
            var genres = _context.Genres.ToList();

            var viewModel = new BallotFormViewModel {
                Genres = genres
            };

            return View("BallotForm", viewModel);
        }

        public ActionResult Edit(int id) {
            var ballot = _context.Ballots.SingleOrDefault(c => c.Id == id);

            if (ballot == null)
                return HttpNotFound();

            var viewModel = new BallotFormViewModel(ballot) {
                Genres = _context.Genres.ToList()
            };

            return View("BallotForm", viewModel);
        }


        public ActionResult Details(int id) {
            var movie = _context.Ballots.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
        // GET: Movies/Random
        public ActionResult Random() {
            var ballot = new Ballot() { Name = "Shrek!" };
            var voters = new List<Voter>
            {
                new Voter { Name = "Customer 1" },
                new Voter { Name = "Customer 2" }
            };
            var viewModel = new RandomBallotViewModel {
                Ballot = ballot,
                Voters = voters
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Ballot ballot) {
            if (!ModelState.IsValid)
            {
                var viewModel = new BallotFormViewModel(ballot)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("BallotForm", viewModel);
            }

            if (ballot.Id == 0) {
                ballot.DateAdded = DateTime.Now;
                _context.Ballots.Add(ballot);
            } else {
                var ballotInDb = _context.Ballots.Single(m => m.Id == ballot.Id);
                ballotInDb.Name = ballot.Name;
                ballotInDb.GenreId = ballot.GenreId;
                ballotInDb.NumberInStock = ballot.NumberInStock;
                ballotInDb.ReleaseDate = ballot.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Ballot");
        }
    }
}