using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL;

namespace BS
{
    public class Puesto : ICRUD<data.Puesto>
    {
        private readonly SolutionDbContext db;
        public Puesto(SolutionDbContext _db)
        {
            db = _db;

        }

        public void Delete(data.Puesto t)
        {
            new DAL.Puesto(db).Delete(t);
        }

        public IEnumerable<data.Puesto> GetAll()
        {
            return new DAL.Puesto(db).GetAll();
        }

        public Task<IEnumerable<data.Puesto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Puesto GetOneByID(int id)
        {
            return new DAL.Puesto(db).GetOneByID(id);
        }

        public Task<data.Puesto> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Puesto t)
        {
            new DAL.Puesto(db).Insert(t);
        }

        public void Update(data.Puesto t)
        {
            new DAL.Puesto(db).Update(t);
        }
    }
}
