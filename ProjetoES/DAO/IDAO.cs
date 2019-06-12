using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoES.DAO
{
    interface IDAO
    {
        void Salvar();

        void Inserir();

        void Consultar();

        void ConsultarPorId(int id);

        void Alterar();


    }
}
