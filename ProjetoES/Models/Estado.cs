using ProjetoES.Util;
using System.ComponentModel.DataAnnotations;

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