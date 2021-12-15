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
    public class Empleado : ICRUD<data.Empleado>
    {
        private RepositoryEmpleado _repo;

        public Empleado(SolutionDbContext _db)
        {

            _repo = new RepositoryEmpleado(_db);
        }

        public void Delete(data.Empleado t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Empleado> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Empleado>> GetAllAsync()
        {
            return _repo.GetAllAsAsync();
        }

        public data.Empleado GetOneByID(int id)
        {
            return _repo.GetOnebyID(id);
        }

        public Task<data.Empleado> GetOneByIdAsync(int id)
        {
            return _repo.GetOneByIdAsAsync(id);
        }

        public void Insert(data.Empleado t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Empleado t)
        {
            _repo.Update(t);
            _repo.Commit(); ;
        }
    }
}
