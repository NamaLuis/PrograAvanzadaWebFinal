using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.W.Models;

namespace API.W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        private readonly restauranteVerdeContext _context;

        public ProvinciasController(restauranteVerdeContext context)
        {
            _context = context;
        }

        // GET: api/Provincias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provincia>>> GetProvincia()
        {
            return await _context.Provincia.ToListAsync();
        }

        // GET: api/Provincias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Provincia>> GetProvincia(int id)
        {
            var provincia = await _context.Provincia.FindAsync(id);

            if (provincia == null)
            {
                return NotFound();
            }

            return provincia;
        }

        // PUT: api/Provincias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvincia(int id, Provincia provincia)
        {
            if (id != provincia.IdProvincia)
            {
                return BadRequest();
            }

            _context.Entry(provincia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinciaExists(id))
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

        // POST: api/Provincias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Provincia>> PostProvincia(Provincia provincia)
        {
            _context.Provincia.Add(provincia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProvinciaExists(provincia.IdProvincia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProvincia", new { id = provincia.IdProvincia }, provincia);
        }

        // DELETE: api/Provincias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Provincia>> DeleteProvincia(int id)
        {
            var provincia = await _context.Provincia.FindAsync(id);
            if (provincia == null)
            {
                return NotFound();
            }

            _context.Provincia.Remove(provincia);
            await _context.SaveChangesAsync();

            return provincia;
        }

        private bool ProvinciaExists(int id)
        {
            return _context.Provincia.Any(e => e.IdProvincia == id);
        }
    }
}
