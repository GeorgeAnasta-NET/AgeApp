using AgeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AgeApp.ViewModel;

namespace AgeApp.Controllers
{
    public class CustomersController : Controller {
        private ApplicationDbContext _context;

        public CustomersController() {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        public ActionResult New() {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }
        
        [HttpPost]
        public ActionResult Save(Voter voter) {

            if(voter.Id == 0)
                _context.Voters.Add(voter);
            else {
                var voterInDb = _context.Voters.Single(c => c.Id == voter.Id);

                voterInDb.Name = voter.Name;
                voterInDb.BirthDate = voter.BirthDate;
                voterInDb.MembershipTypeId = voter.MembershipTypeId;
                voterInDb.IsSubscribedToNewsLetter = voter.IsSubscribedToNewsLetter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ViewResult Index() 
        {
            var voters = _context.Voters.Include(c => c.MembershipType).ToList();

            return View(voters);
        }

        public ActionResult Details(int id) 
        {
            var customer = _context.Voters.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(long id) {
            var voter = _context.Voters.SingleOrDefault(c => c.Id == id);

            if (voter == null) return HttpNotFound();

            var viewModel = new CustomerFormViewModel {
                Voter = voter,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
} 