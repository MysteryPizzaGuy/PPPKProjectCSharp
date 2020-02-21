using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using PPKProjekt.Models;

namespace PPKProjekt.Repository
{
    public class ServisStavkaRepository : DataWorker, IServisStavkaRepository
    {
        public void Create(ServisStavka entity)
        {
                using (IDbConnection connection = database.CreateOpenConnection())
                {

                    IDbTransaction tran = connection.BeginTransaction();


                    using (IDbCommand command = database.CreateStoredProcCommand("CreateServisStavka", connection))
                    {
                        try
                        {
                            command.Connection = connection;
                            command.Transaction = tran;

                            command.Parameters.Add(database.CreateParameter("@pNaziv", entity.Naziv));


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

        public void Delete(ServisStavka entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("DeleteServisStavka", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        //@pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
                        command.Parameters.Add(database.CreateParameter("pID", entity.IDServisStavka));

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

        public IEnumerable<ServisStavka> FindAll()
        {
            List<ServisStavka> list = new List<ServisStavka>();
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("SelectServisStavka", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        using (IDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                ServisStavka temp = new ServisStavka
                                {
                                    IDServisStavka = reader.GetInt32(0),
                                    Naziv = reader.GetString(1)
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

        public ServisStavka FindById(int id)
        {
            ServisStavka temp = null;
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("FindServisStavka", connection))
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

                                temp = new ServisStavka
                                {
                                    IDServisStavka = reader.GetInt32(0),
                                    Naziv=reader.GetString(1)
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

        public void Update(ServisStavka entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("UpdateServisStavka", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        command.Parameters.Add(database.CreateParameter("@pID", entity.IDServisStavka));
                        command.Parameters.Add(database.CreateParameter("@pNaziv", entity.Naziv));


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
