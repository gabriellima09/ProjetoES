using ProjetoES.Facade;
using ProjetoES.Models;

namespace ProjetoES.Command
{
    public class AlterarCommand : AbstractCommand
    {
        public new void Executar(Funcionario funcionario)
        {
            Fachada.Alterar(funcionario);
        }
    }
}