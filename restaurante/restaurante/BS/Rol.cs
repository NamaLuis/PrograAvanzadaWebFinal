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
    public class Rol : ICRUD<data.Rol>
    {
       
        private readonly SolutionDbContext db;
        public Rol(SolutionDbContext _db)
        {
            db = _db;

        }
        public void Delete(data.Rol t)
        {
            new DAL.Rol(db).Delete(t);
        }

        public IEnumerable<data.Rol> GetAll()
        {
            return new DAL.Rol(db).GetAll();
        }

        public Task<IEnumerable<data.Rol>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Rol GetOneByID(int id)
        {
            return new DAL.Rol(db).GetOneByID(id);
        }

        public Task<data.Rol> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Rol t)
        {
            new DAL.Rol(db).Insert(t);
        }

        public void Update(data.Rol t)
        {
            new DAL.Rol(db).Update(t);
        }
    }
}
