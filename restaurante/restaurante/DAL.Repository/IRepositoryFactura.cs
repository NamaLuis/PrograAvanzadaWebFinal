using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryFactura : IRepository<data.Factura>
    {
        Task<IEnumerable<data.Factura>> GetAllAsAsync();
        Task<data.Factura> GetOneByIdAsAsync(int id);
    }
}