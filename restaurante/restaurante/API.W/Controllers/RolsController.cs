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
    public class RolsController : ControllerBase
    {
        private readonly restauranteVerdeContext _context;

        public RolsController(restauranteVerdeContext context)
        {
            _context = context;
        }

        // GET: api/Rols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRol()
        {
            return await _context.Rol.ToListAsync();
        }

        // GET: api/Rols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var rol = await _context.Rol.FindAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            return rol;
        }

        // PUT: api/Rols/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, Rol rol)
        {
            if (id != rol.IdRol)
            {
                return BadRequest();
            }

            _context.Entry(rol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
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

        // POST: api/Rols
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rol>> PostRol(Rol rol)
        {
            _context.Rol.Add(rol);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RolExists(rol.IdRol))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRol", new { id = rol.IdRol }, rol);
        }

        // DELETE: api/Rols/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rol>> DeleteRol(int id)
        {
            var rol = await _context.Rol.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            _context.Rol.Remove(rol);
            await _context.SaveChangesAsync();

            return rol;
        }

        private bool RolExists(int id)
        {
            return _context.Rol.Any(e => e.IdRol == id);
        }
    }
}
