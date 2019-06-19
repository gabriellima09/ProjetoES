using ProjetoES.DAO;
using System.Data.SqlClient;
using System.Text;

namespace ProjetoES.App_Start
{
    public class DatabaseConfig
    {
        public static void Initialize(bool dropDb = false)
        {
            if (dropDb)
            {
                DropDatabase();
            }

            CreateDatabase();
            CreateTables();
        }

        private static void CreateDatabase()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = N'" + DbUtil.DatabaseName + "') BEGIN");
            sb.Append(" CREATE DATABASE " + DbUtil.DatabaseName + " ON PRIMARY");
            sb.Append(" (NAME = " + DbUtil.DatabaseName + ",");
            sb.Append(" FILENAME = '" + DbUtil.Path + DbUtil.DatabaseName + ".mdf',");
            sb.Append(" SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)");
            sb.Append(" LOG ON (NAME = " + DbUtil.DatabaseName + "_Log,");
            sb.Append(" FILENAME = '" + DbUtil.Path + DbUtil.DatabaseName + "Log.ldf',");
            sb.Append(" SIZE = 1MB,");
            sb.Append(" MAXSIZE = 5MB,");
            sb.Append(" FILEGROWTH = 10%)");
            sb.Append("END");

            try
            {
                using (SqlConnection myConn = new SqlConnection(DbUtil.ConnectionString_Master))
                {
                    using (SqlCommand myCommand = new SqlCommand(sb.ToString(), myConn))
                    {
                        myConn.Open();
                        myCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private static void CreateTables()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("IF (SELECT COUNT(name) FROM " + DbUtil.DatabaseName + ".sys.tables where name = 'endereco') = 0");
                sb.Append(" BEGIN");
                sb.Append(" CREATE TABLE endereco(");
                sb.Append(" id INTEGER IDENTITY(1,1) PRIMARY KEY,");
                sb.Append(" logradouro VARCHAR(200),");
                sb.Append(" numero VARCHAR(200),");
                sb.Append(" cidade VARCHAR(200),");
                sb.Append(" estado VARCHAR(200)");
                sb.Append(");");
                sb.Append(" END");

                sb.Append("\n");

                sb.Append("IF (SELECT COUNT(name) FROM " + DbUtil.DatabaseName + ".sys.tables where name = 'funcionario') = 0");
                sb.Append(" BEGIN");
                sb.Append(" CREATE TABLE funcionario(");
                sb.Append(" id INTEGER IDENTITY(1,1) PRIMARY KEY,");
                sb.Append(" nome VARCHAR(200),");
                sb.Append(" cpf VARCHAR(200),");
                sb.Append(" dataContratacao DATE,");
                sb.Append(" matricula VARCHAR(200),");
                sb.Append(" cargo VARCHAR(200),");
                sb.Append(" setor VARCHAR(200),");
                sb.Append(" regional VARCHAR(200),");
                sb.Append(" email VARCHAR(200),");
                sb.Append(" status INTEGER,");
                sb.Append(" codigo INTEGER,");
                sb.Append(" dataCadastro DATE,");
                sb.Append(" id_endereco INTEGER FOREIGN KEY REFERENCES endereco(id)");
                sb.Append(");");
                sb.Append(" END");
                
                using (SqlConnection myConn = new SqlConnection(DbUtil.ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand(sb.ToString(), myConn))
                    {
                        myConn.Open();
                        myCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        private static void DropDatabase()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("IF EXISTS (SELECT 1 FROM sys.databases WHERE name = N'" + DbUtil.DatabaseName + "') BEGIN");
                sb.Append(" DROP DATABASE " + DbUtil.DatabaseName + ";");
                sb.Append("END");

                using (SqlConnection myConn = new SqlConnection(@"Data Source=(localDb)\MSSQLLocalDb;Integrated security=true;database=master"))
                {
                    using (SqlCommand myCommand = new SqlCommand(sb.ToString(), myConn))
                    {
                        myConn.Open();
                        myCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}