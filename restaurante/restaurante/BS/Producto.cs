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

    public class Producto : ICRUD<data.Producto>
    {

        private readonly SolutionDbContext db;
        public Producto(SolutionDbContext _db)
        {
            db = _db;

        }
        public void Delete(data.Producto t)
        {
            new DAL.Producto(db).Delete(t);
        }

        public IEnumerable<data.Producto> GetAll()
        {
            return new DAL.Producto(db).GetAll();
        }

        public Task<IEnumerable<data.Producto>> GetAllAsync()
        {
            return new DAL.Producto(db).GetAllAsync();
        }

        public data.Producto GetOneByID(int id)
        {
            return new DAL.Producto(db).GetOneByID(id);
        }

        public Task<data.Producto> GetOneByIdAsync(int id)
        {
            return new DAL.Producto(db).GetOneByIdAsync(id);
        }

        public void Insert(data.Producto t)
        {
            new DAL.Producto(db).Insert(t);
        }

        public void Update(data.Producto t)
        {
            new DAL.Producto(db).Update(t);
        }
    }
}
