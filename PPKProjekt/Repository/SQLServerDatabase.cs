using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PPKProjekt.Repository
{
    public class SQLServerDatabase : Database
    {
        public override IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }
        public static void InfoMessageHandler(object mySender, SqlInfoMessageEventArgs myEvent)
        {
            System.Diagnostics.Debug.WriteLine("The following message was produced:\n" + myEvent.Errors[0]);

        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            SqlCommand command = (SqlCommand)CreateCommand();
            command.CommandText = commandText;
            command.Connection = (SqlConnection)connection;
            command.CommandType = CommandType.Text;

            return command;
            
        }

        public override IDbConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
            conn.FireInfoMessageEventOnUserErrors = true;
            return conn;
        }

        public override IDbConnection CreateOpenConnection()
        {
            SqlConnection connection = (SqlConnection)CreateConnection();
            connection.InfoMessage += new SqlInfoMessageEventHandler(InfoMessageHandler);
            connection.FireInfoMessageEventOnUserErrors = true;

            connection.Open();
            return connection;
            
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new SqlParameter(parameterName, parameterValue);
        }

        public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            SqlCommand command = (SqlCommand)CreateCommand();
            command.CommandText = procName;
            command.Connection = (SqlConnection)connection;
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }
    }
}
