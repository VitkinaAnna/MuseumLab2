using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab2MuseumVersion2.Models;

namespace Lab2MuseumVersion2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExhibitionsController : ControllerBase
    {
        private readonly Version2Lab2Context _context;

        public ExhibitionsController(Version2Lab2Context context)
        {
            _context = context;
        }

        // GET: api/Exhibitions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exhibition>>> GetExhibitions()
        {
          if (_context.Exhibitions == null)
          {
              return NotFound();
          }
            return await _context.Exhibitions.ToListAsync();
        }

        // GET: api/Exhibitions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exhibition>> GetExhibition(int id)
        {
          if (_context.Exhibitions == null)
          {
              return NotFound();
          }
            var exhibition = await _context.Exhibitions.FindAsync(id);

            if (exhibition == null)
            {
                return NotFound();
            }

            return exhibition;
        }

        // PUT: api/Exhibitions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExhibition(int id, Exhibition exhibition)
        {
            if (id != exhibition.Id)
            {
                return BadRequest();
            }

            _context.Entry(exhibition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExhibitionExists(id))
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

        // POST: api/Exhibitions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exhibition>> PostExhibition(Exhibition exhibition)
        {
          if (_context.Exhibitions == null)
          {
              return Problem("Entity set 'Version2Lab2Context.Exhibitions'  is null.");
          }
            _context.Exhibitions.Add(exhibition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExhibition", new { id = exhibition.Id }, exhibition);
        }

        // DELETE: api/Exhibitions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExhibition(int id)
        {
            if (_context.Exhibitions == null)
            {
                return NotFound();
            }
            var exhibition = await _context.Exhibitions.FindAsync(id);
            if (exhibition == null)
            {
                return NotFound();
            }

            _context.Exhibitions.Remove(exhibition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExhibitionExists(int id)
        {
            return (_context.Exhibitions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
