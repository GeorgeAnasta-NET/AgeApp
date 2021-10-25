using AgeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgeApp.Controllers
{
    public class CustomersController : Controller {
        public ViewResult Index() {
            var customers = GetCustomers();

            return View(customers);
        }

        public ActionResult Details(int id) {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Voter> GetCustomers() {
            return new List<Voter>
            {
                new Voter { Id = 1, Name = "John Smith" },
                new Voter { Id = 2, Name = "Mary Williams" }
            };
        }
    }
} 