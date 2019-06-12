using ProjetoES.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoES.Models
{
    public class ValidarCpf : IStrategy
    {
        public bool processar(Funcionario funcionario)
        {
            return Validador.ValidarCPF(funcionario.Cpf);
        }
    }
}