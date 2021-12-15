using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryCliente : IRepository<data.Cliente>
    {
        Task<IEnumerable<data.Cliente>> GetAllAsAsync();
        Task<data.Cliente> GetOneByIdAsAsync(int id);
    }
}
