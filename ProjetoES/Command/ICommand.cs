using ProjetoES.Models;

namespace ProjetoES.Command
{
    public interface ICommand
    {
        void Executar(Funcionario funcionario);
    }
}
