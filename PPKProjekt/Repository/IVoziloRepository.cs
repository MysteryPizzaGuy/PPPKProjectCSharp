using PPKProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PPKProjekt.Repository
{
    public interface IVoziloRepository
    {
        IEnumerable<Vozilo> FindAll();
        //Returns a null if non found, remember to implement a check
        Vozilo FindById(int id);
        void Create(Vozilo entity);
        void Update(Vozilo entity);
        void Delete(Vozilo entity);
        void InsertTestCase();
    }
}
