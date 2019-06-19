using ProjetoES.DAO;
using ProjetoES.Models;
using ProjetoES.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var lista_objetos_validacao = regra_validacao["funcionario"];

            for(int i = 0; i < lista_objetos_validacao.Count; i++)
            {
                lista_objetos_validacao[i].Processar(entidade);
            }

            var enderecoDao = new EnderecoDAO();
            entidade.IdEndereco = enderecoDao.Salvar(entidade.Endereco);

            entidade.DataCadastro = DateTime.Now;
            entidade.Status = 1;

            var funcionarioDao = new FuncionarioDAO();
            funcionarioDao.Salvar(entidade);
        }

        public void TrocarStatus(int id)
        {
            var funcionarioDAO = new FuncionarioDAO();

            funcionarioDAO.TrocarStatus(id);
        }

        public void Alterar(Funcionario entidade)
        {
            var lista_objetos_validacao = regra_validacao["funcionario"];

            for (int i = 0; i < lista_objetos_validacao.Count; i++)
            {
                lista_objetos_validacao[i].Processar(entidade);
            }
            
            var enderecoDao = new EnderecoDAO();
            enderecoDao.Alterar(entidade.Endereco);

            var funcionarioDao = new FuncionarioDAO();
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