using PPKProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPKProjekt.Repository
{
    public interface IKupnjaGorivaRepository
    {

            IEnumerable<KupnjaGoriva> FindAll();
        //Returns a null if non found, remember to implement a check

            KupnjaGoriva FindById(int id);
            void Create(KupnjaGoriva entity);
            void Update(KupnjaGoriva entity);
            void Delete(KupnjaGoriva entity);
    }
}

