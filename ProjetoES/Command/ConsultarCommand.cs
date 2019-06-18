using ProjetoES.Facade;
using ProjetoES.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoES.Command
{
    public class ConsultarCommand : AbstractCommand
    {
        public List<Funcionario> Executar()
        {
            return Fachada.Consultar().ToList();
        }

        public Funcionario Executar(int id)
        {
            return Fachada.ConsultarPorId(id);
        }
    }
}