using PPKProjekt.Repository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace PPKProjekt.DataSet
{

    public class RouteDataSet : DataWorker
    {
        private const String PATH = "..\\BACKUP\\";

        //public static void ReadXMLFileToDatabase(String FileName,String tblName)
        //{
        //    if (File.Exists(PATH + FileName))
        //    {
        //        using (var filestream = File.Open(PATH + FileName, FileMode.Open)) {
        //            var dataSet = new System.Data.DataSet();
        //            dataSet.ReadXml(filestream);
        //            using (var con = database.CreateOpenConnection())
        //            {
        //                var adapter = SetUPAdapterForTable((SqlConnection)con,tblName);
        //                adapter.Update(dataSet);
        //            }

        //        }
        //    }

        //}

        public static void WriteRoutesToXML(String fileName)
        {
            WriteXMLFromTable(fileName, "tblRuta");
        }

        public static void ReadRoutesFromXML(String fileName)
        {

            if (File.Exists(PATH + fileName))
            {
                using (var filestream = File.Open(PATH + fileName, FileMode.Open))
                {
                    System.Data.DataSet ds = new System.Data.DataSet("tblRuta");
                    using (SqlConnection con = (SqlConnection)database.CreateOpenConnection())
                    {
                        database.CreateStoredProcCommand("emptyDB", con).ExecuteNonQuery();

                        database.CreateStoredProcCommand("EnableIDInsert", con).ExecuteNonQuery();
                        var adapter = SetUPAdapterForTable((SqlConnection)con, "tblRuta");
                        adapter.TableMappings.Add("tblRuta", "tblRuta");
                        //adapter.Fill(dataSet);
                        ds.ReadXml(filestream);
                        if (ds.Tables.Count > 0)
                        {

                            using (SqlBulkCopy cop = new SqlBulkCopy(con, SqlBulkCopyOptions.KeepIdentity, null))
                            {

                                cop.DestinationTableName = "dbo." + "tblRuta";
                                cop.WriteToServer(ds.Tables[0]);
                            }
                        }

                        database.CreateStoredProcCommand("DisableIDInsert", con).ExecuteNonQuery();

                    }

                }
            }
        }

        
        public static void ReadXMLToRestoreDatabase()
        {

                foreach (var tblName in tableNames.Reverse())
                {
                String tblFileName = tblName + ".xml";
                if (File.Exists(PATH+ tblFileName))
                {
                    using (var filestream = File.Open(PATH + tblFileName, FileMode.Open))
                    {
                        System.Data.DataSet ds = new System.Data.DataSet(tblName);
                        using (SqlConnection con = (SqlConnection)database.CreateOpenConnection())
                        {
                            database.CreateStoredProcCommand("EnableIDInsert", con).ExecuteNonQuery();
                            var adapter = SetUPAdapterForTable((SqlConnection)con, tblName);
                            adapter.TableMappings.Add(tblName, tblName);
                            //adapter.Fill(dataSet);
                            ds.ReadXml(filestream);
                            if (ds.Tables.Count >0)
                            {
       
                                using (SqlBulkCopy cop = new SqlBulkCopy(con,SqlBulkCopyOptions.KeepIdentity,null))
                                {

                                    cop.DestinationTableName = "dbo." + tblName;
                                    cop.WriteToServer(ds.Tables[0]);
                                }
                            }

                            database.CreateStoredProcCommand("DisableIDInsert", con).ExecuteNonQuery();

                        }

                    } 
                }
                }
                
            

        }

        private static String[] tableNames = { "tblKupnjaGoriva", "tblRuta", "tblPutniNalog","tblServis","tblServisStavka", "tblVozac", "tblVozilo" };
        public static void DeleteDBAndRestoreFromXML( )
        {

            using (var conn = database.CreateOpenConnection())
            {
                database.CreateStoredProcCommand("emptyDB", conn).ExecuteNonQuery();
                
            }   
            ReadXMLToRestoreDatabase();
        }

        //public static void WriteToXMLFile(String FileName)
        //{
        //    System.Data.DataSet dataSet = new System.Data.DataSet();
        //    using (SqlConnection conn = (SqlConnection)database.CreateOpenConnection())
        //    {
        //        SqlDataAdapter adapter = SetUpAdapterForAll(conn);

        //        using (var fileStream = File.Create(PATH + FileName))
        //        {
        //            dataSet.WriteXml(fileStream,XmlWriteMode.WriteSchema);

        //        }

        //    }
        //}
        public static void WriteXMLFromTable(String FileName,String tblName)
        {
            var dataSet = GetDataSetTable(tblName);

            using(var fileStream = File.Create(PATH + FileName))
            {
                dataSet.WriteXml(fileStream);
                
            }

        }


        public static void BackupDatabaseToXML()
        {
            foreach (var table in tableNames)
            {
                WriteXMLFromTable(table+".xml", table);
            }
        }



        private static System.Data.DataSet GetDataSetTable(String tblName)
        {
            using (var connection =database.CreateOpenConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                var command = database.CreateCommand("SELECT * FROM "+tblName, connection);
                adapter.SelectCommand = (SqlCommand)command;
                System.Data.DataSet dataset = new System.Data.DataSet();
                adapter.Fill(dataset);
                return dataset;

            }
        }

        private static SqlDataAdapter SetUPAdapterForTable(SqlConnection connection,String tblName)
        {
            
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from "+ tblName, connection);

            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);

            adapter.InsertCommand = sqlCommandBuilder.GetInsertCommand();
            adapter.UpdateCommand = sqlCommandBuilder.GetUpdateCommand();
            adapter.DeleteCommand = sqlCommandBuilder.GetDeleteCommand();

            return adapter;

            
        }
        private static SqlDataAdapter SetUpAdapterForAll(SqlConnection connection)
        {

            
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from tblRuta; Select * from tblPutniNalog; Select * from tblKupnjaGoriva; Select * from tblVozac;" +
                " Select * from tblVozilo", connection);

            //adapter.TableMappings.Add("tblRuta", "RuteData");
            //adapter.TableMappings.Add("tblPutniNalog", "PutniNalogData");
            //adapter.TableMappings.Add("tblKupnjaGoriva", "KupnjaGorivaData");
            //adapter.TableMappings.Add("tblVozac", "VozacData");
            //adapter.TableMappings.Add("tblVozilo", "VoziloData");
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            return adapter;


        }
    }
}
