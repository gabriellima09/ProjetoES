using ProjetoES.Models;
using ProjetoES.Util;

namespace ProjetoES.Strategy
{
    public class ValidarEmail : IStrategy
    {
        public bool Processar(Funcionario funcionario)
        {
            return Validador.ValidarEmail(funcionario.Email);
        }
    }
}