using ProjetoES.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoES.Models
{
    public class ConsultarCommand : ICommand
    {
        public void executar(Funcionario funcionario)
        {
        }

        public List<Funcionario> executar()
        {
            Fachada fachada = new Fachada();
            return fachada.Consultar();
        }

        public Funcionario executar(int id)
        {
            Fachada fachada = new Fachada();

            return fachada.ConsultarPorId(id);
        }
    }
}