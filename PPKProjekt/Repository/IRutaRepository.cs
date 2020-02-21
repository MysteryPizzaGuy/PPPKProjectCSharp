using PPKProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPKProjekt.Repository
{
    interface IRutaRepository
    {

        IEnumerable<Ruta> FindAll();
        //Returns a null if non found, remember to implement a check

        Ruta FindById(int id);
        void Create(Ruta entity);
        void Update(Ruta entity);
        void Delete(Ruta entity);
    }
}
