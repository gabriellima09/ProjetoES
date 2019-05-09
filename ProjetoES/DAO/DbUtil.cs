using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoES.DAO
{
    public class DbUtil
    {
        public static string ConnectionString => _SqlConnectionStringBuilder.ConnectionString;
        public static string DatabaseName => _DatabaseNameBuilder;
        public static string Path => _PathBuilder;
        public static string DataServerName => _ServerNameBuilder;

        private static string _DatabaseNameBuilder
        {
            get
            {
                return "projetoES";
            }
        }

        private static string _PathBuilder
        {
            get
            {
                return @"C:\Users\gabriel.gomes\";
            }
        }

        private static string _ServerNameBuilder
        {
            get
            {
                return @"(localDb)\MSSQLLocalDb";
            }
        }
        
        private static SqlConnectionStringBuilder _SqlConnectionStringBuilder
        {
            get
            {
                return new SqlConnectionStringBuilder
                {
                    DataSource = _ServerNameBuilder,
                    InitialCatalog = _DatabaseNameBuilder,
                    IntegratedSecurity = true
                };
            }
        }
    }
}