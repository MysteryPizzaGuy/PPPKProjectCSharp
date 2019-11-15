using PPKProjekt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PPKProjekt.Repository
{
    public class VoziloRepository : DataWorker, IVoziloRepository
    {
        public void Create(Vozilo entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateStoredProcCommand("VehicleCreate", connection))
                {
                    //@pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
                    command.Parameters.Add(database.CreateParameter("@pTip", entity.Tip));
                    command.Parameters.Add(database.CreateParameter("@pMarka", entity.Marka));
                    command.Parameters.Add(database.CreateParameter("@pGodinaProizvodnje", entity.GodinaProizvodnje));
                    command.Parameters.Add(database.CreateParameter("@pInicijalniKM", entity.InicijalniKM));

                    command.ExecuteNonQuery();
                }


            }
        }

        public void Delete(Vozilo entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateStoredProcCommand("DeleteVehicle", connection))
                {
                    //@pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
                    command.Parameters.Add(database.CreateParameter("pID", entity.IDVozilo));

                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Vozilo> FindAll()
        {
            List<Vozilo> list = new List<Vozilo>();
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateStoredProcCommand("SelectAllVehicles", connection))
                {
                    using (IDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Vozilo temp = new Vozilo
                            {
                                IDVozilo = reader.GetInt32(0),
                                Tip = reader.GetString(1),
                                Marka = reader.GetString(2),
                                GodinaProizvodnje = reader.GetDateTime(3),
                                InicijalniKM = reader.GetInt32(4)
                            };
                            list.Add(temp);
                        }
                    }
                }
            }
            return list.AsEnumerable();
        }

       
        public Vozilo FindById(int id)
        {
            Vozilo temp = null;
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateStoredProcCommand("FindVoziloByID", connection))
                {
                    command.Parameters.Add(database.CreateParameter("pID", id));

                    using (IDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            temp = new Vozilo
                            {
                                IDVozilo = reader.GetInt32(0),
                                Tip = reader.GetString(1),
                                Marka = reader.GetString(2),
                                GodinaProizvodnje = reader.GetDateTime(3),
                                InicijalniKM = reader.GetInt32(4)
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
                using (IDbCommand command = database.CreateStoredProcCommand("InsertTestVehicles", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Vozilo entity)
        {
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateStoredProcCommand("UpdateVehicle", connection))
                {
                    //@pIme nvarchar(50), @pPrezime nvarchar(50), @pBrojMobitela nvarchar(50),@pSerijskiBrojVozacke nvarchar(8)
                    command.Parameters.Add(database.CreateParameter("pID", entity.IDVozilo));

                    command.Parameters.Add(database.CreateParameter("pTip", entity.Tip));
                    command.Parameters.Add(database.CreateParameter("pMarka", entity.Marka));
                    command.Parameters.Add(database.CreateParameter("pGodinaProizvodnje", entity.GodinaProizvodnje));
                    command.Parameters.Add(database.CreateParameter("pInicijalniKM", entity.InicijalniKM));

                    command.ExecuteNonQuery();
                }
            }
        }
     
    }
}
