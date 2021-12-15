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
    public class ClienteController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        public ClienteController(SolutionDbContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Cliente>>> GetCliente()
        {
            var res = await new BS.Cliente(_context).GetAllAsync();
            return res.ToList();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Cliente>> GetCliente(int id)
        {
            var cliente = await new BS.Cliente(_context).GetOneByIdAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, data.Cliente cliente)
        {
            if (id != cliente.Cedula)
            {
                return BadRequest();
            }

           

            try
            {
                new BS.Cliente(_context).Update(cliente);
            }
            catch (Exception ee)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Cliente>> PostCliente(data.Cliente cliente)
        {
            
            try
            {
                new BS.Cliente(_context).Insert(cliente);
            }
            catch (Exception ee)
            {
                if (ClienteExists(cliente.Cedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCliente", new { id = cliente.Cedula }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Cliente>> DeleteCliente(int id)
        {
            var cliente = new BS.Cliente(_context).GetOneByID(id);
            if (cliente == null)
            {
                return NotFound();
            }


            new BS.Cliente(_context).Delete(cliente);
            return cliente;
        }

        private bool ClienteExists(int id)
        {
            return (new BS.Rol(_context).GetOneByID(id) != null);
        }
    }
}