using ProjetoES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoES.DAO
{
    public class FuncionarioDAO
    {
        private DbContext door;

        private void Inserir(Funcionario funcionario)
        {
            var Query = "";

            Query += "INSERT INTO funcionario (nome, cpf, dataContratacao, matricula, cargo, setor, regional, email, status, codigo, dataCadastro, id_endereco)";

            Query += string.Format(" VALUES ('{0}','{1}', CONVERT(date, '{2}', 103),'{3}','{4}','{5}','{6}','{7}','{8}','{9}',CONVERT(date, '{10}', 103), '{11}');", funcionario.Nome, funcionario.Cpf, funcionario.DataContratacao, funcionario.Matricula, funcionario.Cargo,
                funcionario.Setor, funcionario.Regional, funcionario.Email, funcionario.Status, funcionario.CodigoFuncionario, funcionario.DataCadastro, funcionario.IdEndereco);

            using (door = new DbContext())
            {
                door.ExecutaComandoQuery(Query);
            }
        }

        public void Alterar(Funcionario funcionario)
        {
            var Query = "";

            Query += "UPDATE funcionario SET";
            Query += string.Format(" nome = '{0}', ", funcionario.Nome);
            Query += string.Format(" cpf = '{0}', ", funcionario.Cpf);
            Query += string.Format(" dataContratacao = '{0}', ", funcionario.DataContratacao);
            Query += string.Format(" matricula = '{0}', ", funcionario.Matricula);
            Query += string.Format(" cargo = '{0}', ", funcionario.Cargo);
            Query += string.Format(" setor = '{0}', ", funcionario.Setor);
            Query += string.Format(" regional = '{0}', ", funcionario.Regional);
            Query += string.Format(" email = '{0}', ", funcionario.Email);
            Query += string.Format(" codigo = '{0}' ", funcionario.CodigoFuncionario);
            Query += string.Format(" WHERE id = '{0}' ", funcionario.Id);

            using (door = new DbContext())
            {
                door.ExecutaComandoQuery(Query);
            }
        }

        private int BuscarStatus(int id)
        {
            int status = 0;

            string Query = "SELECT status FROM funcionario WHERE id = " + id;

            using (door = new DbContext())
            {
                using (var reader = door.ExecutaComandoQueryComRetorno(Query))
                {
                    while (reader.Read())
                    {
                        status = Convert.ToInt32(Convert.ToString(reader["status"]));
                    }
                }
            }
            return status;
        }

        public void TrocarStatus(int id)
        {
            var status = BuscarStatus(id);

            var Query = "";


            if (status == 1)
            {
                Query += "UPDATE funcionario SET status = 0";
            }
            else
            {
                Query += "UPDATE funcionario SET status = 1";
            }

            using (door = new DbContext())
            {
                door.ExecutaComandoQuery(Query);
            }
        }

       
        public void Salvar(Funcionario funcionario)
        {
            if (funcionario.Id > 0)
                Alterar(funcionario);
            else
                Inserir(funcionario);
        }

        public List<Funcionario> Consultar()
        {
            var funcionarios = new List<Funcionario>();

            var Query = "SELECT f.*, e.* FROM funcionario as f INNER JOIN endereco as e ON f.id_endereco = e.id;";

            using (door = new DbContext())
            {
                using (var reader = door.ExecutaComandoQueryComRetorno(Query))
                {
                    while (reader.Read())
                    {
                        var funcionario = new Funcionario();

                        funcionario.Endereco = new Endereco();
                        funcionario.Endereco.Cidade = new Cidade();
                        funcionario.Endereco.Cidade.Estado = new Estado();

                        funcionario.Id = Convert.ToInt32(reader["id"]);
                        funcionario.IdEndereco = Convert.ToInt32(reader["id_endereco"]);
                        funcionario.Endereco.Id = funcionario.IdEndereco;
                        funcionario.Nome = Convert.ToString(reader["nome"]);
                        funcionario.Cpf = Convert.ToString(reader["cpf"]);
                        funcionario.DataContratacao = Convert.ToDateTime(reader["dataContratacao"]);
                        funcionario.Cargo = Convert.ToString(reader["cargo"]);
                        funcionario.Setor = Convert.ToString(reader["setor"]);
                        funcionario.Matricula = Convert.ToString(reader["matricula"]);
                        funcionario.Regional = Convert.ToString(reader["regional"]);
                        funcionario.Email = Convert.ToString(reader["email"]);
                        funcionario.Status = Convert.ToInt32(reader["status"]);
                        funcionario.CodigoFuncionario = Convert.ToInt32(reader["codigo"]);
                        funcionario.DataCadastro = Convert.ToDateTime(reader["dataCadastro"]);
                        funcionario.Endereco.Logradouro = Convert.ToString(reader["logradouro"]);
                        funcionario.Endereco.Numero = Convert.ToString(reader["numero"]);
                        funcionario.Endereco.Cidade.Nome = Convert.ToString(reader["cidade"]);
                        funcionario.Endereco.Cidade.Estado.Nome = Convert.ToString(reader["estado"]);

                        funcionarios.Add(funcionario);
                    }
                }

                return funcionarios;
            }
        }

        public Funcionario ConsultarPorId(int id)
        {
            var funcionario = new Funcionario();

            var Query = "SELECT f.*, e.* FROM funcionario as f INNER JOIN endereco as e ON f.id_endereco = e.id where f.id = " + id + ";";

            using (door = new DbContext())
            {
                using (var reader = door.ExecutaComandoQueryComRetorno(Query))
                {
                    while (reader.Read())
                    {
                        funcionario.Endereco = new Endereco();
                        funcionario.Endereco.Cidade = new Cidade();
                        funcionario.Endereco.Cidade.Estado = new Estado();

                        funcionario.Id = Convert.ToInt32(reader["id"]);
                        funcionario.IdEndereco = Convert.ToInt32(reader["id_endereco"]);
                        funcionario.Endereco.Id = funcionario.IdEndereco;
                        funcionario.Nome = Convert.ToString(reader["nome"]);
                        funcionario.Cpf = Convert.ToString(reader["cpf"]);
                        funcionario.DataContratacao = Convert.ToDateTime(reader["dataContratacao"]);
                        funcionario.Cargo = Convert.ToString(reader["cargo"]);
                        funcionario.Setor = Convert.ToString(reader["setor"]);
                        funcionario.Matricula = Convert.ToString(reader["matricula"]);
                        funcionario.Regional = Convert.ToString(reader["regional"]);
                        funcionario.Email = Convert.ToString(reader["email"]);
                        funcionario.Status = Convert.ToInt32(reader["status"]);
                        funcionario.CodigoFuncionario = Convert.ToInt32(reader["codigo"]);
                        funcionario.DataCadastro = Convert.ToDateTime(reader["dataCadastro"]);
                        funcionario.Endereco.Logradouro = Convert.ToString(reader["logradouro"]);
                        funcionario.Endereco.Numero = Convert.ToString(reader["numero"]);
                        funcionario.Endereco.Cidade.Nome = Convert.ToString(reader["cidade"]);
                        funcionario.Endereco.Cidade.Estado.Nome = Convert.ToString(reader["estado"]);
                    }
                }

                return funcionario;
            }
        }

    }
}