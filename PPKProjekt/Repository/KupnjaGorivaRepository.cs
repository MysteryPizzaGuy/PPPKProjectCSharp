using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using PPKProjekt.Models;

namespace PPKProjekt.Repository
{
    public class KupnjaGorivaRepository : DataWorker, IKupnjaGorivaRepository
    {
        public void Create(KupnjaGoriva entity)
        {
            //WarrantCreate @pVozacID int, @pVoziloID int, @pStartGrad nvarchar(50),@pStopGrad nvarchar(50),@pOcekivaniDani int
            using (IDbConnection connection = database.CreateOpenConnection())
            {

                IDbTransaction tran = connection.BeginTransaction();


                using (IDbCommand command = database.CreateStoredProcCommand("CreateFuelBuying", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;

                        command.Parameters.Add(database.CreateParameter("@pPutniNalogID", entity.PutniNalog.IDPutniNalog));
                        command.Parameters.Add(database.CreateParameter("@pLokacija", entity.Lokacija));
                        command.Parameters.Add(database.CreateParameter("@pGorivoPoLitri", entity.GorivoPoLitri));
                        command.Parameters.Add(database.CreateParameter("@pCijenaPoLitri", entity.CijenaPoLitri));


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

        public void Delete(KupnjaGoriva entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("DeleteFuelBuying", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        //@pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
                        command.Parameters.Add(database.CreateParameter("pID", entity.IDKupnjaGoriva));

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

        public IEnumerable<KupnjaGoriva> FindAll()
        {
            List<KupnjaGoriva> list = new List<KupnjaGoriva>();
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("SelectAllFuelBuying", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        using (IDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                IPutniNalogRepository putrepo = new PutniNalogRepository();
                                PutniNalog putniNalog = putrepo.FindById(reader.GetInt32(1));
                                KupnjaGoriva temp = new KupnjaGoriva
                                {
                                    IDKupnjaGoriva = reader.GetInt32(0),
                                    Lokacija = reader.GetString(2),
                                    GorivoPoLitri = reader.GetFloat(3),
                                    CijenaPoLitri = reader.GetFloat(4),
                                    PutniNalog = putniNalog

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

        public KupnjaGoriva FindById(int id)
        {
            KupnjaGoriva temp = null;
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("FindFuelBuyingByID", connection))
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

                                IPutniNalogRepository putrepo = new PutniNalogRepository();
                                PutniNalog putniNalog = putrepo.FindById(reader.GetInt32(1));
                                temp = new KupnjaGoriva
                                {
                                    IDKupnjaGoriva = reader.GetInt32(0),
                                    Lokacija = reader.GetString(2),
                                    GorivoPoLitri = reader.GetFloat(3),
                                    CijenaPoLitri = reader.GetFloat(4),
                                    PutniNalog=putniNalog

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

        public void Update(KupnjaGoriva entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("UpdateFuelBuying", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        command.Parameters.Add(database.CreateParameter("@pID", entity.IDKupnjaGoriva));
                        command.Parameters.Add(database.CreateParameter("@pPutniNalogID", entity.PutniNalog.IDPutniNalog));
                        command.Parameters.Add(database.CreateParameter("@pLokacija", entity.Lokacija));
                        command.Parameters.Add(database.CreateParameter("@pGorivoPoLitri", entity.GorivoPoLitri));
                        command.Parameters.Add(database.CreateParameter("@pCijenaPoLitri", entity.CijenaPoLitri));


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
