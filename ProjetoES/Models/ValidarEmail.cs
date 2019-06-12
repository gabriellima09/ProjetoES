using ProjetoES.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoES.Models
{
    public class ValidarEmail : IStrategy
    {
        public bool processar(Funcionario funcionario)
        {
            return Validador.ValidarEmail(funcionario.Email);
        }
    }
}