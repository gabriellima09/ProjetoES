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
            if (string.IsNullOrWhiteSpace(cpf))
            {
                return false;
            }
            else
            {
                var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                cpf = cpf.Trim().Replace(".", "").Replace("-", "");
                if (cpf.Length != 11)
                    return false;

                for (int j = 0; j < 10; j++)
                    if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                        return false;

                var tempCpf = cpf.Substring(0, 9);
                var soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

                var resto = soma % 11;
                resto = resto < 2 ? 0 : 11 - resto;

                var digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

                resto = soma % 11;
                resto = resto < 2 ? 0 : 11 - resto;

                digito = digito + resto.ToString();

                return cpf.EndsWith(digito);
            }
        }
       

        public static bool ValidarData(this DateTime data)
        {
            return data != null && data <= DateTime.Now;
        }

        public static bool ValidarEmail(this string email)
        {
            return Regex.IsMatch(email,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
        }

        public static bool ValidarPropriedadeVazia(this string propriedade)
        {
            return !string.IsNullOrWhiteSpace(propriedade);
        }
    }
}