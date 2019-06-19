using ProjetoES.Strategy;
using ProjetoES.Util;

namespace ProjetoES.Models
{
    public class ValidarEndereco : IStrategy
    {
        public bool Processar(Funcionario funcionario)
        {
            return Validador.ValidarPropriedadeVazia(funcionario.Endereco.Complemento)
               && Validador.ValidarPropriedadeVazia(funcionario.Endereco.Logradouro)
               && Validador.ValidarPropriedadeVazia(funcionario.Endereco.Numero)
               && Validador.ValidarPropriedadeVazia(funcionario.Endereco.Cidade.Nome)
               && Validador.ValidarPropriedadeVazia(funcionario.Endereco.Cidade.Estado.Nome);
        }
    }
}