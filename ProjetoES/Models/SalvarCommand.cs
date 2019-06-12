using ProjetoES.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoES.Models
{
    class SalvarCommand : ICommand
    {
        public void executar(Funcionario funcionario)
        {
            Fachada fachada = new Fachada();

            fachada.Cadastrar(funcionario);
        }
    }
}
