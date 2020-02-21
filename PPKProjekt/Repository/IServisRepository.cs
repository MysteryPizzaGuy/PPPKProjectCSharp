using PPKProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPKProjekt.Repository
{
    public interface IServisRepository
    {
        IEnumerable<Servis> FindAll();
        Servis FindById(int id);
        void Create(Servis entity);
        void Update(Servis entity);
        void Delete(Servis entity);
    }
}
