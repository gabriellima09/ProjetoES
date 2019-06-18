using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoES.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo CPF é obrigatório", AllowEmptyStrings = false)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo E-mail é obrigatório", AllowEmptyStrings = false)]
        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Campo Data de Contratacao é obrigatório", AllowEmptyStrings = false)]
        public DateTime DataContratacao { get; set; }

        [Required(ErrorMessage = "Campo Matricula é obrigatório", AllowEmptyStrings = false)]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Campo Cargo é obrigatório", AllowEmptyStrings = false)]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Campo Setor é obrigatório", AllowEmptyStrings = false)]
        public string Setor { get; set; }

        [Required(ErrorMessage = "Campo Regional é obrigatório", AllowEmptyStrings = false)]
        public string Regional { get; set; }

        [Required(ErrorMessage = "Campo Status é obrigatório", AllowEmptyStrings = false)]
        public int Status { get; set; }

        [Required(ErrorMessage = "Campo Código do Funcionário é obrigatório", AllowEmptyStrings = false)]
        public int CodigoFuncionario { get; set; }

        public int IdEndereco { get; set; }
        public Endereco Endereco { get; set; }
    }
}