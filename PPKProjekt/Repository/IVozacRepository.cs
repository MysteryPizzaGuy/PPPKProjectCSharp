using PPKProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PPKProjekt.Repository
{
    public interface IVozacRepository
    {
        IEnumerable<Vozac> FindAll();
        Vozac FindById(int id);
        void Create(Vozac entity);
        void Update(Vozac entity);
        void Delete(Vozac entity);
        void InsertTestCase();
    }
}
