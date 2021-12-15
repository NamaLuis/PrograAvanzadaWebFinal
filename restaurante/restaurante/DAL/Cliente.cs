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
    public class Cliente : ICRUD<data.Cliente>
    {
        private RepositoryCliente _repo;

        public Cliente(SolutionDbContext _db)
        {

            _repo = new RepositoryCliente(_db);
        }

        public void Delete(data.Cliente t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Cliente> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Cliente>> GetAllAsync()
        {
            return _repo.GetAllAsAsync();
        }

        public data.Cliente GetOneByID(int id)
        {
            return _repo.GetOnebyID(id);
        }

        public Task<data.Cliente> GetOneByIdAsync(int id)
        {
            return _repo.GetOneByIdAsAsync(id);
        }
    

        public void Insert(data.Cliente t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Cliente t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
