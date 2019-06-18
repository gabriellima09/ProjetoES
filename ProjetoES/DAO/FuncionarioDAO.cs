using ProjetoES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoES.DAO
{
    public class FuncionarioDAO : IDAO<Funcionario>
    {
        private DbContext door;

        public void Inserir(Funcionario entidade)
        {
            var Query = "";

            Query += "INSERT INTO funcionario (nome, cpf, dataContratacao, matricula, cargo, setor, regional, email, status, codigo, dataCadastro, id_endereco) ";

            Query += string.Format("VALUES ('{0}','{1}', CONVERT(date, '{2}'),'{3}','{4}','{5}','{6}','{7}','{8}','{9}',CONVERT(date, '{10}'), '{11}');", entidade.Nome, entidade.Cpf, entidade.DataContratacao, entidade.Matricula, entidade.Cargo,
                entidade.Setor, entidade.Regional, entidade.Email, entidade.Status, entidade.CodigoFuncionario, entidade.DataCadastro, entidade.IdEndereco);

            using (door = new DbContext())
            {
                door.ExecutaComandoQuery(Query);
            }
        }

        public void Alterar(Funcionario entidade)
        {
            var Query = "";

            Query += "UPDATE funcionario SET";
            Query += string.Format(" nome = '{0}', ", entidade.Nome);
            Query += string.Format(" cpf = '{0}', ", entidade.Cpf);
            Query += string.Format(" dataContratacao = '{0}', ", entidade.DataContratacao);
            Query += string.Format(" matricula = '{0}', ", entidade.Matricula);
            Query += string.Format(" cargo = '{0}', ", entidade.Cargo);
            Query += string.Format(" setor = '{0}', ", entidade.Setor);
            Query += string.Format(" regional = '{0}', ", entidade.Regional);
            Query += string.Format(" email = '{0}', ", entidade.Email);
            Query += string.Format(" codigo = '{0}' ", entidade.CodigoFuncionario);
            Query += string.Format(" WHERE id = '{0}' ", entidade.Id);

            using (door = new DbContext())
            {
                door.ExecutaComandoQuery(Query);
            }
        }

        public void AtivarFuncionario(int id)
        {
            var Query = "";

            Query += "UPDATE funcionario SET status = 1";
            Query += string.Format(" WHERE id = '{0}' ", id);

            using (door = new DbContext())
            {
                door.ExecutaComandoQuery(Query);
            }
        }

        public void InativarFuncionario(int id)
        {
            var Query = "";

            Query += "UPDATE funcionario SET status = 0";
            Query += string.Format(" WHERE id = '{0}' ", id);

            using (door = new DbContext())
            {
                door.ExecutaComandoQuery(Query);
            }
        }

        public void Salvar(Funcionario entidade)
        {
            if (entidade.Id > 0)
                Alterar(entidade);
            else
                Inserir(entidade);
        }

        public IList<Funcionario> Consultar()
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