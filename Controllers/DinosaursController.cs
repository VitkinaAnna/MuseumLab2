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
    public class DinosaursController : ControllerBase
    {
        private readonly Version2Lab2Context _context;

        public DinosaursController(Version2Lab2Context context)
        {
            _context = context;
        }

        // GET: api/Dinosaurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dinosaur>>> GetDinosaurs()
        {
          if (_context.Dinosaurs == null)
          {
              return NotFound();
          }
            return await _context.Dinosaurs.ToListAsync();
        }

        // GET: api/Dinosaurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dinosaur>> GetDinosaur(int id)
        {
          if (_context.Dinosaurs == null)
          {
              return NotFound();
          }
            var dinosaur = await _context.Dinosaurs.FindAsync(id);

            if (dinosaur == null)
            {
                return NotFound();
            }

            return dinosaur;
        }

        // PUT: api/Dinosaurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDinosaur(int id, Dinosaur dinosaur)
        {
            if (id != dinosaur.Id)
            {
                return BadRequest();
            }

            _context.Entry(dinosaur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DinosaurExists(id))
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

        // POST: api/Dinosaurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dinosaur>> PostDinosaur(Dinosaur dinosaur)
        {
          if (_context.Dinosaurs == null)
          {
              return Problem("Entity set 'Version2Lab2Context.Dinosaurs'  is null.");
          }
            _context.Dinosaurs.Add(dinosaur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDinosaur", new { id = dinosaur.Id }, dinosaur);
        }

        // DELETE: api/Dinosaurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDinosaur(int id)
        {
            if (_context.Dinosaurs == null)
            {
                return NotFound();
            }
            var dinosaur = await _context.Dinosaurs.FindAsync(id);
            if (dinosaur == null)
            {
                return NotFound();
            }

            _context.Dinosaurs.Remove(dinosaur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DinosaurExists(int id)
        {
            return (_context.Dinosaurs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
