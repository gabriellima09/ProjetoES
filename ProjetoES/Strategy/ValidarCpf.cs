using ProjetoES.Models;
using ProjetoES.Util;

namespace ProjetoES.Strategy
{
    public class ValidarCpf : IStrategy
    {
        public bool Processar(Funcionario funcionario)
        {
            return Validador.ValidarCPF(funcionario.Cpf);
        }
    }
}