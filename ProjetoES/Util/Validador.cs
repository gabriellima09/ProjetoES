using ProjetoES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ProjetoES.Util
{
    public static class Validador
    {
        public static bool ValidarCPF(this string cpf)
        {
            return Regex.IsMatch(cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$") && !string.IsNullOrWhiteSpace(cpf);
        }
        
        public static bool ValidarData(this DateTime data)
        {
            return data != null && data <= DateTime.Now;
        }

        public static bool ValidarEmail(this string email)
        {
            return Regex.IsMatch(email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
        }

        public static bool ValidarPropriedadeVazia(this string propriedade)
        {
            return !string.IsNullOrWhiteSpace(propriedade);
        }
    }
}