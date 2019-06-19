using ProjetoES.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoES.Models
{
    public class TrocarStatusCommand : ICommand
    {
        public void executar(Funcionario funcionario)
        {

        }

        public void executar(int id)
        {
            Fachada fachada = new Fachada();

            fachada.TrocarStatus(id);
        }

    }
}