using ProjetoES.Facade;
using ProjetoES.Models;

namespace ProjetoES.Command
{
    public abstract class AbstractCommand : ICommand
    {
        protected Fachada Fachada = new Fachada();

        public void Executar(Funcionario funcionario)
        {

        }
    }
}