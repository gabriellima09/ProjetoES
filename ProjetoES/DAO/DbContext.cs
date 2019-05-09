using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoES.DAO
{
    public class DbContext : IDisposable
    {
        private readonly string BdServerName = DbUtil.DataServerName;
        private readonly string BdName = DbUtil.DatabaseName;
        private readonly SqlConnection conexao;

        public DbContext()
        {
            conexao = new SqlConnection(DbUtil.ConnectionString);
            conexao.Open();
        }

        public void ExecutaComandoQuery(string Query)
        {
            using (var cmdComando = new SqlCommand
            {
                CommandText = Query,
                CommandType = CommandType.Text,
                Connection = conexao
            })
            {
                cmdComando.ExecuteScalar();
            }
        }

        public SqlDataReader ExecutaComandoQueryComRetorno(string Query)
        {
            using (var cmdComando = new SqlCommand(Query, conexao))
            {
                return cmdComando.ExecuteReader();
            }
        }

        public void Dispose()
        {
            if (conexao.State != ConnectionState.Closed)
            {
                conexao.Close();
            }

            GC.SuppressFinalize(this);
        }
    }
}