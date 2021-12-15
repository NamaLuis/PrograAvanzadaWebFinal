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
    public class Rol : ICRUD<data.Rol>
    {
        private Repository<data.Rol> _repo = null;

        public Rol(SolutionDbContext _db) {

            _repo = new Repository<data.Rol>(_db);
        }
        public void Delete(data.Rol t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Rol> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Rol>> GetAllAsync()
        {
            return null;
        }

        public data.Rol GetOneByID(int id)
        {
            return _repo.GetOnebyID(id);
        }

        public Task<data.Rol> GetOneByIdAsync(int id)
        {
            return null;
        }

        public void Insert(data.Rol t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Rol t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
