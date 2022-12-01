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
    public class Team2Controller : ControllerBase
    {
        private readonly CricketContext _context;

        public Team2Controller(CricketContext context)
        {
            _context = context;
        }

        // GET: api/Team2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team2>>> GetTeam2s()
        {
            return await _context.Team2s.ToListAsync();
        }

        // GET: api/Team2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team2>> GetTeam2(int id)
        {
            var team2 = await _context.Team2s.FindAsync(id);

            if (team2 == null)
            {
                return NotFound();
            }

            return team2;
        }

        // PUT: api/Team2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam2(int id, Team2 team2)
        {
            if (id != team2.Id)
            {
                return BadRequest();
            }

            _context.Entry(team2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Team2Exists(id))
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

        // POST: api/Team2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team2>> PostTeam2(Team2 team2)
        {
            _context.Team2s.Add(team2);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Team2Exists(team2.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTeam2", new { id = team2.Id }, team2);
        }

        // DELETE: api/Team2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam2(int id)
        {
            var team2 = await _context.Team2s.FindAsync(id);
            if (team2 == null)
            {
                return NotFound();
            }

            _context.Team2s.Remove(team2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Team2Exists(int id)
        {
            return _context.Team2s.Any(e => e.Id == id);
        }
    }
}
