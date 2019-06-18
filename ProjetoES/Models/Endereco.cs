using ProjetoES.Util;
using System.ComponentModel.DataAnnotations;

namespace ProjetoES.Models
{
    public class Endereco
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Logradouro é obrigatório", AllowEmptyStrings = false)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo Número é obrigatório", AllowEmptyStrings = false)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo Cidade é obrigatório", AllowEmptyStrings = false)]
        public Cidade Cidade { get; set; }

        public string Complemento { get; set; }


        public bool Validar()
        {
            return Validador.ValidarPropriedadeVazia(Logradouro)
                && Validador.ValidarPropriedadeVazia(Numero)
                && Cidade.Validar();
        }

    }
}