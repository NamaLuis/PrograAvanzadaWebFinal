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
    public class ProductoController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        public ProductoController(SolutionDbContext context)
        {
            _context = context;
        }

        // GET: api/Productoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Producto>>> GetProducto()
        {
            var res = await new BS.Producto(_context).GetAllAsync();
            return res.ToList();
        }

        // GET: api/Productoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Producto>> GetProducto(int id)
        {
            var producto = await new BS.Producto(_context).GetOneByIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/Productoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, data.Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return BadRequest();
            }

            

            try
            {
                new BS.Producto(_context).Update(producto);
            }
            catch (Exception ee)
            {
                if (!ProductoExists(id))
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

        // POST: api/Productoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Producto>> PostProducto(data.Producto producto)
        {
            
            try
            {
                new BS.Producto(_context).Insert(producto);
            }
            catch (Exception ee)
            {
                if (ProductoExists(producto.IdProducto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProducto", new { id = producto.IdProducto }, producto);
        }

        // DELETE: api/Productoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Producto>> DeleteProducto(int id)
        {
            var producto = new BS.Producto(_context).GetOneByID(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();

            return producto;
        }

        private bool ProductoExists(int id)
        {
            return (new BS.Producto(_context).GetOneByID(id) != null);
        }
    }
}

