using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL.Repository
{
    public class RepositoryProducto : Repository<data.Producto>, IRepositoryProducto
    {
        public RepositoryProducto(SolutionDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Producto>> GetAllAsAsync()
        {
            return await _db.Producto
                .Include(m => m.IdProveedorNavigation)
                .ToListAsync();
        }

        public async Task<data.Producto> GetOneByIdAsAsync(int id)
        {
            return await _db.Producto
                .Include(m => m.IdProveedorNavigation)
                .SingleOrDefaultAsync(m => m.IdProducto == id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }

    }
}