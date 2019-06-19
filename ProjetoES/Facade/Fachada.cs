using ProjetoES.DAO;
using ProjetoES.Models;
using ProjetoES.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoES.Facade
{
    public class Fachada : IFachada<Funcionario>
    {
        private Dictionary<string, List<IStrategy>> regra_validacao = new Dictionary<string, List<IStrategy>>();

        public Fachada()
        {
            List<IStrategy> lista_validacao = new List<IStrategy>
            {
                new ValidarCpf(),
                new ValidarData(),
                new ValidarEmail(),
                new ValidarFuncionario(),
                new ValidarEndereco()
            };

            regra_validacao.Add("funcionario", lista_validacao);
        }

        public void Cadastrar(Funcionario entidade)
        {
            List<IStrategy> lista_objetos_validacao = regra_validacao["funcionario"];

            var flgValidaOk = true;

            for(int i = 0; i < lista_objetos_validacao.Count; i++)
            {
                if (!lista_objetos_validacao[i].Processar(entidade));
            }

            if (!flgValidaOk)
                return;

            EnderecoDAO enderecoDao = new EnderecoDAO();
            entidade.IdEndereco = enderecoDao.Salvar(entidade.Endereco);

            entidade.DataCadastro = DateTime.Now;
            entidade.Status = 1;

            FuncionarioDAO funcionarioDao = new FuncionarioDAO();
            funcionarioDao.Salvar(entidade);
        }

        public void AtivarFuncionario(int id)
        {
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
            funcionarioDAO.AtivarFuncionario(id);
        }

        public void InativarFuncionario(int id)
        {
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
            funcionarioDAO.InativarFuncionario(id);
        }

        public void Alterar(Funcionario entidade)
        {
            List<IStrategy> lista_objetos_validacao = regra_validacao["funcionario"];

            for (int i = 0; i < lista_objetos_validacao.Count; i++)
            {
                lista_objetos_validacao[i].Processar(entidade);
            }

            EnderecoDAO enderecoDao = new EnderecoDAO();
            enderecoDao.Alterar(entidade.Endereco);

            FuncionarioDAO funcionarioDao = new FuncionarioDAO();
            funcionarioDao.Salvar(entidade);
        }

        public IList<Funcionario> Consultar()
        {
            return new FuncionarioDAO().Consultar().ToList();
        }

        public Funcionario ConsultarPorId(int id)
        {
            return new FuncionarioDAO().ConsultarPorId(id);
        }
    }
}