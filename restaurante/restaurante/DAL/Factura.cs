using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.Repository;

namespace DAL
{
     public class Factura : ICRUD<data.Factura>
    {
        private RepositoryFactura _repo;

        public Factura(SolutionDbContext _db)
        {

            _repo = new RepositoryFactura(_db);
        }

        public void Delete(data.Factura t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Factura> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Factura>> GetAllAsync()
        {
            return _repo.GetAllAsAsync();
        }

        public data.Factura GetOneByID(int id)
        {
            return _repo.GetOnebyID(id);
        }

        public Task<data.Factura> GetOneByIdAsync(int id)
        {
            return _repo.GetOneByIdAsAsync(id);
        }

        public void Insert(data.Factura t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Factura t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
