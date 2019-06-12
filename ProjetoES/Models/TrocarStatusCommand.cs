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

        public void executar(int id, int status)
        {
            Fachada fachada = new Fachada();

            if (status == 1)
            {
                fachada.InativarFuncionario(id);
            }
            else
            {
                fachada.AtivarFuncionario(id);
            }

        }

    }
}