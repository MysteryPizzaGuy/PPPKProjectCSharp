using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PPKProjekt.Repository
{
    public sealed class DatabaseFactory
    {
        private static string constring =null;
        public DatabaseFactory(string connstring)
        {
            if (constring == null)
            {
                constring = connstring;
            }
        }
        public static Database CreateDatabase()
        {
            Database createdDatabase = new SQLServerDatabase();
            createdDatabase.connectionString = constring;
            return createdDatabase;

        }
    }
}
