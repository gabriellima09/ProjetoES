using ProjetoES.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoES.Models
{
    public class ValidarPropriedadeVazia : IStrategy
    {
        public bool processar(Funcionario funcionario)
        {
            return Validador.ValidarPropriedadeVazia(funcionario.Nome) 
                && Validador.ValidarPropriedadeVazia(funcionario.Matricula)
                && Validador.ValidarPropriedadeVazia(funcionario.Cargo)
                && Validador.ValidarPropriedadeVazia(funcionario.Setor)
                && Validador.ValidarPropriedadeVazia(funcionario.Regional)
                && funcionario.Endereco.Validar();
        }
    }
}