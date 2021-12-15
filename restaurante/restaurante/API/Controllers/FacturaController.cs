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
    public class FacturaController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        public FacturaController(SolutionDbContext context)
        {
            _context = context;
        }

        // GET: api/Facturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Factura>>> GetFactura()
        {
            var res = await new BS.Factura(_context).GetAllAsync();
            return res.ToList();
        }

        // GET: api/Facturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Factura>> GetFactura(int id)
        {
            var factura = await new BS.Factura(_context).GetOneByIdAsync(id);

            if (factura == null)
            {
                return NotFound();
            }

            return factura;
        }

        // PUT: api/Facturas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, data.Factura factura)
        {
            if (id != factura.IdFactura)
            {
                return BadRequest();
            }

         
            try
            {
                new BS.Factura(_context).Update(factura);
            }
            catch (Exception ee)
            {
                if (!FacturaExists(id))
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

        // POST: api/Facturas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Factura>> PostFactura(data.Factura factura)
        {
           
            try
            {
                new BS.Factura(_context).Insert(factura);
            }
            catch (Exception ee)
            {
                if (FacturaExists(factura.IdFactura))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFactura", new { id = factura.IdFactura }, factura);
        }

        // DELETE: api/Facturas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Factura>> DeleteFactura(int id)
        {
            var factura = new BS.Factura(_context).GetOneByID(id);
            if (factura == null)
            {
                return NotFound();
            }

            new BS.Factura(_context).Delete(factura);

            return factura;
        }

        private bool FacturaExists(int id)
        {
            return (new BS.Rol(_context).GetOneByID(id) != null);
        }
    }
}
