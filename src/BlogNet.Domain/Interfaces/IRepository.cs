using System.Linq.Expressions;

namespace BlogNet.Domain.Interfaces;
public interface IRepository<T> : IDisposable
{
    Task Adicionar(T model);
    Task<T?> ObterPorId(Guid id);
    Task<List<T>> ObterTodos();
    Task Atualizar(T model);
    Task Remover(Guid id);
    Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> expression);
    Task<int> SaveChanges();
}
