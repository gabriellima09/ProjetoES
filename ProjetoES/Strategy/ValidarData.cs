using ProjetoES.Models;
using ProjetoES.Util;

namespace ProjetoES.Strategy
{
    public class ValidarData : IStrategy
    {
        public bool Processar(Funcionario funcionario)
        {
            return Validador.ValidarData(funcionario.DataContratacao);
        }
    }
}