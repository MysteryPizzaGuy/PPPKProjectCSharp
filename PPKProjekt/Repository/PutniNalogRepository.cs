using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PPKProjekt.Models;

namespace PPKProjekt.Repository
{
    public class PutniNalogRepository : DataWorker, IPutniNalogRepository
    {
        public void Create(PutniNalog entity)
        {
            //WarrantCreate @pVozacID int, @pVoziloID int, @pStartGrad nvarchar(50),@pStopGrad nvarchar(50),@pOcekivaniDani int
            using (IDbConnection connection = database.CreateOpenConnection())
            {

                IDbTransaction tran = connection.BeginTransaction();


                using (IDbCommand command = database.CreateStoredProcCommand("WarrantCreate", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;

                        command.Parameters.Add(database.CreateParameter("@pVozacID", entity.Vozac.IDVozac));
                        command.Parameters.Add(database.CreateParameter("@pVoziloID", entity.Vozilo.IDVozilo));
                        command.Parameters.Add(database.CreateParameter("@pStartGrad", entity.StartGrad));
                        command.Parameters.Add(database.CreateParameter("@pStopGrad", entity.StopGrad));
                        command.Parameters.Add(database.CreateParameter("@pStartDate", entity.StartDate));
                        command.Parameters.Add(database.CreateParameter("@pStopDate", entity.StopDate));

                        command.ExecuteNonQuery();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {

                        try
                        {
                            tran.Rollback();
                        }
                        catch (Exception ex2)
                        {

                            throw ex2;
                        }
                    }

                }


            }
        }

        public void Delete(PutniNalog entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("DeleteWarrant", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        //@pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
                        command.Parameters.Add(database.CreateParameter("pID", entity.IDPutniNalog));

                        command.ExecuteNonQuery();
                        tran.Commit();

                    }
                    catch (Exception ex)
                    {

                        try
                        {
                            tran.Rollback();
                        }
                        catch (Exception ex2)
                        {

                            throw;
                        }
                    }
                }
            }
        }

        public IEnumerable<PutniNalog> FindAll()
        {
            List<PutniNalog> list = new List<PutniNalog>();
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("SelectAllWarrants", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        using (IDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                IVozacRepository vozrepo = new VozacRepository();
                                IVoziloRepository vozilorepo = new VoziloRepository();
                                Vozac tempvoz = vozrepo.FindById(reader.GetInt32(1));
                                Vozilo tempvozilo = vozilorepo.FindById(reader.GetInt32(2));
                                PutniNalog temp = new PutniNalog
                                {
                                    IDPutniNalog = reader.GetInt32(0),
                                    Vozac = tempvoz,
                                    Vozilo = tempvozilo,
                                    StartGrad = reader.GetString(3),
                                    StopGrad = reader.GetString(4),
                                    StartDate = reader.GetDateTime(5),
                                    StopDate = reader.GetDateTime(6)
                                };
                                list.Add(temp);
                            }
                        }
                        tran.Commit();

                    }
                    catch (Exception ex)
                    {

                        try
                        {
                            tran.Rollback();
                        }
                        catch (Exception ex2)
                        {

                            throw;
                        }
                    }
                }
            }
            return list.AsEnumerable();
        }

        public IEnumerable<PutniNalog> FindBetweenDates(DateTime begin, DateTime end)
        {
            PutniNalog temp = null;
            List<PutniNalog> listPutniNalog = new List<PutniNalog>();
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("FindWarrantBetweenDates", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        command.Parameters.Add(database.CreateParameter("pBegin", begin));
                        command.Parameters.Add(database.CreateParameter("pEnd", end));
                        using (IDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                IVozacRepository vozrepo = new VozacRepository();
                                IVoziloRepository vozilorepo = new VoziloRepository();
                                Vozac tempvoz = vozrepo.FindById(reader.GetInt32(1));
                                Vozilo tempvozilo = vozilorepo.FindById(reader.GetInt32(2));
                                temp = new PutniNalog
                                {
                                    IDPutniNalog = reader.GetInt32(0),
                                    Vozac = tempvoz,
                                    Vozilo = tempvozilo,
                                    StartGrad = reader.GetString(3),
                                    StopGrad = reader.GetString(4),
                                    StartDate = reader.GetDateTime(5),
                                    StopDate=reader.GetDateTime(6)
                                };
                                listPutniNalog.Add(temp);

                            }
                        }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {

                        try
                        {
                            
                            tran.Rollback();
                            throw ex;
                        }
                        catch (Exception ex2)
                        {

                            throw ex2;
                        }
                    }
                }
            }
            return listPutniNalog.AsEnumerable();
        }

        public PutniNalog FindById(int id)
        {
            PutniNalog temp = null;
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("FindWarrantByID", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        command.Parameters.Add(database.CreateParameter("pID", id));
                        using (IDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                IVozacRepository vozrepo = new VozacRepository();
                                IVoziloRepository vozilorepo = new VoziloRepository();
                                Vozac tempvoz = vozrepo.FindById(reader.GetInt32(1));
                                Vozilo tempvozilo = vozilorepo.FindById(reader.GetInt32(2));
                                temp = new PutniNalog
                                {
                                    IDPutniNalog = reader.GetInt32(0),
                                    Vozac = tempvoz,
                                    Vozilo = tempvozilo,
                                    StartGrad = reader.GetString(3),
                                    StopGrad = reader.GetString(4),
                                    StartDate = reader.GetDateTime(5),
                                    StopDate = reader.GetDateTime(6)
                                };
                            }
                        }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {

                        try
                        {
                            tran.Rollback();
                        }
                        catch (Exception ex2)
                        {

                            throw;
                        }
                    }
                }
            }
            return temp;
        }

        public void InsertTestCase()
        {
            throw new NotImplementedException();
        }

        public void Update(PutniNalog entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("UpdateWarrant", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        //@pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
                        command.Parameters.Add(database.CreateParameter("pID", entity.IDPutniNalog));

                        command.Parameters.Add(database.CreateParameter("pVozacID", entity.Vozac.IDVozac));
                        command.Parameters.Add(database.CreateParameter("pVoziloID", entity.Vozilo.IDVozilo));
                        command.Parameters.Add(database.CreateParameter("pStartGrad", entity.StartGrad));
                        command.Parameters.Add(database.CreateParameter("pStopGrad", entity.StopGrad));
                        command.Parameters.Add(database.CreateParameter("pStartDate", entity.StartDate));

                        command.Parameters.Add(database.CreateParameter("pStopDate", entity.StopDate));

                        command.ExecuteNonQuery();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {

                        try
                        {
                            tran.Rollback();
                        }
                        catch (Exception ex2)
                        {

                            throw;
                        }
                    }

                }
            }
        }
    }
}
