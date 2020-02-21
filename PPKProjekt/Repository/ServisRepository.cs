using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using PPKProjekt.Models;

namespace PPKProjekt.Repository
{
    public class ServisRepository : DataWorker,IServisRepository
    {
        public void Create(Servis entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {

                IDbTransaction tran = connection.BeginTransaction();


                using (IDbCommand command = database.CreateStoredProcCommand("CreateServis", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        IServisStavkaRepository repo = new ServisStavkaRepository();

                        command.Parameters.Add(database.CreateParameter("@pVoziloID", entity.Vozilo.IDVozilo));
                        command.Parameters.Add(database.CreateParameter("@pServisStavkaID", entity.ServisStavka.IDServisStavka));
                        command.Parameters.Add(database.CreateParameter("@pDatum", entity.Datum));
                        command.Parameters.Add(database.CreateParameter("@pNaziv", entity.Naziv));
                        command.Parameters.Add(database.CreateParameter("@pOpis", entity.Opis));
                        command.Parameters.Add(database.CreateParameter("@pCijena", entity.Cijena));


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

        public void Delete(Servis entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("DeleteServis", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        //@pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
                        command.Parameters.Add(database.CreateParameter("pID", entity.IDServis));

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

        public IEnumerable<Servis> FindAll()
        {
            List<Servis> list = new List<Servis>();
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("SelectServis", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            IVoziloRepository vozrepo = new VoziloRepository();
                            IServisStavkaRepository ssrepo = new ServisStavkaRepository();




                            while (reader.Read())
                            {

                                Vozilo vozilo = vozrepo.FindById(reader.GetInt32(1));
                                ServisStavka servisStavka = ssrepo.FindById(reader.GetInt32(2));
                                Servis temp = new Servis
                                {
                                    IDServis = reader.GetInt32(0),
                                    ServisStavka = servisStavka,
                                    Vozilo = vozilo,
                                    Datum=reader.GetDateTime(3),
                                    Naziv = reader.GetString(4),
                                    Opis = reader.GetString(5),
                                    Cijena = reader.GetDouble(6)
                                    
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

        public Servis FindById(int id)
        {
            Servis temp = null;
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("FindServis", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        command.Parameters.Add(database.CreateParameter("pID", id));
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            IVoziloRepository vozrepo = new VoziloRepository();
                            IServisStavkaRepository ssrepo = new ServisStavkaRepository();




                            while (reader.Read())
                            {

                                Vozilo vozilo = vozrepo.FindById(reader.GetInt32(1));
                                ServisStavka servisStavka = ssrepo.FindById(reader.GetInt32(2));
                                temp = new Servis
                                {
                                    IDServis = reader.GetInt32(0),
                                    ServisStavka = servisStavka,
                                    Vozilo = vozilo,
                                    Datum = reader.GetDateTime(3),
                                    Naziv = reader.GetString(4),
                                    Opis = reader.GetString(5),
                                    Cijena = reader.GetDouble(6)

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

        public void Update(Servis entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                IDbTransaction tran = connection.BeginTransaction();

                using (IDbCommand command = database.CreateStoredProcCommand("UpdateServis", connection))
                {
                    try
                    {
                        command.Connection = connection;
                        command.Transaction = tran;
                        IServisStavkaRepository repo = new ServisStavkaRepository();

                        command.Parameters.Add(database.CreateParameter("@pID", entity.IDServis));

                        command.Parameters.Add(database.CreateParameter("@pVoziloID", entity.Vozilo.IDVozilo));
                        command.Parameters.Add(database.CreateParameter("@pServisStavkaID", entity.ServisStavka.IDServisStavka));
                        command.Parameters.Add(database.CreateParameter("@pDatum", entity.Datum));
                        command.Parameters.Add(database.CreateParameter("@pNaziv", entity.Naziv));
                        command.Parameters.Add(database.CreateParameter("@pOpis", entity.Opis));
                        command.Parameters.Add(database.CreateParameter("@pCijena", entity.Cijena));


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
