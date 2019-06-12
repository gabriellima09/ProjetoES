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
        private Dictionary<string, List<IStrategy>> regra_validacao = new Dictionary<string, List<IStrategy>>();

        public Fachada()
        {
            List<IStrategy> lista_validacao = new List<IStrategy>();
            lista_validacao.Add(new ValidarCpf());
            lista_validacao.Add(new ValidarData());
            lista_validacao.Add(new ValidarEmail());
            lista_validacao.Add(new ValidarPropriedadeVazia());

            regra_validacao.Add("funcionario", lista_validacao);
        }

        public void Cadastrar(Funcionario funcionario)
        {
            var lista_objetos_validacao = regra_validacao["funcionario"];

            for(int i = 0; i < lista_objetos_validacao.Count; i++)
            {
                lista_objetos_validacao[i].processar(funcionario);
            }

            var enderecoDao = new EnderecoDAO();
            funcionario.IdEndereco = enderecoDao.Salvar(funcionario.Endereco);

            funcionario.DataCadastro = DateTime.Now;
            funcionario.Status = 1;

            var funcionarioDao = new FuncionarioDAO();
            funcionarioDao.Salvar(funcionario);
        }

        public void AtivarFuncionario(int id)
        {
            var funcionarioDAO = new FuncionarioDAO();
            funcionarioDAO.AtivarFuncionario(id);
        }

        public void InativarFuncionario(int id)
        {
            var funcionarioDAO = new FuncionarioDAO();
            funcionarioDAO.InativarFuncionario(id);
        }

        public void Alterar(Funcionario funcionario)
        {
            var lista_objetos_validacao = regra_validacao["funcionario"];

            for (int i = 0; i < lista_objetos_validacao.Count; i++)
            {
                lista_objetos_validacao[i].processar(funcionario);
            }
            
            var enderecoDao = new EnderecoDAO();
            enderecoDao.Alterar(funcionario.Endereco);

            var funcionarioDao = new FuncionarioDAO();
            funcionarioDao.Salvar(funcionario);
        }

        public List<Funcionario> Consultar()
        {
            return new FuncionarioDAO().Consultar();
        }

        public Funcionario ConsultarPorId(int id)
        {
            return new FuncionarioDAO().ConsultarPorId(id);
        }
    }
}