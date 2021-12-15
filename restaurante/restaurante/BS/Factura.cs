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

    public class Factura : ICRUD<data.Factura>
    {

        private readonly SolutionDbContext db;
        public Factura(SolutionDbContext _db)
        {
            db = _db;

        }
        public void Delete(data.Factura t)
        {
            new DAL.Factura(db).Delete(t);
        }

        public IEnumerable<data.Factura> GetAll()
        {
            return new DAL.Factura(db).GetAll();
        }

        public Task<IEnumerable<data.Factura>> GetAllAsync()
        {
            return new DAL.Factura(db).GetAllAsync();
        }

        public data.Factura GetOneByID(int id)
        {
            return new DAL.Factura(db).GetOneByID(id);
        }

        public Task<data.Factura> GetOneByIdAsync(int id)
        {
            return new DAL.Factura(db).GetOneByIdAsync(id);
        }

        public void Insert(data.Factura t)
        {
            new DAL.Factura(db).Insert(t);
        }

        public void Update(data.Factura t)
        {
            new DAL.Factura(db).Update(t);
        }
    }
}
