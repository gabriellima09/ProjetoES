using ProjetoES.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoES.Models
{
    public class Cidade
    {
        [Required(ErrorMessage = "Campo Cidade é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Cidade é obrigatório", AllowEmptyStrings = false)]
        public Estado Estado { get; set; }

        public bool Validar()
        {
            return Estado.Validar()
                && Validador.ValidarPropriedadeVazia(Nome);
        }
    }
}