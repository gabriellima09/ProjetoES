using ProjetoES.Facade;

namespace ProjetoES.Command
{
    public class TrocarStatusCommand : AbstractCommand
    {
        public void Executar(int id, int status)
        {
            if (status == 1)
            {
                Fachada.InativarFuncionario(id);
            }
            else
            {
                Fachada.AtivarFuncionario(id);
            }
        }
    }
}