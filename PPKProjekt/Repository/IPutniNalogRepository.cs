using PPKProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PPKProjekt.Repository
{
    public interface IPutniNalogRepository
    {
        IEnumerable<PutniNalog> FindAll();
        //Returns a null if non found, remember to implement a check

        PutniNalog FindById(int id);
        IEnumerable<PutniNalog> FindBetweenDates(DateTime begin, DateTime end);
        void Create(PutniNalog entity);
        void Update(PutniNalog entity);
        void Delete(PutniNalog entity);
        void InsertTestCase();
    }
}
