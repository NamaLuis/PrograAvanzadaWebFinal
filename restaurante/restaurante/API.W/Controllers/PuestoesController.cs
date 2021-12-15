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
    public class PuestoesController : ControllerBase
    {
        private readonly restauranteVerdeContext _context;

        public PuestoesController(restauranteVerdeContext context)
        {
            _context = context;
        }

        // GET: api/Puestoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Puesto>>> GetPuesto()
        {
            return await _context.Puesto.ToListAsync();
        }

        // GET: api/Puestoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Puesto>> GetPuesto(int id)
        {
            var puesto = await _context.Puesto.FindAsync(id);

            if (puesto == null)
            {
                return NotFound();
            }

            return puesto;
        }

        // PUT: api/Puestoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuesto(int id, Puesto puesto)
        {
            if (id != puesto.IdPuesto)
            {
                return BadRequest();
            }

            _context.Entry(puesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuestoExists(id))
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

        // POST: api/Puestoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Puesto>> PostPuesto(Puesto puesto)
        {
            _context.Puesto.Add(puesto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PuestoExists(puesto.IdPuesto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPuesto", new { id = puesto.IdPuesto }, puesto);
        }

        // DELETE: api/Puestoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Puesto>> DeletePuesto(int id)
        {
            var puesto = await _context.Puesto.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }

            _context.Puesto.Remove(puesto);
            await _context.SaveChangesAsync();

            return puesto;
        }

        private bool PuestoExists(int id)
        {
            return _context.Puesto.Any(e => e.IdPuesto == id);
        }
    }
}
