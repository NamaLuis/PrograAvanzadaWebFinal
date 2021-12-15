using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL.Repository
{
    public class RepositoryEmpleado : Repository<data.Empleado>, IRepositoryEmpleado
    {
        public RepositoryEmpleado(SolutionDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Empleado>> GetAllAsAsync()
        {
            return await _db.Empleado
                .Include(m => m.IdPuestoNavigation)
                .Include(m => m.IdRolNavigation)
                .ToListAsync();
        }

        public async Task<data.Empleado> GetOneByIdAsAsync(int id)
        {
            return await _db.Empleado
                .Include(m => m.IdPuestoNavigation)
                .Include(m => m.IdRolNavigation)
                .SingleOrDefaultAsync(m => m.IdEmpleado == id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }

    }
}