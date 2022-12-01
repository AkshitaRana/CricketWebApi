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
    public class UmpiresController : ControllerBase
    {
        private readonly CricketContext _context;

        public UmpiresController(CricketContext context)
        {
            _context = context;
        }

        // GET: api/Umpires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Umpire>>> GetUmpires()
        {
            return await _context.Umpires.ToListAsync();
        }

        // GET: api/Umpires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Umpire>> GetUmpire(int id)
        {
            var umpire = await _context.Umpires.FindAsync(id);

            if (umpire == null)
            {
                return NotFound();
            }

            return umpire;
        }

        // PUT: api/Umpires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUmpire(int id, Umpire umpire)
        {
            if (id != umpire.Id)
            {
                return BadRequest();
            }

            _context.Entry(umpire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UmpireExists(id))
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

        // POST: api/Umpires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Umpire>> PostUmpire(Umpire umpire)
        {
            _context.Umpires.Add(umpire);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UmpireExists(umpire.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUmpire", new { id = umpire.Id }, umpire);
        }

        // DELETE: api/Umpires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUmpire(int id)
        {
            var umpire = await _context.Umpires.FindAsync(id);
            if (umpire == null)
            {
                return NotFound();
            }

            _context.Umpires.Remove(umpire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UmpireExists(int id)
        {
            return _context.Umpires.Any(e => e.Id == id);
        }
    }
}
