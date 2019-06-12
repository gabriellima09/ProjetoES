using System.Collections.Generic;

namespace ProjetoES.Facade
{
    public interface IFachada<T>
    {
        void Cadastrar(T entidade);
        void AtivarFuncionario(int id);
        void InativarFuncionario(int id);
        void Alterar(T entidade);
        IList<T> Consultar();
        T ConsultarPorId(int id);
    }
}
