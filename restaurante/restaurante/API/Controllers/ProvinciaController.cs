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
    public class ProvinciaController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        public ProvinciaController(SolutionDbContext context)
        {
            _context = context;
        }

        // GET: api/Provincias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Provincia>>> GetProvincia()
        {
            return new BS.Provincia(_context).GetAll().ToList();
        }

        // GET: api/Provincias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Provincia>> GetProvincia(int id)
        {
            var provincia = new BS.Provincia(_context).GetOneByID(id);

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
        public async Task<IActionResult> PutProvincia(int id, data.Provincia provincia)
        {
            if (id != provincia.IdProvincia)
            {
                return BadRequest();
            }

            

            try
            {
                new BS.Provincia(_context).Update(provincia);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<data.Provincia>> PostProvincia(data.Provincia provincia)
        {
            
            try
            {
                new BS.Provincia(_context).Insert(provincia);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<data.Provincia>> DeleteProvincia(int id)
        {
            var provincia = new BS.Provincia(_context).GetOneByID(id);
            if (provincia == null)
            {
                return NotFound();
            }

            new BS.Provincia(_context).Delete(provincia);

            return provincia;
        }

        private bool ProvinciaExists(int id)
        {
            return (new BS.Provincia(_context).GetOneByID(id) != null);
        }
    }
}
