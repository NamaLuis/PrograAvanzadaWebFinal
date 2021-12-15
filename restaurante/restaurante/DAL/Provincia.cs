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
    public class Provincia : ICRUD<data.Provincia>
    {
        private Repository<data.Provincia> _repo = null;

        public Provincia(SolutionDbContext _db)
        {

            _repo = new Repository<data.Provincia>(_db);
        }
        public void Delete(data.Provincia t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Provincia> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Provincia>> GetAllAsync()
        {
            return null;
        }

        public data.Provincia GetOneByID(int id)
        {
            return _repo.GetOnebyID(id);
        }

        public Task<data.Provincia> GetOneByIdAsync(int id)
        {
            return null;
        }

        public void Insert(data.Provincia t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Provincia t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
