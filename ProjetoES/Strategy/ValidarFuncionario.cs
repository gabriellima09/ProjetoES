using ProjetoES.Models;
using ProjetoES.Util;

namespace ProjetoES.Strategy
{
    public class ValidarFuncionario : IStrategy
    {
        public bool Processar(Funcionario funcionario)
        {
            return Validador.ValidarPropriedadeVazia(funcionario.Nome) 
                && Validador.ValidarPropriedadeVazia(funcionario.Matricula)
                && Validador.ValidarPropriedadeVazia(funcionario.Cargo)
                && Validador.ValidarPropriedadeVazia(funcionario.Setor)
                && Validador.ValidarPropriedadeVazia(funcionario.Regional)
                && funcionario.Endereco.Validar();
        }
    }
}