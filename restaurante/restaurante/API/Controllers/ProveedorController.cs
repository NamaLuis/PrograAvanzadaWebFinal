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
    public class ProveedorController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        public ProveedorController(SolutionDbContext context)
        {
            _context = context;
        }

        // GET: api/Proveedors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Proveedor>>> GetProveedor()
        {
            return new BS.Proveedor(_context).GetAll().ToList();
        }

        // GET: api/Proveedors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Proveedor>> GetProveedor(int id)
        {
            var proveedor = new BS.Proveedor(_context).GetOneByID(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return proveedor;
        }

        // PUT: api/Proveedors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(int id, data.Proveedor proveedor)
        {
            if (id != proveedor.IdProveedor)
            {
                return BadRequest();
            }

            

            try
            {
                new BS.Proveedor(_context).Update(proveedor);
            }
            catch (Exception ee)
            {
                if (!ProveedorExists(id))
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

        // POST: api/Proveedors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Proveedor>> PostProveedor(data.Proveedor proveedor)
        {
            
            try
            {
                new BS.Proveedor(_context).Insert(proveedor);
            }
            catch (Exception ee)
            {
                if (ProveedorExists(proveedor.IdProveedor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProveedor", new { id = proveedor.IdProveedor }, proveedor);
        }

        // DELETE: api/Proveedors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Proveedor>> DeleteProveedor(int id)
        {
            var proveedor = new BS.Proveedor(_context).GetOneByID(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            new BS.Proveedor(_context).Delete(proveedor);

            return proveedor;
        }

        private bool ProveedorExists(int id)
        {
            return (new BS.Proveedor(_context).GetOneByID(id) != null);
        }
    }
}