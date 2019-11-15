//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Threading.Tasks;

//namespace PPKProjekt.Repository
//{
//    public abstract class RepositoryBase<T> : DataWorker, IRepositoryBase<T> where T : class { 
    

//        public RepositoryBase()
//        {
//        }

//        public IQueryable<T> FindAll()
//        {
//            using (IDbConnection connection = database.CreateOpenConnection())
//            {
//                using (IDbCommand command = database.CreateCommand("SELECT * FROM FLOWERS", connection))
//                {
//                    using (IDataReader reader = command.ExecuteReader())
//                    {
//                        // read flowers and process ...
//                    }
//                }
//            }
//        }

//        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
//        {
//            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
//        }

//        public void Create(T entity)
//        {
//            this.RepositoryContext.Set<T>().Add(entity);
//        }

//        public void Update(T entity)
//        {
//            this.RepositoryContext.Set<T>().Update(entity);
//        }

//        public void Delete(T entity)
//        {
//            this.RepositoryContext.Set<T>().Remove(entity);
//        }
//    }
//}
