using PPKProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPKProjekt.Repository
{
    public interface IServisStavkaRepository
    {
        IEnumerable<ServisStavka> FindAll();
        ServisStavka FindById(int id);
        void Create(ServisStavka entity);
        void Update(ServisStavka entity);
        void Delete(ServisStavka entity);
    }
}
