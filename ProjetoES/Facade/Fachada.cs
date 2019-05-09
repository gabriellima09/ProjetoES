using ProjetoES.DAO;
using ProjetoES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoES.Facade
{
    public class Fachada
    {
        public static void Cadastrar(Funcionario funcionario)
        {
            if (funcionario.Validar())
            {
                var enderecoDao = new EnderecoDAO();
                funcionario.IdEndereco = enderecoDao.Salvar(funcionario.Endereco);

                funcionario.DataCadastro = DateTime.Now;
                funcionario.Status = 1;

                var funcionarioDao = new FuncionarioDAO();
                funcionarioDao.Salvar(funcionario);
            }
            else
            {
                throw new Exception("Ocorreu um erro ao tentar cadastrar o funcionário. Os dados do funcionário não são válidos ...");
            }
        }

        public static void AtivarFuncionario(int id)
        {
            var funcionarioDAO = new FuncionarioDAO();
            funcionarioDAO.AtivarFuncionario(id);
        }

        public static void InativarFuncionario(int id)
        {
            var funcionarioDAO = new FuncionarioDAO();
            funcionarioDAO.InativarFuncionario(id);
        }

        public static void Alterar(Funcionario funcionario)
        {
            if (funcionario.Validar())
            {
                var enderecoDao = new EnderecoDAO();
                enderecoDao.Alterar(funcionario.Endereco);

                var funcionarioDao = new FuncionarioDAO();
                funcionarioDao.Salvar(funcionario);
            }
            else
            {
                throw new Exception("Ocorreu um erro ao tentar cadastrar o funcionário. Os dados do funcionário não são válidos ...");
            }
        }

        public static List<Funcionario> Consultar()
        {
            return new FuncionarioDAO().Consultar();
        }

        public static Funcionario ConsultarPorId(int id)
        {
            return new FuncionarioDAO().ConsultarPorId(id);
        }

    }
}