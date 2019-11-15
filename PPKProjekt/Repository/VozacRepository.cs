using PPKProjekt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PPKProjekt.Repository
{
    public class VozacRepository : DataWorker, IVozacRepository
    {
        public void Create(Vozac entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateCommand("INSERT into tblVozac (IME,Prezime,BrojMobitela,SerijskiBrojVozacke) VALUES (@pIme, @pPrezime, @pBrojMobitela, @pSerijskiBrojVozacke)", connection))
                {
                    //@pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
                    command.Parameters.Add(database.CreateParameter("@pIme", entity.Ime));
                    command.Parameters.Add(database.CreateParameter("@pPrezime", entity.Prezime));
                    command.Parameters.Add(database.CreateParameter("@pBrojMobitela", entity.BrojMobitela));
                    command.Parameters.Add(database.CreateParameter("@pSerijskiBrojVozacke", entity.SerijskiBrojVozacke));

                    command.ExecuteNonQuery();
                }


            }
        }

        public void Delete(Vozac entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateCommand("DELETE FROM tblVozac Where IDVozac = @pID", connection))
                {
                    //@pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
                    command.Parameters.Add(database.CreateParameter("pID", entity.IDVozac));

                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Vozac> FindAll()
        {
            List<Vozac> list = new List<Vozac>();
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateCommand("SELECT * FROM tblVozac", connection))
                {
                    using (IDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Vozac temp = new Vozac
                            {
                                IDVozac = reader.GetInt32(0),
                                Ime = reader.GetString(1),
                                Prezime = reader.GetString(2),
                                BrojMobitela = reader.GetString(3),
                                SerijskiBrojVozacke = reader.GetString(4)
                            };
                            list.Add(temp); 
                        }
                    }
                }
            }
            return list.AsEnumerable();
        }



        public Vozac FindById(int id)
        {
            Vozac temp = null;
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateCommand("Select * from tblVozac where IDVozac=@pID", connection))
                {
                    command.Parameters.Add(database.CreateParameter("pID", id));
                    using (IDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            temp = new Vozac
                            {
                                IDVozac = reader.GetInt32(0),
                                Ime = reader.GetString(1),
                                Prezime = reader.GetString(2),
                                BrojMobitela = reader.GetString(3),
                                SerijskiBrojVozacke = reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return temp;
        }

        public void InsertTestCase()
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateStoredProcCommand("InsertTestDrivers", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Vozac entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateCommand("UPDATE tblVozac SET Ime = @pIme, Prezime = @pPrezime, BrojMobitela = @pBrojMobitela, SerijskiBrojVozacke = @pSerijskiBrojVozacke Where IDVozac = @pID", connection))
                {
                    //@pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
                    command.Parameters.Add(database.CreateParameter("@pID", entity.IDVozac));

                    command.Parameters.Add(database.CreateParameter("@pIme", entity.Ime));
                    command.Parameters.Add(database.CreateParameter("@pPrezime", entity.Prezime));
                    command.Parameters.Add(database.CreateParameter("@pBrojMobitela", entity.BrojMobitela));
                    command.Parameters.Add(database.CreateParameter("@pSerijskiBrojVozacke", entity.SerijskiBrojVozacke));

                    command.ExecuteNonQuery();
                }
            }
        }
        
    }
}
