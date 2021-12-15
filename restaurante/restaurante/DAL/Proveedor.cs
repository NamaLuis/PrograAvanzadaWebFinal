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
    public class Proveedor : ICRUD<data.Proveedor>
    {
        private Repository<data.Proveedor> _repo = null;

        public Proveedor(SolutionDbContext _db)
        {

            _repo = new Repository<data.Proveedor>(_db);
        }
        public void Delete(data.Proveedor t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Proveedor> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Proveedor>> GetAllAsync()
        {
            return null;
        }

        public data.Proveedor GetOneByID(int id)
        {
            return _repo.GetOnebyID(id);
        }

        public Task<data.Proveedor> GetOneByIdAsync(int id)
        {
            return null;
        }

        public void Insert(data.Proveedor t)
        {
            _repo.Insert(t);
            _repo.Commit(); ;
        }

        public void Update(data.Proveedor t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
