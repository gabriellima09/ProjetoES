﻿using ProjetoES.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoES.DAO
{
    public class EnderecoDAO
    {
        private DbContext door;

        public int Salvar(Endereco entidade)
        {
            var Query = "";

            Query += "INSERT INTO endereco (logradouro, numero, cidade, estado) ";

            Query += string.Format("VALUES ('{0}','{1}','{2}','{3}');", entidade.Logradouro, entidade.Numero, entidade.Cidade.Nome, entidade.Cidade.Estado.Nome);

            var Query_busca = "SELECT MAX(id) as id FROM endereco;";

            using (door = new DbContext())
            {
                door.ExecutaComandoQuery(Query);

                var retorno = door.ExecutaComandoQueryComRetorno(Query_busca);

                if (retorno.Read())
                {
                    var endereco_com_id = int.Parse(retorno["id"].ToString());

                    return endereco_com_id;
                }

                return 0;
            }
        }

        public int Alterar(Endereco entidade)
        {
            var Query = "";

            Query += "UPDATE endereco SET";
            Query += string.Format(" logradouro = '{0}', ", entidade.Logradouro);
            Query += string.Format(" numero = '{0}', ", entidade.Numero);
            Query += string.Format(" cidade = '{0}', ", entidade.Cidade.Nome);
            Query += string.Format(" estado = '{0}' ", entidade.Cidade.Estado.Nome);
            Query += string.Format(" WHERE id = '{0}' ", entidade.Id);

            using (door = new DbContext())
            {
                door.ExecutaComandoQuery(Query);
            }

            return 0;
        }

        public IList<Endereco> Consultar()
        {
            var Query = "SELECT * FROM endereco;";

            using (door = new DbContext())
            {
                var retorno = door.ExecutaComandoQueryComRetorno(Query);

                return toList(retorno);
            }
        }

        private List<Endereco> toList(SqlDataReader reader)
        {
            var enderecos = new List<Endereco>();

            while (reader.Read())
            {
                var endereco = new Endereco();

                endereco.Id = int.Parse(reader["id"].ToString());
                endereco.Logradouro = reader["logradouro"].ToString();
                endereco.Cidade.Nome = reader["cidade"].ToString();
                endereco.Cidade.Estado.Nome = reader["estado"].ToString();

                enderecos.Add(endereco);
            }

            return enderecos;
        }

        public Endereco ConsultarPorId(int id)
        {
            var Query = string.Format("SELECT * FROM endereco WHERE id_funcionario = {0}", id);


            using (door = new DbContext())
            {
                var retorno = door.ExecutaComandoQueryComRetorno(Query);
                return toList(retorno).FirstOrDefault();
            }
        }
    }
}