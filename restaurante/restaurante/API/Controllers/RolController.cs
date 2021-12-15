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
    public class RolController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        public RolController(SolutionDbContext context)
        {
            _context = context;
        }

        // GET: api/Rols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Rol>>> GetRol()
        {
            return new BS.Rol(_context).GetAll().ToList();
        }

        // GET: api/Rols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Rol>> GetRol(int id)
        {
            var rol = new BS.Rol(_context).GetOneByID(id);

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
        public async Task<IActionResult> PutRol(int id, data.Rol rol)
        {
            if (id != rol.IdRol)
            {
                return BadRequest();
            }
            

            try
            {
                new BS.Rol(_context).Update(rol);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<data.Rol>> PostRol(data.Rol rol)
        {
           
            try
            {
                new BS.Rol(_context).Insert(rol);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<data.Rol>> DeleteRol(int id)
        {
            var rol = new BS.Rol(_context).GetOneByID(id);
            if (rol == null)
            {
                return NotFound();
            }

            new BS.Rol(_context).Delete(rol);

            return rol;
        }

        private bool RolExists(int id)
        {
            return (new BS.Rol(_context).GetOneByID(id) != null);
            
        }
    }
}
