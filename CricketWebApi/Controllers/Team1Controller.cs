using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CricketWebApi.Data;
using CricketWebApi.Models;

namespace CricketWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Team1Controller : ControllerBase
    {
        private readonly CricketContext _context;

        public Team1Controller(CricketContext context)
        {
            _context = context;
        }

        // GET: api/Team1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team1>>> GetTeam1s()
        {
            return await _context.Team1s.ToListAsync();
        }

        // GET: api/Team1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team1>> GetTeam1(int id)
        {
            var team1 = await _context.Team1s.FindAsync(id);

            if (team1 == null)
            {
                return NotFound();
            }

            return team1;
        }

        // PUT: api/Team1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam1(int id, Team1 team1)
        {
            if (id != team1.Id)
            {
                return BadRequest();
            }

            _context.Entry(team1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Team1Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Team1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team1>> PostTeam1(Team1 team1)
        {
            _context.Team1s.Add(team1);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Team1Exists(team1.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTeam1", new { id = team1.Id }, team1);
        }

        // DELETE: api/Team1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam1(int id)
        {
            var team1 = await _context.Team1s.FindAsync(id);
            if (team1 == null)
            {
                return NotFound();
            }

            _context.Team1s.Remove(team1);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Team1Exists(int id)
        {
            return _context.Team1s.Any(e => e.Id == id);
        }
    }
}
