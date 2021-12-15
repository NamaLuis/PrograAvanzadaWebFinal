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
    public class Proveedor : ICRUD<data.Proveedor>
    {
        private readonly SolutionDbContext db;
        public Proveedor(SolutionDbContext _db)
        {
            db = _db;

        }

        public void Delete(data.Proveedor t)
        {
            new DAL.Proveedor(db).Delete(t);
        }

        public IEnumerable<data.Proveedor> GetAll()
        {
            return new DAL.Proveedor(db).GetAll();
        }

        public Task<IEnumerable<data.Proveedor>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Proveedor GetOneByID(int id)
        {
            return new DAL.Proveedor(db).GetOneByID(id);
        }

        public Task<data.Proveedor> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Proveedor t)
        {
            new DAL.Proveedor(db).Insert(t);
        }

        public void Update(data.Proveedor t)
        {
            new DAL.Proveedor(db).Update(t);
        }
    }
}
