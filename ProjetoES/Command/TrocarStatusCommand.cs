using ProjetoES.Facade;

namespace ProjetoES.Command
{
    public class TrocarStatusCommand : AbstractCommand
    {
        public void Executar(int id)
        {
            Fachada.TrocarStatus(id);
        }
    }
}