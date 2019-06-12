using ProjetoES.Facade;
using ProjetoES.Models;

namespace ProjetoES.Command
{
    public class SalvarCommand : AbstractCommand
    {
        public new void Executar(Funcionario funcionario)
        {
            Fachada.Cadastrar(funcionario);
        }
    }
}
