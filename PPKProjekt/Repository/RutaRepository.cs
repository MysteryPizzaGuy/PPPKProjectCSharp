using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using PPKProjekt.Models;

namespace PPKProjekt.Repository
{
    public class RutaRepository : DataWorker, IRutaRepository
    {
        public void Create(Ruta entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {

                IDbTransaction tran = connection.BeginTransaction();


                using (IDbCommand command = database.CreateStoredProcCommand("CreateRoute", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;

                        command.Parameters.Add(database.CreateParameter("@pPutniNalogID", entity.PutniNalog.IDPutniNalog));
                        command.Parameters.Add(database.CreateParameter("@pVrijeme", entity.Vrijeme));
                        command.Parameters.Add(database.CreateParameter("@pACoordX", entity.ACoordX));
                        command.Parameters.Add(database.CreateParameter("@pACoordY", entity.ACoordY));
                        command.Parameters.Add(database.CreateParameter("@pBCoordX", entity.BCoordX));
                        command.Parameters.Add(database.CreateParameter("@pBCoordY", entity.BCoordY));
                        command.Parameters.Add(database.CreateParameter("@pPrijedeniKM", entity.PrijedeniKM));
                        command.Parameters.Add(database.CreateParameter("@pProsjecniKMH", entity.ProsjecniKMH));
                        command.Parameters.Add(database.CreateParameter("@pPotrosenoGorivoLitre", entity.PotrosenoGorivoLitre));

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

        public void Delete(Ruta entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("DeleteRoute", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        //@pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
                        command.Parameters.Add(database.CreateParameter("pID", entity.IDRuta));

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

        public IEnumerable<Ruta> FindAll()
        {
            List<Ruta> list = new List<Ruta>();
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("SelectAllRoutes", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        using (IDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                IPutniNalogRepository putnirepo = new PutniNalogRepository();
                                PutniNalog putninalog = putnirepo.FindById(reader.GetInt32(1));
                                Ruta temp = new Ruta
                                {
                                    IDRuta = reader.GetInt32(0),
                                    PutniNalog = putninalog,
                                    Vrijeme = reader.GetDateTime(2),
                                    ACoordX = reader.GetInt32(3),
                                    ACoordY = reader.GetInt32(4),
                                    BCoordX = reader.GetInt32(5),
                                    BCoordY = reader.GetInt32(6),
                                    PrijedeniKM=reader.GetDouble(7),
                                    ProsjecniKMH=reader.GetDouble(8),
                                    PotrosenoGorivoLitre=reader.GetDouble(9)
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

        public Ruta FindById(int id)
        {
            Ruta temp = null;
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("FindRoute", connection))
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
                                IPutniNalogRepository putnirepo = new PutniNalogRepository();
                                PutniNalog putninalog = putnirepo.FindById(reader.GetInt32(1));
                                temp = new Ruta
                                {
                                    IDRuta = reader.GetInt32(0),
                                    PutniNalog = putninalog,
                                    Vrijeme = reader.GetDateTime(2),
                                    ACoordX = reader.GetInt32(3),
                                    ACoordY = reader.GetInt32(4),
                                    BCoordX = reader.GetInt32(5),
                                    BCoordY = reader.GetInt32(6),
                                    PrijedeniKM = reader.GetDouble(7),
                                    ProsjecniKMH = reader.GetDouble(8),
                                    PotrosenoGorivoLitre = reader.GetDouble(9)
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

        public void Update(Ruta entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("UpdateRoute", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;

                        command.Parameters.Add(database.CreateParameter("@pID", entity.IDRuta));
                        command.Parameters.Add(database.CreateParameter("@pPutniNalogID", entity.PutniNalog.IDPutniNalog));
                        command.Parameters.Add(database.CreateParameter("@pVrijeme", entity.Vrijeme));
                        command.Parameters.Add(database.CreateParameter("@pACoordX", entity.ACoordX));
                        command.Parameters.Add(database.CreateParameter("@pACoordY", entity.ACoordY));
                        command.Parameters.Add(database.CreateParameter("@pBCoordX", entity.BCoordX));
                        command.Parameters.Add(database.CreateParameter("@pBCoordY", entity.BCoordY));
                        command.Parameters.Add(database.CreateParameter("@pPrijedeniKM", entity.PrijedeniKM));
                        command.Parameters.Add(database.CreateParameter("@pProsjecniKMH", entity.ProsjecniKMH));
                        command.Parameters.Add(database.CreateParameter("@pPotrosenoGorivoLitre", entity.PotrosenoGorivoLitre));

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
