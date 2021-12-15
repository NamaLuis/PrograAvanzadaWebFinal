using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL.Repository
{
    public class RepositoryCliente : Repository<data.Cliente>, IRepositoryCliente
    {
        public RepositoryCliente(SolutionDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Cliente>> GetAllAsAsync()
        {
            return await _db.Cliente
                .Include(m => m.IdprovinciaNavigation)
                .ToListAsync();
        }

        public async Task<data.Cliente> GetOneByIdAsAsync(int id)
        {
            return await _db.Cliente
                .Include(m => m.IdprovinciaNavigation)
                .SingleOrDefaultAsync(m => m.Cedula == id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }

    }
}