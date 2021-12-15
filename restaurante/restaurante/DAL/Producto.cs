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
    public class Producto : ICRUD<data.Producto>
    {
        private RepositoryProducto _repo;

        public Producto(SolutionDbContext _db)
        {

            _repo = new RepositoryProducto(_db);
        }

        public void Delete(data.Producto t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Producto> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Producto>> GetAllAsync()
        {
            return _repo.GetAllAsAsync();
        }

        public data.Producto GetOneByID(int id)
        {
            return _repo.GetOnebyID(id);
        }

        public Task<data.Producto> GetOneByIdAsync(int id)
        {
            return _repo.GetOneByIdAsAsync(id);
        }

        public void Insert(data.Producto t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Producto t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
