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
    public class PuestoController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        public PuestoController(SolutionDbContext context)
        {
            _context = context;
        }

        // GET: api/Puestoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Puesto>>> GetPuesto()
        {
            return new BS.Puesto(_context).GetAll().ToList();
        }

        // GET: api/Puestoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Puesto>> GetPuesto(int id)
        {
            var puesto = new BS.Puesto(_context).GetOneByID(id);

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
        public async Task<IActionResult> PutPuesto(int id, data.Puesto puesto)
        {
            if (id != puesto.IdPuesto)
            {
                return BadRequest();
            }

            

            try
            {
                new BS.Puesto(_context).Update(puesto);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<data.Puesto>> PostPuesto(data.Puesto puesto)
        {
            
            try
            {
                new BS.Puesto(_context).Insert(puesto);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<data.Puesto>> DeletePuesto(int id)
        {
            var puesto = new BS.Puesto(_context).GetOneByID(id);
            if (puesto == null)
            {
                return NotFound();
            }

            new BS.Puesto(_context).Delete(puesto);

            return puesto;
        }

        private bool PuestoExists(int id)
        {
            return (new BS.Puesto(_context).GetOneByID(id) != null);
        }
    }
}