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
    public class Provincia : ICRUD<data.Provincia>
    {
        private readonly SolutionDbContext db;
        public Provincia(SolutionDbContext _db)
        {
            db = _db;

        }

        public void Delete(data.Provincia t)
        {
            new DAL.Provincia(db).Delete(t);
        }

        public IEnumerable<data.Provincia> GetAll()
        {
            return new DAL.Provincia(db).GetAll();
        }

        public Task<IEnumerable<data.Provincia>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Provincia GetOneByID(int id)
        {
            return new DAL.Provincia(db).GetOneByID(id);
        }

        public Task<data.Provincia> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Provincia t)
        {
            new DAL.Provincia(db).Insert(t);
        }

        public void Update(data.Provincia t)
        {
            new DAL.Provincia(db).Update(t);
        }
    }
}
