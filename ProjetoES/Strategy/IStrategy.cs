using ProjetoES.Models;

namespace ProjetoES.Strategy
{
    public interface IStrategy
    {
        bool Processar(Funcionario funcionario);
    }
}
