using System.Collections.Generic;

namespace ProjetoES.DAO
{
    public interface IDAO<T>
    {
        void Salvar(T entidade);
        void Inserir(T entidade);
        IList<T> Consultar();
        T ConsultarPorId(int id);
        void Alterar(T entidade);
    }
}
