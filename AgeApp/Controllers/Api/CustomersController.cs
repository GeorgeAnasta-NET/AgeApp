using AgeApp.Dtos;
using AgeApp.Models;
using AutoMapper;
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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Voters.ToList().Select(Mapper.Map<Voter, CustomerDto>);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(long id)
        {
            var customer = _context.Voters.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();
            
            return Ok(Mapper.Map< Voter, CustomerDto>(customer));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Voter>(customerDto);
            _context.Voters.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id.ToString()), customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(long id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Voters.SingleOrDefault(c => c.Id == id);

            if (customerInDb is null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            Mapper.Map(customerDto, customerInDb);
            
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
