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
    public class BallotsController : ApiController
    {
        private ApplicationDbContext _context;

        public BallotsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<BallotDto> GetBallots()
        {
            return _context.Ballots.ToList().Select(Mapper.Map<Ballot, BallotDto>);
        }

        public IHttpActionResult GetBallot(int id)
        {
            var ballot = _context.Ballots.SingleOrDefault(c => c.Id == id);

            if (ballot == null)
                return NotFound();

            return Ok(Mapper.Map<Ballot, BallotDto>(ballot));
        }

        [HttpPost]
        public IHttpActionResult CreateBallot(BallotDto ballotDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ballot = Mapper.Map<BallotDto, Ballot>(ballotDto);
            _context.Ballots.Add(ballot);
            _context.SaveChanges();

            ballotDto.Id = ballot.Id;
            return Created(new Uri(Request.RequestUri + "/" + ballot.Id), ballotDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateBallot (int id, BallotDto ballotDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ballotInDb = _context.Ballots.SingleOrDefault(c => c.Id == id);

            if (ballotInDb == null)
                return NotFound();

            Mapper.Map(ballotDto, ballotInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteBallot (int id)
        {
            var ballotInDb = _context.Ballots.SingleOrDefault(c => c.Id == id);

            if (ballotInDb == null)
                return NotFound();

            _context.Ballots.Remove(ballotInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
