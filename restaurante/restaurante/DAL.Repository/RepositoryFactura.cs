using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public class RepositoryFactura : Repository<data.Factura>, IRepositoryFactura
    {
        public RepositoryFactura(SolutionDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Factura>> GetAllAsAsync()
        {
            return await _db.Factura
                .Include(m => m.IdClienteNavigation)
                .Include(m => m.IdEmpleadoNavigation)
                .Include(m => m.IdProductoNavigation)
                .ToListAsync();
        }

        public async Task<data.Factura> GetOneByIdAsAsync(int id)
        {
            return await _db.Factura
                .Include(m => m.IdClienteNavigation)
                .Include(m => m.IdEmpleadoNavigation)
                .Include(m => m.IdProductoNavigation)
                .SingleOrDefaultAsync(m => m.IdFactura == id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }

    }
}