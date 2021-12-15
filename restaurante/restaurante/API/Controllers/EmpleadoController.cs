using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        public EmpleadoController(SolutionDbContext context)
        {
            _context = context;
        }

        // GET: api/Empleadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Empleado>>> GetEmpleado()
        {
            var res = await new BS.Empleado(_context).GetAllAsync();
            return res.ToList();
        }

        // GET: api/Empleadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Empleado>> GetEmpleado(int id)
        {
            var empleado = await new BS.Empleado(_context).GetOneByIdAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        // PUT: api/Empleadoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, data.Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return BadRequest();
            }

           

            try
            {
                new BS.Empleado(_context).Update(empleado);
            }
            catch (Exception ee)
            {
                if (!EmpleadoExists(id))
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

        // POST: api/Empleadoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Empleado>> PostEmpleado(data.Empleado empleado)
        {
            
            try
            {
                new BS.Empleado(_context).Insert(empleado);
            }
            catch (Exception ee)
            {
                if (EmpleadoExists(empleado.IdEmpleado))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpleado", new { id = empleado.IdEmpleado }, empleado);
        }

        // DELETE: api/Empleadoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Empleado>> DeleteEmpleado(int id)
        {
            var empleado = new BS.Empleado(_context).GetOneByID(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();

            return empleado;
        }

        private bool EmpleadoExists(int id)
        {
            return (new BS.Rol(_context).GetOneByID(id) != null);
        }
    }
}
