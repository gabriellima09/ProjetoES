using ProjetoES.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoES.Models
{
    public class Estado
    {
        [Required(ErrorMessage = "Campo Estado é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        public bool Validar()
        {
            return Validador.ValidarPropriedadeVazia(Nome);
        }

    }
}