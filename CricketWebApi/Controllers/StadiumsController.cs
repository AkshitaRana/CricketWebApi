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
    public class StadiumsController : ControllerBase
    {
        private readonly CricketContext _context;

        public StadiumsController(CricketContext context)
        {
            _context = context;
        }

        // GET: api/Stadia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stadium>>> GetStadia()
        {
            return await _context.Stadia.ToListAsync();
        }

        // GET: api/Stadia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stadium>> GetStadium(int id)
        {
            var stadium = await _context.Stadia.FindAsync(id);

            if (stadium == null)
            {
                return NotFound();
            }

            return stadium;
        }

        // PUT: api/Stadia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStadium(int id, Stadium stadium)
        {
            if (id != stadium.Id)
            {
                return BadRequest();
            }

            _context.Entry(stadium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StadiumExists(id))
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

        // POST: api/Stadia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stadium>> PostStadium(Stadium stadium)
        {
            _context.Stadia.Add(stadium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StadiumExists(stadium.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStadium", new { id = stadium.Id }, stadium);
        }

        // DELETE: api/Stadia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStadium(int id)
        {
            var stadium = await _context.Stadia.FindAsync(id);
            if (stadium == null)
            {
                return NotFound();
            }

            _context.Stadia.Remove(stadium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StadiumExists(int id)
        {
            return _context.Stadia.Any(e => e.Id == id);
        }
    }
}
