using AgeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ViewResult Index() 
        {
            var customers = _context.Voters.ToList();

            return View(customers);
        }

        public ActionResult Details(int id) {
            var customer = _context.Voters.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
} 