using AgeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgeApp.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/customers
        public IEnumerable<Voter> GetCustomers()
        {
            return _context.Voters.ToList();
        }
        //GET /api/customers/1
        public Voter GetCustomer(long id)
        {
            var customer = _context.Voters.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            

            return customer;
        }
        //PUT /api/customers
        [HttpPost]
        public Voter CreateCustomer(Voter customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Voters.Add(customer);
            _context.SaveChanges();

            return customer;
        }
        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(long id, Voter customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Voters.SingleOrDefault(c => c.Id == id);

            if (customerInDb is null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customer.Name;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();

        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(long id)
        {
            var customerInDb = _context.Voters.SingleOrDefault(c => c.Id == id);

            if (customerInDb is null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Voters.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
