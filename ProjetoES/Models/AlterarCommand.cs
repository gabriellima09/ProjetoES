using ProjetoES.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoES.Models
{
    public class AlterarCommand : ICommand
    {
        public void executar(Funcionario funcionario)
        {
            Fachada fachada = new Fachada();
            fachada.Alterar(funcionario);
        }
    }
}