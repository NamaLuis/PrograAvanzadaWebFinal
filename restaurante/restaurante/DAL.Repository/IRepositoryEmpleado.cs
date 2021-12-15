using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryEmpleado : IRepository<data.Empleado>
    {
        Task<IEnumerable<data.Empleado>> GetAllAsAsync();
        Task<data.Empleado> GetOneByIdAsAsync(int id);
    }
}
