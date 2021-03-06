using AgeApp.Dtos;
using AgeApp.Models;
using AutoMapper;
using System;
using System.Data.Entity;
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
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Voters
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Voter, CustomerDto>);

            return Ok(customerDtos);
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
        public IHttpActionResult UpdateCustomer(long id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Voters.SingleOrDefault(c => c.Id == id);

            if (customerInDb is null)
                return NotFound();


            Mapper.Map(customerDto, customerInDb);
            
            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(long id)
        {
            var customerInDb = _context.Voters.SingleOrDefault(c => c.Id == id);

            if (customerInDb is null)
                return NotFound();

            _context.Voters.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
