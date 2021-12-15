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

    public class Cliente : ICRUD<data.Cliente>
    {

        private readonly SolutionDbContext db;
        public Cliente(SolutionDbContext _db)
        {
            db = _db;

        }
        public void Delete(data.Cliente t)
        {
            new DAL.Cliente(db).Delete(t);
        }

        public IEnumerable<data.Cliente> GetAll()
        {
            return new DAL.Cliente(db).GetAll();
        }

        public Task<IEnumerable<data.Cliente>> GetAllAsync()
        {
            return new DAL.Cliente(db).GetAllAsync();
        }

        public data.Cliente GetOneByID(int id)
        {
            return new DAL.Cliente(db).GetOneByID(id);
        }

        public Task<data.Cliente> GetOneByIdAsync(int id)
        {
            return new DAL.Cliente(db).GetOneByIdAsync(id);
        }

        public void Insert(data.Cliente t)
        {
            new DAL.Cliente(db).Insert(t);
        }

        public void Update(data.Cliente t)
        {
            new DAL.Cliente(db).Update(t);
        }
    }
}
