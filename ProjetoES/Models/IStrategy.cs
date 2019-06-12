using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoES.Models
{
    public interface IStrategy
    {
        bool processar(Funcionario funcionario);
    }
}
