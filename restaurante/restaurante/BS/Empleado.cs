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

    public class Empleado : ICRUD<data.Empleado>
    {

        private readonly SolutionDbContext db;
        public Empleado(SolutionDbContext _db)
        {
            db = _db;

        }
        public void Delete(data.Empleado t)
        {
            new DAL.Empleado(db).Delete(t);
        }

        public IEnumerable<data.Empleado> GetAll()
        {
            return new DAL.Empleado(db).GetAll();
        }

        public Task<IEnumerable<data.Empleado>> GetAllAsync()
        {
            return new DAL.Empleado(db).GetAllAsync();
        }

        public data.Empleado GetOneByID(int id)
        {
            return new DAL.Empleado(db).GetOneByID(id);
        }

        public Task<data.Empleado> GetOneByIdAsync(int id)
        {
            return new DAL.Empleado(db).GetOneByIdAsync(id);
        }

        public void Insert(data.Empleado t)
        {
            new DAL.Empleado(db).Insert(t);
        }

        public void Update(data.Empleado t)
        {
            new DAL.Empleado(db).Update(t);
        }
    }
}
