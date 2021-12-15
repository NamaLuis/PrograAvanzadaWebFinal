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
    public class Puesto : ICRUD<data.Puesto>
    {
        private Repository<data.Puesto> _repo = null;

        public Puesto(SolutionDbContext _db)
        {

            _repo = new Repository<data.Puesto>(_db);
        }
        public void Delete(data.Puesto t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Puesto> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Puesto>> GetAllAsync()
        {
            return null;
        }

        public data.Puesto GetOneByID(int id)
        {
            return _repo.GetOnebyID(id);
        }

        public Task<data.Puesto> GetOneByIdAsync(int id)
        {
            return null;
        }

        public void Insert(data.Puesto t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Puesto t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
